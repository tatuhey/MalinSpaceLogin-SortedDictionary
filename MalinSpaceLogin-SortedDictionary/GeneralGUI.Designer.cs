namespace MalinSpaceLogin_SortedDictionary
{
    partial class GeneralGUI
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
            this.gbRawdata = new System.Windows.Forms.GroupBox();
            this.lbStaffMain = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbShortcut = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbStaffSecondary = new System.Windows.Forms.ListBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.gbRawdata.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gbShortcut.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRawdata
            // 
            this.gbRawdata.Controls.Add(this.lbStaffMain);
            this.gbRawdata.Location = new System.Drawing.Point(12, 6);
            this.gbRawdata.Name = "gbRawdata";
            this.gbRawdata.Size = new System.Drawing.Size(189, 313);
            this.gbRawdata.TabIndex = 13;
            this.gbRawdata.TabStop = false;
            // 
            // lbStaffMain
            // 
            this.lbStaffMain.FormattingEnabled = true;
            this.lbStaffMain.Location = new System.Drawing.Point(6, 13);
            this.lbStaffMain.Name = "lbStaffMain";
            this.lbStaffMain.Size = new System.Drawing.Size(177, 290);
            this.lbStaffMain.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 327);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(606, 22);
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // stLabel
            // 
            this.stLabel.Name = "stLabel";
            this.stLabel.Size = new System.Drawing.Size(44, 17);
            this.stLabel.Text = "stLabel";
            // 
            // gbShortcut
            // 
            this.gbShortcut.Controls.Add(this.label5);
            this.gbShortcut.Controls.Add(this.label4);
            this.gbShortcut.Controls.Add(this.label3);
            this.gbShortcut.Controls.Add(this.label2);
            this.gbShortcut.Controls.Add(this.label1);
            this.gbShortcut.Location = new System.Drawing.Point(402, 6);
            this.gbShortcut.Name = "gbShortcut";
            this.gbShortcut.Size = new System.Drawing.Size(189, 313);
            this.gbShortcut.TabIndex = 11;
            this.gbShortcut.TabStop = false;
            this.gbShortcut.Text = "Shortcuts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "and selection";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Alt + C | Clear texboxes, listbox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Alt + A | Open Admin GUI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Alt + I | Clear ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alt + N | Clear Name";
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbID);
            this.gbLogin.Controls.Add(this.tbName);
            this.gbLogin.Controls.Add(this.lbStaffSecondary);
            this.gbLogin.Controls.Add(this.lbName);
            this.gbLogin.Controls.Add(this.lbID);
            this.gbLogin.Location = new System.Drawing.Point(207, 6);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(189, 313);
            this.gbLogin.TabIndex = 10;
            this.gbLogin.TabStop = false;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(72, 13);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(111, 20);
            this.tbID.TabIndex = 5;
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbID_KeyDown);
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(72, 42);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(111, 20);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // lbStaffSecondary
            // 
            this.lbStaffSecondary.FormattingEnabled = true;
            this.lbStaffSecondary.Location = new System.Drawing.Point(6, 68);
            this.lbStaffSecondary.Name = "lbStaffSecondary";
            this.lbStaffSecondary.Size = new System.Drawing.Size(177, 238);
            this.lbStaffSecondary.TabIndex = 1;
            this.lbStaffSecondary.SelectedIndexChanged += new System.EventHandler(this.lbStaffSecondary_SelectedIndexChanged);
            this.lbStaffSecondary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbStaffSecondary_KeyDown);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 42);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(60, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Staff Name";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(6, 16);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(43, 13);
            this.lbID.TabIndex = 3;
            this.lbID.Text = "Staff ID";
            // 
            // GeneralGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 349);
            this.Controls.Add(this.gbRawdata);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbShortcut);
            this.Controls.Add(this.gbLogin);
            this.Name = "GeneralGUI";
            this.Text = "Malin Staff Detail - Sorted Dictionary";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GeneralGUI_KeyDown);
            this.gbRawdata.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbShortcut.ResumeLayout(false);
            this.gbShortcut.PerformLayout();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRawdata;
        private System.Windows.Forms.ListBox lbStaffMain;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stLabel;
        private System.Windows.Forms.GroupBox gbShortcut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbLogin;
        internal System.Windows.Forms.TextBox tbID;
        internal System.Windows.Forms.TextBox tbName;
        internal System.Windows.Forms.ListBox lbStaffSecondary;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbID;
    }
}

