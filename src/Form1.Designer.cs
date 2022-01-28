namespace SkillCheckSimulator
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
            this.scoreLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.hexHuntressLullabyComboBox = new System.Windows.Forms.ComboBox();
            this.skillCheckTypeComboBox = new System.Windows.Forms.ComboBox();
            this.skillCheckTypeLabel = new System.Windows.Forms.Label();
            this.hexHuntressLullabyLabel = new System.Windows.Forms.Label();
            this.greatSkillCheckStreakCountLabel = new System.Windows.Forms.Label();
            this.goodSkillCheckStreakCountLabel = new System.Windows.Forms.Label();
            this.greatSkillCheckCountLabel = new System.Windows.Forms.Label();
            this.goodSkillCheckCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(48, 15);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score: 0";
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(750, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(36, 15);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "GLHF";
            // 
            // hexHuntressLullabyComboBox
            // 
            this.hexHuntressLullabyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hexHuntressLullabyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hexHuntressLullabyComboBox.FormattingEnabled = true;
            this.hexHuntressLullabyComboBox.Location = new System.Drawing.Point(667, 415);
            this.hexHuntressLullabyComboBox.Name = "hexHuntressLullabyComboBox";
            this.hexHuntressLullabyComboBox.Size = new System.Drawing.Size(121, 23);
            this.hexHuntressLullabyComboBox.TabIndex = 5;
            this.hexHuntressLullabyComboBox.TabStop = false;
            this.hexHuntressLullabyComboBox.SelectedIndexChanged += new System.EventHandler(this.hexHuntressLullabyComboBox_SelectedIndexChanged);
            // 
            // skillCheckTypeComboBox
            // 
            this.skillCheckTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skillCheckTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCheckTypeComboBox.FormattingEnabled = true;
            this.skillCheckTypeComboBox.Location = new System.Drawing.Point(12, 415);
            this.skillCheckTypeComboBox.Name = "skillCheckTypeComboBox";
            this.skillCheckTypeComboBox.Size = new System.Drawing.Size(121, 23);
            this.skillCheckTypeComboBox.TabIndex = 6;
            this.skillCheckTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.skillCheckTypeComboBox_SelectedIndexChanged);
            // 
            // skillCheckTypeLabel
            // 
            this.skillCheckTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skillCheckTypeLabel.AutoSize = true;
            this.skillCheckTypeLabel.Location = new System.Drawing.Point(25, 397);
            this.skillCheckTypeLabel.Name = "skillCheckTypeLabel";
            this.skillCheckTypeLabel.Size = new System.Drawing.Size(91, 15);
            this.skillCheckTypeLabel.TabIndex = 7;
            this.skillCheckTypeLabel.Text = "Skill Check Type";
            // 
            // hexHuntressLullabyLabel
            // 
            this.hexHuntressLullabyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hexHuntressLullabyLabel.AutoSize = true;
            this.hexHuntressLullabyLabel.Location = new System.Drawing.Point(667, 397);
            this.hexHuntressLullabyLabel.Name = "hexHuntressLullabyLabel";
            this.hexHuntressLullabyLabel.Size = new System.Drawing.Size(122, 15);
            this.hexHuntressLullabyLabel.TabIndex = 8;
            this.hexHuntressLullabyLabel.Text = "Hex: Huntress Lullaby";
            // 
            // greatSkillCheckStreakCountLabel
            // 
            this.greatSkillCheckStreakCountLabel.AutoSize = true;
            this.greatSkillCheckStreakCountLabel.Location = new System.Drawing.Point(12, 33);
            this.greatSkillCheckStreakCountLabel.Name = "greatSkillCheckStreakCountLabel";
            this.greatSkillCheckStreakCountLabel.Size = new System.Drawing.Size(142, 15);
            this.greatSkillCheckStreakCountLabel.TabIndex = 9;
            this.greatSkillCheckStreakCountLabel.Text = "Great Skill Check Streak: 0";
            // 
            // goodSkillCheckStreakCountLabel
            // 
            this.goodSkillCheckStreakCountLabel.AutoSize = true;
            this.goodSkillCheckStreakCountLabel.Location = new System.Drawing.Point(12, 57);
            this.goodSkillCheckStreakCountLabel.Name = "goodSkillCheckStreakCountLabel";
            this.goodSkillCheckStreakCountLabel.Size = new System.Drawing.Size(143, 15);
            this.goodSkillCheckStreakCountLabel.TabIndex = 10;
            this.goodSkillCheckStreakCountLabel.Text = "Good Skill Check Streak: 0";
            // 
            // greatSkillCheckCountLabel
            // 
            this.greatSkillCheckCountLabel.AccessibleDescription = "";
            this.greatSkillCheckCountLabel.AutoSize = true;
            this.greatSkillCheckCountLabel.Location = new System.Drawing.Point(12, 81);
            this.greatSkillCheckCountLabel.Name = "greatSkillCheckCountLabel";
            this.greatSkillCheckCountLabel.Size = new System.Drawing.Size(107, 15);
            this.greatSkillCheckCountLabel.TabIndex = 11;
            this.greatSkillCheckCountLabel.Text = "Great Skill Check: 0";
            // 
            // goodSkillCheckCountLabel
            // 
            this.goodSkillCheckCountLabel.AccessibleDescription = "";
            this.goodSkillCheckCountLabel.AutoSize = true;
            this.goodSkillCheckCountLabel.Location = new System.Drawing.Point(12, 106);
            this.goodSkillCheckCountLabel.Name = "goodSkillCheckCountLabel";
            this.goodSkillCheckCountLabel.Size = new System.Drawing.Size(108, 15);
            this.goodSkillCheckCountLabel.TabIndex = 12;
            this.goodSkillCheckCountLabel.Text = "Good Skill Check: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goodSkillCheckCountLabel);
            this.Controls.Add(this.greatSkillCheckCountLabel);
            this.Controls.Add(this.goodSkillCheckStreakCountLabel);
            this.Controls.Add(this.greatSkillCheckStreakCountLabel);
            this.Controls.Add(this.hexHuntressLullabyLabel);
            this.Controls.Add(this.skillCheckTypeLabel);
            this.Controls.Add(this.skillCheckTypeComboBox);
            this.Controls.Add(this.hexHuntressLullabyComboBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.scoreLabel);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Dead By Daylight - Skill Check Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyBoard_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label scoreLabel;
        private Label messageLabel;
        private ComboBox hexHuntressLullabyComboBox;
        private ComboBox skillCheckTypeComboBox;
        private Label skillCheckTypeLabel;
        private Label hexHuntressLullabyLabel;
        private Label greatSkillCheckStreakCountLabel;
        private Label goodSkillCheckStreakCountLabel;
        private Label greatSkillCheckCountLabel;
        private Label goodSkillCheckCountLabel;
    }
}