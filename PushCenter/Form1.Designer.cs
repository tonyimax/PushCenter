namespace PushCenter
{
    partial class Form1
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
            this.btnPush = new System.Windows.Forms.Button();
            this.lab_Title = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmb_PushPlatform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_PushTarget = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeviceTabHost = new System.Windows.Forms.TabControl();
            this.tabPageAndroid = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageIOS = new System.Windows.Forms.TabPage();
            this.tabPageWindowPhone = new System.Windows.Forms.TabPage();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDeskTop = new System.Windows.Forms.TabPage();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnAutoPush = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lab_ServerMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.DeviceTabHost.SuspendLayout();
            this.tabPageAndroid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(826, 472);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 23);
            this.btnPush.TabIndex = 0;
            this.btnPush.Text = "推送(&P)";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // lab_Title
            // 
            this.lab_Title.AutoSize = true;
            this.lab_Title.Location = new System.Drawing.Point(35, 31);
            this.lab_Title.Name = "lab_Title";
            this.lab_Title.Size = new System.Drawing.Size(65, 12);
            this.lab_Title.TabIndex = 1;
            this.lab_Title.Text = "消息标题：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "MessagePush-MetroX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "消息内容：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 68);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(398, 119);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Hello,This is a Message Pushed by MetroX!";
            // 
            // cmb_PushPlatform
            // 
            this.cmb_PushPlatform.FormattingEnabled = true;
            this.cmb_PushPlatform.Items.AddRange(new object[] {
            "Android",
            "IOS",
            "WindowsPhone",
            "Web",
            "DeskTop"});
            this.cmb_PushPlatform.Location = new System.Drawing.Point(632, 28);
            this.cmb_PushPlatform.Name = "cmb_PushPlatform";
            this.cmb_PushPlatform.Size = new System.Drawing.Size(145, 20);
            this.cmb_PushPlatform.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "推送平台：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "推送目标：";
            // 
            // cmb_PushTarget
            // 
            this.cmb_PushTarget.FormattingEnabled = true;
            this.cmb_PushTarget.Items.AddRange(new object[] {
            "全部"});
            this.cmb_PushTarget.Location = new System.Drawing.Point(632, 68);
            this.cmb_PushTarget.Name = "cmb_PushTarget";
            this.cmb_PushTarget.Size = new System.Drawing.Size(145, 20);
            this.cmb_PushTarget.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeviceTabHost);
            this.groupBox1.Location = new System.Drawing.Point(38, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已连接设备：";
            // 
            // DeviceTabHost
            // 
            this.DeviceTabHost.Controls.Add(this.tabPageAndroid);
            this.DeviceTabHost.Controls.Add(this.tabPageIOS);
            this.DeviceTabHost.Controls.Add(this.tabPageWindowPhone);
            this.DeviceTabHost.Controls.Add(this.tabPageWeb);
            this.DeviceTabHost.Controls.Add(this.tabPageDeskTop);
            this.DeviceTabHost.Location = new System.Drawing.Point(6, 20);
            this.DeviceTabHost.Name = "DeviceTabHost";
            this.DeviceTabHost.SelectedIndex = 0;
            this.DeviceTabHost.Size = new System.Drawing.Size(861, 211);
            this.DeviceTabHost.TabIndex = 0;
            // 
            // tabPageAndroid
            // 
            this.tabPageAndroid.Controls.Add(this.dataGridView1);
            this.tabPageAndroid.Location = new System.Drawing.Point(4, 22);
            this.tabPageAndroid.Name = "tabPageAndroid";
            this.tabPageAndroid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAndroid.Size = new System.Drawing.Size(853, 185);
            this.tabPageAndroid.TabIndex = 0;
            this.tabPageAndroid.Text = "Android";
            this.tabPageAndroid.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DeviceName,
            this.Version,
            this.IP,
            this.Port,
            this.MAC,
            this.ConnectDate,
            this.Status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(847, 179);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // DeviceName
            // 
            this.DeviceName.HeaderText = "Name";
            this.DeviceName.Name = "DeviceName";
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            // 
            // MAC
            // 
            this.MAC.HeaderText = "MAC";
            this.MAC.Name = "MAC";
            // 
            // ConnectDate
            // 
            this.ConnectDate.HeaderText = "ConnectDate";
            this.ConnectDate.Name = "ConnectDate";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // tabPageIOS
            // 
            this.tabPageIOS.Location = new System.Drawing.Point(4, 22);
            this.tabPageIOS.Name = "tabPageIOS";
            this.tabPageIOS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIOS.Size = new System.Drawing.Size(853, 185);
            this.tabPageIOS.TabIndex = 1;
            this.tabPageIOS.Text = "IOS";
            this.tabPageIOS.UseVisualStyleBackColor = true;
            // 
            // tabPageWindowPhone
            // 
            this.tabPageWindowPhone.Location = new System.Drawing.Point(4, 22);
            this.tabPageWindowPhone.Name = "tabPageWindowPhone";
            this.tabPageWindowPhone.Size = new System.Drawing.Size(853, 185);
            this.tabPageWindowPhone.TabIndex = 2;
            this.tabPageWindowPhone.Text = "WindowPhone";
            this.tabPageWindowPhone.UseVisualStyleBackColor = true;
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.Controls.Add(this.dataGridView2);
            this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Size = new System.Drawing.Size(853, 185);
            this.tabPageWeb.TabIndex = 3;
            this.tabPageWeb.Text = "Web";
            this.tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(853, 185);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Version";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "IP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Port";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "MAC";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ConnectDate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Status";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // tabPageDeskTop
            // 
            this.tabPageDeskTop.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeskTop.Name = "tabPageDeskTop";
            this.tabPageDeskTop.Size = new System.Drawing.Size(853, 185);
            this.tabPageDeskTop.TabIndex = 4;
            this.tabPageDeskTop.Text = "DeskTop";
            this.tabPageDeskTop.UseVisualStyleBackColor = true;
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(735, 472);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(85, 23);
            this.btnStopService.TabIndex = 0;
            this.btnStopService.Text = "停止服务(&T)";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(648, 472);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(81, 23);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "启动服务(&S)";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnAutoPush
            // 
            this.btnAutoPush.Location = new System.Drawing.Point(545, 472);
            this.btnAutoPush.Name = "btnAutoPush";
            this.btnAutoPush.Size = new System.Drawing.Size(97, 23);
            this.btnAutoPush.TabIndex = 0;
            this.btnAutoPush.Text = "自动推送(&A)";
            this.btnAutoPush.UseVisualStyleBackColor = true;
            this.btnAutoPush.Click += new System.EventHandler(this.btnAutoPush_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(548, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(363, 88);
            this.listBox1.TabIndex = 5;
            // 
            // lab_ServerMsg
            // 
            this.lab_ServerMsg.AutoSize = true;
            this.lab_ServerMsg.Location = new System.Drawing.Point(141, 477);
            this.lab_ServerMsg.Name = "lab_ServerMsg";
            this.lab_ServerMsg.Size = new System.Drawing.Size(41, 12);
            this.lab_ServerMsg.TabIndex = 6;
            this.lab_ServerMsg.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 543);
            this.Controls.Add(this.lab_ServerMsg);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_PushTarget);
            this.Controls.Add(this.cmb_PushPlatform);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_Title);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnAutoPush);
            this.Controls.Add(this.btnPush);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息推送中心";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.DeviceTabHost.ResumeLayout(false);
            this.tabPageAndroid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Label lab_Title;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmb_PushPlatform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_PushTarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl DeviceTabHost;
        private System.Windows.Forms.TabPage tabPageAndroid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageIOS;
        private System.Windows.Forms.TabPage tabPageWindowPhone;
        private System.Windows.Forms.TabPage tabPageWeb;
        private System.Windows.Forms.TabPage tabPageDeskTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnAutoPush;
        public  System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lab_ServerMsg;
    }
}

