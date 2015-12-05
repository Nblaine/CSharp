namespace Inverted_Index
{
    partial class frmInvertedIndex
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRunSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStopWord = new System.Windows.Forms.TextBox();
            this.lstStopWords = new System.Windows.Forms.ListBox();
            this.btnAddStopWord = new System.Windows.Forms.Button();
            this.btnAddRange = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstResultsDisplay = new System.Windows.Forms.ListBox();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRunSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search String";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(949, 601);
            this.pnlMain.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(9, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(847, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // btnRunSearch
            // 
            this.btnRunSearch.Location = new System.Drawing.Point(862, 25);
            this.btnRunSearch.Name = "btnRunSearch";
            this.btnRunSearch.Size = new System.Drawing.Size(75, 26);
            this.btnRunSearch.TabIndex = 1;
            this.btnRunSearch.Text = "Search";
            this.btnRunSearch.UseVisualStyleBackColor = true;
            this.btnRunSearch.Click += new System.EventHandler(this.btnRunSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAddRange);
            this.groupBox2.Controls.Add(this.btnAddStopWord);
            this.groupBox2.Controls.Add(this.lstStopWords);
            this.groupBox2.Controls.Add(this.txtStopWord);
            this.groupBox2.Location = new System.Drawing.Point(3, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(943, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stopwords";
            // 
            // txtStopWord
            // 
            this.txtStopWord.Location = new System.Drawing.Point(9, 23);
            this.txtStopWord.Name = "txtStopWord";
            this.txtStopWord.Size = new System.Drawing.Size(347, 26);
            this.txtStopWord.TabIndex = 0;
            // 
            // lstStopWords
            // 
            this.lstStopWords.FormattingEnabled = true;
            this.lstStopWords.ItemHeight = 20;
            this.lstStopWords.Location = new System.Drawing.Point(362, 23);
            this.lstStopWords.Name = "lstStopWords";
            this.lstStopWords.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStopWords.Size = new System.Drawing.Size(572, 144);
            this.lstStopWords.TabIndex = 1;
            // 
            // btnAddStopWord
            // 
            this.btnAddStopWord.Location = new System.Drawing.Point(9, 55);
            this.btnAddStopWord.Name = "btnAddStopWord";
            this.btnAddStopWord.Size = new System.Drawing.Size(75, 29);
            this.btnAddStopWord.TabIndex = 2;
            this.btnAddStopWord.Text = "Add";
            this.btnAddStopWord.UseVisualStyleBackColor = true;
            // 
            // btnAddRange
            // 
            this.btnAddRange.Location = new System.Drawing.Point(90, 55);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(101, 29);
            this.btnAddRange.TabIndex = 3;
            this.btnAddRange.Text = "Add Range";
            this.btnAddRange.UseVisualStyleBackColor = true;
            this.btnAddRange.Click += new System.EventHandler(this.btnAddRange_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(197, 55);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 29);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(283, 55);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(69, 29);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvWords);
            this.groupBox3.Controls.Add(this.lstResultsDisplay);
            this.groupBox3.Location = new System.Drawing.Point(3, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(943, 266);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // lstResultsDisplay
            // 
            this.lstResultsDisplay.FormattingEnabled = true;
            this.lstResultsDisplay.ItemHeight = 20;
            this.lstResultsDisplay.Location = new System.Drawing.Point(9, 25);
            this.lstResultsDisplay.Name = "lstResultsDisplay";
            this.lstResultsDisplay.Size = new System.Drawing.Size(482, 224);
            this.lstResultsDisplay.TabIndex = 0;
            // 
            // dgvWords
            // 
            this.dgvWords.AllowUserToAddRows = false;
            this.dgvWords.AllowUserToDeleteRows = false;
            this.dgvWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWords.Location = new System.Drawing.Point(497, 25);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.Size = new System.Drawing.Size(440, 224);
            this.dgvWords.TabIndex = 1;
            // 
            // frmInvertedIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 601);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmInvertedIndex";
            this.Text = "Inverted Index";
            this.Load += new System.EventHandler(this.frmInvertedIndex_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRunSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddRange;
        private System.Windows.Forms.Button btnAddStopWord;
        private System.Windows.Forms.ListBox lstStopWords;
        private System.Windows.Forms.TextBox txtStopWord;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstResultsDisplay;
        private System.Windows.Forms.DataGridView dgvWords;
    }
}

