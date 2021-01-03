/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:    •µÓ∆Ô ø£®Knights Warrior£© 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       https://github.com/knightswarrior
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace KnightsWarriorAutoupdater
{
    [Serializable]
    [XmlRoot("configuration")]
    public class Config
    {
        #region The private fields
        private bool enabled = true;
        private bool silence = false;
        private string serverUrl = string.Empty;
        private UpdateFileList updateFileList = new UpdateFileList();
        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME);
        #endregion

        #region The public property
        [XmlElement("Enabled")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        [XmlElement("Silence")]
        public bool Silence
        {
            get { return silence; }
            set { silence = value; }
        }
        [XmlElement("ServerUrl")]
        public string ServerUrl
        {
            get { return serverUrl; }
            set { serverUrl = value; }
        }
        [XmlArray("UpdateFileList")]
        [XmlArrayItem("LocalFile")]
        public UpdateFileList UpdateFileList
        {
            get { return updateFileList; }
            set { updateFileList = value; }
        }
        #endregion

        #region The public method
        public Config()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    CreatDefaultConfig(configFilePath);
                }
            }
            catch (Exception errMsg)
            {
                Console.WriteLine("Config::Config() running error! " + errMsg);
            }
        }
        public static Config LoadConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamReader sr = new StreamReader(file);
            Config config = xs.Deserialize(sr) as Config;
            sr.Close();

            return config;
        }

        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }

        public void CreatDefaultConfig(string file)
        {
            this.Silence = false;
            this.Enabled = false;
            this.ServerUrl = ConstFile.SERVERURL;
            FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
            this.UpdateFileList.Add(new LocalFile(Path.GetFileName(Application.ExecutablePath), Application.ProductVersion, (int)fileInfo.Length));
            this.UpdateFileList.Add(new LocalFile("AutoUpdater.dll", "0.0.0.0", 0));

            this.SaveConfig(file);
        }
        #endregion
    }

}
