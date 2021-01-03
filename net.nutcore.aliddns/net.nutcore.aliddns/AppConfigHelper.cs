using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace net.nutcore.aliddns
{
    internal class AppConfigHelper
    {
        #region The private fields
        private static readonly string configFile = "aliddns_config.xml";
        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile);
        #endregion

        public Config config = new Config();
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppConfigHelper()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    this.CreatDefaultConfig(configFilePath);
                    this.LoadConfig(configFilePath);
                }
                else
                {
                    this.LoadConfig(configFilePath);
                    if(config == null)
                    {
                        Console.WriteLine("Config file setting error! New config file is created now!");
                        FileInfo fileInfo = new FileInfo(configFilePath);
                        fileInfo.MoveTo(configFilePath + ".bak");
                        this.CreatDefaultConfig(configFilePath);
                        Console.WriteLine("New config file is created ok!");
                        this.LoadConfig(configFilePath);
                    }
                }
            }
            catch(Exception errMsg)
            {
                Console.WriteLine("AppConfigHelper() running error! " + errMsg);
            }
        }

        /// <summary>
        /// 创建XML格式的配置文件file
        /// </summary>
        /// <param name="fFile"></param>
        public void CreatDefaultConfig(string file)
        {
            this.config.startup.supportedRuntime.version = "v4.0";
            this.config.startup.supportedRuntime.sku = ".NETFramework,Version=v4.5.2";
            this.config.appSettings.Add(new Add("AliDDNSVersion", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            this.config.appSettings.Add(new Add("AccessKeyID", ""));
            this.config.appSettings.Add(new Add("AccessKeySecret", ""));
            this.config.appSettings.Add(new Add("RecordID", ""));
            this.config.appSettings.Add(new Add("fullDomainName", "www.xxx.com"));
            this.config.appSettings.Add(new Add("TTL", "600"));
            this.config.appSettings.Add(new Add("WaitingTime", "600"));
            this.config.appSettings.Add(new Add("autoUpdate", "Off"));
            this.config.appSettings.Add(new Add("whatIsUrl", "http://whatismyip.akamai.com/,http://www.3322.org/dyndns/getip,http://ip.qq.com/,http://www.net.cn/static/customercare/yourip.asp"));
            this.config.appSettings.Add(new Add("autoBoot", "Off"));
            this.config.appSettings.Add(new Add("minimized", "Off"));
            this.config.appSettings.Add(new Add("logautosave", "Off"));
            this.config.appSettings.Add(new Add("ngrokauto", "Off"));
            this.config.appSettings.Add(new Add("ngrokexists", "Off"));

            this.SaveConfig(configFilePath);
        }

        public string GetAppSetting(string strKey)
        {
            foreach(Add item in config.appSettings)
            {
                if(item.key.ToString() == strKey)
                {
                    return item.value.ToString();
                }
            }
            return null;
        }

        public bool SetAppSetting(string strKey, string strValue)
        {
            foreach(var item in config.appSettings)
            {
                if(item.key.ToString() == strKey)
                {
                    item.value = strValue;
                    this.SaveConfig(configFilePath);
                    return true;
                }
            }
            return false;
        }

        public bool AddAppSetting(string strKey, string strValue)
        {
            foreach (var item in config.appSettings)
            {
                if (item.key.ToString() == strKey)
                {
                    return false;
                }
                else
                {
                    config.appSettings.Add(new Add(strKey, strValue));
                    this.SaveConfig(configFilePath);
                    return true;
                }
            }
            return false;
        }

        public bool isKeyExists(string strKey)
        {
            foreach (var item in config.appSettings)
            {
                if (item.key.ToString() == strKey)
                {
                    return true;
                }
            }
            return false;
        }

        #region The public method
        public void LoadConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config), new XmlRootAttribute("configuration"));
            StreamReader sr = new StreamReader(file);
            this.config = xs.Deserialize(sr) as Config;
            sr.Close();
        }

        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this.config);
            sw.Close();
        }
        #endregion
    }

    [Serializable]
    [XmlRoot("configuration")]
    public class Config
    {
        #region The private fields
        private StartUp startUp = new StartUp();
        private AppSettingList appSettingList = new AppSettingList();
        #endregion

        #region The public property
        [XmlElement("startup")]
        public StartUp startup
        {
            get { return startUp; }
            set { startUp = value; }
        }
        [XmlArray("appSettings")]
        [XmlArrayItem("add")]
        public AppSettingList appSettings
        {
            get { return appSettingList; }
            set { appSettingList = value; }
        }
        #endregion
    }

    public class StartUp
    {
        #region The private fields
        private SupportedRuntime supportedruntime = new SupportedRuntime();
        #endregion

        #region The public property
        public SupportedRuntime supportedRuntime
        {
            get { return supportedruntime; }
            set { supportedruntime = value; }
        }
        #endregion
    }

    public class SupportedRuntime
    {
        #region The private fields
        private string strVer = "v4.0";
        private string strSku = ".NETFramework,Version=v4.5.2";
        #endregion

        #region The public property
        [XmlAttribute("version")]
        public string version
        {
            get { return strVer; }
            set { strVer = value; }
        }
        [XmlAttribute("sku")]
        public string sku
        {
            get { return strSku; }
            set { strSku = value; }
        }
        #endregion
    }

    public class AppSettingList : List<Add>
    {

    }

    public class Add
    {
        #region The private fields
        private string strKey = string.Empty;
        private string strValue = string.Empty;
        #endregion

        #region The public property
        [XmlAttribute("key")]
        public string key
        {
            get { return strKey; }
            set { strKey = value; }
        }
        [XmlAttribute("value")]
        public string value
        {
            get { return strValue; }
            set { strValue = value; }
        }
        #endregion

        #region The constructor of LocalFile
        public Add(string key, string value)
        {
            this.strKey = key;
            this.strValue = value;
        }

        public Add()
        {
        }
        #endregion
    }
}
