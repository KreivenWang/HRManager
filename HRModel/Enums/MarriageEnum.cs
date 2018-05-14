using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public enum MarriageEnum
    {
        [Localize("已婚")]
        Married,
        [Localize("未婚")]
        NotMarried,
        [Localize("离异")]
        Divorced,
        [Localize("其他")]
        Unknown
    }
}
