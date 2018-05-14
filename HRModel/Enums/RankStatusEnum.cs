using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public enum RankStatusEnum
    {
        [Localize("升职")]
        Up,
        [Localize("降职")]
        Down,
        [Localize("平职")]
        Even,
        [Localize("转正")]
        ToFull
    }
}
