//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年01月18日03:14:00
//

using MessagePack;

namespace DefaultNamespace
{
    [MessagePackObject]
    public struct Ve3
    {
        [Key(0)]
        public float X;
        [Key(1)]
        public float Y;
        [Key(2)]
        public float Z;
    }
}