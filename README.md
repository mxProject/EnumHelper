# EnumHelper
Helper methods for Enum type.

# Dependency
C# 7.3

# Usage

### Sample enums ###

I defined two sample enum types: SampleEnum and SampleFlag.

* Both have the same value represented by a bit flag.
* LeftRight and RightLeft are the same value (Left | Right).
If multiple enumerated values of the same value are defined, the first definition found will be valid.
* FlagsAttribute applies to SampleEnum. FlagsAttribute does not apply to SampleEnum.

```c#
enum SampleEnum
{
    [EnumAlias("N"), EnumHidden]
    None = 0,

    [EnumDisplay("<L>", 2), EnumAlias("L")]
    Left = 1,

    [EnumDisplay("<R>", 1), EnumAlias("R")]
    Right = 2,

    [EnumDisplay("<C>", 3), EnumAlias("C")]
    Center = 4,

    [EnumDisplay("<L-R>", 4), EnumAlias("LR"), EnumHidden]
    LeftRight = Left | Right,

    [EnumDisplay("<R-L>", 5), EnumAlias("RL"), EnumHidden]
    RightLeft = Right| Left,

    [EnumHidden]
    All = Left | Right | Center,
}

[Flags]
enum SampleFlag
{
    [EnumAlias("N"), EnumHidden]
    None = 0,

    [EnumDisplay("<L>", 2), EnumAlias("L")]
    Left = 1,

    [EnumDisplay("<R>", 1), EnumAlias("R")]
    Right = 2,

    [EnumDisplay("<C>", 3), EnumAlias("C")]
    Center = 4,

    [EnumDisplay("<L-R>", 4), EnumAlias("LR"), EnumHidden]
    LeftRight = Left | Right,

    [EnumDisplay("<R-L>", 5), EnumAlias("RL"), EnumHidden]
    RightLeft = Right | Left,

    [EnumHidden]
    All = Left | Right | Center,
}
```

### Attributes for enums ###

Attributes applied to enum values have the following roles:

| Attribute type | Role |
|:--|:--|
| EnumAlias | Defines an alias for the string value of the enum value. |
| EnumDisplay | Define display name and display order of the enum value. |
| EnumHidden | Defines that the enum value is hidden. |

### Sample (EnumAlias) ###

```c#

// Converts enum to alias.
Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("N"));
Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("L"));
Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("R"));
Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("C"));
Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("LR"));

> None
> Left
> Right
> Center
> LeftRight

Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("N"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("L"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("R"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("C"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("LR"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("L,R"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("R,L"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("L,C"));
Debug.WriteLine(EnumHelper.FromAlias<SampleFlag>("L,R,C"));

> None
> Left
> Right
> Center
> LeftRight
> LeftRight
> LeftRight
> Left, Center
> All

Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("X"));
> throw ArgumentException.

Debug.WriteLine(EnumHelper.TryFromAlias("X", out SampleEnum value));
> False

// Converts alias to enum.
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.None));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.Left));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.Right));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.Center));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.LeftRight));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.RightLeft));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.Left | SampleEnum.Center));
Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.All));

> N
> L
> R
> C
> LR
> (null)
> (null)

Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.None));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.Left));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.Right));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.Center));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.RightLeft));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.Left | SampleFlag.Center));
Debug.WriteLine(EnumHelper.GetAlias(SampleFlag.All));

> N
> L
> R
> C
> LR
> LR
> L,C
> L,R,C,LR

// Converts alias to enum. (Extension method)
Debug.WriteLine(SampleEnum.Left.GetAlias());
Debug.WriteLine(SampleFlag.Right.GetAlias());

> L
> R

// Register custom conversion method.
EnumHelper.RegistAlias<SampleEnum>(enumValue =>
{
    return new EnumAliasInfo(enumValue.ToString().ToUpper());
}
);

Debug.WriteLine(EnumHelper.FromAlias<SampleEnum>("LEFT"));
> Left

Debug.WriteLine(EnumHelper.GetAlias(SampleEnum.Right));
> RIGHT
```

### Sample (EnumDisplay, EnumHidden) ###

