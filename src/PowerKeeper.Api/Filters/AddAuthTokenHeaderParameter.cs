using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PowerKeeper.Api.Filters
{
    /// <summary>
    /// this class is for swagger to generate Token Header filed on swagger UI
    /// <remarks>
    /// create by xingbo 18/07/18
    /// </remarks>
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var _serviceFilter = new ServiceFilterAttribute(typeof(AuthAttribute));
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            var actionAttrs = context.ApiDescription.ActionAttributes();
            var isAuthorized = actionAttrs.Any(a => a.GetType() == _serviceFilter.GetType());
            if (isAuthorized == false) //提供action都没有权限特性标记，检查控制器有没有
            {
                var controllerAttrs = context.ApiDescription.ControllerAttributes();
                isAuthorized = controllerAttrs.Any(a => a.GetType() == _serviceFilter.GetType());
            }

            if (isAuthorized)
            {
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "Authorization",  //添加Authorization头部参数
                    In = "header",
                    Type = "string",
                    Required = false
                });
            }
        }
    }
}
