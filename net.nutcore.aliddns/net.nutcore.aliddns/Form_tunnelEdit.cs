using System;
using System.Windows.Forms;

namespace net.nutcore.aliddns
{
    public partial class Form_tunnelEdit : Form
    {
        public int tunnelIndex;
        public string tunnelMode;
        public Form_tunnelEdit()
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterParent; //在调用本窗体前，需使用tunnel.Owner=this;为本窗体指定Parent
            
        }

        private void Form_tunnelEdit_Load(object sender, EventArgs e)
        {
            

        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (textBox_symbol.Text == "" || comboBox_proto.Text == "" || textBox_localPort.Text == "")
            {
                MessageBox.Show("录入参数出错，请检查录入。\r\n1、英文标识应为2-5位英文\r\n2、网络协议应在http、https、tcp中三选一\r\n3、域名应为2-5位英文\r\n4、当网络协议为tcp时，域名可以为空\r\n5、网络端口应为1-65535之间正整数",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            Form_main mainform = (Form_main)this.Owner;
            mainform.listView_ngrok.BeginUpdate();
            if(tunnelMode == "addNew")
            {
                ListViewItem item = mainform.listView_ngrok.Items.Add((tunnelIndex + 1).ToString());
                item.SubItems.Add(textBox_symbol.Text);
                item.SubItems.Add(comboBox_proto.Text);
                item.SubItems.Add(textBox_localPort.Text);
                item.SubItems.Add(textBox_serverPort.Text);
                item.SubItems.Add(textBox_subdomain.Text);
                item.EnsureVisible();
                mainform.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "网络穿透隧道添加成功！" + "\r\n");
            }
            else
            {
                if (mainform.listView_ngrok.SelectedItems.Count > 0)
                {
                    mainform.listView_ngrok.SelectedItems[0].SubItems[1].Text = textBox_symbol.Text;
                    mainform.listView_ngrok.SelectedItems[0].SubItems[2].Text = comboBox_proto.Text;
                    mainform.listView_ngrok.SelectedItems[0].SubItems[3].Text = textBox_localPort.Text;
                    mainform.listView_ngrok.SelectedItems[0].SubItems[4].Text = textBox_serverPort.Text;
                    mainform.listView_ngrok.SelectedItems[0].SubItems[5].Text = textBox_subdomain.Text;
                    mainform.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "网络穿透隧道修改成功！" + "\r\n");
                }
            }
            mainform.listView_ngrok.EndUpdate();
            this.Dispose();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox_proto_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_proto.Text == "tcp")
            {
                textBox_subdomain.Enabled = false;
                textBox_subdomain.Text = null;
            }
            else
            {
                textBox_subdomain.Enabled = true;
            }

            if (comboBox_proto.Text == "http" || comboBox_proto.Text == "https")
            {
                textBox_serverPort.Enabled = false;
                textBox_serverPort.Text = null;
            }
            else
            {
                textBox_serverPort.Enabled = true;
            }
        }
    }
}
