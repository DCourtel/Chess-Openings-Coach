using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Openings_Coach
{
    public partial class FrmRenameBook : Form
    {
        public FrmRenameBook(string currentName)
        {
            InitializeComponent();

            TxtBxNewName.Text = currentName;
        }

        #region Properties

        /// <summary>
        /// Gets the new name given by the user.
        /// </summary>
        public string NewName
        {
            get { return TxtBxNewName.Text; }
        }

        #endregion Properties

        #region Events

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion Events

        private void TxtBxNewName_TextChanged(object sender, EventArgs e)
        {
            BtnOk.Enabled = !string.IsNullOrWhiteSpace(TxtBxNewName.Text);
        }
    }
}
