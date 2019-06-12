using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerKeeper.Application.Helper
{
    /// <summary>
    /// 验证枚举
    /// create by xingbo 19/06/11
    /// </summary>
    public class EnumValAttribute : ValidationAttribute
    {
        private Type _type;
        private Dictionary<int, string> enumValList;
        private ValidationContext _validationContext;

        public EnumValAttribute(Type enumType)
        {
            _type = enumType;
            enumValList = new Dictionary<int, string>();
            Infra.Tool.Helpers.Enum.GetItems(_type).ForEach((x) =>
            {
                enumValList.Add((int)x.Value, x.Text);
            });
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            _validationContext = validationContext;
            if (enumValList.Keys.Any(x => x == (int)value))
                return ValidationResult.Success;
            return new ValidationResult(ErrorMessage);
        }


        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in enumValList.Keys)
                    str.Append($"{item}");
                return $"\"{_validationContext.MemberName}\"不在({str.ToString()})范围内.";
            }
        }
    }
}
