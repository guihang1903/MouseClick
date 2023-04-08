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
            mesg = new Label();
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
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // StartClick
            // 
            StartClick.Location = new Point(137, 146);
            StartClick.Name = "StartClick";
            StartClick.Size = new Size(105, 30);
            StartClick.TabIndex = 0;
            StartClick.Text = "开始点击（F9）";
            StartClick.UseVisualStyleBackColor = true;
            StartClick.Click += Start_Click;
            // 
            // IntervalTime
            // 
            IntervalTime.Location = new Point(88, 38);
            IntervalTime.Name = "IntervalTime";
            IntervalTime.Size = new Size(154, 23);
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
            radioLeft.Location = new Point(168, 105);
            radioLeft.Name = "radioLeft";
            radioLeft.Size = new Size(74, 21);
            radioLeft.TabIndex = 3;
            radioLeft.TabStop = true;
            radioLeft.Text = "点击左键";
            radioLeft.UseVisualStyleBackColor = true;
            // 
            // radioRgiht
            // 
            radioRgiht.AutoSize = true;
            radioRgiht.Location = new Point(88, 105);
            radioRgiht.Name = "radioRgiht";
            radioRgiht.Size = new Size(74, 21);
            radioRgiht.TabIndex = 4;
            radioRgiht.Text = "点击右键";
            radioRgiht.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 195);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 5;
            label4.Text = "开始时间";
            // 
            // EndClick
            // 
            EndClick.Enabled = false;
            EndClick.Location = new Point(22, 146);
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
            startTime.Location = new Point(113, 195);
            startTime.Name = "startTime";
            startTime.Size = new Size(62, 17);
            startTime.TabIndex = 7;
            startTime.Text = "startTime";
            // 
            // mesg
            // 
            mesg.AutoSize = true;
            mesg.ForeColor = Color.Red;
            mesg.Location = new Point(29, 126);
            mesg.Name = "mesg";
            mesg.Size = new Size(40, 17);
            mesg.TabIndex = 8;
            mesg.Text = "mesg";
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
            clickCount.Location = new Point(88, 74);
            clickCount.Name = "clickCount";
            clickCount.Size = new Size(154, 23);
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
            menuStrip1.Size = new Size(269, 25);
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
            label6.Location = new Point(22, 248);
            label6.Name = "label6";
            label6.Size = new Size(80, 17);
            label6.TabIndex = 13;
            label6.Text = "上次结束时间";
            // 
            // lastEndTime
            // 
            lastEndTime.AutoSize = true;
            lastEndTime.Location = new Point(113, 248);
            lastEndTime.Name = "lastEndTime";
            lastEndTime.Size = new Size(78, 17);
            lastEndTime.TabIndex = 14;
            lastEndTime.Text = "lastEndTime";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 220);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 15;
            label5.Text = "点击次数";
            // 
            // clickNumber
            // 
            clickNumber.AutoSize = true;
            clickNumber.Location = new Point(113, 220);
            clickNumber.Name = "clickNumber";
            clickNumber.Size = new Size(81, 17);
            clickNumber.TabIndex = 16;
            clickNumber.Text = "clickNumber";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 277);
            Controls.Add(clickNumber);
            Controls.Add(label5);
            Controls.Add(lastEndTime);
            Controls.Add(label6);
            Controls.Add(menuStrip1);
            Controls.Add(label2);
            Controls.Add(clickCount);
            Controls.Add(label3);
            Controls.Add(mesg);
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
            Text = "鼠标连点器 By袁鹏";
            FormClosing += Form1_FormClosing;
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
        private Label mesg;
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
    }
}