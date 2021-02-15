
namespace Chess_Openings_Coach
{
    partial class FrmGameStatisticsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NupGameCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NupWhiteWon = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NupDraw = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.NupBlackWon = new System.Windows.Forms.NumericUpDown();
            this.gameStatisticsControl1 = new Chess_Openings_Coach.GameStatisticsControl();
            ((System.ComponentModel.ISupportInitialize)(this.NupGameCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupWhiteWon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupBlackWon)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(321, 148);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.Location = new System.Drawing.Point(240, 148);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "&Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game count:";
            // 
            // NupGameCount
            // 
            this.NupGameCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NupGameCount.Location = new System.Drawing.Point(86, 44);
            this.NupGameCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NupGameCount.Name = "NupGameCount";
            this.NupGameCount.Size = new System.Drawing.Size(91, 20);
            this.NupGameCount.TabIndex = 2;
            this.NupGameCount.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NupGameCount.ValueChanged += new System.EventHandler(this.NupGameCount_ValueChanged);
            this.NupGameCount.Enter += new System.EventHandler(this.NupGameCount_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Whites won:";
            // 
            // NupWhiteWon
            // 
            this.NupWhiteWon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NupWhiteWon.Location = new System.Drawing.Point(86, 70);
            this.NupWhiteWon.Name = "NupWhiteWon";
            this.NupWhiteWon.Size = new System.Drawing.Size(91, 20);
            this.NupWhiteWon.TabIndex = 4;
            this.NupWhiteWon.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            this.NupWhiteWon.ValueChanged += new System.EventHandler(this.NupWhiteWon_ValueChanged);
            this.NupWhiteWon.Enter += new System.EventHandler(this.NupGameCount_Enter);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Draw count:";
            // 
            // NupDraw
            // 
            this.NupDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NupDraw.Location = new System.Drawing.Point(86, 96);
            this.NupDraw.Name = "NupDraw";
            this.NupDraw.Size = new System.Drawing.Size(91, 20);
            this.NupDraw.TabIndex = 6;
            this.NupDraw.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.NupDraw.ValueChanged += new System.EventHandler(this.NupDraw_ValueChanged);
            this.NupDraw.Enter += new System.EventHandler(this.NupGameCount_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Black won:";
            // 
            // NupBlackWon
            // 
            this.NupBlackWon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NupBlackWon.Enabled = false;
            this.NupBlackWon.Location = new System.Drawing.Point(86, 122);
            this.NupBlackWon.Name = "NupBlackWon";
            this.NupBlackWon.Size = new System.Drawing.Size(91, 20);
            this.NupBlackWon.TabIndex = 8;
            this.NupBlackWon.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            // 
            // gameStatisticsControl1
            // 
            this.gameStatisticsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameStatisticsControl1.GameCount = 1000000;
            this.gameStatisticsControl1.Location = new System.Drawing.Point(12, 12);
            this.gameStatisticsControl1.Name = "gameStatisticsControl1";
            this.gameStatisticsControl1.NullPercent = 34;
            this.gameStatisticsControl1.Size = new System.Drawing.Size(384, 13);
            this.gameStatisticsControl1.TabIndex = 0;
            this.gameStatisticsControl1.TabStop = false;
            this.gameStatisticsControl1.Text = "gameStatisticsControl1";
            this.gameStatisticsControl1.WhitePercent = 33;
            // 
            // FrmGameStatisticsEditor
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(408, 183);
            this.Controls.Add(this.gameStatisticsControl1);
            this.Controls.Add(this.NupBlackWon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NupDraw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NupWhiteWon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NupGameCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGameStatisticsEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.NupGameCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupWhiteWon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupDraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NupBlackWon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NupGameCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NupWhiteWon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NupDraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NupBlackWon;
        private GameStatisticsControl gameStatisticsControl1;
    }
}