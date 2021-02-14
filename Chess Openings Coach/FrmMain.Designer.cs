
namespace Chess_Openings_Coach
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TrvRepertoires = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chessboard1 = new ChessboardControl.Chessboard();
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LearnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxMnuRepertoire = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chessOpeningInfo1 = new Chess_Openings_Coach.ChessOpeningInfo();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TrvRepertoires);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // TrvRepertoires
            // 
            this.TrvRepertoires.CheckBoxes = true;
            resources.ApplyResources(this.TrvRepertoires, "TrvRepertoires");
            this.TrvRepertoires.ForeColor = System.Drawing.Color.DarkGray;
            this.TrvRepertoires.Name = "TrvRepertoires";
            this.TrvRepertoires.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvRepertoires_AfterCheck);
            this.TrvRepertoires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvRepertoires_AfterSelect);
            this.TrvRepertoires.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvRepertoires_NodeMouseClick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.chessboard1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chessOpeningInfo1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // chessboard1
            // 
            resources.ApplyResources(this.chessboard1, "chessboard1");
            this.chessboard1.Name = "chessboard1";
            this.chessboard1.ShowVisualHints = false;
            this.chessboard1.OnPieceMoved += new ChessboardControl.Chessboard.PieceMovedEventHandler(this.chessboard1_OnPieceMoved);
            // 
            // MnuMain
            // 
            this.MnuMain.BackColor = System.Drawing.SystemColors.Control;
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.aideToolStripMenuItem});
            resources.ApplyResources(this.MnuMain, "MnuMain");
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.toolStripSeparator,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.QuitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.NewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.NewToolStripMenuItem, "NewToolStripMenuItem");
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            // 
            // OpenToolStripMenuItem
            // 
            resources.ApplyResources(this.OpenToolStripMenuItem, "OpenToolStripMenuItem");
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // SaveToolStripMenuItem
            // 
            resources.ApplyResources(this.SaveToolStripMenuItem, "SaveToolStripMenuItem");
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.SaveAsToolStripMenuItem, "SaveAsToolStripMenuItem");
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            resources.ApplyResources(this.QuitToolStripMenuItem, "QuitToolStripMenuItem");
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator3,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.SelectAllToolStripMenuItem});
            resources.ApplyResources(this.editionToolStripMenuItem, "editionToolStripMenuItem");
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            resources.ApplyResources(this.CancelToolStripMenuItem, "CancelToolStripMenuItem");
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            resources.ApplyResources(this.RedoToolStripMenuItem, "RedoToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // CutToolStripMenuItem
            // 
            resources.ApplyResources(this.CutToolStripMenuItem, "CutToolStripMenuItem");
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            // 
            // CopyToolStripMenuItem
            // 
            resources.ApplyResources(this.CopyToolStripMenuItem, "CopyToolStripMenuItem");
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            // 
            // PasteToolStripMenuItem
            // 
            resources.ApplyResources(this.PasteToolStripMenuItem, "PasteToolStripMenuItem");
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            resources.ApplyResources(this.SelectAllToolStripMenuItem, "SelectAllToolStripMenuItem");
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.LearnToolStripMenuItem,
            this.QuizToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            resources.ApplyResources(this.modeToolStripMenuItem, "modeToolStripMenuItem");
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Checked = true;
            this.CreateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            resources.ApplyResources(this.CreateToolStripMenuItem, "CreateToolStripMenuItem");
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // LearnToolStripMenuItem
            // 
            this.LearnToolStripMenuItem.Name = "LearnToolStripMenuItem";
            resources.ApplyResources(this.LearnToolStripMenuItem, "LearnToolStripMenuItem");
            this.LearnToolStripMenuItem.Click += new System.EventHandler(this.LearnToolStripMenuItem_Click);
            // 
            // QuizToolStripMenuItem
            // 
            this.QuizToolStripMenuItem.Name = "QuizToolStripMenuItem";
            resources.ApplyResources(this.QuizToolStripMenuItem, "QuizToolStripMenuItem");
            this.QuizToolStripMenuItem.Click += new System.EventHandler(this.QuizToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            resources.ApplyResources(this.aideToolStripMenuItem, "aideToolStripMenuItem");
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            // 
            // CtxMnuRepertoire
            // 
            resources.ApplyResources(this.CtxMnuRepertoire, "CtxMnuRepertoire");
            this.CtxMnuRepertoire.Name = "CtxMnuRepertoire";
            this.CtxMnuRepertoire.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CtxMnuRepertoire_ItemClicked);
            // 
            // chessOpeningInfo1
            // 
            this.chessOpeningInfo1.BackColor = System.Drawing.SystemColors.Window;
            this.chessOpeningInfo1.Comment = "";
            resources.ApplyResources(this.chessOpeningInfo1, "chessOpeningInfo1");
            this.chessOpeningInfo1.Eco = "";
            this.chessOpeningInfo1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chessOpeningInfo1.Name = "chessOpeningInfo1";
            this.chessOpeningInfo1.OpeningMove = "";
            this.chessOpeningInfo1.OpeningName = "";
            this.chessOpeningInfo1.UseDarkTheme = false;
            this.chessOpeningInfo1.OnInfoChanged += new System.EventHandler(this.chessOpeningInfo1_OnInfoChaned);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MnuMain);
            this.MainMenuStrip = this.MnuMain;
            this.Name = "FrmMain";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChessboardControl.Chessboard chessboard1;
        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LearnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView TrvRepertoires;
        private System.Windows.Forms.ContextMenuStrip CtxMnuRepertoire;
        private ChessOpeningInfo chessOpeningInfo1;
        private System.Windows.Forms.ToolStripMenuItem QuizToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

