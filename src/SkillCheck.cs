using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace SkillCheckSimulator
{
    public sealed class SkillCheck
    {
        public enum SkillCheckTier
        {
            Miss,
            Great,
            Good,
        }

        private static readonly Random random = new Random();

        private static readonly SolidBrush blackBrush = new SolidBrush(Color.Black);
        private static readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private static readonly SolidBrush backgroundBrush = new SolidBrush(Color.Gray);

        private Stopwatch stopWatch;

        private readonly float outlineWidth;
        private readonly Size circleSize;
        private readonly Size innerZoneSize;
        private readonly Size outerZoneSize;

        private readonly float greatSkillZoneStartingAngle;
        private readonly float greatSkillZoneSize;
        private readonly float goodSkillZoneStartingAngle;
        private readonly float goodSkillZoneSize;

        private readonly int indicatorSize;
        private float indicatorStartingAngle;
        private readonly int indicatorDurationInMs;
        private float indicatorAngleIncrement;
        public bool IsCompleted { get; private set; }

        public SkillCheck(float greatSkillZoneSize, float goodSkillZoneSize)
        {
            var circleSize = 150;
            var zoneWidthSize = 15;

            this.stopWatch = new Stopwatch();
            this.outlineWidth = 2f;

            this.circleSize = new Size(circleSize, circleSize);
            this.innerZoneSize = new Size(circleSize - zoneWidthSize / 2, circleSize - zoneWidthSize / 2);
            this.outerZoneSize = new Size(circleSize + zoneWidthSize / 2, circleSize + zoneWidthSize / 2);

            this.greatSkillZoneSize = greatSkillZoneSize;
            this.goodSkillZoneSize = goodSkillZoneSize;

            this.greatSkillZoneStartingAngle = 270f - this.goodSkillZoneSize - this.greatSkillZoneSize;

            this.greatSkillZoneStartingAngle = random.Next(270 - (int)this.goodSkillZoneSize - (int)this.greatSkillZoneSize);
            this.goodSkillZoneStartingAngle = this.greatSkillZoneStartingAngle + this.greatSkillZoneSize;

            this.indicatorSize = circleSize / 2;
            this.indicatorStartingAngle = -90f;
            this.indicatorDurationInMs = (int)(1000 * 2.25);
            this.indicatorAngleIncrement = 0f;
            this.IsCompleted = false;
        }

        public SkillCheckTier Trigger()
        {
            this.IsCompleted = true;
            var indicatorAngle = this.indicatorStartingAngle + this.indicatorAngleIncrement;

            // Great zone skill check
            if (indicatorAngle >= this.greatSkillZoneStartingAngle && indicatorAngle <= this.greatSkillZoneStartingAngle + this.greatSkillZoneSize)
            {
                return SkillCheckTier.Great;
            }
            // Good zone skill check
            else if (indicatorAngle >= this.goodSkillZoneStartingAngle && indicatorAngle <= this.goodSkillZoneStartingAngle + this.goodSkillZoneSize)
            {
                return SkillCheckTier.Good;
            }

            return SkillCheckTier.Miss;
        }

        public void Draw(Graphics g, Point offset)
        {
            this.DrawSkillCheck(g, offset);
            this.DrawIndicator(g, offset);
        }

        private void DrawIndicator(Graphics g, Point offset)
        {
            var redPen = new Pen(Color.Red, outlineWidth);
            if (!this.stopWatch.IsRunning)
            {
                this.stopWatch.Start();
            }

            this.indicatorAngleIncrement = Math.Min((float)this.stopWatch.ElapsedMilliseconds / (float)this.indicatorDurationInMs * 360f, 360f);
            if (this.indicatorAngleIncrement == 360f)
            {
                this.IsCompleted = true;
            }

            this.GetLineOnCircle(offset, this.indicatorStartingAngle + indicatorAngleIncrement, this.circleSize.Width / 2 - this.indicatorSize / 2, this.circleSize.Width / 2 + this.indicatorSize / 2, out var startingPoint, out var endingPoint);
            g.DrawLine(redPen, startingPoint, endingPoint);
        }

        private void DrawSkillCheck(Graphics g, Point offset)
        {
            var whitePen = new Pen(Color.White, outlineWidth);

            // Draw middle circle
            g.DrawEllipse(whitePen, new Rectangle(offset - circleSize / 2, circleSize));

            // Draw skill zone
            var outerZoneRectangle = new Rectangle(offset - this.outerZoneSize / 2, this.outerZoneSize);
            g.FillPie(whiteBrush, outerZoneRectangle, this.greatSkillZoneStartingAngle, this.greatSkillZoneSize); // Great skill zone
            g.FillPie(backgroundBrush, outerZoneRectangle, this.goodSkillZoneStartingAngle, this.goodSkillZoneSize); // Good skill zone

            // Draw outlines for the skill zone
            var innerZoneRectangle = new Rectangle(offset - this.innerZoneSize / 2, this.innerZoneSize);
            g.FillEllipse(backgroundBrush, innerZoneRectangle);
            g.DrawArc(whitePen, outerZoneRectangle, this.greatSkillZoneStartingAngle, this.greatSkillZoneSize + this.goodSkillZoneSize); // Outer arc
            g.DrawArc(whitePen, innerZoneRectangle, this.greatSkillZoneStartingAngle, this.greatSkillZoneSize + this.goodSkillZoneSize); // Inner arc

            this.GetLineOnCircle(offset, this.greatSkillZoneStartingAngle, this.innerZoneSize.Width / 2, this.outerZoneSize.Width / 2, out var startingPoint, out var endingPoint);
            g.DrawLine(whitePen, startingPoint, endingPoint); // Great skill zone line
            this.GetLineOnCircle(offset, this.goodSkillZoneStartingAngle + this.goodSkillZoneSize, this.innerZoneSize.Width / 2, this.outerZoneSize.Width / 2, out startingPoint, out endingPoint);
            g.DrawLine(whitePen, startingPoint, endingPoint); // Good skill zone line
        }

        private void GetLineOnCircle(Point offset, float angle, int innerSize, int outerSize, out Point start, out Point end)
        {
            start = RotatePoint(new Point(innerSize, 0), -angle);
            start.Offset(offset);
            end = RotatePoint(new Point(outerSize, 0), -angle);
            end.Offset(offset);
        }

        private Point RotatePoint(Point point, float angle)
        {
            var matrix = new Matrix();
            matrix.Rotate(angle);

            return Point.Round(new PointF(matrix.MatrixElements.M11 * point.X + matrix.MatrixElements.M12 * point.Y, matrix.MatrixElements.M21 * point.X + matrix.MatrixElements.M22 * point.Y));
        }
    }
}
