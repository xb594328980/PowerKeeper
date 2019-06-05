using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerKeeper.Infra.Tool.Helpers
{
    /// <summary>
    /// Json操作
    /// </summary>
    public static class Json
    {
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T ToObject<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="isConvertToSingleQuotes">是否将双引号转成单引号</param>
        /// <param name="camelCase">是否开启骆驼命名序列化属性，默认为false</param>
        public static string ToJson(this object target, bool isConvertToSingleQuotes = false, bool camelCase = false)
        {
            if (target == null)
                return "{}";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            if (camelCase)
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var result = JsonConvert.SerializeObject(target, settings);
            if (isConvertToSingleQuotes)
                result = result.Replace("\"", "'");
            return result;
        }
    }
}
