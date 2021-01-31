
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
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rétablirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.couperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sélectionnertoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personnaliserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.àproposdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chessboard1 = new ChessboardControl.Chessboard();
            this.TrvRepertoires = new System.Windows.Forms.TreeView();
            this.chessOpeningInfo1 = new Chess_Openings_Coach.ChessOpeningInfo();
            this.CtxMnuRepertoire = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuMain
            // 
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.aideToolStripMenuItem});
            resources.ApplyResources(this.MnuMain, "MnuMain");
            this.MnuMain.Name = "MnuMain";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator,
            this.enregistrerToolStripMenuItem,
            this.enregistrersousToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            resources.ApplyResources(this.fichierToolStripMenuItem, "fichierToolStripMenuItem");
            // 
            // nouveauToolStripMenuItem
            // 
            resources.ApplyResources(this.nouveauToolStripMenuItem, "nouveauToolStripMenuItem");
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            // 
            // ouvrirToolStripMenuItem
            // 
            resources.ApplyResources(this.ouvrirToolStripMenuItem, "ouvrirToolStripMenuItem");
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // enregistrerToolStripMenuItem
            // 
            resources.ApplyResources(this.enregistrerToolStripMenuItem, "enregistrerToolStripMenuItem");
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // enregistrersousToolStripMenuItem
            // 
            this.enregistrersousToolStripMenuItem.Name = "enregistrersousToolStripMenuItem";
            resources.ApplyResources(this.enregistrersousToolStripMenuItem, "enregistrersousToolStripMenuItem");
            this.enregistrersousToolStripMenuItem.Click += new System.EventHandler(this.enregistrersousToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            resources.ApplyResources(this.quitterToolStripMenuItem, "quitterToolStripMenuItem");
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.rétablirToolStripMenuItem,
            this.toolStripSeparator3,
            this.couperToolStripMenuItem,
            this.copierToolStripMenuItem,
            this.collerToolStripMenuItem,
            this.toolStripSeparator4,
            this.sélectionnertoutToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            resources.ApplyResources(this.editionToolStripMenuItem, "editionToolStripMenuItem");
            // 
            // annulerToolStripMenuItem
            // 
            this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
            resources.ApplyResources(this.annulerToolStripMenuItem, "annulerToolStripMenuItem");
            // 
            // rétablirToolStripMenuItem
            // 
            this.rétablirToolStripMenuItem.Name = "rétablirToolStripMenuItem";
            resources.ApplyResources(this.rétablirToolStripMenuItem, "rétablirToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // couperToolStripMenuItem
            // 
            resources.ApplyResources(this.couperToolStripMenuItem, "couperToolStripMenuItem");
            this.couperToolStripMenuItem.Name = "couperToolStripMenuItem";
            // 
            // copierToolStripMenuItem
            // 
            resources.ApplyResources(this.copierToolStripMenuItem, "copierToolStripMenuItem");
            this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
            // 
            // collerToolStripMenuItem
            // 
            resources.ApplyResources(this.collerToolStripMenuItem, "collerToolStripMenuItem");
            this.collerToolStripMenuItem.Name = "collerToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // sélectionnertoutToolStripMenuItem
            // 
            this.sélectionnertoutToolStripMenuItem.Name = "sélectionnertoutToolStripMenuItem";
            resources.ApplyResources(this.sélectionnertoutToolStripMenuItem, "sélectionnertoutToolStripMenuItem");
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personnaliserToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            resources.ApplyResources(this.outilsToolStripMenuItem, "outilsToolStripMenuItem");
            // 
            // personnaliserToolStripMenuItem
            // 
            this.personnaliserToolStripMenuItem.Name = "personnaliserToolStripMenuItem";
            resources.ApplyResources(this.personnaliserToolStripMenuItem, "personnaliserToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.àproposdeToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            resources.ApplyResources(this.aideToolStripMenuItem, "aideToolStripMenuItem");
            // 
            // àproposdeToolStripMenuItem
            // 
            this.àproposdeToolStripMenuItem.Name = "àproposdeToolStripMenuItem";
            resources.ApplyResources(this.àproposdeToolStripMenuItem, "àproposdeToolStripMenuItem");
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.chessboard1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TrvRepertoires, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chessOpeningInfo1, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // chessboard1
            // 
            resources.ApplyResources(this.chessboard1, "chessboard1");
            this.chessboard1.Name = "chessboard1";
            this.chessboard1.ShowVisualHints = false;
            this.chessboard1.OnPieceMoved += new ChessboardControl.Chessboard.PieceMovedEventHandler(this.chessboard1_OnPieceMoved);
            // 
            // TrvRepertoires
            // 
            this.TrvRepertoires.CheckBoxes = true;
            resources.ApplyResources(this.TrvRepertoires, "TrvRepertoires");
            this.TrvRepertoires.Name = "TrvRepertoires";
            this.tableLayoutPanel1.SetRowSpan(this.TrvRepertoires, 2);
            this.TrvRepertoires.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvRepertoires_AfterCheck);
            this.TrvRepertoires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvRepertoires_AfterSelect);
            this.TrvRepertoires.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvRepertoires_NodeMouseClick);
            // 
            // chessOpeningInfo1
            // 
            this.chessOpeningInfo1.Comment = "";
            resources.ApplyResources(this.chessOpeningInfo1, "chessOpeningInfo1");
            this.chessOpeningInfo1.Eco = "";
            this.chessOpeningInfo1.Name = "chessOpeningInfo1";
            this.chessOpeningInfo1.OpeningMove = "";
            this.chessOpeningInfo1.OpeningName = "";
            this.chessOpeningInfo1.OnInfoChanged += new System.EventHandler(this.chessOpeningInfo1_OnInfoChaned);
            // 
            // CtxMnuRepertoire
            // 
            this.CtxMnuRepertoire.Name = "CtxMnuRepertoire";
            resources.ApplyResources(this.CtxMnuRepertoire, "CtxMnuRepertoire");
            this.CtxMnuRepertoire.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CtxMnuRepertoire_ItemClicked);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MnuMain);
            this.MainMenuStrip = this.MnuMain;
            this.Name = "FrmMain";
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChessboardControl.Chessboard chessboard1;
        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrersousToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rétablirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem couperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sélectionnertoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personnaliserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem àproposdeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView TrvRepertoires;
        private System.Windows.Forms.ContextMenuStrip CtxMnuRepertoire;
        private ChessOpeningInfo chessOpeningInfo1;
    }
}

