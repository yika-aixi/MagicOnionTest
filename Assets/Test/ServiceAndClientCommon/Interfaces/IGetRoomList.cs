//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日04:18:26
//Assembly-CSharp

using MagicOnion;

namespace MagicOnionTestService.LobbyMessageTest
{
    public interface IGetRoomList:IService<IGetRoomList>
    {
        /// <summary>
        /// 获取所有房间
        /// </summary>
        /// <returns></returns>
        UnaryResult<string[]> GetAllRoom();
    }
}