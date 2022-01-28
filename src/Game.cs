using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheckSimulator
{
    public class Game
    {
        public Settings CurrentSettings { get; private set; }

        private const int GreatSkillCheckScore = 300;
        private const int GoodSkillCheckScore = 50;

        private static readonly Random random = new Random();

        private SkillCheck? skillCheck;
        private int minNewSkillCheckTimeInMs = 1000 * 3;
        private int maxNewSkillCheckTimeInMs = 1000 * 10;

        private int score;
        private Label scoreLabel;

        private Label messageLabel;

        private int greatSkillCheckStreakCount;
        private Label greatSkillCheckStreakCountLabel;
        private int goodSkillCheckStreakCount;
        private Label goodSkillCheckStreakCountLabel;
        private int greatSkillCheckCount;
        private Label greatSkillCheckCountLabel;
        private int goodSkillCheckCount;
        private Label goodSkillCheckCountLabel;

        private System.Windows.Forms.Timer? newSkillCheckTimer = default;

        SoundPlayer skillCheckStartSound;
        SoundPlayer skillCheckGoodSound;
        SoundPlayer skillCheckGreatSound;
        SoundPlayer skillCheckFailed1Sound;
        SoundPlayer skillCheckFailed2Sound;
        private const int SkillCheckStartDelayInMs = (int)(1000 * 1.12f);

        public Game(Label scoreLabel, Label messageLabel, Label greatSkillCheckStreakCountLabel, Label goodSkillCheckStreakCountLabel, Label greatSkillCheckCountLabel, Label goodSkillCheckCountLabel)
        {
            this.score = 0;
            this.scoreLabel = scoreLabel;
            this.messageLabel = messageLabel;
            this.greatSkillCheckStreakCountLabel = greatSkillCheckStreakCountLabel;
            this.goodSkillCheckStreakCountLabel = goodSkillCheckStreakCountLabel;
            this.greatSkillCheckCountLabel = greatSkillCheckCountLabel;
            this.goodSkillCheckCountLabel = goodSkillCheckCountLabel;

            this.skillCheckStartSound = new SoundPlayer(Path.Join("Resources", "Sounds", "skill_check_start.wav"));
            this.skillCheckStartSound.Load();
            this.skillCheckGoodSound = new SoundPlayer(Path.Join("Resources", "Sounds", "skill_check_good.wav"));
            this.skillCheckGoodSound.Load();
            this.skillCheckGreatSound = new SoundPlayer(Path.Join("Resources", "Sounds", "skill_check_great.wav"));
            this.skillCheckGreatSound.Load();
            this.skillCheckFailed1Sound = new SoundPlayer(Path.Join("Resources", "Sounds", "skill_check_failed1.wav"));
            this.skillCheckFailed1Sound.Load();
            this.skillCheckFailed2Sound = new SoundPlayer(Path.Join("Resources", "Sounds", "skill_check_failed2.wav"));
            this.skillCheckFailed2Sound.Load();

            this.CurrentSettings = new Settings
            {
                CurrentSkillCheckType = Settings.SkillCheckType.Regular,
                HexHuntressLullabyState = Settings.HexHuntressLullaby.Disabled,
                IsSpineChillOn = false,
            };

            this.ResetSkillCheck();
        }

        public void Draw(Graphics g, Point offset)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (this.skillCheck != default)
            {
                this.skillCheck.Draw(g, offset);
                this.ResetSkillCheck(true);
            }
        }
        
        public void Trigger()
        {
            if (this.skillCheck != default)
            {
                var skillCheckTier = this.skillCheck.Trigger();
                if (skillCheckTier == SkillCheck.SkillCheckTier.Great)
                {
                    this.score += GreatSkillCheckScore;
                    ++this.greatSkillCheckStreakCount;
                    ++this.greatSkillCheckCount;
                    this.greatSkillCheckStreakCountLabel.Text = $"Great Skill Check Streak: {this.greatSkillCheckStreakCount}";
                    this.greatSkillCheckCountLabel.Text = $"Great Skill Check: {this.greatSkillCheckCount}";
                    this.messageLabel.Text = "Great";
                    this.skillCheckGreatSound.Play();
                }
                else if (skillCheckTier == SkillCheck.SkillCheckTier.Good)
                {
                    this.score += GoodSkillCheckScore;
                    ++this.goodSkillCheckStreakCount;
                    ++this.goodSkillCheckCount;
                    this.goodSkillCheckStreakCountLabel.Text = $"Good Skill Check Streak: {this.goodSkillCheckStreakCount}";
                    this.goodSkillCheckCountLabel.Text = $"Good Skill Check: {this.goodSkillCheckCount}";
                    this.messageLabel.Text = "Good";
                    this.skillCheckGoodSound.Play();
                }
                else
                {
                    this.greatSkillCheckStreakCount = 0;
                    this.greatSkillCheckStreakCountLabel.Text = $"Great Skill Check Streak: {this.greatSkillCheckStreakCount}";
                    this.goodSkillCheckStreakCount = 0;
                    this.messageLabel.Text = "Miss";
                    this.goodSkillCheckStreakCountLabel.Text = $"Good Skill Check Streak: {this.goodSkillCheckStreakCount}";

                    this.skillCheckFailed1Sound.Play();
                }

                this.scoreLabel.Text = $"Score: {this.score}";
                this.ResetSkillCheck();
            }
        }

        private void ResetSkillCheck(bool playSound = false)
        {
            if (playSound && this.skillCheck != default && this.skillCheck.IsCompleted)
            {
                this.greatSkillCheckStreakCount = 0;
                this.greatSkillCheckStreakCountLabel.Text = $"Great Skill Check Streak: {this.greatSkillCheckStreakCount}";
                this.goodSkillCheckStreakCount = 0;
                this.goodSkillCheckStreakCountLabel.Text = $"Good Skill Check Streak: {this.goodSkillCheckStreakCount}";

                this.skillCheckFailed2Sound.Play();
            }

            if (this.skillCheck == default || this.skillCheck.IsCompleted)
            {
                this.skillCheck = default;
                this.newSkillCheckTimer = new System.Windows.Forms.Timer();
                this.newSkillCheckTimer.Interval = random.Next(minNewSkillCheckTimeInMs, maxNewSkillCheckTimeInMs);
                this.newSkillCheckTimer.Tick += async (_, _) =>
                {
                    this.newSkillCheckTimer.Stop();

                    switch (this.CurrentSettings.HexHuntressLullabyState)
                    {
                        case Settings.HexHuntressLullaby.Disabled:
                            this.skillCheckStartSound.Play();
                            await Task.Delay(SkillCheckStartDelayInMs);
                            break;
                        case Settings.HexHuntressLullaby.Tokens1:
                            this.skillCheckStartSound.Play();
                            await Task.Delay((int)(SkillCheckStartDelayInMs * (1f - 0.14f)));
                            break;
                        case Settings.HexHuntressLullaby.Tokens2:
                            this.skillCheckStartSound.Play();
                            await Task.Delay((int)(SkillCheckStartDelayInMs * (1f - 0.28f)));
                            break;
                        case Settings.HexHuntressLullaby.Tokens3:
                            this.skillCheckStartSound.Play();
                            await Task.Delay((int)(SkillCheckStartDelayInMs * (1f - 0.42f)));
                            break;
                        case Settings.HexHuntressLullaby.Tokens4:
                            this.skillCheckStartSound.Play();
                            await Task.Delay((int)(SkillCheckStartDelayInMs * (1f - 0.56f)));
                            break;
                        case Settings.HexHuntressLullaby.Tokens5:
                            break;
                    }

                    this.skillCheck = this.CreateSkillCheck();
                };
                newSkillCheckTimer.Start();
            }
        }

        private SkillCheck CreateSkillCheck()
        {
            var greatSkillZoneSize = 0f;
            var goodSkillZoneSize = 0f;
            switch (this.CurrentSettings.CurrentSkillCheckType)
            {
                case Settings.SkillCheckType.Regular:
                    greatSkillZoneSize = 7f;
                    goodSkillZoneSize = 27f;
                    break;
                case Settings.SkillCheckType.Difficult:
                    greatSkillZoneSize = 10f;
                    break;
                case Settings.SkillCheckType.DecisiveStrike:
                    greatSkillZoneSize = 15f;
                    break;
            }

            return new SkillCheck(greatSkillZoneSize, goodSkillZoneSize);
        }

        public class Settings
        {
            public enum SkillCheckType
            {
                Regular,
                Difficult, // Oppresion/Overcharge
                DecisiveStrike,
            }

            public enum HexHuntressLullaby
            {
                Disabled,
                Tokens1,
                Tokens2,
                Tokens3,
                Tokens4,
                Tokens5,
            }

            public SkillCheckType CurrentSkillCheckType { get; set; }
            public HexHuntressLullaby HexHuntressLullabyState { get; set; }
            public bool IsSpineChillOn { get; set; }

            public ImmutableDictionary<string, HexHuntressLullaby> HexHuntressLullabyMapping { get; private set; }
            public ImmutableDictionary<string, SkillCheckType> SkillCheckTypeMapping { get; private set; }

            public Settings()
            {
                var hexHuntressLullabyMappingBuilder = ImmutableDictionary.CreateBuilder<string, HexHuntressLullaby>();
                hexHuntressLullabyMappingBuilder.Add("Disabled", HexHuntressLullaby.Disabled);
                hexHuntressLullabyMappingBuilder.Add("1 Token", HexHuntressLullaby.Tokens1);
                hexHuntressLullabyMappingBuilder.Add("2 Tokens", HexHuntressLullaby.Tokens2);
                hexHuntressLullabyMappingBuilder.Add("3 Tokens", HexHuntressLullaby.Tokens3);
                hexHuntressLullabyMappingBuilder.Add("4 Tokens", HexHuntressLullaby.Tokens4);
                hexHuntressLullabyMappingBuilder.Add("5 Tokens", HexHuntressLullaby.Tokens5);
                HexHuntressLullabyMapping = hexHuntressLullabyMappingBuilder.ToImmutableDictionary();

                var skillCheckTypeMappingBuilder = ImmutableDictionary.CreateBuilder<string, SkillCheckType>();
                skillCheckTypeMappingBuilder.Add("Regular", SkillCheckType.Regular);
                skillCheckTypeMappingBuilder.Add("Difficult", SkillCheckType.Difficult);
                skillCheckTypeMappingBuilder.Add("Decisive Strike", SkillCheckType.DecisiveStrike);
                SkillCheckTypeMapping = skillCheckTypeMappingBuilder.ToImmutableDictionary();
            }
        }
    }
}
