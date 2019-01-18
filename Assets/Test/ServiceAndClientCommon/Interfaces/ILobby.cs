//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月15日01:32:46
//MagicOnionTestService

using System.Threading.Tasks;
using DefaultNamespace;

namespace MagicOnionTestService.LobbyMessageTest
{
    public interface ILobby
    {
        /// <summary>
        /// 客户端实现 加入房间
        /// </summary>
        /// <param name="playerInfo">玩家信息</param>
        void OnJoin(PlayerInfo playerInfo);

        /// <summary>
        /// 服务器实现 加入房间
        /// </summary>
        /// <param name="roomName">房间名</param>
        /// <param name="playerInfo">玩家信息</param>
        Task JoinAsync(string roomName,PlayerInfo playerInfo);

        /// <summary>
        /// 客户端实现 离开房间
        /// </summary>
        /// <param name="playerInfo">玩家信息</param>
        void OnLeave(PlayerInfo playerInfo);

        /// <summary>
        /// 服务器实现 离开房间
        /// </summary>
        Task LeaveAsync();
    }
}