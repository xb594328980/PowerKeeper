using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Tool.Helpers;

namespace PowerKeeper.Api.App_Helper
{
    /// <summary>
    /// ajax请求处理结果对象
    /// </summary>

    public class AjaxResult<T> : ActionResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        private AjaxBackData<T> Data { get; set; }
        /// <summary>
        /// 获取返回数据
        /// </summary>
        public AjaxBackData<T> GetResponseData
        {
            get { return Data; }
        }
        #region 初始化函数

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMsg"></param>
        public AjaxResult(T data, ErrorCodeEnum errorCode = ErrorCodeEnum.ok, string errorMsg = "ok")
        {
            Data = new AjaxBackData<T>(data, errorCode, errorMsg);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMsg"></param>
        public AjaxResult(ErrorCodeEnum errorCode, dynamic errorMsg)
        {
            Data = new AjaxBackData<T>(errorCode, errorMsg);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ex"></param>
        public AjaxResult(Exception ex)
        {
            Data = new AjaxBackData<T>(ex);
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";
            var result = Data.ToJson(false, true);
            response.WriteAsync(result);
        }
    }

    #region 数据

    public class AjaxBackData<T>
    {
        #region 初始化函数
        public AjaxBackData() { }
        /// <summary>
        /// 默认成功函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMsg"></param>
        public AjaxBackData(T data, ErrorCodeEnum errorCode = ErrorCodeEnum.ok, string errorMsg = "ok")
        {
            ErrorCode = ErrorCodeEnum.ok;
            ErrorMsg = ErrorCodeEnum.ok.ToString();
            Data = data;
        }
        public AjaxBackData(ErrorCodeEnum errorCode, string errorMsg)
        {
            ErrorCode = errorCode;
            ErrorMsg = errorMsg;
            Data = default(T);
        }
        public AjaxBackData(Exception ex)
        {
            ErrorCode = ErrorCodeEnum.SystemException;
            ErrorMsg = "系统异常(" + ex.Message + ")";
            Data = default(T);
        }
        #endregion

        /// <summary>
        /// 错误代码 
        /// </summary>
        [JsonProperty("errorCode")]
        public ErrorCodeEnum ErrorCode { get; protected set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; protected set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; protected set; }
    }
    #endregion

}