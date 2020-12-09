namespace net.nutcore.aliddns
{
    partial class Form_tunnelEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_symbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_localPort = new System.Windows.Forms.TextBox();
            this.comboBox_proto = new System.Windows.Forms.ComboBox();
            this.textBox_serverPort = new System.Windows.Forms.TextBox();
            this.textBox_subdomain = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox_tunnel = new System.Windows.Forms.GroupBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox_tunnel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_symbol
            // 
            this.textBox_symbol.Location = new System.Drawing.Point(77, 14);
            this.textBox_symbol.MaxLength = 5;
            this.textBox_symbol.Name = "textBox_symbol";
            this.textBox_symbol.Size = new System.Drawing.Size(87, 21);
            this.textBox_symbol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "英文标识：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "网络协议：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "本地端口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "服务器端口：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "域名：";
            // 
            // textBox_localPort
            // 
            this.textBox_localPort.Location = new System.Drawing.Point(77, 94);
            this.textBox_localPort.MaxLength = 5;
            this.textBox_localPort.Name = "textBox_localPort";
            this.textBox_localPort.Size = new System.Drawing.Size(87, 21);
            this.textBox_localPort.TabIndex = 6;
            // 
            // comboBox_proto
            // 
            this.comboBox_proto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_proto.FormattingEnabled = true;
            this.comboBox_proto.Items.AddRange(new object[] {
            "http",
            "https",
            "tcp"});
            this.comboBox_proto.Location = new System.Drawing.Point(77, 41);
            this.comboBox_proto.Name = "comboBox_proto";
            this.comboBox_proto.Size = new System.Drawing.Size(87, 20);
            this.comboBox_proto.TabIndex = 7;
            this.comboBox_proto.TextChanged += new System.EventHandler(this.comboBox_proto_TextChanged);
            // 
            // textBox_serverPort
            // 
            this.textBox_serverPort.Location = new System.Drawing.Point(77, 121);
            this.textBox_serverPort.MaxLength = 5;
            this.textBox_serverPort.Name = "textBox_serverPort";
            this.textBox_serverPort.Size = new System.Drawing.Size(87, 21);
            this.textBox_serverPort.TabIndex = 8;
            // 
            // textBox_subdomain
            // 
            this.textBox_subdomain.Location = new System.Drawing.Point(77, 67);
            this.textBox_subdomain.MaxLength = 10;
            this.textBox_subdomain.Name = "textBox_subdomain";
            this.textBox_subdomain.Size = new System.Drawing.Size(87, 21);
            this.textBox_subdomain.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "(2-5位)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "(2-10位)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "(1-65535)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "(1-65535)";
            // 
            // groupBox_tunnel
            // 
            this.groupBox_tunnel.Controls.Add(this.label7);
            this.groupBox_tunnel.Controls.Add(this.label9);
            this.groupBox_tunnel.Controls.Add(this.label6);
            this.groupBox_tunnel.Controls.Add(this.label8);
            this.groupBox_tunnel.Controls.Add(this.textBox_subdomain);
            this.groupBox_tunnel.Controls.Add(this.textBox_serverPort);
            this.groupBox_tunnel.Controls.Add(this.comboBox_proto);
            this.groupBox_tunnel.Controls.Add(this.textBox_localPort);
            this.groupBox_tunnel.Controls.Add(this.label5);
            this.groupBox_tunnel.Controls.Add(this.label4);
            this.groupBox_tunnel.Controls.Add(this.label3);
            this.groupBox_tunnel.Controls.Add(this.label2);
            this.groupBox_tunnel.Controls.Add(this.label1);
            this.groupBox_tunnel.Controls.Add(this.textBox_symbol);
            this.groupBox_tunnel.Location = new System.Drawing.Point(5, 7);
            this.groupBox_tunnel.Name = "groupBox_tunnel";
            this.groupBox_tunnel.Size = new System.Drawing.Size(244, 149);
            this.groupBox_tunnel.TabIndex = 14;
            this.groupBox_tunnel.TabStop = false;
            this.groupBox_tunnel.Text = "Tunnel";
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(139, 162);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(58, 25);
            this.button_confirm.TabIndex = 15;
            this.button_confirm.Text = "确定";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(57, 162);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(59, 25);
            this.button_cancel.TabIndex = 16;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_tunnelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 198);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.groupBox_tunnel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::net.nutcore.aliddns.Properties.Resources.alidns;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_tunnelEdit";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.Form_tunnelEdit_Load);
            this.groupBox_tunnel.ResumeLayout(false);
            this.groupBox_tunnel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_symbol;
        public System.Windows.Forms.TextBox textBox_localPort;
        public System.Windows.Forms.ComboBox comboBox_proto;
        public System.Windows.Forms.TextBox textBox_serverPort;
        public System.Windows.Forms.TextBox textBox_subdomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.GroupBox groupBox_tunnel;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_cancel;
    }
}