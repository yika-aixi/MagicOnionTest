//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月16日04:22:44
//Assembly-CSharp

using System;
using System.Threading.Tasks;
using DefaultNamespace;

namespace MagicOnionTestService.LobbyMessageTest
{
    public interface IMove
    {
        /// <summary>
        /// 客户端实现 移动
        /// </summary>
        /// <param name="newPosition"></param>
        void OnMove(Guid id,Ve3 newPosition);
        
        /// <summary>
        /// 服务端实现 移动
        /// </summary>
        /// <param name="newPosition"></param>
        Task MoveAsync(Guid id,Ve3 newPosition);
    }
}