//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日03:28:38
//MagicOnionTestService

using System;
using System.Threading.Tasks;
using DefaultNamespace;
using MagicOnion.Server.Hubs;
using MagicOnionTestService.LobbyMessageTest;

namespace MagicOnionTestService.Impl
{
    public class PlayerHub:StreamingHubBase<IPlayerHub,IPlayer>,IPlayerHub
    {
        IGroup room;
        public PlayerInfo PlayerInfo { get; private set; }

        public void OnJoin(PlayerInfo playerInfo)
        {
        }

        public async Task JoinAsync(string roomName, PlayerInfo playerInfo)
        {
            PlayerInfo = playerInfo;
            //加入房间
            this.room = await this.Group.AddAsync(roomName);
            GetRoomListAPI.AddRoom(room.GroupName);
            //广播消息:加入房间
            this.Broadcast(room).OnJoin(playerInfo);
            Console.WriteLine($"{PlayerInfo.Name} Join Room");
        }

        public void OnLeave(PlayerInfo playerInfo)
        {
        }

        public async Task LeaveAsync()
        {
            //离开房间
            await room.RemoveAsync(this.Context);

            var count = await room.GetMemberCountAsync();
            
            //没有人的房间,删除
            if (count <= 0)
            {
                GetRoomListAPI.RemoveRoom(room.GroupName);
            }
            
            //广播消息:退出房间
            this.Broadcast(room).OnLeave(PlayerInfo);
            Console.WriteLine($"{PlayerInfo.Name} Leave Room");
        }

        public void OnMove(Guid id,Ve3 newPosition)
        {
        }

        public Task MoveAsync(Guid id,Ve3 newPosition)
        {
            this.Broadcast(room).OnMove(id,newPosition);
            
            return Task.CompletedTask;
        }

    }
}