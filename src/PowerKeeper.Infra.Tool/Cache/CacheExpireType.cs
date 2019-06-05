namespace PowerKeeper.Infra.Tool.Cache
{
    /// <summary>
    /// 描述：缓存的保存时间
    /// 创建日期：2014-10-15
    /// 作者：邢博
    /// </summary>
    public enum CacheExpireType
    {
        /// <summary>
        /// 永久，1年
        /// </summary>
        Invariable,
        /// <summary>
        /// 稳定 8小时
        /// </summary>
        Stable,
        /// <summary>
        /// 常用 1小时
        /// </summary>
        Usual,
        /// <summary>
        /// 单个对象，10分钟
        /// </summary>
        RelativelyUsual,
        /// <summary>
        /// 频繁5分钟
        /// </summary>
        Temporary,
        /// <summary>
        /// 1分钟
        /// </summary>
        Minute1,
        /// <summary>
        /// 5分钟
        /// </summary>
        Minute5,
        /// <summary>
        /// 1小时
        /// </summary>
        Hour1,
        /// <summary>
        /// 4小时
        /// </summary>
        Hour4,
        /// <summary>
        /// 1天
        /// </summary>
        Day1,
        /// <summary>
        /// 一直
        /// </summary>
        Always
    }
}
