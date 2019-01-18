//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日03:32:27
//Assembly-CSharp

using System;
using MessagePack;

namespace DefaultNamespace
{
    [MessagePackObject]
    public class PlayerInfo
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public Guid ID;
    }
}