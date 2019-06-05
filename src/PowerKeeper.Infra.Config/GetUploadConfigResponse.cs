using PowerKeeper.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerKeeper.Infra.Config
{
    public class GetUploadConfigResponse : UploadBaseConfig
    {
        private Dictionary<string, UploadFileBaseConfig> _FileConfiges;
        private Dictionary<string, FtpBaseConfig> _FtpConfiges { get; set; }

        private FileTypeEnum _FileType { get; set; }

        public GetUploadConfigResponse(FileTypeEnum fileType, Dictionary<string, UploadFileBaseConfig> fileConfiges, Dictionary<string, FtpBaseConfig> ftpConfiges, UploadBaseConfig localConfig)
        {
            _FileType = fileType;
            _FileConfiges = fileConfiges;
            _FtpConfiges = ftpConfiges;
            MaxFolderCnt = localConfig.MaxFileCnt;
            MaxFileCnt = localConfig.MaxFileCnt;
            Path = localConfig.Path;
            WebUrl = localConfig.WebUrl;
        }

        /// <summary>
        /// 获取文件上传配置
        /// </summary>
        public FileUploadModeEnum FileUploadMode
        {
            get
            {
                if (FtpConfig != null)
                    return FileUploadModeEnum.Ftp;
                return FileUploadModeEnum.LocalFile;
            }
        }

        /// <summary>
        /// 获取文件子文件夹配置
        /// </summary>
        private UploadFileBaseConfig FileConfig
        {
            get
            {
                string fileType = System.Enum.GetName(typeof(FileTypeEnum), (int)_FileType)?.Trim() + "Config";
                var currFileConfig = _FileConfiges.GetValueOrDefault(fileType);
                if (currFileConfig == null)
                    throw new AggregateException("文件配置信息不存在");
                return currFileConfig;
            }
        }

        /// <summary>
        /// 获取文件夹配置
        /// </summary>
        public  string Dic
        {
            get
            {
                return FileConfig.Dic;
            }
        }
        /// <summary>
        /// ftp文件设置
        /// </summary>
        public FtpBaseConfig FtpConfig
        {
            get
            {
                return _FtpConfiges.GetValueOrDefault(FileConfig?.UpLoadMode);
            }
        }
    }
}
