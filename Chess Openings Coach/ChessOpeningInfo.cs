using System;
using System.Windows.Forms;
using System.Drawing;

namespace Chess_Openings_Coach
{
    public partial class ChessOpeningInfo : UserControl
    {
        private readonly Color DARK_MODE_BACKGROUND_COLOR = Color.FromArgb(51, 51, 0);
        private readonly Color DARK_MODE_FOREGROUND_COLOR = Color.DarkGray;
        private bool _disableUpdate = false;

        public ChessOpeningInfo()
        {
            InitializeComponent();
        }

        #region Properties

        public int MoveAnnotation
        {
            get { return CmbBxAnnotation.SelectedIndex; }
            set
            {
                if (value != CmbBxAnnotation.SelectedIndex)
                {
                    _disableUpdate = true;
                    CmbBxAnnotation.SelectedIndex = value;
                    _disableUpdate = false;
                }
            }
        }

        public string Comment
        {
            get { return TxtBxComment.Text; }
            set
            {
                if (string.Compare(TxtBxComment.Text, value, false) != 0)
                {
                    _disableUpdate = true;
                    TxtBxComment.Text = value;
                    _disableUpdate = false;
                }
            }
        }

        public int GameCount
        {
            get { return gameStatisticsControl1.GameCount; }
            set
            {
                if (value != gameStatisticsControl1.GameCount)
                {
                    _disableUpdate = true;
                    gameStatisticsControl1.GameCount = value;
                    _disableUpdate = false;
                }
            }
        }

        public int WhitePercent
        {
            get { return gameStatisticsControl1.WhitePercent; }
            set
            {
                if (value != gameStatisticsControl1.WhitePercent)
                {
                    _disableUpdate = true;
                    gameStatisticsControl1.WhitePercent = value;
                    _disableUpdate = false;
                }
            }
        }

        public int NullPercent
        {
            get { return gameStatisticsControl1.NullPercent; }
            set
            {
                if (value != gameStatisticsControl1.NullPercent)
                {
                    _disableUpdate = true;
                    gameStatisticsControl1.NullPercent = value;
                    _disableUpdate = false;
                }
            }
        }

        public string Eco
        {
            get { return TxtBxECO.Text; }
            set
            {
                if (string.Compare(TxtBxECO.Text, value, false) != 0)
                {
                    _disableUpdate = true;
                    TxtBxECO.Text = value;
                    _disableUpdate = false;
                }
            }
        }

        public string OpeningMove
        {
            get { return TxtBxMove.Text; }
            set
            {
                if (string.Compare(TxtBxMove.Text, value, false) != 0)
                {
                    _disableUpdate = true;
                    TxtBxMove.Text = value;
                    _disableUpdate = false;
                }
            }
        }

        public string OpeningName
        {
            get { return TxtBxName.Text; }
            set
            {
                if (string.Compare(TxtBxName.Text, value, false) != 0)
                {
                    _disableUpdate = true;
                    TxtBxName.Text = value;
                    _disableUpdate = false;
                }
            }
        }

        private bool _useDarkTheme = false;
        public bool UseDarkTheme
        {
            get { return _useDarkTheme; }
            set
            {
                _useDarkTheme = value;
                ChangeTheme(_useDarkTheme);
            }
        }

        #endregion Properties

        #region Methods

        private void ChangeTheme(bool useDarkTheme)
        {
            this.BackColor = (useDarkTheme ? DARK_MODE_BACKGROUND_COLOR : SystemColors.Window);
            this.ForeColor = (useDarkTheme ? DARK_MODE_FOREGROUND_COLOR : SystemColors.ControlText);

            foreach (Control ctrl in this.Controls)
            {
                ctrl.BackColor = (useDarkTheme ? DARK_MODE_BACKGROUND_COLOR : SystemColors.Window);
                ctrl.ForeColor = (useDarkTheme ? DARK_MODE_FOREGROUND_COLOR : SystemColors.ControlText);
                ctrl.Refresh();
            }
        }

        public void Clear()
        {
            _disableUpdate = true;
            TxtBxComment.Clear();
            TxtBxECO.Clear();
            TxtBxMove.Clear();
            TxtBxName.Clear();
            _disableUpdate = false;
        }

        public void SelectName()
        {
            this.TxtBxName.Select(0, 0);
            this.TxtBxName.Focus();
            this.TxtBxName.ScrollToCaret();
        }

        #endregion Methods

        private void CmbBxAnnotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_disableUpdate)             { OnInfoChanged?.Invoke(this, new EventArgs()); }
        }

        private void gameStatisticsControl1_DoubleClick(object sender, EventArgs e)
        {
            var gameStatEditor = new FrmGameStatisticsEditor(gameStatisticsControl1.GameCount, gameStatisticsControl1.WhitePercent, gameStatisticsControl1.NullPercent);
            if (gameStatEditor.ShowDialog() == DialogResult.OK)
            {
                gameStatisticsControl1.SetStatistics(gameStatEditor.GameCount, gameStatEditor.WhiteCount, gameStatEditor.DrawCount);
                if (!_disableUpdate)
                { OnInfoChanged?.Invoke(this, new EventArgs()); }
            }
        }

        private void TxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!_disableUpdate)            { OnInfoChanged?.Invoke(this, new EventArgs()); }
        }

        public event EventHandler OnInfoChanged;
    }
}
