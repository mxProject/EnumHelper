using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mxProject;

namespace Test.mxProject.EnumHelpers
{

    internal enum SampleEnum
    {

        [EnumAlias("N"), EnumHidden]
        None = 0,

        [EnumDisplay("左", 2)]
        [EnumAlias("L")]
        Left = 1,

        [EnumDisplay("右", 1)]
        [EnumAlias("R")]
        Right = 2,

        [EnumDisplay("中央", 3)]
        [EnumAlias("C")]
        Center = 4,

        [EnumDisplay("左右", 4)]
        [EnumAlias("LR")]
        [EnumHidden]
        LeftRight = Left | Right,

        [EnumDisplay("右左", 5)]
        [EnumAlias("RL")]
        [EnumHidden]
        RightLeft = Right | Left,

        [EnumHidden]
        All = Left | Right | Center,

    }

    [Flags]
    internal enum SampleFlag
    {

        [EnumAlias("N")]
        [EnumHidden]
        None = 0,

        [EnumDisplay("左", 2)]
        [EnumAlias("L")]
        Left = 1,

        [EnumDisplay("右", 1)]
        [EnumAlias("R")]
        Right = 2,

        [EnumDisplay("中央", 3)]
        [EnumAlias("C")]
        Center = 4,

        [EnumDisplay("左右", 4)]
        [EnumAlias("LR")]
        [EnumHidden]
        LeftRight = Left | Right,

        [EnumDisplay("右左", 5)]
        [EnumAlias("RL")]
        [EnumHidden]
        RightLeft = Right | Left,

        [EnumHidden]
        All = Left | Right | Center,

    }

    public enum ByteEnum : byte
    {
        Zero = 0,
        One = 1
    }

    public enum Int16Enum : short
    {
        Zero = 0,
        One = 1
    }

    public enum Int32Enum : int
    {
        Zero = 0,
        One = 1
    }

    public enum Int64Enum : long
    {
        Zero = 0,
        One = 1
    }

    public enum SByteEnum : sbyte
    {
        Zero = 0,
        One = 1
    }

    public enum UInt16Enum : ushort
    {
        Zero = 0,
        One = 1
    }

    public enum UInt32Enum : uint
    {
        Zero = 0,
        One = 1
    }

    public enum UInt64Enum : ulong
    {
        Zero = 0,
        One = 1
    }

}
