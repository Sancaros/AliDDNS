/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:   圣殿骑士（Knights Warrior） 
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
using System.Linq;
using System.Text;

namespace KnightsWarriorAutoupdater
{
    public class ConstFile
    {
        public const string TEMPFOLDERNAME = "TempFolder";
        public const string CONFIGFILEKEY = "config_";
        public const string FILENAME = "aliddns_update.xml";
        public const string ROOLBACKFILE = "AliDDNS.exe";
        public const string MESSAGETITLE = "自动升级";
        public const string CANCELORNOT = FILENAME + " 正在升级中，请确认是否取消?";
        public const string APPLYTHEUPDATE = "程序需要重启以完成升级，点击“OK”重启！";
        public const string NOTNETWORK = "更新本地应用失败！请检查" + FILENAME + "下载文件清单。\r\n应用程序将重启，您可能需要选择“跳过”停止循环升级。";
        public const string SERVERURL = "https://www.demodomain.cn/AliDDNS/updatefilelist.xml";
    }
}
