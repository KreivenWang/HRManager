using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManagerClient.Utility
{
    public static class EnumTranslater
    {
        public static string ToChString(this Enum e)
        {
            if (e is SexEnum) {
                return ((SexEnum)e).ToChString();
            } else if (e is JobStatusEnum) {
                return ((JobStatusEnum)e).ToChString();
            } else if (e is MarriageEnum) {
                return ((MarriageEnum)e).ToChString();
            }
            return null;
        }

        public static string ToChString(this SexEnum e)
        {
            var result = "";
            switch (e) {
                case SexEnum.Male:
                    result = "男";
                    break;
                case SexEnum.Female:
                    result = "女";
                    break;
                case SexEnum.Unknown:
                    result = "未知";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string ToChString(this JobStatusEnum e)
        {
            var result = "";
            switch (e) {
                case JobStatusEnum.OnJob:
                    result = "在职";
                    break;
                case JobStatusEnum.Resigned:
                    result = "离职";
                    break;
                case JobStatusEnum.Other:
                    result = "其它";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string ToChString(this MarriageEnum e)
        {
            var result = "";
            switch (e) {
                case MarriageEnum.Married:
                    result = "已婚";
                    break;
                case MarriageEnum.NotMarried:
                    result = "未婚";
                    break;
                case MarriageEnum.Divorced:
                    result = "离异";
                    break;
                case MarriageEnum.Unknown:
                    result = "未知";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string ToChString(this RankStatusEnum e)
        {
            var result = "";
            switch (e) {
                case RankStatusEnum.Up:
                    result = "升职";
                    break;
                case RankStatusEnum.Down:
                    result = "降职";
                    break;
                case RankStatusEnum.Even:
                    result = "平职";
                    break;
                case RankStatusEnum.ToFull:
                    result = "转正";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
