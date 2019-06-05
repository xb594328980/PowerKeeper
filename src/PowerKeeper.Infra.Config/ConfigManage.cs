using Microsoft.Extensions.Configuration;
using PowerKeeper.Infra.Enum;
using PowerKeeper.Infra.Tool.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Config
{
    /// <summary>
    /// 配置管理
    /// create by xingbo 19/05/24
    /// </summary>
    public class ConfigManage
    {


        /// <summary>
        /// AppConfig内所有字典配置，只能存储string字段，且不能存在下级
        /// </summary>
        public Dictionary<string, string> AppConfig { get; protected set; }

        /// <summary>
        /// Ftp服务器配置信息
        /// </summary>
        public Dictionary<string, FtpBaseConfig> FtpConfig { get; protected set; }

        /// <summary>
        /// UploadFile配置信息
        /// </summary>
        public Dictionary<string, UploadFileBaseConfig> FileConfig { get; protected set; }

        /// <summary>
        /// UploadFile配置信息
        /// </summary>
        public UploadBaseConfig LocalConfig { get; protected set; }

        /// <summary>
        /// EF日志配置
        /// create by xingbo 19/06/03
        /// </summary>
        public EfConfig EfConfig { get; protected set; }
        /// <summary>
        /// 按照文件获取上传配置信息
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public GetUploadConfigResponse GetFileConfig(FileTypeEnum fileType)
        {
            return new GetUploadConfigResponse(fileType, FileConfig, FtpConfig, LocalConfig);
        }
        #region 初始化

        public IConfiguration _configuration { get; }
        public ConfigManage()
        {
            _configuration = Ioc.Create<IConfiguration>();
            this.StartUp();
        }
        private void StartUp()
        {
            Dictionary<string, Type> _setting = GenerateSetting();
            #region AppConfig处理
            var _AppConfig = _configuration.GetSection("AppConfig");
            foreach (var item in _AppConfig.GetChildren())
                AppConfig.Add(item.Key, item.Value);
            #endregion
            foreach (var key in _setting.Keys)
            {
                var currInstance = _setting[key];
                var _config = _configuration.GetSection(key);
                if (_config == null)
                    continue;
                var _configChildren = _config.GetChildren();
                foreach (var item in _configChildren)
                {
                    var tempChild = item.GetChildren();
                    if (tempChild.GetEnumerator().MoveNext())
                    {
                        tempChild.GetEnumerator().Dispose();
                        ProcessingValue(_setting[key], item.Get(_setting[key]), item.Key);
                        continue;//继续循环寻找相同项
                    }
                    else
                    {
                        ProcessingValue(_setting[key], _config.Get(_setting[key]));
                        break;
                    }
                }

            }
        }
        /// <summary>
        /// 处理对象形式参数
        /// create by xingbo 19/05/27
        /// </summary>
        /// <param name="valType">目标值type</param>
        /// <param name="value">值</param>
        /// <param name="key">涉及到对象时，key</param>
        private void ProcessingValue(Type valType, object value, string key = null)
        {
            if (valType == typeof(FtpBaseConfig))
                FtpConfig.Add(key, (FtpBaseConfig)value);
            else if (valType == typeof(UploadBaseConfig))
                LocalConfig = (UploadBaseConfig)value;
            else if (valType == typeof(UploadFileBaseConfig))
                FileConfig.Add(key, (UploadFileBaseConfig)value);
            else if (valType == typeof(EfConfig))
                EfConfig = (EfConfig)value;

        }

        /// <summary>
        /// 配置字典集合
        /// create by xingbo 19/05/27
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Type> GenerateSetting()
        {
            FtpConfig = new Dictionary<string, FtpBaseConfig>();//初始化ftp文件配置
            FileConfig = new Dictionary<string, UploadFileBaseConfig>();//初始化文件配置
            AppConfig = new Dictionary<string, string>();//初始化
            Dictionary<string, Type> setting = new Dictionary<string, Type>();
            setting.Add("FtpConfig", typeof(FtpBaseConfig));//加入ftp ImageCdnConfig配置
            setting.Add("FileConfig", typeof(UploadFileBaseConfig));//加入上传模式配置
            setting.Add("LocalRootConfig", typeof(UploadBaseConfig));//加入上传模式配置
            setting.Add("Logging", typeof(EfConfig));//加入EF日志配置
            return setting;
        }
        #endregion
    }
}
