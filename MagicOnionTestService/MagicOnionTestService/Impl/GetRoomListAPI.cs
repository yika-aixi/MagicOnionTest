//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日04:15:34
//MagicOnionTestService

using System.Collections.Generic;
using MagicOnion;
using MagicOnion.Server;
using MagicOnionTestService.LobbyMessageTest;

namespace MagicOnionTestService.Impl
{
    public class GetRoomListAPI:ServiceBase<IGetRoomList>,IGetRoomList
    {
        public static List<string> _roomNames = new List<string>();

        public static void AddRoom(string roomName)
        {
            if (!_roomNames.Exists(x=>x == roomName))
            {
                _roomNames.Add(roomName);
            }
        }
        
        public static void RemoveRoom(string roomName)
        {
            if (_roomNames.Exists(x=>x == roomName))
            {
                _roomNames.Remove(roomName);
            }
        }
        
        public async UnaryResult<string[]> GetAllRoom()
        {
            return _roomNames.ToArray();
        }
    }
}