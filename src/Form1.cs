namespace SkillCheckSimulator
{
    public partial class Form1 : Form
    {
        private const int Fps = 144;
        private System.Windows.Forms.Timer refreshTimer;

        private Point Center => new Point(this.Width / 2, this.Height / 2);

        Game game;

        public Form1()
        {
            InitializeComponent();


            // Use double buffering to remove flickering
            this.DoubleBuffered = true;

            this.game = new Game(this.scoreLabel, this.messageLabel, this.greatSkillCheckStreakCountLabel, this.goodSkillCheckStreakCountLabel, this.greatSkillCheckCountLabel, this.goodSkillCheckCountLabel);

            var hexHuntressLullabyMappingKeys = this.game.CurrentSettings.HexHuntressLullabyMapping.Keys.ToList();
            hexHuntressLullabyMappingKeys.Sort();
            this.hexHuntressLullabyComboBox.Items.AddRange(hexHuntressLullabyMappingKeys.ToArray());
            this.hexHuntressLullabyComboBox.SelectedIndex = 5; // Disabled

            var skillCheckTypeMappingKeys = this.game.CurrentSettings.SkillCheckTypeMapping.Keys.ToList();
            skillCheckTypeMappingKeys.Sort();
            this.skillCheckTypeComboBox.Items.AddRange(skillCheckTypeMappingKeys.ToArray());
            this.skillCheckTypeComboBox.SelectedIndex = 2; // Regular

            this.Paint += Form1_Paint;

            this.refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = (int)MathF.Round(1000f / Fps);
            refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            this.BackColor = Color.Gray;
            this.game.Draw(e.Graphics, this.Center);
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshTimer.Start();
        }

        private void KeyBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.game.Trigger();
            }
        }

        private void hexHuntressLullabyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.game.CurrentSettings.HexHuntressLullabyState = this.game.CurrentSettings.HexHuntressLullabyMapping[(string)this.hexHuntressLullabyComboBox.SelectedItem];
        }

        private void skillCheckTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.game.CurrentSettings.CurrentSkillCheckType = this.game.CurrentSettings.SkillCheckTypeMapping[(string)this.skillCheckTypeComboBox.SelectedItem];
        }

        private void spineChillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.game.CurrentSettings.IsSpineChillOn = this.spineChillCheckBox.Checked;
            this.scoreLabel.Focus();
        }
    }
}