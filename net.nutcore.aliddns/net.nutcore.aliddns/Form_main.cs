﻿using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static Aliyun.Acs.Alidns.Model.V20150109.DescribeSubDomainRecordsResponse;

namespace net.nutcore.aliddns
{
    public partial class mainForm : Form
    {
        public static bool checkUpdate;
        static IClientProfile clientProfile;
        static DefaultAcsClient client;
        //初始化ngrok操作类
        private Ngrok ngrok = new Ngrok();

        public mainForm()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //手工指定程序配置文件，如果不手工设定，默认是程序名称.exe.config  
            System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "aliddns_config.config"));
            string s = System.Configuration.ConfigurationManager.AppSettings["name"];
            MessageBox.Show(s);
            //获取当前用户名和计算机名并写入日志
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "计算机名: " + System.Environment.UserDomainName + "\r\n");
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户: " + System.Environment.UserName + "\r\n");
            //检查当前用户权限
            System.Security.Principal.WindowsIdentity wid = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal printcipal = new System.Security.Principal.WindowsPrincipal(wid);
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "角色信息:" + printcipal.Identity.Name.ToString() + "\r\n");
            /*
            bool isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Administrator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.User));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: User" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.AccountOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: AccountOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.BackupOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: BackupOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Guest));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Guest" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PowerUser));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: PowerUser" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PrintOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: PrintOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Replicator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Replicator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.SystemOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: SystemOperator" + "\r\n");
            */
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户需要文件写入和注册表操作权限，否则相关参数不起作用！" + "\r\n");
            
            try //检查设置文件，如果没有则新建，并赋值默认值
            {
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                if (File.Exists(config_file) != true) //当设置文件aliddns_config.xml不存在时，创建一个新的。
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "没有找到设置文件 aliddns_config.xml，重新创建！" + "\r\n");
                    if (saveConfigFile())
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件 aliddns_config.xml 创建成功！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件设置项目默认赋值完成！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请填写正确内容，点击“测试并保存”完成设置！" + "\r\n");
                    }
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                this.Dispose();
            }

            //读取设置文件aliddns_config.xml
            if (readConfigFile())
            {
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string updateExe = ExePath + "update.exe";
                if(checkUpdate == true)
                {
                    if (File.Exists(updateExe))
                    {
                        //执行update.exe
                    }
                    else
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "版本检测程序update.exe未找到，跳过版本检测！ " + "\r\n");
                    }
                }
                
                //窗体根据参数判断是否最小化驻留系统托盘
                if (checkBox_minimized.Checked == true)
                {
                    this.ShowInTaskbar = false; //从状态栏清除
                    this.WindowState = FormWindowState.Minimized; //窗体最小化
                    this.Hide(); //窗体隐藏
                }
                else if (checkBox_minimized.Checked == false)
                {
                    this.Show(); //窗体显示
                    this.WindowState = FormWindowState.Normal; //窗体正常化
                    this.ShowInTaskbar = true; //从状态栏显示
                }

                try //获取域名绑定IP
                {
                    clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text, accessKeySecret.Text);
                    client = new DefaultAcsClient(clientProfile);
                    domainIP.Text = getDomainIP();
                }
                catch (Exception error)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名和绑定IP失败，请检查设置项目内容和网络状态！" + "\r\n");
                }
            }

            try //获取WAN口IP
            {
                localIP.Text = getLocalIP();
                if ((localIP.Text != domainIP.Text) && (checkBox_autoBoot.Checked = true))
                {
                    updatePrepare();
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败！" + "\r\n");
            }

            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        private bool readConfigFile()
        {
            try
            {
                //Create xml object
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                XmlDocument xmlDOC = new XmlDocument();
                xmlDOC.Load(config_file);
                //XmlNodeReader readXML = new XmlNodeReader(xmlDOC);
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " DEBUG: " + readXML.Value + "\r\n"); //显示读取内容，用于调试DEBUG。
                XmlNodeList nodes = xmlDOC.SelectSingleNode("configuration").ChildNodes; //读取config节点下所有元素
                /*
                for (int i = 0; i < nodes.Count; i++)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + nodes[i].Name + ":" + nodes[i].InnerText + "\r\n"); //显示读取内容，用于调试DEBUG。
                }
                string[] config = new string[nodes.Count]; //创建一个设置读取数组用于存储读取内容
                int i = 0;
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件找到，开始读取..." + "\r\n");
                while (readXML.Read())
                {
                    readXML.MoveToElement(); //Forward
                    if (readXML.NodeType == XmlNodeType.Text) //(node.NodeType 是Text时，即是最内层 即innertext值，node.Attributes为null。
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + readXML.NodeType + "\r\n"); //显示读取内容，用于调试DEBUG。
                        config[i] = readXML.Value;
                        //此行用于调试读取内容
                        //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "项目[" + i + "]: " + config[i] + "\r\n"); //显示读取内容，用于调试DEBUG。
                        i++;
                    }
                }*/
                accessKeyId.Text = EncryptHelper.AESDecrypt(nodes[0].InnerText);
                accessKeySecret.Text = EncryptHelper.AESDecrypt(nodes[1].InnerText);
                //accessKeyId.Text = nodes[0].InnerText;
                //accessKeySecret.Text = nodes[1].InnerText;
                recordId.Text = nodes[2].InnerText;
                fullDomainName.Text = nodes[3].InnerText;
                label_nextUpdateSeconds.Text = newSeconds.Text = nodes[4].InnerText;
                if (nodes[5].InnerText == "On") checkBox_autoUpdate.Checked = true;
                else checkBox_autoUpdate.Checked = false;
                comboBox_whatIsUrl.Text = nodes[6].InnerText;

                if (nodes[7].InnerText == "On") checkBox_autoBoot.Checked = true;
                else checkBox_autoBoot.Checked = false;

                if (nodes[8].InnerText == "On") checkBox_minimized.Checked = true;
                else checkBox_minimized.Checked = false;

                if (nodes[9].InnerText == "On") checkBox_logAutoSave.Checked = true;
                else checkBox_logAutoSave.Checked = false;

                textBox_TTL.Text = nodes[10].InnerText;

                if (nodes[11].InnerText == "On") checkUpdate = true;
                else checkUpdate = false;

                if (nodes[12].InnerText == "On")
                {
                    checkBox_ngrok.Checked = true;
                    button_ngrok.Enabled = false;
                }
                else
                {
                    checkBox_ngrok.Checked = false;
                    button_ngrok.Enabled = true;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件读取成功！" + "\r\n");
                return true;
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                return false;
            }

        }

        private bool saveConfigFile()
        {
            try
            {
                if (accessKeyId.Text == "" || accessKeySecret.Text == "" || recordId.Text == "" || fullDomainName.Text == "" || newSeconds.Text == "" || comboBox_whatIsUrl.Text == "")
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "任何值都不能为空！无法填写请输入null或0！" + "\r\n");
                    return false;
                }
                string accessKeyId_encrypt = EncryptHelper.AESEncrypt(accessKeyId.Text);
                string accessKeySecret_encrypt = EncryptHelper.AESEncrypt(accessKeySecret.Text);
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                XmlTextWriter textWriter = new XmlTextWriter(config_file, null);
                textWriter.WriteStartDocument(); //文档开始

                textWriter.WriteComment("AlidnsAutoCheckTool");
                textWriter.WriteComment("Version:Beta 1.0");
                //Start config file
                textWriter.WriteStartElement("configuration"); //设置项目开始

                textWriter.WriteStartElement("AccessKeyID", "");
                textWriter.WriteString(accessKeyId_encrypt);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("AccessKeySecret", "");
                textWriter.WriteString(accessKeySecret_encrypt);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("RecordID", "");
                textWriter.WriteString(recordId.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("fullDomainName", "");
                textWriter.WriteString(fullDomainName.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("WaitingTime", "");
                textWriter.WriteString(newSeconds.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("autoUpdate", "");
                if (checkBox_autoUpdate.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("whatIsUrl", "");
                textWriter.WriteString(comboBox_whatIsUrl.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("autoBoot", "");
                if (checkBox_autoBoot.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("minimized", "");
                if (checkBox_minimized.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("logautosave", "");
                if (checkBox_logAutoSave.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("TTL", "");
                textWriter.WriteString(textBox_TTL.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("autoCheckUpdate", "");
                if (checkUpdate == false)
                    textWriter.WriteString("Off");
                else
                    textWriter.WriteString("On");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("ngrokauto", "");
                if (checkBox_ngrok.Checked == false)
                    textWriter.WriteString("Off");
                else
                    textWriter.WriteString("On");
                textWriter.WriteEndElement();

                textWriter.WriteEndElement(); //设置项目结束
                textWriter.WriteEndDocument();//文档结束
                textWriter.Close(); //文档保存关闭

                label_nextUpdateSeconds.Text = newSeconds.Text;

                return true;
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                return false;
            }

        }

        private string getLocalIP()
        {
            try
            {
                string strUrl = comboBox_whatIsUrl.Text; //从控件获取WAN口IP查询网址，默认值为："http://whatismyip.akamai.com/";
                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);
                Stream s = webreq.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd();
                all = Regex.Replace(all, @"(\d+)", "000$1");
                all = Regex.Replace(all, @"0+(\d{1,4})", "$1");
                string reg = @"(\d{1,4}\.\d{1,4}\.\d{1,4}\.\d{1,4})";
                Regex regex = new Regex(reg);
                Match match = regex.Match(all);
                string ip = match.Groups[1].Value;
                if (ip.Length > 0)
                {
                    label_localIpStatus.Text = "已连接";
                    label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "成功获取WAN口IP:" + ip + "\r\n");
                }
                //return ip;
                return Regex.Replace(ip, @"0*(\d+)", "$1");
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                label_localIpStatus.Text = "未连接";
                label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255,255,0,0);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败，请检查设置！" + "\r\n");
                return "0.0.0.0";
            }
        }

        private bool setRecordId() //获取阿里云解析返回recordId
        {
            DescribeSubDomainRecordsRequest request = new DescribeSubDomainRecordsRequest();
            request.SubDomain = fullDomainName.Text;
            try
            {
                DescribeSubDomainRecordsResponse response = client.GetAcsResponse(request);
                List<Record> list = response.DomainRecords;

                if (list.Count == 0) //当不存在域名记录时，添加一个
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问成功，但没有找到对应域名信息！" + "\r\n");
                    if (addDomainRecord())
                        return true;
                    else
                        return false;
                }

                int i = 0;

                foreach (Record record in list) //当存在域名记录时，返回域名记录信息
                {
                    i++;
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务返回RecordId:" + i.ToString() + " RecordId：" + record.RecordId + "\r\n");
                    recordId.Text = record.RecordId;
                    globalRR.Text = record.RR;
                    globalDomainType.Text = record.Type;
                    globalValue.Text = domainIP.Text = record.Value;
                    label_TTL.Text = Convert.ToString(record.TTL);
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                }
                return true;
            }
            //处理错误
            catch (ServerException e)  
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                return false;
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                return false;
            }
        }

        private string getDomainIP()
        {
            DescribeDomainRecordInfoRequest request = new DescribeDomainRecordInfoRequest();
            request.RecordId = recordId.Text;
            try
            {
                DescribeDomainRecordInfoResponse response = client.GetAcsResponse(request);
                if (response.Value != "0.0.0.0")
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名:" + response.RR + "." + response.DomainName + " 已经绑定IP:" + response.Value + "\r\n");
                    recordId.Text = response.RecordId;
                    globalRR.Text = response.RR;
                    globalDomainType.Text = response.Type;
                    globalValue.Text = response.Value;
                    label_TTL.Text = Convert.ToString(response.TTL);
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return response.Value;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名绑定IP失败！" + "\r\n");
                return "0.0.0.0";
            }
            //处理错误 
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                return "0.0.0.0";
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                return "0.0.0.0";
            }
        }

        private void updateDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            UpdateDomainRecordRequest request = new UpdateDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.RecordId = recordId.Text;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在将WAN口IP:" + localIP.Text + "与域名" + fullDomainName.Text + "绑定..." + "\r\n");
                UpdateDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    domainIP.Text = localIP.Text; //更新窗体数据
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新成功！" + "\r\n");
                }
                recordId.Text = response.RecordId;
            }
            //处理错误
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
        }

        private bool addDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            AddDomainRecordRequest request = new AddDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.DomainName = domainName;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在向阿里云DNS服务添加域名:" + fullDomainName.Text + "\r\n");
                AddDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "RecordId:" + response.RecordId + " 域名：" + fullDomainName.Text + "添加成功！" + "\r\n");
                recordId.Text = response.RecordId; 
                globalDomainType.Text = request.Type;
                globalRR.Text = request.RR; 
                globalValue.Text = domainIP.Text = request.Value;
                label_DomainIpStatus.Text = "已绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                return true;
            }
            //处理错误
            catch (ServerException e)  
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                return false;
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                return false;
            }
        }

        private void updatePrepare()
        {
            label_nextUpdateSeconds.Text = newSeconds.Text;
            try
            {
                localIP.Text = getLocalIP();
                domainIP.Text = getDomainIP();
                if (domainIP.Text == localIP.Text)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "一致，无需更新！" + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "不一致，需要更新！" + "\r\n");
                    updateDomainRecord();
                }
                //localIP.Text = getLocalIP();
                //domainIP.Text = getDomainIP();
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新失败！" + "\r\n");
            }
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        //Events in form
        private void updateNow_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---立即开始WAN口IP和域名绑定IP进行查询比较---" + "\r\n");
            updatePrepare();
        }

        private void checkConfig_Click(object sender, EventArgs e)
        {
            try
            {
                //localIP.Text = getLocalIP(); //读取WAN口IP
                //domainIP.Text = getDomainIP(); //读取AliDDNS已经绑定IP
                clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text, accessKeySecret.Text);
                client = new DefaultAcsClient(clientProfile);
                if (setRecordId()) //检查能否从服务器返回RecordId，返回则设置正确，否则设置不正确
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置项目内容填写正确，即将保存到设置文件！ " + "\r\n");

                    if (saveConfigFile()) //检查设置文件是否保存成功
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件保存成功！ " + "\r\n");
                    else
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件保存失败，请检查文件权限！ " + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务没有返回RecordId，设置项目内容没有保存！" + "\r\n");
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问失败，请检查账户accessKeyId和accessKeySecret！" + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                domainIP.Text = "0.0.0.0";
                recordId.Text = "null";
                globalRR.Text = "null";
                globalDomainType.Text = "null";
                globalValue.Text = "null";
                label_TTL.Text = "null";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            }
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }
       
        private void autoUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (checkBox_autoUpdate.Checked == true)
            {
                if(Convert.ToInt32(label_nextUpdateSeconds.Text) > 0)
                {
                    label_nextUpdateSeconds.Text = Convert.ToString((Convert.ToInt32(label_nextUpdateSeconds.Text) - 1));
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---计划任务被触发，开始WAN口IP和域名IP查询比较---" + "\r\n");
                    updatePrepare();
                }
            }
            
            if (checkBox_logAutoSave.Checked == true && textBox_log.GetLineFromCharIndex(textBox_log.Text.Length) > 10000)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---运行日志超过10000行，开始日志转储---" + "\r\n");
                logToFiles();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void notifyIcon_sysTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show(); //窗体显示
                this.WindowState = FormWindowState.Normal; //窗体正常化
                this.ShowInTaskbar = true; //从状态栏显示
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = false; //从状态栏清除
                this.WindowState = FormWindowState.Minimized; //窗体最小化
                this.Hide(); //窗体隐藏
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //取消关闭窗体
            this.WindowState = FormWindowState.Minimized; //窗体最小化
            this.Hide(); //窗体隐藏
        }

        private void button_whatIsTest_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "开始向网址发起查询... " + "\r\n");
            localIP.Text = getLocalIP();
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        private void button_ShowHide_Click(object sender, EventArgs e)
        {
            if (button_ShowHide.Text == "显示录入")
            {
                button_ShowHide.Text = "隐藏录入";
                accessKeyId.PasswordChar = (char)0;
                accessKeySecret.PasswordChar = (char)0;
            }
            else
            {
                button_ShowHide.Text = "显示录入";
                accessKeyId.PasswordChar = '*';
                accessKeySecret.PasswordChar = '*';
            }
        }

        private void fullDomainName_ModifiedChanged(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名修改后请测试并保存！" + "\r\n");
        }

        private void checkBox_autoBoot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_autoBoot.Checked == true)
                {
                    //获取执行该方法的程序集，并获取该程序集的文件路径（由该文件路径可以得到程序集所在的目录）
                    string thisExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;//this.GetType().Assembly.Location;
                                                                                                           //SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run注册表中这个路径是开机自启动的路径
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    Rkey.SetValue("AliDDNS Tray", thisExecutablePath);
                    Rkey.Close();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行设置成功！" + "\r\n");
                }
                else
                {
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    Rkey.DeleteValue("AliDDNS Tray");
                    Rkey.Close();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行取消！" + "\r\n");
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            Form_About about = new Form_About();
            about.Show(this);
        }

        private void checkBox_logAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_logAutoSave.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储启用成功！日志超过1万行将自动转储。" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储取消！" + "\r\n");
        }

        private void logToFiles()
        {
            try
            {
                string logPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string logfile = logPath + DateTime.Now.ToString("yyyyMMddHHmmss") + "aliddns_log.txt";
                if (!File.Exists(logfile))
                {
                    StreamWriter sw = new StreamWriter(logfile); 
                    sw.WriteLine(textBox_log.Text);
                    sw.Close();
                    sw.Dispose();
                    textBox_log.Clear();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志转储为: " + logfile + "\r\n");
                }
                else
                {
                    StreamWriter sw = File.AppendText(logfile);
                    sw.WriteLine(textBox_log.Text);
                    sw.Close();
                    sw.Dispose();
                    textBox_log.Clear();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志转储为: " + logfile + "\r\n");
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
            
        }

        private void checkBox_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_autoUpdate.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新启用成功！" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新取消！" + "\r\n");
        }

        private void checkBox_minimized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_minimized.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘启用！" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘取消！" + "\r\n");
        }

        private void button_setIP_Click(object sender, EventArgs e)
        {
            try
            {
                string strIn = maskedTextBox_setIP.Text;
                if (Regex.IsMatch(strIn, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"))
                {
                    localIP.Text = maskedTextBox_setIP.Text;
                    updateDomainRecord();
                    //getDomainIP();
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查输入格式是否正确！IP地址示例格式:255.255.255.255" + "\r\n");
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        private void notifyIcon_sysTray_Update()
        {
            if ( label_localIpStatus.Text == "未连接" )
            {
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_gray;
            }
            else
            {
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                if ( label_DomainIpStatus.Text == "未绑定" )
                {
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                }
                else
                {
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                    if( localIP.Text == domainIP.Text )
                        this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                }
            }

        }

        public static string verCheckUpdate()
        {
            try
            {
                string strUrl = "https://github.com/wisdomwei201804/AliDDNS/releases/latest";
                if (strUrl.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls1.2 | SecurityProtocolType.Tls12;
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient(
                    new System.Net.Http.HttpClientHandler
                    {
                        //CookieContainer = cookies,
                        AutomaticDecompression = DecompressionMethods.GZip //防止返回的json乱码
                                               | DecompressionMethods.Deflate
                    });
                httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/4.0(compatible;MSIE6.0;WindowsNT5.1)");
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4");
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, sdch");
                httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/x-www-form-urlencoded,application/xhtml+xml,application/json,application/xml;q=0.9,image/webp,*/*;q=0.8");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("UTF-8"));
                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(strUrl).Result;
                //var statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    string ver = System.Text.RegularExpressions.Regex.Match(result, @"""tag_name"":""([^""]*)""").Groups[1].Value;
                    //MessageBox.Show(ver);
                    return ver.ToString();
                }
                else
                    return null;
                httpClient.Dispose();
                response.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return null;
            }
        }

        private void ToolStripMenuItem_checkUPdate_Click(object sender, EventArgs e)
        {
            string strVer = verCheckUpdate();
            if (strVer != null)
            {
                Version remoteVer = new Version(strVer);
                Version localVer = new Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if (remoteVer > localVer)
                    MessageBox.Show("发现新版本: " + remoteVer);
                else
                    MessageBox.Show("没有新版本，无需升级！");
            }
            else
                MessageBox.Show("获取新版本信息失败！");
        }

        private async void checkBox_ngrok_CheckedChanged(object sender, EventArgs e)
        {
             if (checkBox_ngrok.Checked == true)
            {
                button_ngrok.Enabled = false;
                //检测ngrok.exe是否存在
                if (ngrok.IsExists())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，ngrok.exe将自动加载！通过浏览器打开：http://127.0.0.1:4040 查看运行状态。" + "\r\n");
                    await ngrok.Start();
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，但当前目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                }
            }
            else
            {
                await ngrok.Stop();
                button_ngrok.Enabled = true;
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能关闭，再次启动将不会加载！" + "\r\n");
            }
        }

        private void button_ngrok_Click(object sender, EventArgs e)
        {
            Form_ngrok ngrok = new Form_ngrok();
            ngrok.Show(this);
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            //检测ngrok.exe是否存在
            if (( checkBox_ngrok.Checked == true ) && ( !ngrok.IsExists() ))
            {
                MessageBox.Show("设置在当前目录没有发现ngrok.exe，请往官网下载自行编译。\nNgrok官网：https://ngrok.com/download");
            }
        }
    }
}
