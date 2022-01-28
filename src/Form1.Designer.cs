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
            this.infoLabel = new System.Windows.Forms.Label();
            this.hexHuntressLullabyComboBox = new System.Windows.Forms.ComboBox();
            this.skillCheckTypeComboBox = new System.Windows.Forms.ComboBox();
            this.skillCheckTypeLabel = new System.Windows.Forms.Label();
            this.hexHuntressLullabyLabel = new System.Windows.Forms.Label();
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
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(750, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(45, 15);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "GLHF!!!";
            // 
            // hexHuntressLullabyComboBox
            // 
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
            this.skillCheckTypeLabel.AutoSize = true;
            this.skillCheckTypeLabel.Location = new System.Drawing.Point(25, 397);
            this.skillCheckTypeLabel.Name = "skillCheckTypeLabel";
            this.skillCheckTypeLabel.Size = new System.Drawing.Size(91, 15);
            this.skillCheckTypeLabel.TabIndex = 7;
            this.skillCheckTypeLabel.Text = "Skill Check Type";
            // 
            // hexHuntressLullabyLabel
            // 
            this.hexHuntressLullabyLabel.AutoSize = true;
            this.hexHuntressLullabyLabel.Location = new System.Drawing.Point(667, 397);
            this.hexHuntressLullabyLabel.Name = "hexHuntressLullabyLabel";
            this.hexHuntressLullabyLabel.Size = new System.Drawing.Size(122, 15);
            this.hexHuntressLullabyLabel.TabIndex = 8;
            this.hexHuntressLullabyLabel.Text = "Hex: Huntress Lullaby";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hexHuntressLullabyLabel);
            this.Controls.Add(this.skillCheckTypeLabel);
            this.Controls.Add(this.skillCheckTypeComboBox);
            this.Controls.Add(this.hexHuntressLullabyComboBox);
            this.Controls.Add(this.infoLabel);
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
        private Label infoLabel;
        private ComboBox hexHuntressLullabyComboBox;
        private ComboBox skillCheckTypeComboBox;
        private Label skillCheckTypeLabel;
        private Label hexHuntressLullabyLabel;
    }
}