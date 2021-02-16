
namespace Chess_Openings_Coach
{
    partial class ChessOpeningInfo
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBxECO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBxMove = new System.Windows.Forms.TextBox();
            this.TxtBxComment = new System.Windows.Forms.TextBox();
            this.gameStatisticsControl1 = new Chess_Openings_Coach.GameStatisticsControl();
            this.CmbBxAnnotation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // TxtBxName
            // 
            this.TxtBxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxName.Location = new System.Drawing.Point(50, 3);
            this.TxtBxName.Name = "TxtBxName";
            this.TxtBxName.Size = new System.Drawing.Size(375, 23);
            this.TxtBxName.TabIndex = 1;
            this.TxtBxName.TextChanged += new System.EventHandler(this.TxtBx_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ECO: ";
            // 
            // TxtBxECO
            // 
            this.TxtBxECO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxECO.Location = new System.Drawing.Point(50, 32);
            this.TxtBxECO.Name = "TxtBxECO";
            this.TxtBxECO.Size = new System.Drawing.Size(50, 23);
            this.TxtBxECO.TabIndex = 3;
            this.TxtBxECO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtBxECO.TextChanged += new System.EventHandler(this.TxtBx_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Move: ";
            // 
            // TxtBxMove
            // 
            this.TxtBxMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBxMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxMove.Location = new System.Drawing.Point(273, 32);
            this.TxtBxMove.Name = "TxtBxMove";
            this.TxtBxMove.ReadOnly = true;
            this.TxtBxMove.Size = new System.Drawing.Size(52, 23);
            this.TxtBxMove.TabIndex = 5;
            this.TxtBxMove.TabStop = false;
            // 
            // TxtBxComment
            // 
            this.TxtBxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxComment.Location = new System.Drawing.Point(50, 80);
            this.TxtBxComment.Multiline = true;
            this.TxtBxComment.Name = "TxtBxComment";
            this.TxtBxComment.Size = new System.Drawing.Size(375, 91);
            this.TxtBxComment.TabIndex = 8;
            this.TxtBxComment.TextChanged += new System.EventHandler(this.TxtBx_TextChanged);
            // 
            // gameStatisticsControl1
            // 
            this.gameStatisticsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameStatisticsControl1.GameCount = 0;
            this.gameStatisticsControl1.Location = new System.Drawing.Point(53, 61);
            this.gameStatisticsControl1.Name = "gameStatisticsControl1";
            this.gameStatisticsControl1.NullPercent = 34;
            this.gameStatisticsControl1.Size = new System.Drawing.Size(375, 13);
            this.gameStatisticsControl1.TabIndex = 7;
            this.gameStatisticsControl1.Text = "gameStatisticsControl1";
            this.gameStatisticsControl1.WhitePercent = 33;
            this.gameStatisticsControl1.DoubleClick += new System.EventHandler(this.gameStatisticsControl1_DoubleClick);
            // 
            // CmbBxAnnotation
            // 
            this.CmbBxAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBxAnnotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBxAnnotation.FormattingEnabled = true;
            this.CmbBxAnnotation.Items.AddRange(new object[] {
            "??",
            "?",
            "?!",
            "!?",
            "!",
            "!!"});
            this.CmbBxAnnotation.Location = new System.Drawing.Point(331, 33);
            this.CmbBxAnnotation.Name = "CmbBxAnnotation";
            this.CmbBxAnnotation.Size = new System.Drawing.Size(94, 21);
            this.CmbBxAnnotation.TabIndex = 6;
            this.CmbBxAnnotation.SelectedIndexChanged += new System.EventHandler(this.CmbBxAnnotation_SelectedIndexChanged);
            // 
            // ChessOpeningInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CmbBxAnnotation);
            this.Controls.Add(this.gameStatisticsControl1);
            this.Controls.Add(this.TxtBxComment);
            this.Controls.Add(this.TxtBxMove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBxECO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBxName);
            this.Controls.Add(this.label1);
            this.Name = "ChessOpeningInfo";
            this.Size = new System.Drawing.Size(428, 174);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBxECO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBxMove;
        private System.Windows.Forms.TextBox TxtBxComment;
        private GameStatisticsControl gameStatisticsControl1;
        private System.Windows.Forms.ComboBox CmbBxAnnotation;
    }
}
