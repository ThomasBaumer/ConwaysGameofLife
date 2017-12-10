namespace GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BTNTick = new System.Windows.Forms.Button();
            this.LabelOutput = new System.Windows.Forms.Label();
            this.BTNAutoTick = new System.Windows.Forms.Button();
            this.BTNReset = new System.Windows.Forms.Button();
            this.BTNExit = new System.Windows.Forms.Button();
            this.LabelRow = new System.Windows.Forms.Label();
            this.LabelCol = new System.Windows.Forms.Label();
            this.CBRow = new System.Windows.Forms.ComboBox();
            this.CBCol = new System.Windows.Forms.ComboBox();
            this.BTNOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTNTick
            // 
            this.BTNTick.Location = new System.Drawing.Point(12, 532);
            this.BTNTick.Name = "BTNTick";
            this.BTNTick.Size = new System.Drawing.Size(75, 23);
            this.BTNTick.TabIndex = 0;
            this.BTNTick.Text = "Tick";
            this.BTNTick.UseVisualStyleBackColor = true;
            this.BTNTick.Click += new System.EventHandler(this.BTNTick_Click);
            // 
            // LabelOutput
            // 
            this.LabelOutput.AutoSize = true;
            this.LabelOutput.Font = new System.Drawing.Font("Consolas", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOutput.Location = new System.Drawing.Point(12, 9);
            this.LabelOutput.Name = "LabelOutput";
            this.LabelOutput.Size = new System.Drawing.Size(154, 56);
            this.LabelOutput.TabIndex = 1;
            this.LabelOutput.Text = "Space";
            this.LabelOutput.Click += new System.EventHandler(this.LabelOutput_Click);
            // 
            // BTNAutoTick
            // 
            this.BTNAutoTick.Location = new System.Drawing.Point(93, 532);
            this.BTNAutoTick.Name = "BTNAutoTick";
            this.BTNAutoTick.Size = new System.Drawing.Size(75, 23);
            this.BTNAutoTick.TabIndex = 2;
            this.BTNAutoTick.Text = "Auto Tick";
            this.BTNAutoTick.UseVisualStyleBackColor = true;
            this.BTNAutoTick.Click += new System.EventHandler(this.BTNAutoTick_Click);
            // 
            // BTNReset
            // 
            this.BTNReset.Location = new System.Drawing.Point(644, 532);
            this.BTNReset.Name = "BTNReset";
            this.BTNReset.Size = new System.Drawing.Size(75, 23);
            this.BTNReset.TabIndex = 3;
            this.BTNReset.Text = "Reset";
            this.BTNReset.UseVisualStyleBackColor = true;
            this.BTNReset.Click += new System.EventHandler(this.BTNReset_Click);
            // 
            // BTNExit
            // 
            this.BTNExit.Location = new System.Drawing.Point(725, 532);
            this.BTNExit.Name = "BTNExit";
            this.BTNExit.Size = new System.Drawing.Size(75, 23);
            this.BTNExit.TabIndex = 4;
            this.BTNExit.Text = "Exit";
            this.BTNExit.UseVisualStyleBackColor = true;
            this.BTNExit.Click += new System.EventHandler(this.BTNExit_Click);
            // 
            // LabelRow
            // 
            this.LabelRow.AutoSize = true;
            this.LabelRow.Location = new System.Drawing.Point(330, 508);
            this.LabelRow.Name = "LabelRow";
            this.LabelRow.Size = new System.Drawing.Size(46, 17);
            this.LabelRow.TabIndex = 5;
            this.LabelRow.Text = "Rows:";
            // 
            // LabelCol
            // 
            this.LabelCol.AutoSize = true;
            this.LabelCol.Location = new System.Drawing.Point(310, 538);
            this.LabelCol.Name = "LabelCol";
            this.LabelCol.Size = new System.Drawing.Size(66, 17);
            this.LabelCol.TabIndex = 6;
            this.LabelCol.Text = "Columns:";
            // 
            // CBRow
            // 
            this.CBRow.FormattingEnabled = true;
            this.CBRow.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.CBRow.Location = new System.Drawing.Point(382, 501);
            this.CBRow.Name = "CBRow";
            this.CBRow.Size = new System.Drawing.Size(121, 24);
            this.CBRow.TabIndex = 8;
            // 
            // CBCol
            // 
            this.CBCol.FormattingEnabled = true;
            this.CBCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.CBCol.Location = new System.Drawing.Point(382, 531);
            this.CBCol.Name = "CBCol";
            this.CBCol.Size = new System.Drawing.Size(121, 24);
            this.CBCol.TabIndex = 9;
            // 
            // BTNOk
            // 
            this.BTNOk.Location = new System.Drawing.Point(509, 532);
            this.BTNOk.Name = "BTNOk";
            this.BTNOk.Size = new System.Drawing.Size(75, 23);
            this.BTNOk.TabIndex = 10;
            this.BTNOk.Text = "OK";
            this.BTNOk.UseVisualStyleBackColor = true;
            this.BTNOk.Click += new System.EventHandler(this.BTNOk_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 567);
            this.Controls.Add(this.BTNOk);
            this.Controls.Add(this.CBCol);
            this.Controls.Add(this.CBRow);
            this.Controls.Add(this.LabelCol);
            this.Controls.Add(this.LabelRow);
            this.Controls.Add(this.BTNExit);
            this.Controls.Add(this.BTNReset);
            this.Controls.Add(this.BTNAutoTick);
            this.Controls.Add(this.LabelOutput);
            this.Controls.Add(this.BTNTick);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNTick;
        private System.Windows.Forms.Label LabelOutput;
        private System.Windows.Forms.Button BTNAutoTick;
        private System.Windows.Forms.Button BTNReset;
        private System.Windows.Forms.Button BTNExit;
        private System.Windows.Forms.Label LabelRow;
        private System.Windows.Forms.Label LabelCol;
        private System.Windows.Forms.ComboBox CBRow;
        private System.Windows.Forms.ComboBox CBCol;
        private System.Windows.Forms.Button BTNOk;
    }
}

