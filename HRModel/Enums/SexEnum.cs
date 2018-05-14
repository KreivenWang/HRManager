using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public enum SexEnum
    {
        [Localize("男")]
        Male,
        [Localize("女")]
        Female,
        [Localize("未设定")]
        Unknown
    }
}
