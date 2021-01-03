using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static Aliyun.Acs.Alidns.Model.V20150109.DescribeSubDomainRecordsResponse;
using KnightsWarriorAutoupdater;
using System.Xml;

namespace net.nutcore.aliddns
{
    public partial class Form_main : Form
    {
        private delegate void ThreadNew();//代理异步线程->升级
        static IClientProfile clientProfile;
        static DefaultAcsClient client;
        //初始化ngrok操作类
        private NgrokHelper ngrok = new NgrokHelper();
        //初始化appconfig操作类
        private AppConfigHelper cfg = new AppConfigHelper();
        //初始化升级功能类
        private AutoUpdater autoUpdater = new AutoUpdater();

        public Form_main()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        /// <summary>
        /// mainForm窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_main_Load(object sender, EventArgs e)
        {
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
            
            //读取设置文件aliddns_config.xml
            if (appConfig_Load())
            {
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

                //获取阿里云域名记录绑定IP
                //domainIP.Text = getAliDnsRecordDomainIP();
                //获取WAN口IP
                //localIP.Text = getWanIP();
                if (checkBox_autoBoot.Checked == true)
                {
                    updatePrepare();
                }
            }
            //读取updateinfo.txt文件
            textBox_updateInfo.ReadOnly = true;
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string updateInfoFile = filePath + "updateinfo.txt";
            if (File.Exists(updateInfoFile))
            {
                textBox_updateInfo.Text = File.ReadAllText(updateInfoFile, Encoding.Default);
            }
            else
            {
                textBox_updateInfo.Text = "软件运行目录下没有找到updateinfo.txt文件！";
            }

            //获取当前版本
            label_currentVer.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
            if ( checkBox_autoUpgrade.Checked == true )
            {                
                //执行upgrade
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在自动检测升级！ " + "\r\n");
                Updater();
            }
            else
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "自动检测升级未启用！ " + "\r\n");
            }
            //读取ngrok配置文件
            ngrokConfig_Load();
            //监测网络状态、刷新系统托盘图标
            notifyIcon_sysTray_Update();
        }

        /// <summary>
        /// 读取配置文件并初始化控件
        /// </summary>
        /// <returns></returns>
        private bool appConfig_Load()
        {
            try
            {
                textBox_accessKeyId.Text = EncryptHelper.AESDecrypt(cfg.GetAppSetting("AccessKeyID").ToString());
                textBox_accessKeySecret.Text = EncryptHelper.AESDecrypt(cfg.GetAppSetting("AccessKeySecret").ToString());
                textBox_recordId.Text = cfg.GetAppSetting("RecordID").ToString();
                textBox_fullDomainName.Text = cfg.GetAppSetting("fullDomainName").ToString();
                label_nextUpdateSeconds.Text = textBox_newSeconds.Text = cfg.GetAppSetting("WaitingTime").ToString();

                if (cfg.GetAppSetting("autoUpdate").ToString() == "On") checkBox_autoUpdate.Checked = true;
                else checkBox_autoUpdate.Checked = false;

                if (cfg.GetAppSetting("whatIsUrl").ToString() != null)
                {
                    string[] arrayUrl = cfg.GetAppSetting("whatIsUrl").ToString().Split(',');
                    foreach(string strUrl in arrayUrl)
                    {
                        comboBox_whatIsUrl.Items.Add(strUrl.ToString().Trim());
                    }
                    comboBox_whatIsUrl.SelectedIndex = 0;
                }
                
                if (cfg.GetAppSetting("autoBoot").ToString() == "On") checkBox_autoBoot.Checked = true;
                else checkBox_autoBoot.Checked = false;

                if (cfg.GetAppSetting("minimized").ToString() == "On") checkBox_minimized.Checked = true;
                else checkBox_minimized.Checked = false;

                if (cfg.GetAppSetting("logautosave").ToString() == "On") checkBox_logAutoSave.Checked = true;
                else checkBox_logAutoSave.Checked = false;

                textBox_TTL.Text = cfg.GetAppSetting("TTL").ToString();

                if (cfg.GetAppSetting("ngrokauto").ToString() == "On") checkBox_ngrokAuto.Checked = true;
                else checkBox_ngrokAuto.Checked = false;

                if (cfg.GetAppSetting("ngrokexists").ToString() == "On") checkBox_ngrokExists.Checked = true;
                else checkBox_ngrokExists.Checked = false;

                if (autoUpdater.config.Enabled) checkBox_autoUpgrade.Checked = true;
                else checkBox_autoUpgrade.Checked = false;
                if (autoUpdater.config.Silence) checkBox_silence.Checked = true;
                else checkBox_silence.Checked = false;
                textBox_upgradeUrl.Text = autoUpdater.config.ServerUrl.ToString();

                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件读取成功！" + "\r\n");
                return true;
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                return false;
            }

        }

        /// <summary>
        /// 获取网络出口公网IP
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        private string getWanIP(string strUrl)
        {
            try
            {
                if (strUrl != null)
                {
                    Uri uri = new Uri(strUrl);
                    WebRequest webreq = WebRequest.Create(uri);
                    Stream s = webreq.GetResponse().GetResponseStream();
                    StreamReader sr = new StreamReader(s, Encoding.Default);
                    string all = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    all = Regex.Replace(all, @"(\d+)", "000$1");
                    all = Regex.Replace(all, @"0+(\d{1,4})", "$1");
                    string reg = @"(\d{1,4}\.\d{1,4}\.\d{1,4}\.\d{1,4})";
                    Regex regex = new Regex(reg);
                    Match match = regex.Match(all);
                    string ip = match.Groups[1].Value;
                    if ((ip.Length > 0) && (ip.ToString() != "0.0.0.0"))
                    {
                        label_localIpStatus.Text = "已连接";
                        label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "从" + strUrl + "成功获取WAN口IP:" + ip + "\r\n");
                        //return ip;
                        return Regex.Replace(ip, @"0*(\d+)", "$1");
                    }
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "从" + strUrl + "返回IP是空值，查询失败！" + "\r\n");
                    label_localIpStatus.Text = "未连接";
                    label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                    return "0.0.0.0";
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查配置文件查询网址设置！" + "\r\n");
                    return "0.0.0.0";
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                label_localIpStatus.Text = "未连接";
                label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255,255,0,0);
                return "0.0.0.0";
            }
        }

        /// <summary>
        /// 从阿里云获取域名记录recordId
        /// </summary>
        /// <returns></returns>
        private bool getRecordId()
        {
            if(textBox_accessKeyId.Text.ToString()==null||textBox_accessKeySecret.Text.ToString()==null||textBox_fullDomainName.Text.ToString()==null||textBox_TTL.Text.ToString()==null||textBox_newSeconds.Text.ToString()==null)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查设置，不能为空！" + "\r\n");
                return false;
            }
            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", textBox_accessKeyId.Text.ToString(), textBox_accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            DescribeSubDomainRecordsRequest request = new DescribeSubDomainRecordsRequest();
            request.SubDomain = textBox_fullDomainName.Text;
            try
            {
                DescribeSubDomainRecordsResponse response = client.GetAcsResponse(request);
                List<Record> list = response.DomainRecords;

                if (list.Count == 0) //当不存在域名记录时，添加一个
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问成功，但没有找到对应域名记录，请添加域名后重试！" + "\r\n");
                    return false;
                }
                else
                {
                    int i = 0;
                    foreach (Record record in list) //当存在域名记录时，返回域名记录信息
                    {
                        i++;
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务返回RecordId:" + i.ToString() + " RecordId：" + record.RecordId + "\r\n");
                        textBox_recordId.Text = record.RecordId;
                        cfg.SetAppSetting("RecordID", record.RecordId.ToString());
                        label_globalRR.Text = record.RR;
                        label_globalDomainType.Text = record.Type;
                        label_globalValue.Text = label_domainIP.Text = record.Value;
                        label_TTL.Text = Convert.ToString(record.TTL);
                        label_DomainIpStatus.Text = "已绑定";
                        label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    }
                    return true;
                }
            }
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
            //处理错误
            /*
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
                return false;
            }*/
        }

        /// <summary>
        /// 从阿里云服务器获取域名记录信息
        /// </summary>
        /// <returns></returns>
        private string getAliDnsRecordDomainIP()
        {
            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", textBox_accessKeyId.Text.ToString(), textBox_accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            DescribeDomainRecordInfoRequest request = new DescribeDomainRecordInfoRequest();
            request.RecordId = textBox_recordId.Text.ToString();
            try
            {
                DescribeDomainRecordInfoResponse response = client.GetAcsResponse(request);
                string fullDomain = response.RR.ToString() + "." + response.DomainName.ToString();
                if (response.Value != "0.0.0.0")
                {
                    if(fullDomain != textBox_fullDomainName.Text.ToString())
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS域名记录:"+ response.RecordId + " 对应域名为:" + fullDomain + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件域名记录:" + textBox_recordId.Text.ToString() + " 对应域名为:" + textBox_fullDomainName.Text.ToString() + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件设置错误！可能原因是修改域名记录后未及时添加，已经自动修改配置文件与服务器记录一致！" + "\r\n");
                        textBox_fullDomainName.Text = fullDomain;
                        cfg.SetAppSetting("fullDomainName", fullDomain);
                    }
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名:" + response.RR + "." + response.DomainName + " 已经绑定IP:" + response.Value + "\r\n");
                    textBox_recordId.Text = response.RecordId;
                    label_globalRR.Text = response.RR;
                    label_globalDomainType.Text = response.Type;
                    label_globalValue.Text = response.Value;
                    label_TTL.Text = Convert.ToString(response.TTL);
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return response.Value;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名绑定IP失败！" + "\r\n");
            }
            //处理错误 
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "getAliDnsRecordDomainIP() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
            label_DomainIpStatus.Text = "未绑定";
            label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            return "0.0.0.0";
        }

        /// <summary>
        /// 更新域名记录
        /// </summary>
        private void updateDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = textBox_fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", textBox_accessKeyId.Text.ToString(), textBox_accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            UpdateDomainRecordRequest request = new UpdateDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.RecordId = textBox_recordId.Text;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = label_localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在将WAN口IP:" + label_localIP.Text + "与域名" + textBox_fullDomainName.Text + "绑定..." + "\r\n");
                UpdateDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    label_domainIP.Text = label_localIP.Text; //更新窗体数据
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新成功！" + "\r\n");
                    if (checkBox_ngrokAuto.Checked == true)
                    {
                        //button_ngrok.Enabled = false;
                        //cfg.SaveAppSetting("ngrokauto", "On");
                        //检测ngrok.exe是否存在
                        if (ngrok.IsExists())
                        {
                            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "IP地址变化，Ngrok功能重启！本机浏览器打开：http://127.0.0.1:4040 查看运行状态。" + "\r\n");
                            ngrok.Stop();
                            ngrok.Start();
                        }
                        //else
                        //{
                            //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，但当前目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                        //}
                    }
                }
                textBox_recordId.Text = response.RecordId;
            }
            //处理错误
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
        }

        /// <summary>
        /// 添加域名记录
        /// </summary>
        /// <returns></returns>
        private bool addDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = textBox_fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", textBox_accessKeyId.Text.ToString(), textBox_accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            AddDomainRecordRequest request = new AddDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.DomainName = domainName;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = label_localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在向阿里云DNS服务添加域名:" + textBox_fullDomainName.Text + "\r\n");
                AddDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + " 域名：" + textBox_fullDomainName.Text + "添加成功！" + "服务器返回RecordId:" + response.RecordId  + "\r\n");
                    textBox_recordId.Text = response.RecordId.ToString();
                    cfg.SetAppSetting("RecordID", response.RecordId.ToString());
                    label_globalDomainType.Text = request.Type;
                    label_globalRR.Text = request.RR;
                    label_globalValue.Text = label_domainIP.Text = request.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return true;
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + " 域名：" + textBox_fullDomainName.Text + "添加失败！" + "\r\n");
                    label_DomainIpStatus.Text = "未绑定";
                    label_domainIP.Text = "0.0.0.0";
                    textBox_recordId.Text = "null";
                    label_globalRR.Text = "null";
                    label_globalDomainType.Text = "null";
                    label_globalValue.Text = "null";
                    label_TTL.Text = "null";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                    return false;
                }
                    
            }
            //处理错误
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
            return false;
        }

        /// <summary>
        /// 比较是否需要更新域名信息
        /// </summary>
        private void updatePrepare()
        {
            label_nextUpdateSeconds.Text = textBox_newSeconds.Text;
            string[] arrayUrl = cfg.GetAppSetting("whatIsUrl").ToString().Split(',');
            foreach (string strUrl in arrayUrl)
            {
                if ((label_localIP.Text = getWanIP(strUrl)) != "0.0.0.0")
                {
                    break;
                }
            }
            if(label_localIP.Text.ToString() == "0.0.0.0")
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + label_localIP.Text + "，域名绑定IP更新停止，请检查查询网址设置或者手工指定IP！" + "\r\n");
                return;
            }
            label_domainIP.Text = getAliDnsRecordDomainIP();
            if (label_domainIP.Text == label_localIP.Text)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + label_localIP.Text + " 与域名绑定IP:" + label_domainIP.Text + "一致，无需更新！" + "\r\n");
            }
            else
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + label_localIP.Text + " 与域名绑定IP:" + label_domainIP.Text + "不一致，需要更新！" + "\r\n");
                updateDomainRecord();
            }
            //localIP.Text = getWanIP();
            //domainIP.Text = getAliDnsRecordDomainIP();
            //监测网络状态、刷新系统托盘图标
            notifyIcon_sysTray_Update(); 
        }

        private void updateNow_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---立即开始WAN口IP和域名绑定IP进行查询比较---" + "\r\n");
            updatePrepare();
        }

        private void checkConfig_Click(object sender, EventArgs e)
        {
            if (getRecordId()) 
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "测试结果->成功！" + "\r\n");
            }
            else
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "测试结果->失败！请检查设置项目是否正确！" + "\r\n");
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

        private void ToolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            ngrok.Stop();
            this.Dispose();
        }

        private void ToolStripMenuItem_about_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.tabControl1.SelectedTab = tabPage_about;
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

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //取消关闭窗体
            this.WindowState = FormWindowState.Minimized; //窗体最小化
            this.Hide(); //窗体隐藏
        }

        private void button_whatIsTest_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "开始向网址发起查询... " + "\r\n");
            label_localIP.Text = getWanIP(comboBox_whatIsUrl.Text.ToString().Trim());
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        private void button_ShowHide_Click(object sender, EventArgs e)
        {
            if (button_ShowHide.Text == "显示录入")
            {
                button_ShowHide.Text = "隐藏录入";
                textBox_accessKeyId.PasswordChar = (char)0;
                textBox_accessKeySecret.PasswordChar = (char)0;
            }
            else
            {
                button_ShowHide.Text = "显示录入";
                textBox_accessKeyId.PasswordChar = '*';
                textBox_accessKeySecret.PasswordChar = '*';
            }
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
                    cfg.SetAppSetting("autoBoot", "On");
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行设置成功！" + "\r\n");
                }
                else
                {
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    Rkey.DeleteValue("AliDDNS Tray");
                    Rkey.Close();
                    cfg.SetAppSetting("autoBoot", "Off");
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行取消！" + "\r\n");
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
        }

        private void checkBox_logAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_logAutoSave.Checked == true)
            {
                cfg.SetAppSetting("logautosave", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储启用成功！日志超过1万行将自动转储。" + "\r\n");
            }
            else
            {
                cfg.SetAppSetting("logautosave", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储取消！" + "\r\n");
            }
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
            {
                cfg.SetAppSetting("autoUpdate", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新启用成功！" + "\r\n");
            }
            else
            {
                cfg.SetAppSetting("autoUpdate", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新取消！" + "\r\n");
            }
        }

        private void checkBox_minimized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_minimized.Checked == true)
            {
                cfg.SetAppSetting("minimized", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘启用！" + "\r\n");
            }
            else
            {
                cfg.SetAppSetting("minimized", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘取消！" + "\r\n");
            }
        }

        private void button_setIP_Click(object sender, EventArgs e)
        {
            try
            {
                string strIn = maskedTextBox_setIP.Text;
                if (Regex.IsMatch(strIn, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"))
                {
                    label_localIP.Text = maskedTextBox_setIP.Text;
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
            //监测网络状态、刷新系统托盘图标
            notifyIcon_sysTray_Update(); 
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
                    if( label_localIP.Text == label_domainIP.Text )
                        this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                }
            }

        }

        /// <summary>
        /// 从github.com仓库检查软件最新release版本信息，返回版本号
        /// </summary>
        /// <returns></returns>
        public string[] getRemoteVer(string strUrl)
        {
            if (strUrl == null)
            {
                strUrl = "https://github.com/wisdomwei201804/AliDDNS/releases/latest";
            }
            if (strUrl.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls1.2 | SecurityProtocolType.Tls12;
            }
            try
            {              
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
                request.Method = "GET";
                request.Accept = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                string result = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                if (response.StatusCode.ToString() == "OK" )
                {
                    string remoteVer = Regex.Match(result, @"""tag_name"":""([^""]*)""").Groups[1].Value;
                    return new string[] { "OK", remoteVer };
                }
                else
                {
                    return new string[] { "NULL", null };
                }
            }
            catch (Exception error)
            {
                return new string[] { "-1", error.Message.ToString() };
            }
        }

        private void ToolStripMenuItem_checkUpgrade_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在检测升级！ " + "\r\n");
            Updater();
        }

        private void checkBox_ngrokAuto_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox_ngrokAuto.Checked == true)
            {
                cfg.SetAppSetting("ngrokauto", "On");
                //检测ngrok.exe是否存在
                if (ngrok.IsExists())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，ngrok.exe将自动加载！本机浏览器打开：http://127.0.0.1:4040 查看运行状态。" + "\r\n");
                    ngrok.Start();
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，但当前目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                }
            }
            else
            {
                cfg.SetAppSetting("ngrokauto", "Off");
                ngrok.Stop();
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能关闭，再次启动将不会加载！" + "\r\n");
            }
        }

        private void checkBox_ngrokExists_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ngrokExists.Checked == true)
            {
                cfg.SetAppSetting("ngrokexists", "On");
                //检测ngrok.exe是否存在
                if (ngrok.IsExists())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "启动时检测ngrok.exe是否存在。" + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件运行目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                }
            }
            else
            {
                cfg.SetAppSetting("ngrokexists", "Off");
                ngrok.Stop();
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "启动时不再检测ngrok.exe是否存在。" + "\r\n");
            }
        }

        private void Form_main_Shown(object sender, EventArgs e)
        {
            //提醒ngrok.exe是否存在
            if ( checkBox_ngrokExists.Checked == true )
            {
                //检测ngrok.exe是否存在
                if (!ngrok.IsExists())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件运行目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                    MessageBox.Show("软件运行目录没有发现ngrok.exe，请往官网下载自行编译。\nNgrok官网：https://ngrok.com/download");
                }                
            }
        }

        private void fullDomainName_Leave(object sender, EventArgs e)
        {
            cfg.SetAppSetting("fullDomainName", this.textBox_fullDomainName.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名已经保存，点击测试连接将查询域名是否存在，当不存在时点击添加域名会创建新域名记录！" + "\r\n");
        }

        private void accessKeyId_Leave(object sender, EventArgs e)
        {
            cfg.SetAppSetting("AccessKeyID", EncryptHelper.AESEncrypt(this.textBox_accessKeyId.Text.ToString()));
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "accessKeyId已经保存，请完成设置录入后点击测试连接！" + "\r\n");
        }

        private void accessKeySecret_Leave(object sender, EventArgs e)
        {
            cfg.SetAppSetting("AccessKeySecret", EncryptHelper.AESEncrypt(this.textBox_accessKeySecret.Text.ToString()));
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "accessKeySecret已经保存，请完成设置录入后点击测试连接！" + "\r\n");
        }

        private void textBox_TTL_Leave(object sender, EventArgs e)
        {
            cfg.SetAppSetting("TTL",this.textBox_TTL.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "TTL设置修改保存成功！" + "\r\n");
        }

        private void newSeconds_Leave(object sender, EventArgs e)
        {
            cfg.SetAppSetting("WaitingTime", this.textBox_newSeconds.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "自动更新倒计时设置修改保存成功！" + "\r\n");
        }

        private void comboBox_whatIsUrl_Leave(object sender, EventArgs e)
        {
            //cfg.SaveAppSetting("whatIsUrl", this.comboBox_whatIsUrl.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "网址有变化，请测试并确定是否添加进配置文件！" + "\r\n");
        }

        private void button_addNewDomain_Click(object sender, EventArgs e)
        {
            addDomainRecord();
        }

        private void button_addUrl_Click(object sender, EventArgs e)
        {
            string newItem = comboBox_whatIsUrl.Text.Trim().ToLower().ToString();
            for(int i = 0; i < comboBox_whatIsUrl.Items.Count; i++)
            {
                if (newItem == comboBox_whatIsUrl.Items[i].ToString())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "该网址已经存在，无需重复添加！" + "\r\n");
                    return;
                }
            }
            comboBox_whatIsUrl.Items.Add(newItem);
            cfg.AddAppSetting("whatIsUrl", newItem);
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "新增公网IP查询网址保存成功！" + "\r\n");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/wisdomwei201804/AliDDNS/");
        }

        private void checkBox_autoUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_autoUpgrade.Checked == true)
            {
                autoUpdater.config.Enabled = true;
                autoUpdater.config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件自动检测升级启用！" + "\r\n");
            }
            else
            {
                autoUpdater.config.Enabled = false;
                autoUpdater.config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件自动检测升级关闭！" + "\r\n");
            }
        }
        private void button_ngrokApply_Click(object sender, EventArgs e)
        {
            if (ngrok.IsExists())
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok穿透功能已经启动！\r\n本机浏览器打开：http://127.0.0.1:4040 查看运行状态。" + "\r\n");
                ngrok.Start();
            }
            else
            {
                MessageBox.Show("设置在当前目录没有发现ngrok.exe，请往官网下载自行编译。\nNgrok官网：https://ngrok.com/download");
            }
            
        }

        private void ngrokConfig_Load()
        {
            //读取配置文件
            try
            {
                textBox_AuthToken.Text = ngrok.ngrokConfig.authtoken;
                textBox_serverAddr.Text = ngrok.ngrokConfig.server_addr;
                //List<NgrokHelper.Protocol> tunnel = new List<NgrokHelper.Protocol>();
                ArrayList row = new ArrayList();
                Dictionary<object,object> tunnelItems = (Dictionary<object, object>)ngrok.ngrokConfig.tunnels;
                int count = tunnelItems.Count;
                int k = 0;
                foreach (KeyValuePair<object, object> kvp in tunnelItems)
                {
                    row.Add(kvp.Key); 
                    Dictionary<object, object> items = (Dictionary<object, object>)kvp.Value;
                    foreach (KeyValuePair<object, object> items_kvp in items)
                    {
                        if(items_kvp.Key.ToString() == "proto")
                        {
                            Dictionary<object, object> protos = (Dictionary<object, object>)items_kvp.Value;
                            foreach (KeyValuePair<object, object> protos_kvp in protos)
                            {
                                row.Add(protos_kvp.Key);
                                row.Add(protos_kvp.Value);
                                if(protos_kvp.Key.ToString() == "http" || protos_kvp.Key.ToString() == "https")
                                {
                                    row.Add(null);
                                }
                            }
                        }
                        if (items_kvp.Key.ToString() == "subdomain")
                        {
                            row.Add(items_kvp.Value);
                        }
                        if (items_kvp.Key.ToString() == "remote_port")
                        {
                            row.Add(items_kvp.Value);
                            row.Add(null);
                        }
                    }
                }

                listView_ngrok.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                for (int i = 1; i <= count; i++)   //添加数据
                {
                    ListViewItem lvi = new ListViewItem();
                    //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标
                    lvi.Text = i.ToString();
                    for (int j = 2; j <= 6; j++)
                    {
                        lvi.SubItems.Add((string)row[k]);
                        k++;
                    }
                    listView_ngrok.Items.Add(lvi);
                }
                listView_ngrok.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            }
            catch (Exception error)
            {
                MessageBox.Show("配置文件ngrok.cfg读取出错！请修改文件内容或者格式，也可以删除错误文件自动生成新文件。" + error, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ngrokSave_Click(object sender, EventArgs e)
        {
            Dictionary<object,object> tunnel_saved = new Dictionary<object, object>();
            

            for (int i = 0; i < listView_ngrok.Items.Count; i++)
            {
                Dictionary<object, object> item_saved = new Dictionary<object, object>();
                Dictionary<object, object> proto_saved = new Dictionary<object, object>();

                if (listView_ngrok.Items[i].SubItems[2].Text == "http")
                {
                    proto_saved.Add("http", listView_ngrok.Items[i].SubItems[3].Text);
                    item_saved.Add("proto", proto_saved);
                    item_saved.Add("subdomain", listView_ngrok.Items[i].SubItems[5].Text);
                }
                if (listView_ngrok.Items[i].SubItems[2].Text == "https")
                {
                    proto_saved.Add("https", listView_ngrok.Items[i].SubItems[3].Text);
                    item_saved.Add("proto", proto_saved);
                    item_saved.Add("subdomain", listView_ngrok.Items[i].SubItems[5].Text);
                }
                if (listView_ngrok.Items[i].SubItems[2].Text == "tcp")
                {
                    proto_saved.Add("tcp", listView_ngrok.Items[i].SubItems[3].Text);
                    item_saved.Add("proto", proto_saved);
                    item_saved.Add("remote_port", listView_ngrok.Items[i].SubItems[4].Text);
                }
                tunnel_saved.Add(listView_ngrok.Items[i].SubItems[1].Text, item_saved);
            }

            ngrok.ngrokConfig.authtoken = textBox_AuthToken.Text.ToString();
            ngrok.ngrokConfig.server_addr = textBox_serverAddr.Text.ToString();
            ngrok.ngrokConfig.tunnels = tunnel_saved;

            ngrok.SaveConfig();
        }

        private void button_addnew_Click(object sender, EventArgs e)
        {
            Form_tunnelEdit tunnelEditForm = new Form_tunnelEdit();
            tunnelEditForm.Owner = this;
            tunnelEditForm.tunnelMode = "addNew";
            tunnelEditForm.tunnelIndex = listView_ngrok.Items.Count;
            tunnelEditForm.ShowDialog();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            /*foreach (ListViewItem lvi in listView_ngrok.SelectedItems)  //选中项遍历
            {
                //listView_ngrok.Items.RemoveAt(lvi.Index); // 按索引移除
                listView_ngrok.Items.Remove(lvi);   //按项移除
            }*/
            if(listView_ngrok.SelectedItems.Count > 0)
            {
                listView_ngrok.SelectedItems[0].Remove();
            }
            for (int i = 0; i < listView_ngrok.Items.Count; i++)
            {
                listView_ngrok.Items[i].Text = (i+1).ToString();
            }
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "网络穿透隧道删除成功！" + "\r\n");
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (listView_ngrok.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择需要编辑的项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Form_tunnelEdit tunnelEditForm = new Form_tunnelEdit();
                tunnelEditForm.Owner = this;
                int index = listView_ngrok.SelectedIndices[0];
                tunnelEditForm.tunnelIndex = index;
                tunnelEditForm.textBox_symbol.Text = listView_ngrok.Items[index].SubItems[1].Text;
                tunnelEditForm.comboBox_proto.Text = listView_ngrok.Items[index].SubItems[2].Text;
                if (listView_ngrok.Items[index].SubItems[2].Text == "tcp")
                {
                    tunnelEditForm.textBox_subdomain.Enabled = false;
                }
                else
                {
                    tunnelEditForm.textBox_subdomain.Text = listView_ngrok.Items[index].SubItems[5].Text;
                }
                tunnelEditForm.textBox_localPort.Text = listView_ngrok.Items[index].SubItems[3].Text;
                if(listView_ngrok.Items[index].SubItems[2].Text == "http" || listView_ngrok.Items[index].SubItems[2].Text == "https")
                {
                    tunnelEditForm.textBox_serverPort.Enabled = false;
                }
                else
                {
                    tunnelEditForm.textBox_serverPort.Text = listView_ngrok.Items[index].SubItems[4].Text;
                }
                tunnelEditForm.ShowDialog();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (ngrok.IsExists())
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok穿透功能关闭。" + "\r\n");
                ngrok.Stop();
            }
        }

        private void button_upgradeTest_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在检测升级！ " + "\r\n");
            //simpleUpgrade(textBox_upgradeUrl.Text);
            Updater();
        }

        private void textBox_upgradeUrl_Leave(object sender, EventArgs e)
        {
            autoUpdater.config.ServerUrl = this.textBox_upgradeUrl.Text.ToString();
            autoUpdater.config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "升级地址修改成功！" + "\r\n");
        }

        private void simpleUpgrade(object str)
        {
            // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
            if (textBox_log.InvokeRequired)
            {
                string[] remoteVer = this.getRemoteVer(str.ToString());
                if(remoteVer[0].ToString() == "OK")
                {
                    Action<string> changeVer = delegate (string txt)
                    {
                        this.label_latestVer.Text = txt.ToString();
                    };
                    this.Invoke(changeVer, remoteVer[1].ToString());

                    Action<string> appendText = delegate (string txt)
                    {
                        this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取远程版本信息成功，远程版本: " + txt.ToString() + "\r\n");
                    };
                    this.Invoke(appendText, remoteVer[1].ToString());
                    //this.autoUpdater();
                }
                else if(remoteVer[0].ToString() == "NULL")
                {
                    Action<string> appendText = delegate (string txt)
                    {
                        this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "未发现新版本" + "\r\n");
                    };
                    this.Invoke(appendText, null);
                }
                else
                {
                    Action<string> appendText = delegate (string txt)
                    {
                        this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取远程版本信息出错："+ txt.ToString() + "\r\n");
                    };
                    this.Invoke(appendText, remoteVer[1].ToString());
                }
                
            }
            else
            {
                string[] remoteVer = this.getRemoteVer(str.ToString());
                if (remoteVer[0].ToString() == "OK")
                {
                    this.label_latestVer.Text = remoteVer[1].ToString();
                    this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取远程版本信息成功，远程版本: " + remoteVer[1].ToString() + "\r\n");
                    //this.autoUpdater();
                }
                else if (remoteVer[0].ToString() == "NULL")
                {
                    this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "未发现新版本" + "\r\n");
                }
                else
                {
                    this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取远程版本信息出错：" + remoteVer[1].ToString() + "\r\n");
                }
            }
        }

        private void Updater()
        {
            #region check and download new version program
            bool bHasError = false;
            //IAutoUpdater autoUpdater = new AutoUpdater();
            try
            {
                autoUpdater.Update();
            }
            catch (WebException exp)
            {
                //MessageBox.Show("Can not find the specified resource");
                this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "访问网络出错：" + exp + "\r\n");
                bHasError = true;
            }
            catch (XmlException exp)
            {
                bHasError = true;
                //MessageBox.Show("Download the upgrade file error");
                this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "下载升级文件出错：" + exp + "\r\n");
            }
            catch (NotSupportedException exp)
            {
                bHasError = true;
                //MessageBox.Show("Upgrade address configuration error");
                this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "升级地址设置错误：" + exp + "\r\n");
            }
            catch (ArgumentException exp)
            {
                bHasError = true;
                //MessageBox.Show("Download the upgrade file error");
                this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "下载升级文件出错：" + exp + "\r\n");
            }
            catch (Exception exp)
            {
                bHasError = true;
                //MessageBox.Show("An error occurred during the upgrade process");
                this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "升级过程中发现错误：" + exp + "\r\n");
            }
            finally
            {
                if (bHasError == true)
                {
                    try
                    {
                        autoUpdater.RollBack();
                    }
                    catch (Exception exp)
                    {
                        //Log the message to your file or database
                        this.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "升级回滚出错：" + exp + "\r\n");
                    }
                }
            }
            #endregion
        }

        private void checkBox_silence_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_silence.Checked == true)
            {
                autoUpdater.config.Silence = true;
                autoUpdater.config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置升级过程静默开启！" + "\r\n");
            }
            else
            {
                autoUpdater.config.Silence = false;
                autoUpdater.config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置升级过程静默关闭！" + "\r\n");
            }
        }
    }
}
