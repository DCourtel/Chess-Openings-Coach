using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Openings_Coach
{
    public partial class GameStatisticsControl : Control
    {
        private const double _gameCountFactor = 0.15;
        private readonly LinearGradientBrush _whiteBrush;
        private readonly LinearGradientBrush _nullBrush;
        private readonly LinearGradientBrush _blackBrush;

        public GameStatisticsControl()
        {
            InitializeComponent();

            _whiteBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.FromArgb(200, 200, 200), Color.FromArgb(159, 159, 159));
            _nullBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.FromArgb(115, 115, 115), Color.FromArgb(102, 102, 102));
            _blackBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height), Color.FromArgb(69, 69, 69), Color.FromArgb(51, 51, 51));
        }

        /// <summary>
        /// Create an instance of the class with the given values.
        /// </summary>
        /// <param name="gameCount">Total number of games played.</param>
        /// <param name="whitePercent">Percentage of games won by Whites.</param>
        /// <param name="nullPercent">Percentage of games ended by a draw.</param>
        public GameStatisticsControl(int gameCount, int whitePercent, int nullPercent) : this()
        {
            SetStatistics(gameCount, whitePercent, nullPercent);
        }

        #region Properties

        protected override Size DefaultSize { get { return new Size(300, 13); } }

        private int _gameCount = 1_000_000;
        /// <summary>
        /// Gets or sets the total number of game played.
        /// </summary>
        public int GameCount
        {
            get { return _gameCount; }
            set
            {
                if (value != _gameCount && value >= 0)
                {
                    _gameCount = value;
                    Invalidate();
                }
            }
        }

        private int _whitePercent = 33;
        /// <summary>
        /// Gets or sets the percentage of games won by Whites.
        /// </summary>
        public int WhitePercent
        {
            get { return _whitePercent; }
            set
            {
                if (value != _whitePercent)
                {
                    _whitePercent = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the percentage of games won by Blacks.
        /// </summary>
        public int BlackPercent { get { return 100 - (WhitePercent + NullPercent); } }

        private int _nullPercent = 34;
        /// <summary>
        /// Gets or sets the percentage of games ended by a draw.
        /// </summary>
        public int NullPercent
        {
            get { return _nullPercent; }
            set
            {
                if (value != _nullPercent)
                {
                    _nullPercent = value;
                    Invalidate();
                }

            }
        }

        #endregion Properties

        /// <summary>
        /// Defines the game statistics.
        /// </summary>
        /// <param name="gameCount">Total number of games played.</param>
        /// <param name="whitePercent">Percentage of games won by Whites.</param>
        /// <param name="nullPercent">Percentage of games ended by a draw.</param>
        public void SetStatistics(int gameCount, int whitePercent, int nullPercent)
        {

            this.WhitePercent = whitePercent;
            this.NullPercent = nullPercent;
            this.GameCount = gameCount;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (var g = pe.Graphics)
            {
                var gameCountWidth = (int)(this.Width * _gameCountFactor);
                var gameCountRectF = new RectangleF(0, 0, gameCountWidth, this.Height);
                var gameCountTextSize = g.MeasureString(GameCount.ToString("0,0"), this.Font);
                var gameCountTextRectF = new RectangleF(gameCountRectF.Width - gameCountTextSize.Width, 0, gameCountTextSize.Width, this.Height);

                var whiteRectF = new RectangleF(gameCountWidth, 0, (this.Width - gameCountWidth) * this.WhitePercent / 100, this.Height);
                var whiteTextSize = g.MeasureString($"{this.WhitePercent}%", this.Font);
                var whiteTextRectF = new RectangleF(whiteRectF.X + (whiteRectF.Width - whiteTextSize.Width) / 2, 0, whiteTextSize.Width, this.Height);

                var nullRectF = new RectangleF(gameCountWidth + whiteRectF.Width, 0, (this.Width - gameCountWidth) * this.NullPercent / 100, this.Height);
                var nullTextSize = g.MeasureString($"{this.NullPercent}%", this.Font);
                var nullTextRectF = new RectangleF(nullRectF.X + (nullRectF.Width - nullTextSize.Width) / 2, 0, nullTextSize.Width, this.Height);

                var blackRectF = new RectangleF(gameCountWidth + whiteRectF.Width + nullRectF.Width, 0, this.Width - (gameCountRectF.Width + whiteRectF.Width + nullRectF.Width), this.Height);
                var blackTextSize = g.MeasureString($"{this.BlackPercent}%", this.Font);
                var blackTextRectF = new RectangleF(blackRectF.X + (blackRectF.Width - blackTextSize.Width) / 2, 0, blackTextSize.Width, this.Height);

                //  Draw Game Count
                g.FillRectangle(Brushes.Black, gameCountRectF);
                if (gameCountTextSize.Width < gameCountRectF.Width) { g.DrawString(GameCount.ToString("0,0"), this.Font, Brushes.Gainsboro, gameCountTextRectF); }

                //  Draw White percentage
                g.FillRectangle(_whiteBrush, whiteRectF);
                if (whiteTextSize.Width < whiteRectF.Width) { g.DrawString($"{this.WhitePercent}%", this.Font, Brushes.Black, whiteTextRectF); }

                //  Draw null percentage
                g.FillRectangle(_nullBrush, nullRectF);
                if (nullTextSize.Width < nullRectF.Width) { g.DrawString($"{this.NullPercent}%", this.Font, Brushes.Gainsboro, nullTextRectF); }

                //  Draw Blacks percentage
                g.FillRectangle(_blackBrush, blackRectF);
                if (blackTextSize.Width < blackRectF.Width) { g.DrawString($"{this.BlackPercent}%", this.Font, Brushes.Gainsboro, blackTextRectF); }

                g.Flush();
            }
        }
    }
}
