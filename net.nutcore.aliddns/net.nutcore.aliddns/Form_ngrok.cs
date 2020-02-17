﻿using System;
using System.Windows.Forms;

namespace net.nutcore.aliddns
{
    public partial class Form_ngrok : Form
    {
        //初始化ngrok操作类
        private NgrokHelper ngrok = new NgrokHelper();
        public Form_ngrok()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            var token = textBox_AuthToken.Text.ToString();
            var server_addr = textBox_serverAddr.Text.ToString();

            var lanhttp = 80;
            int.TryParse(textBox_lanHttp.Text, out lanhttp);
            textBox_lanHttp.Text = lanhttp.ToString();

            var lanhttps = 443;
            int.TryParse(textBox_lanHttps.Text, out lanhttps);
            textBox_lanHttps.Text = lanhttp.ToString();

            var subdomain = textBox_subDomain.Text.ToString();

            var remoteport1 = 2221;
            int.TryParse(textBox_remotePort1.Text, out remoteport1);
            textBox_remotePort1.Text = remoteport1.ToString();
            var lanport1 = 21;
            int.TryParse(textBox_lanPort1.Text, out lanport1);
            textBox_lanPort1.Text = lanport1.ToString();

            var remoteport2 = 2222;
            int.TryParse(textBox_remotePort2.Text, out remoteport2);
            textBox_remotePort2.Text = remoteport2.ToString();
            var lanport2 = 22;
            int.TryParse(textBox_lanPort2.Text, out lanport2);
            textBox_lanPort2.Text = lanport2.ToString();

            var remoteport3 = 33890;
            int.TryParse(textBox_remotePort3.Text, out remoteport3);
            textBox_remotePort3.Text = remoteport3.ToString();
            var lanport3 = 3389;
            int.TryParse(textBox_lanPort3.Text, out lanport3);
            textBox_lanPort3.Text = lanport3.ToString();

            var remoteport4 = 10099;
            int.TryParse(textBox_remotePort4.Text, out remoteport4);
            textBox_remotePort4.Text = remoteport4.ToString();
            var lanport4 = 9000;
            int.TryParse(textBox_lanPort4.Text, out lanport4);
            textBox_lanPort4.Text = lanport4.ToString();

            ngrok.Save(token, server_addr, subdomain, lanhttp, lanhttps, remoteport1, lanport1, remoteport2, lanport2, remoteport3, lanport3, remoteport4, lanport4, false, true, true);
            this.Close();
            this.Dispose();
        }

        private void Form_ngrok_Shown(object sender, EventArgs e)
        {
            //检测ngrok.exe是否存在
            if (!ngrok.IsExists())
            {
                MessageBox.Show("设置在当前目录没有发现ngrok.exe，请往官网下载自行编译。\nNgrok官网：https://ngrok.com/download");
            }
            //读取配置文件
            try
            {
                var config = ngrok.Load();
                textBox_AuthToken.Text = config.authtoken;
                textBox_serverAddr.Text = config.server_addr;
                textBox_subDomain.Text = config.tunnels.website_http.subdomain.ToString();
                textBox_lanHttp.Text = config.tunnels.website_http.proto.http.ToString();
                textBox_lanHttps.Text = config.tunnels.website_http.proto.https.ToString();
                textBox_remotePort1.Text = config.tunnels.tcp1.remote_port.ToString();
                textBox_lanPort1.Text = config.tunnels.tcp1.proto.tcp.ToString();
                textBox_remotePort2.Text = config.tunnels.tcp2.remote_port.ToString();
                textBox_lanPort2.Text = config.tunnels.tcp2.proto.tcp.ToString();
                textBox_remotePort3.Text = config.tunnels.tcp3.remote_port.ToString();
                textBox_lanPort3.Text = config.tunnels.tcp3.proto.tcp.ToString();
                textBox_remotePort4.Text = config.tunnels.tcp4.remote_port.ToString();
                textBox_lanPort4.Text = config.tunnels.tcp4.proto.tcp.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("配置文件ngrok.cfg读取出错！请修改文件内容或者格式，也可以删除错误文件自动生成新文件。","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Dispose();
            }

        }
    }
}
