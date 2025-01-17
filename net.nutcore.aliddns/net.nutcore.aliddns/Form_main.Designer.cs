﻿namespace net.nutcore.aliddns
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.timeSetGroup = new System.Windows.Forms.GroupBox();
            this.checkBox_ngrokExists = new System.Windows.Forms.CheckBox();
            this.checkBox_ngrokAuto = new System.Windows.Forms.CheckBox();
            this.checkBox_logAutoSave = new System.Windows.Forms.CheckBox();
            this.checkBox_minimized = new System.Windows.Forms.CheckBox();
            this.checkBox_autoBoot = new System.Windows.Forms.CheckBox();
            this.debugMessage = new System.Windows.Forms.GroupBox();
            this.label_TTL = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_recordId = new System.Windows.Forms.TextBox();
            this.label_globalValue = new System.Windows.Forms.Label();
            this.label_globalDomainType = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_globalRR = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.globalSetGroup = new System.Windows.Forms.GroupBox();
            this.button_addNewDomain = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_TTL = new System.Windows.Forms.TextBox();
            this.button_ShowHide = new System.Windows.Forms.Button();
            this.button_checkAndSaveConfig = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_fullDomainName = new System.Windows.Forms.TextBox();
            this.textBox_accessKeySecret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_accessKeyId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_newSeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.autoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_checkUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_about = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_netstate = new System.Windows.Forms.GroupBox();
            this.label_DomainIpStatus = new System.Windows.Forms.Label();
            this.label_localIpStatus = new System.Windows.Forms.Label();
            this.label_domainIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_localIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_setWanIp = new System.Windows.Forms.GroupBox();
            this.button_addUrl = new System.Windows.Forms.Button();
            this.maskedTextBox_setIP = new System.Windows.Forms.MaskedTextBox();
            this.button_setIP = new System.Windows.Forms.Button();
            this.comboBox_whatIsUrl = new System.Windows.Forms.ComboBox();
            this.button_whatIsTest = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_ddns = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox_autoUpdate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_nextUpdateSeconds = new System.Windows.Forms.Label();
            this.button_updateNow = new System.Windows.Forms.Button();
            this.tabPage_ngrok = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_AuthToken = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_serverAddr = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_ngrokSave = new System.Windows.Forms.Button();
            this.button_ngrokApply = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_addnew = new System.Windows.Forms.Button();
            this.listView_ngrok = new System.Windows.Forms.ListView();
            this.columnHeader_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_symbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_proto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_lanport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_remoteport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_subdomain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage_other = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_silence = new System.Windows.Forms.CheckBox();
            this.textBox_upgradeUrl = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button_updateTest = new System.Windows.Forms.Button();
            this.checkBox_autoUpgrade = new System.Windows.Forms.CheckBox();
            this.label_latestVer = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label_currentVer = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPage_about = new System.Windows.Forms.TabPage();
            this.textBox_updateInfo = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.timeSetGroup.SuspendLayout();
            this.debugMessage.SuspendLayout();
            this.globalSetGroup.SuspendLayout();
            this.contextMenuStrip_sysTrayMenu.SuspendLayout();
            this.groupBox_netstate.SuspendLayout();
            this.groupBox_setWanIp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_ddns.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage_ngrok.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage_other.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage_about.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeSetGroup
            // 
            this.timeSetGroup.Controls.Add(this.checkBox_ngrokExists);
            this.timeSetGroup.Controls.Add(this.checkBox_ngrokAuto);
            this.timeSetGroup.Controls.Add(this.checkBox_logAutoSave);
            this.timeSetGroup.Controls.Add(this.checkBox_minimized);
            this.timeSetGroup.Controls.Add(this.checkBox_autoBoot);
            this.timeSetGroup.Location = new System.Drawing.Point(4, 4);
            this.timeSetGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeSetGroup.Name = "timeSetGroup";
            this.timeSetGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeSetGroup.Size = new System.Drawing.Size(640, 128);
            this.timeSetGroup.TabIndex = 0;
            this.timeSetGroup.TabStop = false;
            this.timeSetGroup.Text = "启动设置";
            // 
            // checkBox_ngrokExists
            // 
            this.checkBox_ngrokExists.AutoSize = true;
            this.checkBox_ngrokExists.Location = new System.Drawing.Point(14, 94);
            this.checkBox_ngrokExists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_ngrokExists.Name = "checkBox_ngrokExists";
            this.checkBox_ngrokExists.Size = new System.Drawing.Size(223, 22);
            this.checkBox_ngrokExists.TabIndex = 2;
            this.checkBox_ngrokExists.Text = "检测ngrok.exe是否存在";
            this.checkBox_ngrokExists.UseVisualStyleBackColor = true;
            this.checkBox_ngrokExists.CheckedChanged += new System.EventHandler(this.checkBox_ngrokExists_CheckedChanged);
            // 
            // checkBox_ngrokAuto
            // 
            this.checkBox_ngrokAuto.AutoSize = true;
            this.checkBox_ngrokAuto.Location = new System.Drawing.Point(14, 62);
            this.checkBox_ngrokAuto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_ngrokAuto.Name = "checkBox_ngrokAuto";
            this.checkBox_ngrokAuto.Size = new System.Drawing.Size(151, 22);
            this.checkBox_ngrokAuto.TabIndex = 1;
            this.checkBox_ngrokAuto.Text = "自动启动ngrok";
            this.checkBox_ngrokAuto.UseVisualStyleBackColor = true;
            this.checkBox_ngrokAuto.CheckedChanged += new System.EventHandler(this.checkBox_ngrokAuto_CheckedChanged);
            // 
            // checkBox_logAutoSave
            // 
            this.checkBox_logAutoSave.AutoSize = true;
            this.checkBox_logAutoSave.Location = new System.Drawing.Point(387, 62);
            this.checkBox_logAutoSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_logAutoSave.Name = "checkBox_logAutoSave";
            this.checkBox_logAutoSave.Size = new System.Drawing.Size(142, 22);
            this.checkBox_logAutoSave.TabIndex = 4;
            this.checkBox_logAutoSave.Text = "日志自动转储";
            this.checkBox_logAutoSave.UseVisualStyleBackColor = true;
            this.checkBox_logAutoSave.CheckedChanged += new System.EventHandler(this.checkBox_logAutoSave_CheckedChanged);
            // 
            // checkBox_minimized
            // 
            this.checkBox_minimized.AutoSize = true;
            this.checkBox_minimized.Location = new System.Drawing.Point(387, 28);
            this.checkBox_minimized.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_minimized.Name = "checkBox_minimized";
            this.checkBox_minimized.Size = new System.Drawing.Size(142, 22);
            this.checkBox_minimized.TabIndex = 3;
            this.checkBox_minimized.Text = "启动时最小化";
            this.checkBox_minimized.UseVisualStyleBackColor = true;
            this.checkBox_minimized.CheckedChanged += new System.EventHandler(this.checkBox_minimized_CheckedChanged);
            // 
            // checkBox_autoBoot
            // 
            this.checkBox_autoBoot.AutoSize = true;
            this.checkBox_autoBoot.Location = new System.Drawing.Point(14, 28);
            this.checkBox_autoBoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_autoBoot.Name = "checkBox_autoBoot";
            this.checkBox_autoBoot.Size = new System.Drawing.Size(196, 22);
            this.checkBox_autoBoot.TabIndex = 0;
            this.checkBox_autoBoot.Text = "随系统启动自动运行";
            this.checkBox_autoBoot.UseVisualStyleBackColor = true;
            this.checkBox_autoBoot.CheckedChanged += new System.EventHandler(this.checkBox_autoBoot_CheckedChanged);
            // 
            // debugMessage
            // 
            this.debugMessage.Controls.Add(this.label_TTL);
            this.debugMessage.Controls.Add(this.label15);
            this.debugMessage.Controls.Add(this.textBox_recordId);
            this.debugMessage.Controls.Add(this.label_globalValue);
            this.debugMessage.Controls.Add(this.label_globalDomainType);
            this.debugMessage.Controls.Add(this.label12);
            this.debugMessage.Controls.Add(this.label11);
            this.debugMessage.Controls.Add(this.label_globalRR);
            this.debugMessage.Controls.Add(this.label10);
            this.debugMessage.Controls.Add(this.label9);
            this.debugMessage.Location = new System.Drawing.Point(320, 69);
            this.debugMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.debugMessage.Name = "debugMessage";
            this.debugMessage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.debugMessage.Size = new System.Drawing.Size(324, 118);
            this.debugMessage.TabIndex = 3;
            this.debugMessage.TabStop = false;
            this.debugMessage.Text = "调试信息";
            // 
            // label_TTL
            // 
            this.label_TTL.AutoSize = true;
            this.label_TTL.Location = new System.Drawing.Point(236, 66);
            this.label_TTL.Name = "label_TTL";
            this.label_TTL.Size = new System.Drawing.Size(62, 18);
            this.label_TTL.TabIndex = 7;
            this.label_TTL.Text = "<null>";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 18);
            this.label15.TabIndex = 6;
            this.label15.Text = "TTL:";
            // 
            // textBox_recordId
            // 
            this.textBox_recordId.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_recordId.Location = new System.Drawing.Point(102, 27);
            this.textBox_recordId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_recordId.Name = "textBox_recordId";
            this.textBox_recordId.ReadOnly = true;
            this.textBox_recordId.Size = new System.Drawing.Size(172, 28);
            this.textBox_recordId.TabIndex = 1;
            this.textBox_recordId.Text = "<null>";
            // 
            // label_globalValue
            // 
            this.label_globalValue.AutoSize = true;
            this.label_globalValue.Location = new System.Drawing.Point(68, 94);
            this.label_globalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_globalValue.Name = "label_globalValue";
            this.label_globalValue.Size = new System.Drawing.Size(62, 18);
            this.label_globalValue.TabIndex = 9;
            this.label_globalValue.Text = "<null>";
            // 
            // label_globalDomainType
            // 
            this.label_globalDomainType.AutoSize = true;
            this.label_globalDomainType.Location = new System.Drawing.Point(144, 66);
            this.label_globalDomainType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_globalDomainType.Name = "label_globalDomainType";
            this.label_globalDomainType.Size = new System.Drawing.Size(62, 18);
            this.label_globalDomainType.TabIndex = 5;
            this.label_globalDomainType.Text = "<null>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 93);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 8;
            this.label12.Text = "Value:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 66);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "Type:";
            // 
            // label_globalRR
            // 
            this.label_globalRR.AutoSize = true;
            this.label_globalRR.Location = new System.Drawing.Point(39, 66);
            this.label_globalRR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_globalRR.Name = "label_globalRR";
            this.label_globalRR.Size = new System.Drawing.Size(62, 18);
            this.label_globalRR.TabIndex = 3;
            this.label_globalRR.Text = "<null>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 66);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "RR:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "RecordId";
            // 
            // globalSetGroup
            // 
            this.globalSetGroup.Controls.Add(this.button_addNewDomain);
            this.globalSetGroup.Controls.Add(this.label13);
            this.globalSetGroup.Controls.Add(this.textBox_TTL);
            this.globalSetGroup.Controls.Add(this.button_ShowHide);
            this.globalSetGroup.Controls.Add(this.button_checkAndSaveConfig);
            this.globalSetGroup.Controls.Add(this.label6);
            this.globalSetGroup.Controls.Add(this.textBox_fullDomainName);
            this.globalSetGroup.Controls.Add(this.textBox_accessKeySecret);
            this.globalSetGroup.Controls.Add(this.label5);
            this.globalSetGroup.Controls.Add(this.textBox_accessKeyId);
            this.globalSetGroup.Controls.Add(this.label4);
            this.globalSetGroup.Location = new System.Drawing.Point(320, 194);
            this.globalSetGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.globalSetGroup.Name = "globalSetGroup";
            this.globalSetGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.globalSetGroup.Size = new System.Drawing.Size(324, 218);
            this.globalSetGroup.TabIndex = 4;
            this.globalSetGroup.TabStop = false;
            this.globalSetGroup.Text = "阿里云账号";
            // 
            // button_addNewDomain
            // 
            this.button_addNewDomain.Location = new System.Drawing.Point(218, 178);
            this.button_addNewDomain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_addNewDomain.Name = "button_addNewDomain";
            this.button_addNewDomain.Size = new System.Drawing.Size(98, 34);
            this.button_addNewDomain.TabIndex = 10;
            this.button_addNewDomain.Text = "添加域名";
            this.button_addNewDomain.UseVisualStyleBackColor = true;
            this.button_addNewDomain.Click += new System.EventHandler(this.button_addNewDomain_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 18);
            this.label13.TabIndex = 6;
            this.label13.Text = "TTL(秒)";
            // 
            // textBox_TTL
            // 
            this.textBox_TTL.Location = new System.Drawing.Point(98, 142);
            this.textBox_TTL.Name = "textBox_TTL";
            this.textBox_TTL.Size = new System.Drawing.Size(54, 28);
            this.textBox_TTL.TabIndex = 7;
            this.textBox_TTL.Text = "600";
            this.textBox_TTL.Leave += new System.EventHandler(this.textBox_TTL_Leave);
            // 
            // button_ShowHide
            // 
            this.button_ShowHide.Location = new System.Drawing.Point(112, 178);
            this.button_ShowHide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ShowHide.Name = "button_ShowHide";
            this.button_ShowHide.Size = new System.Drawing.Size(98, 34);
            this.button_ShowHide.TabIndex = 9;
            this.button_ShowHide.Text = "显示录入";
            this.button_ShowHide.UseVisualStyleBackColor = true;
            this.button_ShowHide.Click += new System.EventHandler(this.button_ShowHide_Click);
            // 
            // button_checkAndSaveConfig
            // 
            this.button_checkAndSaveConfig.Location = new System.Drawing.Point(8, 178);
            this.button_checkAndSaveConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_checkAndSaveConfig.Name = "button_checkAndSaveConfig";
            this.button_checkAndSaveConfig.Size = new System.Drawing.Size(98, 34);
            this.button_checkAndSaveConfig.TabIndex = 8;
            this.button_checkAndSaveConfig.Text = "测试连接";
            this.button_checkAndSaveConfig.UseVisualStyleBackColor = true;
            this.button_checkAndSaveConfig.Click += new System.EventHandler(this.checkConfig_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "完整域名";
            // 
            // textBox_fullDomainName
            // 
            this.textBox_fullDomainName.Location = new System.Drawing.Point(98, 104);
            this.textBox_fullDomainName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_fullDomainName.Name = "textBox_fullDomainName";
            this.textBox_fullDomainName.Size = new System.Drawing.Size(216, 28);
            this.textBox_fullDomainName.TabIndex = 5;
            this.textBox_fullDomainName.Text = "www.xxx.com";
            this.textBox_fullDomainName.Leave += new System.EventHandler(this.fullDomainName_Leave);
            // 
            // textBox_accessKeySecret
            // 
            this.textBox_accessKeySecret.Location = new System.Drawing.Point(98, 64);
            this.textBox_accessKeySecret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_accessKeySecret.Name = "textBox_accessKeySecret";
            this.textBox_accessKeySecret.PasswordChar = '*';
            this.textBox_accessKeySecret.Size = new System.Drawing.Size(216, 28);
            this.textBox_accessKeySecret.TabIndex = 3;
            this.textBox_accessKeySecret.Text = "null";
            this.textBox_accessKeySecret.Leave += new System.EventHandler(this.accessKeySecret_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "KeySecret";
            // 
            // textBox_accessKeyId
            // 
            this.textBox_accessKeyId.Location = new System.Drawing.Point(64, 24);
            this.textBox_accessKeyId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_accessKeyId.Name = "textBox_accessKeyId";
            this.textBox_accessKeyId.PasswordChar = '*';
            this.textBox_accessKeyId.Size = new System.Drawing.Size(248, 28);
            this.textBox_accessKeyId.TabIndex = 1;
            this.textBox_accessKeyId.Text = "null";
            this.textBox_accessKeyId.Leave += new System.EventHandler(this.accessKeyId_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "KeyId";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "秒更新一次";
            // 
            // textBox_newSeconds
            // 
            this.textBox_newSeconds.Location = new System.Drawing.Point(60, 27);
            this.textBox_newSeconds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_newSeconds.Name = "textBox_newSeconds";
            this.textBox_newSeconds.Size = new System.Drawing.Size(88, 28);
            this.textBox_newSeconds.TabIndex = 1;
            this.textBox_newSeconds.Text = "60";
            this.textBox_newSeconds.Leave += new System.EventHandler(this.newSeconds_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "每隔";
            // 
            // autoUpdateTimer
            // 
            this.autoUpdateTimer.Enabled = true;
            this.autoUpdateTimer.Interval = 1000;
            this.autoUpdateTimer.Tick += new System.EventHandler(this.autoUpdateTimer_Tick);
            // 
            // notifyIcon_sysTray
            // 
            this.notifyIcon_sysTray.ContextMenuStrip = this.contextMenuStrip_sysTrayMenu;
            this.notifyIcon_sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_sysTray.Icon")));
            this.notifyIcon_sysTray.Text = "AliDDNS Tray";
            this.notifyIcon_sysTray.Visible = true;
            this.notifyIcon_sysTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_sysTray_MouseDoubleClick);
            // 
            // contextMenuStrip_sysTrayMenu
            // 
            this.contextMenuStrip_sysTrayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Exit,
            this.ToolStripMenuItem_checkUpgrade,
            this.ToolStripMenuItem_about});
            this.contextMenuStrip_sysTrayMenu.Name = "contextMenuStrip1";
            this.contextMenuStrip_sysTrayMenu.Size = new System.Drawing.Size(153, 94);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_Exit.Text = "退出";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Quit_Click);
            // 
            // ToolStripMenuItem_checkUpgrade
            // 
            this.ToolStripMenuItem_checkUpgrade.Name = "ToolStripMenuItem_checkUpgrade";
            this.ToolStripMenuItem_checkUpgrade.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_checkUpgrade.Text = "检查升级";
            this.ToolStripMenuItem_checkUpgrade.Click += new System.EventHandler(this.ToolStripMenuItem_checkUpgrade_Click);
            // 
            // ToolStripMenuItem_about
            // 
            this.ToolStripMenuItem_about.Name = "ToolStripMenuItem_about";
            this.ToolStripMenuItem_about.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_about.Text = "关于";
            this.ToolStripMenuItem_about.Click += new System.EventHandler(this.ToolStripMenuItem_about_Click);
            // 
            // groupBox_netstate
            // 
            this.groupBox_netstate.Controls.Add(this.label_DomainIpStatus);
            this.groupBox_netstate.Controls.Add(this.label_localIpStatus);
            this.groupBox_netstate.Controls.Add(this.label_domainIP);
            this.groupBox_netstate.Controls.Add(this.label2);
            this.groupBox_netstate.Controls.Add(this.label_localIP);
            this.groupBox_netstate.Controls.Add(this.label1);
            this.groupBox_netstate.Location = new System.Drawing.Point(9, 9);
            this.groupBox_netstate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_netstate.Name = "groupBox_netstate";
            this.groupBox_netstate.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_netstate.Size = new System.Drawing.Size(634, 57);
            this.groupBox_netstate.TabIndex = 0;
            this.groupBox_netstate.TabStop = false;
            this.groupBox_netstate.Text = "网络状态";
            // 
            // label_DomainIpStatus
            // 
            this.label_DomainIpStatus.AutoSize = true;
            this.label_DomainIpStatus.ForeColor = System.Drawing.Color.Red;
            this.label_DomainIpStatus.Location = new System.Drawing.Point(556, 28);
            this.label_DomainIpStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DomainIpStatus.Name = "label_DomainIpStatus";
            this.label_DomainIpStatus.Size = new System.Drawing.Size(62, 18);
            this.label_DomainIpStatus.TabIndex = 5;
            this.label_DomainIpStatus.Text = "未绑定";
            // 
            // label_localIpStatus
            // 
            this.label_localIpStatus.AutoSize = true;
            this.label_localIpStatus.ForeColor = System.Drawing.Color.Red;
            this.label_localIpStatus.Location = new System.Drawing.Point(234, 28);
            this.label_localIpStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_localIpStatus.Name = "label_localIpStatus";
            this.label_localIpStatus.Size = new System.Drawing.Size(62, 18);
            this.label_localIpStatus.TabIndex = 2;
            this.label_localIpStatus.Text = "未连接";
            // 
            // label_domainIP
            // 
            this.label_domainIP.AutoSize = true;
            this.label_domainIP.Location = new System.Drawing.Point(396, 28);
            this.label_domainIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_domainIP.Name = "label_domainIP";
            this.label_domainIP.Size = new System.Drawing.Size(71, 18);
            this.label_domainIP.TabIndex = 4;
            this.label_domainIP.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "域名IP:";
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Location = new System.Drawing.Point(86, 28);
            this.label_localIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(71, 18);
            this.label_localIP.TabIndex = 1;
            this.label_localIP.Text = "0.0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "WAN口IP:";
            // 
            // groupBox_setWanIp
            // 
            this.groupBox_setWanIp.Controls.Add(this.button_addUrl);
            this.groupBox_setWanIp.Controls.Add(this.maskedTextBox_setIP);
            this.groupBox_setWanIp.Controls.Add(this.button_setIP);
            this.groupBox_setWanIp.Controls.Add(this.comboBox_whatIsUrl);
            this.groupBox_setWanIp.Controls.Add(this.button_whatIsTest);
            this.groupBox_setWanIp.Controls.Add(this.label14);
            this.groupBox_setWanIp.Location = new System.Drawing.Point(9, 69);
            this.groupBox_setWanIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_setWanIp.Name = "groupBox_setWanIp";
            this.groupBox_setWanIp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_setWanIp.Size = new System.Drawing.Size(302, 202);
            this.groupBox_setWanIp.TabIndex = 1;
            this.groupBox_setWanIp.TabStop = false;
            this.groupBox_setWanIp.Text = "WAN口IP设置";
            // 
            // button_addUrl
            // 
            this.button_addUrl.Location = new System.Drawing.Point(158, 99);
            this.button_addUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_addUrl.Name = "button_addUrl";
            this.button_addUrl.Size = new System.Drawing.Size(135, 34);
            this.button_addUrl.TabIndex = 3;
            this.button_addUrl.Text = "添加网址";
            this.button_addUrl.UseVisualStyleBackColor = true;
            this.button_addUrl.Click += new System.EventHandler(this.button_addUrl_Click);
            // 
            // maskedTextBox_setIP
            // 
            this.maskedTextBox_setIP.Location = new System.Drawing.Point(10, 150);
            this.maskedTextBox_setIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBox_setIP.Mask = "000.000.000.000";
            this.maskedTextBox_setIP.Name = "maskedTextBox_setIP";
            this.maskedTextBox_setIP.PromptChar = ' ';
            this.maskedTextBox_setIP.Size = new System.Drawing.Size(157, 28);
            this.maskedTextBox_setIP.TabIndex = 4;
            // 
            // button_setIP
            // 
            this.button_setIP.Location = new System.Drawing.Point(178, 148);
            this.button_setIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_setIP.Name = "button_setIP";
            this.button_setIP.Size = new System.Drawing.Size(114, 34);
            this.button_setIP.TabIndex = 5;
            this.button_setIP.Text = "手工指定IP";
            this.button_setIP.UseVisualStyleBackColor = true;
            this.button_setIP.Click += new System.EventHandler(this.button_setIP_Click);
            // 
            // comboBox_whatIsUrl
            // 
            this.comboBox_whatIsUrl.FormattingEnabled = true;
            this.comboBox_whatIsUrl.Location = new System.Drawing.Point(9, 62);
            this.comboBox_whatIsUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_whatIsUrl.Name = "comboBox_whatIsUrl";
            this.comboBox_whatIsUrl.Size = new System.Drawing.Size(282, 26);
            this.comboBox_whatIsUrl.TabIndex = 1;
            this.comboBox_whatIsUrl.Leave += new System.EventHandler(this.comboBox_whatIsUrl_Leave);
            // 
            // button_whatIsTest
            // 
            this.button_whatIsTest.Location = new System.Drawing.Point(9, 99);
            this.button_whatIsTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_whatIsTest.Name = "button_whatIsTest";
            this.button_whatIsTest.Size = new System.Drawing.Size(135, 34);
            this.button_whatIsTest.TabIndex = 2;
            this.button_whatIsTest.Text = "获取WAN口IP";
            this.button_whatIsTest.UseVisualStyleBackColor = true;
            this.button_whatIsTest.Click += new System.EventHandler(this.button_whatIsTest_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 33);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "查询网址:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_ddns);
            this.tabControl1.Controls.Add(this.tabPage_ngrok);
            this.tabControl1.Controls.Add(this.tabPage_other);
            this.tabControl1.Controls.Add(this.tabPage_about);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 454);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_ddns
            // 
            this.tabPage_ddns.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_ddns.Controls.Add(this.groupBox6);
            this.tabPage_ddns.Controls.Add(this.groupBox_netstate);
            this.tabPage_ddns.Controls.Add(this.debugMessage);
            this.tabPage_ddns.Controls.Add(this.groupBox_setWanIp);
            this.tabPage_ddns.Controls.Add(this.globalSetGroup);
            this.tabPage_ddns.Location = new System.Drawing.Point(4, 28);
            this.tabPage_ddns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_ddns.Name = "tabPage_ddns";
            this.tabPage_ddns.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_ddns.Size = new System.Drawing.Size(654, 422);
            this.tabPage_ddns.TabIndex = 0;
            this.tabPage_ddns.Text = "DDNS";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox_autoUpdate);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label_nextUpdateSeconds);
            this.groupBox6.Controls.Add(this.button_updateNow);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.textBox_newSeconds);
            this.groupBox6.Location = new System.Drawing.Point(9, 278);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(300, 134);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "更新设置";
            // 
            // checkBox_autoUpdate
            // 
            this.checkBox_autoUpdate.AutoSize = true;
            this.checkBox_autoUpdate.Location = new System.Drawing.Point(10, 64);
            this.checkBox_autoUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_autoUpdate.Name = "checkBox_autoUpdate";
            this.checkBox_autoUpdate.Size = new System.Drawing.Size(106, 22);
            this.checkBox_autoUpdate.TabIndex = 3;
            this.checkBox_autoUpdate.Text = "自动更新";
            this.checkBox_autoUpdate.UseVisualStyleBackColor = true;
            this.checkBox_autoUpdate.CheckedChanged += new System.EventHandler(this.checkBox_autoUpdate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "秒后更新记录";
            // 
            // label_nextUpdateSeconds
            // 
            this.label_nextUpdateSeconds.ForeColor = System.Drawing.Color.Red;
            this.label_nextUpdateSeconds.Location = new System.Drawing.Point(126, 66);
            this.label_nextUpdateSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nextUpdateSeconds.Name = "label_nextUpdateSeconds";
            this.label_nextUpdateSeconds.Size = new System.Drawing.Size(45, 18);
            this.label_nextUpdateSeconds.TabIndex = 4;
            this.label_nextUpdateSeconds.Text = "60";
            this.label_nextUpdateSeconds.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button_updateNow
            // 
            this.button_updateNow.Location = new System.Drawing.Point(9, 93);
            this.button_updateNow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_updateNow.Name = "button_updateNow";
            this.button_updateNow.Size = new System.Drawing.Size(278, 34);
            this.button_updateNow.TabIndex = 6;
            this.button_updateNow.Text = "立即更新";
            this.button_updateNow.UseVisualStyleBackColor = true;
            this.button_updateNow.Click += new System.EventHandler(this.updateNow_Click);
            // 
            // tabPage_ngrok
            // 
            this.tabPage_ngrok.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_ngrok.Controls.Add(this.button2);
            this.tabPage_ngrok.Controls.Add(this.groupBox1);
            this.tabPage_ngrok.Controls.Add(this.button1);
            this.tabPage_ngrok.Controls.Add(this.groupBox2);
            this.tabPage_ngrok.Controls.Add(this.groupBox3);
            this.tabPage_ngrok.Location = new System.Drawing.Point(4, 28);
            this.tabPage_ngrok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_ngrok.Name = "tabPage_ngrok";
            this.tabPage_ngrok.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_ngrok.Size = new System.Drawing.Size(654, 422);
            this.tabPage_ngrok.TabIndex = 1;
            this.tabPage_ngrok.Text = "NGROK";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 486);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_AuthToken);
            this.groupBox1.Location = new System.Drawing.Point(357, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(284, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "认证令牌";
            // 
            // textBox_AuthToken
            // 
            this.textBox_AuthToken.Location = new System.Drawing.Point(16, 27);
            this.textBox_AuthToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_AuthToken.Name = "textBox_AuthToken";
            this.textBox_AuthToken.Size = new System.Drawing.Size(256, 28);
            this.textBox_AuthToken.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 486);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_serverAddr);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(339, 72);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务端Ngrokd";
            // 
            // textBox_serverAddr
            // 
            this.textBox_serverAddr.Location = new System.Drawing.Point(75, 27);
            this.textBox_serverAddr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_serverAddr.Name = "textBox_serverAddr";
            this.textBox_serverAddr.Size = new System.Drawing.Size(252, 28);
            this.textBox_serverAddr.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 32);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "地址:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_stop);
            this.groupBox3.Controls.Add(this.button_edit);
            this.groupBox3.Controls.Add(this.button_ngrokSave);
            this.groupBox3.Controls.Add(this.button_ngrokApply);
            this.groupBox3.Controls.Add(this.button_delete);
            this.groupBox3.Controls.Add(this.button_addnew);
            this.groupBox3.Controls.Add(this.listView_ngrok);
            this.groupBox3.Location = new System.Drawing.Point(9, 90);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(632, 316);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "内网端Ngrok";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(540, 270);
            this.button_stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(82, 38);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "停止";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(540, 76);
            this.button_edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(82, 36);
            this.button_edit.TabIndex = 2;
            this.button_edit.Text = "编辑";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_ngrokSave
            // 
            this.button_ngrokSave.Location = new System.Drawing.Point(540, 168);
            this.button_ngrokSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ngrokSave.Name = "button_ngrokSave";
            this.button_ngrokSave.Size = new System.Drawing.Size(82, 38);
            this.button_ngrokSave.TabIndex = 4;
            this.button_ngrokSave.Text = "保存";
            this.button_ngrokSave.UseVisualStyleBackColor = true;
            this.button_ngrokSave.Click += new System.EventHandler(this.button_ngrokSave_Click);
            // 
            // button_ngrokApply
            // 
            this.button_ngrokApply.Location = new System.Drawing.Point(540, 224);
            this.button_ngrokApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ngrokApply.Name = "button_ngrokApply";
            this.button_ngrokApply.Size = new System.Drawing.Size(82, 38);
            this.button_ngrokApply.TabIndex = 5;
            this.button_ngrokApply.Text = "启动";
            this.button_ngrokApply.UseVisualStyleBackColor = true;
            this.button_ngrokApply.Click += new System.EventHandler(this.button_ngrokApply_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(540, 122);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(82, 38);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_addnew
            // 
            this.button_addnew.Location = new System.Drawing.Point(540, 30);
            this.button_addnew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_addnew.Name = "button_addnew";
            this.button_addnew.Size = new System.Drawing.Size(82, 38);
            this.button_addnew.TabIndex = 1;
            this.button_addnew.Text = "增加";
            this.button_addnew.UseVisualStyleBackColor = true;
            this.button_addnew.Click += new System.EventHandler(this.button_addnew_Click);
            // 
            // listView_ngrok
            // 
            this.listView_ngrok.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_id,
            this.columnHeader_symbol,
            this.columnHeader_proto,
            this.columnHeader_lanport,
            this.columnHeader_remoteport,
            this.columnHeader_subdomain});
            this.listView_ngrok.FullRowSelect = true;
            this.listView_ngrok.GridLines = true;
            this.listView_ngrok.HideSelection = false;
            this.listView_ngrok.Location = new System.Drawing.Point(9, 30);
            this.listView_ngrok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView_ngrok.Name = "listView_ngrok";
            this.listView_ngrok.Size = new System.Drawing.Size(520, 276);
            this.listView_ngrok.TabIndex = 0;
            this.listView_ngrok.UseCompatibleStateImageBehavior = false;
            this.listView_ngrok.View = System.Windows.Forms.View.Details;
            this.listView_ngrok.DoubleClick += new System.EventHandler(this.button_edit_Click);
            // 
            // columnHeader_id
            // 
            this.columnHeader_id.Text = "序号";
            this.columnHeader_id.Width = 36;
            // 
            // columnHeader_symbol
            // 
            this.columnHeader_symbol.Text = "英文标识";
            this.columnHeader_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_proto
            // 
            this.columnHeader_proto.Text = "协议";
            this.columnHeader_proto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_proto.Width = 50;
            // 
            // columnHeader_lanport
            // 
            this.columnHeader_lanport.Text = "内网端口";
            this.columnHeader_lanport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_remoteport
            // 
            this.columnHeader_remoteport.Text = "服务器端口";
            this.columnHeader_remoteport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_remoteport.Width = 72;
            // 
            // columnHeader_subdomain
            // 
            this.columnHeader_subdomain.Text = "域名";
            this.columnHeader_subdomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_subdomain.Width = 72;
            // 
            // tabPage_other
            // 
            this.tabPage_other.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_other.Controls.Add(this.groupBox4);
            this.tabPage_other.Controls.Add(this.timeSetGroup);
            this.tabPage_other.Location = new System.Drawing.Point(4, 28);
            this.tabPage_other.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_other.Name = "tabPage_other";
            this.tabPage_other.Size = new System.Drawing.Size(654, 422);
            this.tabPage_other.TabIndex = 2;
            this.tabPage_other.Text = "其它";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_silence);
            this.groupBox4.Controls.Add(this.textBox_upgradeUrl);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.button_updateTest);
            this.groupBox4.Controls.Add(this.checkBox_autoUpgrade);
            this.groupBox4.Controls.Add(this.label_latestVer);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label_currentVer);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Location = new System.Drawing.Point(4, 141);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(640, 148);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "升级设置";
            // 
            // checkBox_silence
            // 
            this.checkBox_silence.AutoSize = true;
            this.checkBox_silence.Location = new System.Drawing.Point(387, 30);
            this.checkBox_silence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_silence.Name = "checkBox_silence";
            this.checkBox_silence.Size = new System.Drawing.Size(142, 22);
            this.checkBox_silence.TabIndex = 8;
            this.checkBox_silence.Text = "升级静默完成";
            this.checkBox_silence.UseVisualStyleBackColor = true;
            this.checkBox_silence.CheckedChanged += new System.EventHandler(this.checkBox_silence_CheckedChanged);
            // 
            // textBox_upgradeUrl
            // 
            this.textBox_upgradeUrl.Location = new System.Drawing.Point(72, 66);
            this.textBox_upgradeUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_upgradeUrl.Name = "textBox_upgradeUrl";
            this.textBox_upgradeUrl.Size = new System.Drawing.Size(289, 28);
            this.textBox_upgradeUrl.TabIndex = 7;
            this.textBox_upgradeUrl.Leave += new System.EventHandler(this.textBox_upgradeUrl_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 70);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 18);
            this.label17.TabIndex = 6;
            this.label17.Text = "地址:";
            // 
            // button_updateTest
            // 
            this.button_updateTest.Location = new System.Drawing.Point(387, 63);
            this.button_updateTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_updateTest.Name = "button_updateTest";
            this.button_updateTest.Size = new System.Drawing.Size(144, 38);
            this.button_updateTest.TabIndex = 5;
            this.button_updateTest.Text = "立即检测升级";
            this.button_updateTest.UseVisualStyleBackColor = true;
            this.button_updateTest.Click += new System.EventHandler(this.button_upgradeTest_Click);
            // 
            // checkBox_autoUpgrade
            // 
            this.checkBox_autoUpgrade.AutoSize = true;
            this.checkBox_autoUpgrade.Location = new System.Drawing.Point(14, 30);
            this.checkBox_autoUpgrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_autoUpgrade.Name = "checkBox_autoUpgrade";
            this.checkBox_autoUpgrade.Size = new System.Drawing.Size(160, 22);
            this.checkBox_autoUpgrade.TabIndex = 4;
            this.checkBox_autoUpgrade.Text = "自动检测新版本";
            this.checkBox_autoUpgrade.UseVisualStyleBackColor = true;
            this.checkBox_autoUpgrade.CheckedChanged += new System.EventHandler(this.checkBox_autoUpgrade_CheckedChanged);
            // 
            // label_latestVer
            // 
            this.label_latestVer.AutoSize = true;
            this.label_latestVer.Location = new System.Drawing.Point(320, 116);
            this.label_latestVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_latestVer.Name = "label_latestVer";
            this.label_latestVer.Size = new System.Drawing.Size(71, 18);
            this.label_latestVer.TabIndex = 3;
            this.label_latestVer.Text = "0.0.0.0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(222, 116);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(89, 18);
            this.label28.TabIndex = 2;
            this.label28.Text = "远程版本:";
            // 
            // label_currentVer
            // 
            this.label_currentVer.AutoSize = true;
            this.label_currentVer.Location = new System.Drawing.Point(108, 116);
            this.label_currentVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_currentVer.Name = "label_currentVer";
            this.label_currentVer.Size = new System.Drawing.Size(71, 18);
            this.label_currentVer.TabIndex = 1;
            this.label_currentVer.Text = "0.0.0.0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(10, 116);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 18);
            this.label30.TabIndex = 0;
            this.label30.Text = "本地版本:";
            // 
            // tabPage_about
            // 
            this.tabPage_about.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_about.Controls.Add(this.textBox_updateInfo);
            this.tabPage_about.Controls.Add(this.groupBox5);
            this.tabPage_about.Location = new System.Drawing.Point(4, 28);
            this.tabPage_about.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage_about.Name = "tabPage_about";
            this.tabPage_about.Size = new System.Drawing.Size(654, 422);
            this.tabPage_about.TabIndex = 3;
            this.tabPage_about.Text = "关于";
            // 
            // textBox_updateInfo
            // 
            this.textBox_updateInfo.Location = new System.Drawing.Point(4, 75);
            this.textBox_updateInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_updateInfo.Multiline = true;
            this.textBox_updateInfo.Name = "textBox_updateInfo";
            this.textBox_updateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_updateInfo.Size = new System.Drawing.Size(638, 314);
            this.textBox_updateInfo.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.linkLabel2);
            this.groupBox5.Location = new System.Drawing.Point(4, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(640, 62);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "著作信息";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 26);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(143, 18);
            this.label31.TabIndex = 0;
            this.label31.Text = "本程序发布地址:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(160, 26);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(188, 18);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "AliDDNS 3.0 之后版本";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_log.Location = new System.Drawing.Point(6, 465);
            this.textBox_log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(654, 142);
            this.textBox_log.TabIndex = 12;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 627);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_main";
            this.Text = "AliDDNS Sancaros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.Shown += new System.EventHandler(this.Form_main_Shown);
            this.timeSetGroup.ResumeLayout(false);
            this.timeSetGroup.PerformLayout();
            this.debugMessage.ResumeLayout(false);
            this.debugMessage.PerformLayout();
            this.globalSetGroup.ResumeLayout(false);
            this.globalSetGroup.PerformLayout();
            this.contextMenuStrip_sysTrayMenu.ResumeLayout(false);
            this.groupBox_netstate.ResumeLayout(false);
            this.groupBox_netstate.PerformLayout();
            this.groupBox_setWanIp.ResumeLayout(false);
            this.groupBox_setWanIp.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_ddns.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage_ngrok.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage_other.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage_about.ResumeLayout(false);
            this.tabPage_about.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox timeSetGroup;
        private System.Windows.Forms.GroupBox debugMessage;
        private System.Windows.Forms.GroupBox globalSetGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_newSeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_fullDomainName;
        private System.Windows.Forms.TextBox textBox_accessKeySecret;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_accessKeyId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer autoUpdateTimer;
        private System.Windows.Forms.Button button_checkAndSaveConfig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_globalRR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_globalDomainType;
        private System.Windows.Forms.Label label_globalValue;
        private System.Windows.Forms.TextBox textBox_recordId;
        private System.Windows.Forms.NotifyIcon notifyIcon_sysTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.GroupBox groupBox_netstate;
        private System.Windows.Forms.Label label_DomainIpStatus;
        private System.Windows.Forms.Label label_localIpStatus;
        private System.Windows.Forms.Label label_domainIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_localIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ShowHide;
        private System.Windows.Forms.CheckBox checkBox_autoBoot;
        private System.Windows.Forms.CheckBox checkBox_minimized;
        private System.Windows.Forms.CheckBox checkBox_logAutoSave;
        private System.Windows.Forms.GroupBox groupBox_setWanIp;
        private System.Windows.Forms.ComboBox comboBox_whatIsUrl;
        private System.Windows.Forms.Button button_whatIsTest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_setIP;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_setIP;
        private System.Windows.Forms.Label label_TTL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_TTL;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_checkUpgrade;
        private System.Windows.Forms.CheckBox checkBox_ngrokAuto;
        private System.Windows.Forms.Button button_addNewDomain;
        private System.Windows.Forms.Button button_addUrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_ddns;
        private System.Windows.Forms.TabPage tabPage_ngrok;
        private System.Windows.Forms.TabPage tabPage_other;
        private System.Windows.Forms.TabPage tabPage_about;
        public System.Windows.Forms.ListView listView_ngrok;
        private System.Windows.Forms.ColumnHeader columnHeader_id;
        private System.Windows.Forms.ColumnHeader columnHeader_subdomain;
        private System.Windows.Forms.ColumnHeader columnHeader_proto;
        private System.Windows.Forms.ColumnHeader columnHeader_remoteport;
        private System.Windows.Forms.ColumnHeader columnHeader_lanport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_AuthToken;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_serverAddr;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_updateInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox_autoUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_nextUpdateSeconds;
        private System.Windows.Forms.Button button_updateNow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_autoUpgrade;
        private System.Windows.Forms.Label label_latestVer;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label_currentVer;
        private System.Windows.Forms.Label label30;
        public System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_addnew;
        private System.Windows.Forms.ColumnHeader columnHeader_symbol;
        private System.Windows.Forms.Button button_ngrokApply;
        private System.Windows.Forms.Button button_ngrokSave;
        private System.Windows.Forms.CheckBox checkBox_ngrokExists;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.TextBox textBox_upgradeUrl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_updateTest;
        private System.Windows.Forms.CheckBox checkBox_silence;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_about;
    }
}

