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
            label2 = new Label();
            EndClick = new Button();
            startTime = new Label();
            mesg = new Label();
            label3 = new Label();
            clickCount = new TextBox();
            label4 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            简体中文ToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // StartClick
            // 
            StartClick.Location = new Point(133, 146);
            StartClick.Name = "StartClick";
            StartClick.Size = new Size(105, 30);
            StartClick.TabIndex = 0;
            StartClick.Text = "开始点击（F9）";
            StartClick.UseVisualStyleBackColor = true;
            StartClick.Click += Start_Click;
            // 
            // IntervalTime
            // 
            IntervalTime.Location = new Point(84, 38);
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
            radioLeft.Location = new Point(164, 105);
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
            radioRgiht.Location = new Point(84, 105);
            radioRgiht.Name = "radioRgiht";
            radioRgiht.Size = new Size(74, 21);
            radioRgiht.TabIndex = 4;
            radioRgiht.Text = "点击右键";
            radioRgiht.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 195);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 5;
            label2.Text = "开始时间";
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
            startTime.Location = new Point(84, 195);
            startTime.Name = "startTime";
            startTime.Size = new Size(43, 17);
            startTime.TabIndex = 7;
            startTime.Text = "label3";
            // 
            // mesg
            // 
            mesg.AutoSize = true;
            mesg.ForeColor = Color.Red;
            mesg.Location = new Point(23, 219);
            mesg.Name = "mesg";
            mesg.Size = new Size(0, 17);
            mesg.TabIndex = 8;
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
            clickCount.Location = new Point(84, 74);
            clickCount.Name = "clickCount";
            clickCount.Size = new Size(154, 23);
            clickCount.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 77);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 11;
            label4.Text = "点击次数";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 250);
            Controls.Add(label4);
            Controls.Add(clickCount);
            Controls.Add(label3);
            Controls.Add(mesg);
            Controls.Add(startTime);
            Controls.Add(EndClick);
            Controls.Add(label2);
            Controls.Add(radioRgiht);
            Controls.Add(radioLeft);
            Controls.Add(label1);
            Controls.Add(IntervalTime);
            Controls.Add(StartClick);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "鼠标连点器 By袁鹏";
            FormClosing += Form1_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartClick;
        private TextBox IntervalTime;
        private Label label1;
        private RadioButton radioLeft;
        private RadioButton radioRgiht;
        private Label label2;
        private Button EndClick;
        private Label startTime;
        private Label mesg;
        private Label label3;
        private TextBox clickCount;
        private Label label4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 简体中文ToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
    }
}