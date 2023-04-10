namespace MouseClick
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            StartClick = new Button();
            IntervalTime = new TextBox();
            label1 = new Label();
            radioLeft = new RadioButton();
            radioRgiht = new RadioButton();
            label4 = new Label();
            EndClick = new Button();
            startTime = new Label();
            label3 = new Label();
            clickCount = new TextBox();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            简体中文ToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            chineseToolStripMenuItem1 = new ToolStripMenuItem();
            englishToolStripMenuItem1 = new ToolStripMenuItem();
            label6 = new Label();
            lastEndTime = new Label();
            label5 = new Label();
            clickNumber = new Label();
            label7 = new Label();
            clickNumCheckBox = new CheckBox();
            label8 = new Label();
            lockCheckBox = new CheckBox();
            notifyIcon1 = new NotifyIcon(components);
            label9 = new Label();
            randomMoveCheckBox = new CheckBox();
            label10 = new Label();
            randomX = new TextBox();
            label11 = new Label();
            label12 = new Label();
            randomY = new TextBox();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // StartClick
            // 
            StartClick.Location = new Point(152, 232);
            StartClick.Name = "StartClick";
            StartClick.Size = new Size(105, 30);
            StartClick.TabIndex = 0;
            StartClick.Text = "开始点击（F9）";
            StartClick.UseVisualStyleBackColor = true;
            StartClick.Click += Start_Click;
            // 
            // IntervalTime
            // 
            IntervalTime.Location = new Point(98, 38);
            IntervalTime.Name = "IntervalTime";
            IntervalTime.Size = new Size(87, 23);
            IntervalTime.TabIndex = 1;
            IntervalTime.Text = "1000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 41);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 2;
            label1.Text = "点击间隔";
            // 
            // radioLeft
            // 
            radioLeft.AutoSize = true;
            radioLeft.Checked = true;
            radioLeft.Location = new Point(192, 105);
            radioLeft.Name = "radioLeft";
            radioLeft.Size = new Size(50, 21);
            radioLeft.TabIndex = 3;
            radioLeft.TabStop = true;
            radioLeft.Text = "左键";
            radioLeft.UseVisualStyleBackColor = true;
            // 
            // radioRgiht
            // 
            radioRgiht.AutoSize = true;
            radioRgiht.Location = new Point(98, 105);
            radioRgiht.Name = "radioRgiht";
            radioRgiht.Size = new Size(50, 21);
            radioRgiht.TabIndex = 4;
            radioRgiht.Text = "右键";
            radioRgiht.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 302);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 5;
            label4.Text = "开始时间";
            // 
            // EndClick
            // 
            EndClick.Enabled = false;
            EndClick.Location = new Point(22, 232);
            EndClick.Name = "EndClick";
            EndClick.Size = new Size(105, 30);
            EndClick.TabIndex = 6;
            EndClick.Text = "停止点击(F10)";
            EndClick.UseVisualStyleBackColor = true;
            EndClick.Click += EndClick_Click;
            // 
            // startTime
            // 
            startTime.AutoSize = true;
            startTime.Location = new Point(113, 302);
            startTime.Name = "startTime";
            startTime.Size = new Size(62, 17);
            startTime.TabIndex = 7;
            startTime.Text = "startTime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 107);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 9;
            label3.Text = "点击方式";
            // 
            // clickCount
            // 
            clickCount.Location = new Point(98, 74);
            clickCount.Name = "clickCount";
            clickCount.Size = new Size(87, 23);
            clickCount.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 77);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 11;
            label2.Text = "点击次数";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 简体中文ToolStripMenuItem, englishToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 48);
            // 
            // 简体中文ToolStripMenuItem
            // 
            简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem";
            简体中文ToolStripMenuItem.Size = new Size(124, 22);
            简体中文ToolStripMenuItem.Text = "简体中文";
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Size = new Size(124, 22);
            englishToolStripMenuItem.Text = "English";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(291, 25);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { languageToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(44, 21);
            settingsToolStripMenuItem.Text = "设置";
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chineseToolStripMenuItem1, englishToolStripMenuItem1 });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(100, 22);
            languageToolStripMenuItem.Text = "语言";
            // 
            // chineseToolStripMenuItem1
            // 
            chineseToolStripMenuItem1.Name = "chineseToolStripMenuItem1";
            chineseToolStripMenuItem1.Size = new Size(124, 22);
            chineseToolStripMenuItem1.Text = "简体中文";
            chineseToolStripMenuItem1.Click += ChineseToolStripMenuItem1_Click;
            // 
            // englishToolStripMenuItem1
            // 
            englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            englishToolStripMenuItem1.Size = new Size(124, 22);
            englishToolStripMenuItem1.Text = "English";
            englishToolStripMenuItem1.Click += EnglishToolStripMenuItem1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 325);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 13;
            label6.Text = "结束时间";
            // 
            // lastEndTime
            // 
            lastEndTime.AutoSize = true;
            lastEndTime.Location = new Point(113, 325);
            lastEndTime.Name = "lastEndTime";
            lastEndTime.Size = new Size(78, 17);
            lastEndTime.TabIndex = 14;
            lastEndTime.Text = "lastEndTime";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 280);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 15;
            label5.Text = "点击次数";
            // 
            // clickNumber
            // 
            clickNumber.AutoSize = true;
            clickNumber.Location = new Point(113, 280);
            clickNumber.Name = "clickNumber";
            clickNumber.Size = new Size(81, 17);
            clickNumber.TabIndex = 16;
            clickNumber.Text = "clickNumber";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(191, 41);
            label7.Name = "label7";
            label7.Size = new Size(32, 17);
            label7.TabIndex = 17;
            label7.Text = "毫秒";
            // 
            // clickNumCheckBox
            // 
            clickNumCheckBox.AutoSize = true;
            clickNumCheckBox.Location = new Point(192, 76);
            clickNumCheckBox.Name = "clickNumCheckBox";
            clickNumCheckBox.Size = new Size(75, 21);
            clickNumCheckBox.TabIndex = 18;
            clickNumCheckBox.Text = "统计次数";
            clickNumCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(22, 137);
            label8.Name = "label8";
            label8.Size = new Size(56, 17);
            label8.TabIndex = 19;
            label8.Text = "锁定鼠标";
            // 
            // lockCheckBox
            // 
            lockCheckBox.AutoSize = true;
            lockCheckBox.Location = new Point(98, 136);
            lockCheckBox.Name = "lockCheckBox";
            lockCheckBox.Size = new Size(51, 21);
            lockCheckBox.TabIndex = 20;
            lockCheckBox.Text = "开启";
            lockCheckBox.UseVisualStyleBackColor = true;
            lockCheckBox.CheckedChanged += SuperCheckBox_CheckedChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "鼠标连点器 By袁鹏";
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(155, 137);
            label9.Name = "label9";
            label9.Size = new Size(43, 17);
            label9.TabIndex = 21;
            label9.Text = "label9";
            // 
            // randomMoveCheckBox
            // 
            randomMoveCheckBox.AutoSize = true;
            randomMoveCheckBox.Enabled = false;
            randomMoveCheckBox.Location = new Point(98, 163);
            randomMoveCheckBox.Name = "randomMoveCheckBox";
            randomMoveCheckBox.Size = new Size(147, 21);
            randomMoveCheckBox.TabIndex = 22;
            randomMoveCheckBox.Text = "在窗口内随机移动鼠标";
            randomMoveCheckBox.UseVisualStyleBackColor = true;
            randomMoveCheckBox.CheckedChanged += RandomMoveCheckBox_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(98, 196);
            label10.Name = "label10";
            label10.Size = new Size(56, 17);
            label10.TabIndex = 23;
            label10.Text = "移动范围";
            // 
            // randomX
            // 
            randomX.Enabled = false;
            randomX.Location = new Point(181, 193);
            randomX.MaxLength = 4;
            randomX.Name = "randomX";
            randomX.Size = new Size(34, 23);
            randomX.TabIndex = 24;
            randomX.Text = "100";
            randomX.KeyPress += RandomX_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(165, 196);
            label11.Name = "label11";
            label11.Size = new Size(16, 17);
            label11.TabIndex = 25;
            label11.Text = "X";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(219, 196);
            label12.Name = "label12";
            label12.Size = new Size(15, 17);
            label12.TabIndex = 26;
            label12.Text = "Y";
            // 
            // randomY
            // 
            randomY.Enabled = false;
            randomY.Location = new Point(234, 193);
            randomY.MaxLength = 4;
            randomY.Name = "randomY";
            randomY.Size = new Size(34, 23);
            randomY.TabIndex = 27;
            randomY.Text = "100";
            randomY.KeyPress += RandomY_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 367);
            Controls.Add(randomY);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(randomX);
            Controls.Add(label10);
            Controls.Add(randomMoveCheckBox);
            Controls.Add(label9);
            Controls.Add(lockCheckBox);
            Controls.Add(label8);
            Controls.Add(clickNumCheckBox);
            Controls.Add(label7);
            Controls.Add(clickNumber);
            Controls.Add(label5);
            Controls.Add(lastEndTime);
            Controls.Add(label6);
            Controls.Add(menuStrip1);
            Controls.Add(label2);
            Controls.Add(clickCount);
            Controls.Add(label3);
            Controls.Add(startTime);
            Controls.Add(EndClick);
            Controls.Add(label4);
            Controls.Add(radioRgiht);
            Controls.Add(radioLeft);
            Controls.Add(label1);
            Controls.Add(IntervalTime);
            Controls.Add(StartClick);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "鼠标连点器 By袁鹏";
            FormClosing += Form1_FormClosing;
            SizeChanged += Form1_SizeChanged;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartClick;
        private TextBox IntervalTime;
        private Label label1;
        private RadioButton radioLeft;
        private RadioButton radioRgiht;
        private Label label4;
        private Button EndClick;
        private Label startTime;
        private Label label3;
        private TextBox clickCount;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 简体中文ToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem chineseToolStripMenuItem1;
        private ToolStripMenuItem englishToolStripMenuItem1;
        private Label label6;
        private Label lastEndTime;
        private Label label5;
        private Label clickNumber;
        private Label label7;
        private CheckBox clickNumCheckBox;
        private Label label8;
        private CheckBox lockCheckBox;
        private NotifyIcon notifyIcon1;
        private Label label9;
        private CheckBox randomMoveCheckBox;
        private Label label10;
        private TextBox randomX;
        private Label label11;
        private Label label12;
        private TextBox randomY;
    }
}