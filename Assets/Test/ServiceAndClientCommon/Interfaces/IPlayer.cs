//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日02:56:05
//Assembly-CSharp

using System;
using DefaultNamespace;

namespace MagicOnionTestService.LobbyMessageTest
{
    public interface IPlayer:ILobby,IMove
    {
        PlayerInfo PlayerInfo { get; }
    }
}