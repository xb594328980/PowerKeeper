using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Api.Extensions
{
    /// <summary>
    /// 添加自定义路由前缀
    ///  <remarks>create by xingbo 18/12/24</remarks>
    /// </summary>
    public static class MvcOption
    {
        /// <summary>
        /// 添加自定义
        /// 实现IApplicationModelConvention的RouteConvention
        /// <remarks>create by xingbo 18/12/24</remarks>
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="routeAttribute"></param>
        public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            // 添加我们自定义 实现IApplicationModelConvention的RouteConvention
            opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }
    }
}
