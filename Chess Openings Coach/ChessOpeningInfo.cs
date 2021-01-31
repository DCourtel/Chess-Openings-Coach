using System;
using System.Windows.Forms;

namespace Chess_Openings_Coach
{
    public partial class ChessOpeningInfo : UserControl
    {
        private bool _disableUpdate = false;

        public ChessOpeningInfo()
        {
            InitializeComponent();
        }

        #region Properties

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

        #endregion Properties

        #region Methods

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

        private void TxtBx_TextChanged(object sender, EventArgs e)
        {
            if (!_disableUpdate)
            { OnInfoChanged?.Invoke(this, new EventArgs()); }
        }

        public event EventHandler OnInfoChanged;
    }
}
