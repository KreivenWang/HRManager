using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public enum JobStatusEnum
    {
        [Localize("在职")]
        OnJob,
        [Localize("离职")]
        Resigned,
        [Localize("其他")]
        Other
    }
}
