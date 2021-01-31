using ChessboardControl;
using ChessOpeningRepertoire;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Chess_Openings_Coach
{
    public partial class FrmMain : Form
    {
        private TreeNode _whiteRepertoireNode;
        private TreeNode _blackRepertoireNode;
        private readonly Color DARK_MODE_BACKGROUND_COLOR = Color.FromArgb(51, 51, 0);
        private readonly Color DARK_MODE_FOREGROUND_COLOR = Color.DarkGray;
        private const string _ctxMnuLoadNewBook = "Load new book…";
        private const string _ctxMnuRename = "Rename…";
        private const string _ctxMnuDelete = "Delete";

        private enum WorkingMode
        {
            Create,
            Learn,
            Quiz
        }

        private System.Resources.ResourceManager resMan = new System.Resources.ResourceManager("Chess_Openings_Coach.Internationalization.Resources", typeof(FrmMain).Assembly);

        public FrmMain()
        {
            //  System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            CreateDefaultBook();
            CreateContextMenu();
            ChangeTheme(IsDarkThemeEnable);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the currently opened chess opening book.
        /// </summary>
        private OpeningBook Book { get; set; }

        /// <summary>
        /// Gets if dark mode is enable.
        /// </summary>
        private bool IsDarkThemeEnable
        {
            get
            {
                //  HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize  AppsUseLightTheme   DWORD   0=Dark  1=Light
                try
                {
                    using (var hkcu = Microsoft.Win32.Registry.CurrentUser)
                    {
                        using (var themeKey = hkcu.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", false))
                        {
                            if (themeKey != null)
                            {
                                return (int)themeKey.GetValue("AppsUseLightTheme", 1) == 0;
                            }
                        }
                    }
                }
                catch (Exception) { }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets the currently selected repertoire.
        /// </summary>
        private OpeningRepertoire SelectedRepertoire { get; set; }

        /// <summary>
        /// Gets or sets the behavior of the application.
        /// </summary>
        private WorkingMode WorkMode { get; set; } = WorkingMode.Create;

        #endregion Properties

        #region Methods

        private OpeningMove AddMove(ChessMove move)
        {
            try
            {
                if (TrvRepertoires.SelectedNode != null)
                {
                    if (TrvRepertoires.SelectedNode.Tag.GetType() == typeof(OpeningMove))
                    {
                        var moveColor = chessboard1.Turn == ChessColor.White ? ChessColor.Black : ChessColor.White;
                        var currentMove = (OpeningMove)TrvRepertoires.SelectedNode.Tag;
                        var moveIndex = currentMove.MoveIndex + (moveColor == ChessColor.Black ? 0 : 1);
                        var newMove = new OpeningMove(new OpeningHalfMove(move), moveColor, moveIndex, chessboard1.GetFEN());
                        var newNode = new TreeNode(newMove.ToString()) { Tag = newMove };
                        TrvRepertoires.SelectedNode.Nodes.Add(newNode);
                        TrvRepertoires.SelectedNode = newNode;
                        currentMove.Children.Add(newMove);
                        chessOpeningInfo1.Enabled = true;

                        return newMove;
                    }
                    else if (TrvRepertoires.SelectedNode.Tag.GetType() == typeof(OpeningRepertoire))
                    {
                        var moveColor = chessboard1.Turn == ChessColor.White ? ChessColor.Black : ChessColor.White;
                        var newOpening = new OpeningMove(new OpeningHalfMove(move), moveColor, 1, chessboard1.GetFEN());
                        var newNode = new TreeNode(newOpening.ToString()) { Tag = newOpening };
                        TrvRepertoires.SelectedNode.Nodes.Add(newNode);
                        TrvRepertoires.SelectedNode = newNode;
                        this.SelectedRepertoire.Moves.Add(newOpening);
                        chessOpeningInfo1.Enabled = true;
                        ShowOpeningInfo(newOpening);
                    }
                }
            }
            catch (Exception ex)
            {
                chessboard1.UndoMove();
                ShowError(ex);
            }
            return null;
        }

        private void ContexMenuItemClicked(ToolStripItem clickedItem)
        {
            try
            {
                switch (clickedItem.Name)
                {
                    case _ctxMnuLoadNewBook:
                        break;
                    case _ctxMnuRename:
                        var newNameDlg = new FrmRenameBook(this.Book.Name);
                        if (newNameDlg.ShowDialog() == DialogResult.OK)
                        {
                            this.Book.Name = newNameDlg.NewName;
                            TrvRepertoires.Nodes[0].Text = newNameDlg.NewName;
                        }
                        break;
                    case _ctxMnuDelete:
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CreateContextMenu()
        {
            try
            {
                ToolStripMenuItem loadNewBookItem = new ToolStripMenuItem(Translate("ctxMnu_LoadNewBook"));
                loadNewBookItem.Enabled = false;
                loadNewBookItem.Name = _ctxMnuLoadNewBook;
                ToolStripMenuItem renameItem = new ToolStripMenuItem(Translate("ctxMnu_Rename"));
                renameItem.Enabled = false;
                renameItem.Name = _ctxMnuRename;
                ToolStripMenuItem deleteItem = new ToolStripMenuItem(Translate("ctxMnu_Delete"));
                deleteItem.Enabled = false;
                deleteItem.Name = _ctxMnuDelete;

                CtxMnuRepertoire.Items.Add(loadNewBookItem);
                CtxMnuRepertoire.Items.Add(renameItem);
                CtxMnuRepertoire.Items.Add(deleteItem);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CreateDefaultBook()
        {
            Book = new OpeningBook(Translate("trv_DefaultBook"));
            LoadBook(Book);
        }

        private void ChangeMode(WorkingMode newMode)
        {
            this.WorkMode = newMode;
            switch (newMode)
            {
                case WorkingMode.Create:
                    CreateToolStripMenuItem.Checked = true;
                    LearnToolStripMenuItem.Checked = false;
                    QuizToolStripMenuItem.Checked = false;
                    break;
                case WorkingMode.Learn:
                    CreateToolStripMenuItem.Checked = false;
                    LearnToolStripMenuItem.Checked = true;
                    QuizToolStripMenuItem.Checked = false;
                    break;
                case WorkingMode.Quiz:
                    CreateToolStripMenuItem.Checked = false;
                    LearnToolStripMenuItem.Checked = false;
                    QuizToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void ChangeTheme(bool useDarkTheme)
        {
            this.BackColor = (useDarkTheme ? DARK_MODE_BACKGROUND_COLOR : SystemColors.Window);
            this.ForeColor = (useDarkTheme ? DARK_MODE_FOREGROUND_COLOR : SystemColors.ControlText);

            ChangeTheme(this.Controls, useDarkTheme);
            chessOpeningInfo1.UseDarkTheme = useDarkTheme;
        }

        private void ChangeTheme(Control.ControlCollection controls, bool useDarkTheme)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.BackColor = (useDarkTheme ? DARK_MODE_BACKGROUND_COLOR : SystemColors.Window);
                ctrl.ForeColor = (useDarkTheme ? DARK_MODE_FOREGROUND_COLOR : SystemColors.ControlText);
                ctrl.Refresh();
                try
                {
                    if (ctrl.Controls != null && ctrl.Controls.Count > 0)
                    {
                        ChangeTheme(ctrl.Controls, useDarkTheme);
                    }
                }
                catch (Exception) { }
            }
        }

        private void ChangeQuizSelection(TreeNode selectedNode)
        {
            try
            {
                var nodeType = selectedNode.Tag.GetType();
                if (nodeType == typeof(OpeningMove))
                {
                    var move = (OpeningMove)selectedNode.Tag;
                    move.Selected = selectedNode.Checked;
                    if (selectedNode.Checked)
                    {
                        //  Select all parent nodes
                        var parentNode = selectedNode.Parent;
                        if (parentNode != null && parentNode.Tag.GetType() == typeof(OpeningMove))
                        {
                            parentNode.Checked = true;
                        }
                    }
                    else
                    {
                        //  Unselect all children nodes
                        if (selectedNode.Nodes.Count > 0)
                        {
                            foreach (TreeNode childNode in selectedNode.Nodes)
                            {
                                childNode.Checked = false;
                            }
                        }
                    }
                }
                else if (nodeType == typeof(OpeningRepertoire))
                {
                    var repertoire = (OpeningRepertoire)selectedNode.Tag;
                    repertoire.Selected = selectedNode.Checked;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private OpeningRepertoire GetParentRepertoire(TreeNode childNode)
        {
            if (childNode == null) { return null; }
            if (childNode == _whiteRepertoireNode && _whiteRepertoireNode.Tag != null) { return (OpeningRepertoire)_whiteRepertoireNode.Tag; }
            if (childNode == _blackRepertoireNode && _blackRepertoireNode.Tag != null) { return (OpeningRepertoire)_blackRepertoireNode.Tag; }

            return GetParentRepertoire(childNode.Parent);
        }

        private string Translate(string text)
        {
            try
            {
                return resMan.GetString(text);
            }
            catch (Exception) { }

            return $"Missing ressource:{(string.IsNullOrWhiteSpace(text) ? "null" : text)}";
        }

        private void LoadBook()
        {
            try
            {
                var loadFile = new OpenFileDialog();
                loadFile.Filter = "Opening Books|*.coc|All Files|*.*";

                if (!string.IsNullOrWhiteSpace(this.Book.Filename))
                {
                    loadFile.FileName = this.Book.Filename;
                }
                if (loadFile.ShowDialog() == DialogResult.OK)
                {
                    this.Book = OpeningBook.LoadFromFile(loadFile.FileName);
                    LoadBook(this.Book);
                    SaveToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadBook(OpeningBook book)
        {
            TrvRepertoires.Nodes.Clear();

            var bookNode = new TreeNode(book.Name) { Tag = book };
            TrvRepertoires.Nodes.Add(bookNode);

            _whiteRepertoireNode = new TreeNode(Translate("trv_WhiteRepertoire")) { Tag = book.WhiteRepertoire };
            bookNode.Nodes.Add(_whiteRepertoireNode);
            LoadOpenings(_whiteRepertoireNode, book.WhiteRepertoire.Moves);
            _whiteRepertoireNode.Expand();

            _blackRepertoireNode = new TreeNode(Translate("trv_BlackRepertoire")) { Tag = book.BlackRepertoire };
            bookNode.Nodes.Add(_blackRepertoireNode);
            LoadOpenings(_blackRepertoireNode, book.BlackRepertoire.Moves);
            _blackRepertoireNode.Expand();

            bookNode.Expand();
            SaveAsToolStripMenuItem.Enabled = true;
            if (!string.IsNullOrWhiteSpace(this.Book.Filename)) { SaveToolStripMenuItem.Enabled = true; }
        }

        private void LoadOpenings(TreeNode repertoireNode, List<OpeningMove> moves)
        {
            foreach (var move in moves)
            {
                var openingNode = new TreeNode(move.ToString()) { Tag = move };
                openingNode.Checked = move.Selected;
                repertoireNode.Nodes.Add(openingNode);
                if (move.Children.Count > 0)
                {
                    LoadOpenings(openingNode, move.Children);
                }
            }
        }

        private void NodeSelected(TreeNode clickedNode)
        {
            TrvRepertoires.SelectedNode = clickedNode;
            var nodeType = clickedNode.Tag.GetType();

            if (nodeType == typeof(OpeningBook))
            {
                chessboard1.SetupInitialPosition();
                chessboard1.Enabled = false;
                chessOpeningInfo1.Clear();
                chessOpeningInfo1.Enabled = false;
                SelectedRepertoire = null;
            }
            else
            if (nodeType == typeof(OpeningRepertoire))
            {
                chessboard1.SetupInitialPosition();
                chessboard1.Enabled = true;
                chessOpeningInfo1.Clear();
                chessOpeningInfo1.Enabled = false;
                SelectedRepertoire = (OpeningRepertoire)clickedNode.Tag;
                chessboard1.BoardDirection = SelectedRepertoire.Color == ChessColor.White ? BoardDirection.BlackOnTop : BoardDirection.WhiteOnTop;
            }
            else
            if (nodeType == typeof(OpeningMove))
            {
                SelectedRepertoire = GetParentRepertoire(TrvRepertoires.SelectedNode);
                chessboard1.Enabled = true;
                var selectedMove = (OpeningMove)clickedNode.Tag;
                chessboard1.LoadFEN(selectedMove.FenPosition);
                ShowOpeningInfo(selectedMove);
                chessOpeningInfo1.Enabled = true;
                chessboard1.BoardDirection = SelectedRepertoire.Color == ChessColor.White ? BoardDirection.BlackOnTop : BoardDirection.WhiteOnTop;
            }
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(this.Book.Filename))
            {
                SaveAs();
            }
            else
            {
                try
                {
                    this.Book.Save();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void SaveAs()
        {
            var saveAs = new SaveFileDialog();
            saveAs.Filter = "Opening Books|*.coc|All Files|*.*";

            if (!string.IsNullOrWhiteSpace(this.Book.Filename))
            {
                var fileInfo = new FileInfo(this.Book.Filename);
                if (fileInfo.Exists) { saveAs.FileName = fileInfo.FullName; }
            }
            if (saveAs.ShowDialog() == DialogResult.OK)
            {
                this.Book.Filename = saveAs.FileName;
                try
                {
                    this.Book.Save();
                    SaveToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private TreeNode SearchExistingNode(ChessMove move)
        {
            try
            {
                if (TrvRepertoires.SelectedNode != null)
                {
                    foreach (TreeNode childNode in TrvRepertoires.SelectedNode.Nodes)
                    {
                        OpeningMove childMove = (OpeningMove)childNode.Tag;
                        if (childMove.Move == new OpeningHalfMove(move))
                        {
                            return childNode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                chessboard1.UndoMove();
                ShowError(ex);
            }
            return null;
        }

        private void ShowContextMenuForBook()
        {
            try
            {
                CtxMnuRepertoire.Items[_ctxMnuLoadNewBook].Enabled = true;
                CtxMnuRepertoire.Items[_ctxMnuRename].Enabled = true;
                CtxMnuRepertoire.Items[_ctxMnuDelete].Enabled = false;
                CtxMnuRepertoire.Show(Cursor.Position);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowContextMenuForMove()
        {
            try
            {
                CtxMnuRepertoire.Items[_ctxMnuLoadNewBook].Enabled = false;
                CtxMnuRepertoire.Items[_ctxMnuRename].Enabled = false;
                CtxMnuRepertoire.Items[_ctxMnuDelete].Enabled = true;
                CtxMnuRepertoire.Show(Cursor.Position);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowOpeningInfo(OpeningMove opening)
        {
            try
            {
                chessOpeningInfo1.OpeningName = opening.Name;
                chessOpeningInfo1.Eco = opening.ECO;
                chessOpeningInfo1.OpeningMove = opening.Move.ToSAN;
                chessOpeningInfo1.Comment = opening.Comment;
                chessOpeningInfo1.SelectName();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void UpdateOpeningInfo()
        {
            try
            {
                if (TrvRepertoires.SelectedNode != null && TrvRepertoires.SelectedNode.Tag.GetType() == typeof(OpeningMove))
                {
                    var selectedOpening = (OpeningMove)TrvRepertoires.SelectedNode.Tag;
                    selectedOpening.Name = chessOpeningInfo1.OpeningName;
                    selectedOpening.ECO = chessOpeningInfo1.Eco;
                    selectedOpening.Comment = chessOpeningInfo1.Comment;
                    TrvRepertoires.SelectedNode.Text = selectedOpening.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion Methods

        #region Events

        #region Context Menu

        private void CtxMnuRepertoire_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContexMenuItemClicked(e.ClickedItem);
        }

        #endregion Context Menu

        #region MainMenu

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(WorkingMode.Create);
        }

        private void LearnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(WorkingMode.Learn);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadBook();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(WorkingMode.Quiz);
        }


        #endregion MainMenu

        #region TreeView Repertoire

        private void TrvRepertoires_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ChangeQuizSelection(e.Node);
        }

        private void TrvRepertoires_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Action == TreeViewAction.ByKeyboard)
            {
                NodeSelected(e.Node);
            }
        }

        private void TrvRepertoires_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TrvRepertoires.SelectedNode = e.Node;
                var nodeType = e.Node.Tag.GetType();
                if (nodeType == typeof(OpeningBook))
                {
                    chessboard1.Enabled = false;
                    chessOpeningInfo1.Clear();
                    chessOpeningInfo1.Enabled = false;
                    ShowContextMenuForBook();
                }
                else if (nodeType == typeof(OpeningRepertoire))
                {
                    SelectedRepertoire = (OpeningRepertoire)e.Node.Tag;
                    chessOpeningInfo1.Clear();
                    chessOpeningInfo1.Enabled = true;
                }
                else if (nodeType == typeof(OpeningMove))
                {
                    chessboard1.Enabled = true;
                    chessOpeningInfo1.Clear();
                    chessOpeningInfo1.Enabled = true;
                    ShowContextMenuForMove();
                }
            }
            else
            {
                NodeSelected(e.Node);
            }
        }

        #endregion TreeView Repertoire

        #region Chessboard

        private void chessboard1_OnPieceMoved(Chessboard sender, ChessMove move)
        {
            TreeNode existingNode = SearchExistingNode(move);
            if (existingNode != null)
            {
                TrvRepertoires.SelectedNode = existingNode;
            }
            else
            {
                var newOpening = AddMove(move);
                if (newOpening != null)
                {
                    ShowOpeningInfo(newOpening);
                }
            }
        }

        #endregion Chessboard

        #region MoveInfo

        private void chessOpeningInfo1_OnInfoChaned(object sender, EventArgs e)
        {
            UpdateOpeningInfo();
        }

        #endregion MoveInfo

        #endregion Events
    }
}
