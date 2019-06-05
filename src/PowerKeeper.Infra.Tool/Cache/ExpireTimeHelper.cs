using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerKeeper.Infra.Tool.Cache
{
    public class ExpireTimeHelper
    {
        public static DateTime GetExpireTime(CacheExpireType exType)
        {
            switch (exType)
            {
                case CacheExpireType.Minute1:
                    return DateTime.Now.AddMinutes(1);
                case CacheExpireType.Minute5:
                    return DateTime.Now.AddMinutes(5);
                case CacheExpireType.Hour1:
                    return DateTime.Now.AddHours(1);
                case CacheExpireType.Hour4:
                    return DateTime.Now.AddHours(4);
                case CacheExpireType.Day1:
                    return DateTime.Now.AddDays(1);
                case CacheExpireType.Always:
                    return DateTime.Now.AddYears(1);
                case CacheExpireType.Invariable:
                    return DateTime.Now.AddYears(1);
                case CacheExpireType.Stable:
                    return DateTime.Now.AddHours(8);
                case CacheExpireType.Usual:
                    return DateTime.Now.AddHours(1);
                case CacheExpireType.RelativelyUsual:
                    return DateTime.Now.AddMinutes(10);
                case CacheExpireType.Temporary:
                    return DateTime.Now.AddMinutes(5);
                default:
                    return DateTime.Now.AddMinutes(5);
            }
        }
    }
}