```c#

// Gets the display name.
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.None));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.Left));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.Right));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.Center));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.LeftRight));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.RightLeft));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.Left | SampleEnum.Center));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.All));

> None
> <L>
> <R>
> <C>
> <L-R>
> <L-R>
> (null)
> All

Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.None));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.Left));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.Right));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.Center));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.RightLeft));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.Left | SampleFlag.Center));
Debug.WriteLine(EnumHelper.GetDisplayName(SampleFlag.All));

> None
> <L>
> <R>
> <C>
> <L-R>
> <L-R>
> <L>,<C>
> All

// Gets the display name. (Extension method)
Debug.WriteLine(SampleEnum.Left.GetDisplayName());
Debug.WriteLine(SampleFlag.Right.GetDisplayName());

> <L>
> <R>

// Gets enum values in display order.
IList<SampleEnum> values = EnumHelper.GetOrderedValues<SampleEnum>(false);
for (int i = 0; i < values.Count; ++i)
{
    Debug.WriteLine(string.Format("[{0}] {1}", i, values[i]));
}

> [0] None
> [1] All
> [2] Right
> [3] Left
> [4] Center
> [5] RightLeft
> [6] RightLeft

// Gets enum values in display order. (Except hidden values)
IList<SampleEnum> values = EnumHelper.GetOrderedValues<SampleEnum>(true);
for (int i = 0; i < values.Count; ++i)
{
    Debug.WriteLine(string.Format("[{0}] {1}", i, values[i]));
}

> [0] Right
> [1] Left
> [2] Center

// Register custom conversion method.
EnumHelper.RegistDisplayInfo<SampleEnum>(enumValue =>
{
    return new EnumDisplayInfo(enumValue.ToString().ToUpper(), (int)enumValue);
}
);

Debug.WriteLine(EnumHelper.GetDisplayName(SampleEnum.Right));
> RIGHT

Debug.WriteLine(EnumHelper.GetDisplayOrder(SampleEnum.Right));
> 2
```

### Sample (numeric string) ###

```c#

// Converts to numeric string.
Debug.WriteLine(EnumHelper.ToNumericString(SampleEnum.Left));
Debug.WriteLine(EnumHelper.ToNumericString(SampleEnum.Right, "d2"));
Debug.WriteLine(EnumHelper.ToNumericString(SampleEnum.Left | SampleEnum.Center));
Debug.WriteLine(EnumHelper.ToNumericString(SampleEnum.All));

> 1
> 02
> 5
> 7

// Converts to numeric string. (Extension method)
Debug.WriteLine(SampleEnum.Left.ToNumericString());
Debug.WriteLine(SampleEnum.Right.ToNumericString("d2"));
Debug.WriteLine((SampleEnum.Left | SampleEnum.Center).ToNumericString());
Debug.WriteLine(SampleEnum.All.ToNumericString());

> 1
> 02
> 5
> 7

// Converts from numeric string.
Debug.WriteLine(EnumHelper.FromNumericString<SampleEnum>("1"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleEnum>("02"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleEnum>("5"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleEnum>("7"))

> Left
> Right
> 5
> All

Debug.WriteLine(EnumHelper.FromNumericString<SampleFlag>("1"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleFlag>("02"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleFlag>("5"))
Debug.WriteLine(EnumHelper.FromNumericString<SampleFlag>("7"))

> Left
> Right
> Left, Center
> All
```

### Sample (Logical operation) ###

These are generic methods used in general purpose processing. Casting values using Expression, but overhead occurs.

```c#

// EnumHelper.And<TEnum>(TEnum target, TEnum value) where TEnum : Enum
Debug.WriteLine(EnumHelper.And(SampleFlag.Left, SampleFlag.Right));
Debug.WriteLine(EnumHelper.And(SampleFlag.LeftRight, SampleFlag.Right));
Debug.WriteLine(EnumHelper.And(SampleFlag.Right, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.And(SampleFlag.All, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.And(SampleFlag.All, SampleFlag.RightLeft));

> None
> Right
> Right
> LeftRight
> LeftRight

// EnumHelper.Or<TEnum>(TEnum target, TEnum value) where TEnum : Enum
Debug.WriteLine(EnumHelper.Or(SampleFlag.Left, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Or(SampleFlag.LeftRight, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Or(SampleFlag.Right, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.Or(SampleFlag.Center, SampleFlag.Left));
Debug.WriteLine(EnumHelper.Or(SampleFlag.Center, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.Or(SampleFlag.All, SampleFlag.RightLeft));

> LeftRight
> LeftRight
> LeftRight
> Left, Center
> All
> All

// EnumHelper.Xor<TEnum>(TEnum target, TEnum value) where TEnum : Enum
Debug.WriteLine(EnumHelper.Xor(SampleFlag.Left, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Xor(SampleFlag.LeftRight, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Xor(SampleFlag.Right, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.Xor(SampleFlag.LeftRight, SampleFlag.RightLeft));
Debug.WriteLine(EnumHelper.Xor(SampleFlag.All, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Xor(SampleFlag.All, SampleFlag.RightLeft));

> LeftRight
> Left
> Left
> None
> Left, Center
> Center

// EnumHelper.Remove<TEnum>(TEnum target, TEnum value) where TEnum : Enum
Debug.WriteLine(EnumHelper.Remove(SampleFlag.Left, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Remove(SampleFlag.LeftRight, SampleFlag.Right));
Debug.WriteLine(EnumHelper.Remove(SampleFlag.Right, SampleFlag.LeftRight));
Debug.WriteLine(EnumHelper.Remove(SampleFlag.Left | SampleFlag.Center, SampleFlag.Left));
Debug.WriteLine(EnumHelper.Remove(SampleFlag.All, SampleFlag.RightLeft));
Debug.WriteLine(EnumHelper.Remove(SampleFlag.All, SampleFlag.Left));

> Left
> Left
> None
> Center
> Center
> Right, Center
```

# Licence
This software is released under the MIT License, see LICENSE.

# Authors
mxProject

