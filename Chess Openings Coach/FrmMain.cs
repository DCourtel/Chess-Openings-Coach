﻿using ChessboardControl;
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
        private bool _updatingSelection = false;
        private const string _ctxMnuLoadNewBook = "Load new book…";
        private const string _ctxMnuRename = "Rename…";
        private const string _ctxMnuDelete = "Delete";
        private const string _selectAllChildren = "SelectAllChildren";
        private const string _expandAllChildren = "ExpandAllChildren";
        private Random _rnd = new Random(DateTime.Now.Millisecond);

        private enum WorkingMode
        {
            Create,
            Learn,
            Quiz
        }

        private readonly System.Resources.ResourceManager resMan = new System.Resources.ResourceManager("Chess_Openings_Coach.Internationalization.Resources", typeof(FrmMain).Assembly);

        public FrmMain()
        {
            //  System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            CreateDefaultBook();
            CreateContextMenu();
            ChangeTheme(IsDarkThemeEnabled);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the currently opened chess opening book.
        /// </summary>
        private OpeningBook Book { get; set; }

        /// <summary>
        /// Gets if dark mode is enabled.
        /// </summary>
        private bool IsDarkThemeEnabled
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
        /// Gets or sets for which color the user is learning/quizzing.
        /// </summary>
        private ChessColor WorkColor { get; set; } = ChessColor.White;

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
                        var newMove = new OpeningMove(new OpeningHalfMove(move), moveColor, moveIndex, chessboard1.GetFEN())
                        {
                            Name = currentMove.Name,
                            ECO = currentMove.ECO
                        };
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
                        CtxMnuRepertoire.Hide();
                        var newNameDlg = new FrmRenameBook(this.Book.Name);
                        if (newNameDlg.ShowDialog() == DialogResult.OK)
                        {
                            this.Book.Name = newNameDlg.NewName;
                            TrvRepertoires.Nodes[0].Text = newNameDlg.NewName;
                        }
                        break;
                    case _selectAllChildren:
                        _updatingSelection = true;
                        ChangeAllChildNodesSelection(TrvRepertoires.SelectedNode, !TrvRepertoires.SelectedNode.Checked);
                        TrvRepertoires.SelectedNode.Checked = !TrvRepertoires.SelectedNode.Checked;
                        TrvRepertoires.SelectedNode.ExpandAll();
                        _updatingSelection = false;
                        break;
                    case _expandAllChildren:
                        if (TrvRepertoires.SelectedNode.IsExpanded)
                        { TrvRepertoires.SelectedNode.Collapse(); }
                        else
                        { TrvRepertoires.SelectedNode.ExpandAll(); }
                        break;
                    case _ctxMnuDelete:
                        CtxMnuRepertoire.Hide();
                        if (MessageBox.Show(Translate("Msg_SureToDelete"),
                            Translate("Msg_Confirmation"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            try
                            {
                                TreeNode selectedNode = TrvRepertoires.SelectedNode;
                                TreeNode parentNode = selectedNode.Parent;
                                OpeningMove parentMove = (OpeningMove)parentNode.Tag;
                                OpeningMove selectedMove = (OpeningMove)selectedNode.Tag;

                                parentMove.Children.Remove(selectedMove);
                                parentNode.Nodes.Remove(selectedNode);
                                NodeSelected(parentNode);
                            }
                            catch (Exception ex)
                            {
                                ShowError(ex);
                            }
                        }
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
                ToolStripMenuItem loadNewBookItem = new ToolStripMenuItem(Translate("ctxMnu_LoadNewBook"), Properties.Resources.folder_open_32)
                {
                    Enabled = false,
                    Name = _ctxMnuLoadNewBook
                };
                ToolStripMenuItem renameItem = new ToolStripMenuItem(Translate("ctxMnu_Rename"), Properties.Resources.pen_32)
                {
                    Enabled = false,
                    Name = _ctxMnuRename
                };
                ToolStripMenuItem selectAllChildrenItem = new ToolStripMenuItem(Translate("ctxMnu_SelectAllChildren"), Properties.Resources.selectAll_32)
                {
                    Enabled = false,
                    Name = _selectAllChildren
                };
                ToolStripMenuItem expandAllChildrenItem = new ToolStripMenuItem(Translate("ctxMnu_ExpandAllChildren"), Properties.Resources.ExpandAll_32)
                {
                    Enabled = false,
                    Name = _expandAllChildren
                };
                ToolStripMenuItem deleteItem = new ToolStripMenuItem(Translate("ctxMnu_Delete"), Properties.Resources.delete_32)
                {
                    Enabled = false,
                    Name = _ctxMnuDelete
                };

                CtxMnuRepertoire.Items.Add(loadNewBookItem);
                CtxMnuRepertoire.Items.Add(renameItem);
                CtxMnuRepertoire.Items.Add(selectAllChildrenItem);
                CtxMnuRepertoire.Items.Add(expandAllChildrenItem);
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

        private void ChangeAllChildNodesSelection(TreeNode node, bool isChecked)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                OpeningMove move = (OpeningMove)childNode.Tag;
                childNode.Checked = isChecked;
                move.Selected = isChecked;
                if (childNode.Nodes.Count > 0) { ChangeAllChildNodesSelection(childNode, isChecked); }
            }
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
                    SetupLearningMode();
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
                    _updatingSelection = true;
                    ChangeAllChildNodesSelection(selectedNode, selectedNode.Checked);
                    _updatingSelection = false;
                }
                else if (nodeType == typeof(OpeningBook))
                {
                    var blackRepertoire = (OpeningRepertoire)_blackRepertoireNode.Tag;
                    var whiteRepertoire = (OpeningRepertoire)_whiteRepertoireNode.Tag;
                    blackRepertoire.Selected = selectedNode.Checked;
                    whiteRepertoire.Selected = selectedNode.Checked;

                    _updatingSelection = true;
                    _whiteRepertoireNode.Checked = selectedNode.Checked;
                    _blackRepertoireNode.Checked = selectedNode.Checked;
                    ChangeAllChildNodesSelection(_whiteRepertoireNode, selectedNode.Checked);
                    ChangeAllChildNodesSelection(_blackRepertoireNode, selectedNode.Checked);
                    _updatingSelection = false;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            TrvRepertoires.SelectedNode = selectedNode;
            TrvRepertoires.Focus();
        }

        private OpeningRepertoire GetParentRepertoire(TreeNode childNode)
        {
            if (childNode == null) { return null; }
            if (childNode == _whiteRepertoireNode && _whiteRepertoireNode.Tag != null) { return (OpeningRepertoire)_whiteRepertoireNode.Tag; }
            if (childNode == _blackRepertoireNode && _blackRepertoireNode.Tag != null) { return (OpeningRepertoire)_blackRepertoireNode.Tag; }

            return GetParentRepertoire(childNode.Parent);
        }

        private TreeNode GetRandomEnabledChildNode(TreeNode parentNode)
        {
            var enabledChildNodes = new List<TreeNode>();
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                if (childNode.Checked)
                {
                    enabledChildNodes.Add(childNode);
                }
            }
            if (enabledChildNodes.Count > 0)
            {
                return enabledChildNodes[GetRandomNumber(0, enabledChildNodes.Count)];
            }
            return null;
        }

        private int GetRandomNumber(int min, int max)
        {
            return _rnd.Next(min, max);
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
                    QuitToolStripMenuItem.Enabled = true;
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

            TrvRepertoires.Focus();
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

        private void SetupLearningMode()
        {
            if (TrvRepertoires.SelectedNode == null || TrvRepertoires.SelectedNode == TrvRepertoires.Nodes[0])
            {
                //  If the root node is selected, choose Black or White randomly
                TrvRepertoires.SelectedNode = (GetRandomNumber(0, 10) <= 4 ? _whiteRepertoireNode : _blackRepertoireNode);
                chessboard1.Enabled = true;
            }
            SelectedRepertoire = GetParentRepertoire(TrvRepertoires.SelectedNode);
            WorkColor = SelectedRepertoire.Color;
            SetupLearningMode(WorkColor);
        }

        private void SetupLearningMode(ChessColor color)
        {
            TrvRepertoires.SelectedNode = (color == ChessColor.White ? _whiteRepertoireNode : _blackRepertoireNode);
            NodeSelected(TrvRepertoires.SelectedNode);
            if (color == ChessColor.Black)
            {
                chessboard1.BoardDirection = BoardDirection.WhiteOnTop;
                var childNode = GetRandomEnabledChildNode(TrvRepertoires.SelectedNode);
                if (childNode == null)
                {
                    MessageBox.Show(Translate("Msg_EnableAtLeastOneLine"));
                }
                else
                {
                    TrvRepertoires.SelectedNode = childNode;
                    NodeSelected(childNode);
                }
            }
            else
            {
                chessboard1.BoardDirection = BoardDirection.BlackOnTop;
            }
        }

        private void ShowContextMenuForBook()
        {
            try
            {
                CtxMnuRepertoire.Items[_ctxMnuLoadNewBook].Enabled = true;
                CtxMnuRepertoire.Items[_ctxMnuRename].Enabled = true;
                CtxMnuRepertoire.Items[_selectAllChildren].Enabled = false;
                CtxMnuRepertoire.Items[_expandAllChildren].Enabled = false;
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
                CtxMnuRepertoire.Items[_selectAllChildren].Enabled = true;
                CtxMnuRepertoire.Items[_selectAllChildren].Text = TrvRepertoires.SelectedNode.Checked ? Translate("ctxMnu_UnselectAllChildren") : Translate("ctxMnu_SelectAllChildren");
                CtxMnuRepertoire.Items[_expandAllChildren].Enabled = true;
                CtxMnuRepertoire.Items[_expandAllChildren].Text = TrvRepertoires.SelectedNode.IsExpanded ? Translate("ctxMnu_CollapseAllChildren") : Translate("ctxMnu_ExpandAllChildren");
                CtxMnuRepertoire.Items[_expandAllChildren].Image = TrvRepertoires.SelectedNode.IsExpanded ? Properties.Resources.CollapseAll_32 : Properties.Resources.ExpandAll_32;
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
                chessOpeningInfo1.MoveAnnotation = opening.MoveAnnotation;
                chessOpeningInfo1.Comment = opening.Comment;
                chessOpeningInfo1.SelectName();
                chessOpeningInfo1.GameCount = opening.MoveStat.GameCount;
                chessOpeningInfo1.WhitePercent = opening.MoveStat.WhiteStat;
                chessOpeningInfo1.NullPercent = opening.MoveStat.NullStat;
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
                    selectedOpening.MoveAnnotation = chessOpeningInfo1.MoveAnnotation;
                    selectedOpening.Comment = chessOpeningInfo1.Comment;
                    selectedOpening.MoveStat.GameCount = chessOpeningInfo1.GameCount;
                    selectedOpening.MoveStat.WhiteStat = chessOpeningInfo1.WhitePercent;
                    selectedOpening.MoveStat.NullStat = chessOpeningInfo1.NullPercent;
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
            if (!_updatingSelection)
            { ChangeQuizSelection(e.Node); }
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
                NodeSelected(existingNode);
                switch (WorkMode)
                {
                    case WorkingMode.Create:
                        break;
                    case WorkingMode.Learn:
                        var childNode = GetRandomEnabledChildNode(existingNode);
                        if (childNode == null)
                        {
                            if (MessageBox.Show(Translate("Msg_NomoreChildNode"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                SetupLearningMode(WorkColor);
                            }
                        }
                        else
                        {
                            TrvRepertoires.SelectedNode = childNode;
                            NodeSelected(childNode);
                            if (GetRandomEnabledChildNode(childNode) == null)
                            {
                                //  No more moves for the user
                                if (MessageBox.Show(Translate("Msg_NomoreChildNode"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    SetupLearningMode(WorkColor);
                                }
                            }
                        }
                        break;
                    case WorkingMode.Quiz:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (WorkMode)
                {
                    case WorkingMode.Create:
                        var newOpening = AddMove(move);
                        if (newOpening != null)
                        {
                            ShowOpeningInfo(newOpening);
                        }
                        break;
                    case WorkingMode.Learn:
                        //  Played a wrong move
                        MessageBox.Show(Translate("Msg_NotChildMove"), Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chessboard1.UndoMove();
                        break;
                    case WorkingMode.Quiz:
                        break;
                    default:
                        break;
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
