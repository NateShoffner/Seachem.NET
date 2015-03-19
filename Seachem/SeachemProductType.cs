#region

using System;

#endregion

namespace Seachem
{
    [Flags]
    public enum SeachemProductType
    {
        Gravel = 0x01,
        Planted = 0x02,
        Reef = 0x04
    }
}