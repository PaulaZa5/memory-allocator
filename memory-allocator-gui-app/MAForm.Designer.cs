namespace memory_allocation_gui_app
{
    partial class memAllocator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memAllocator));
            this.outResizeLbl = new System.Windows.Forms.Label();
            this.outResizeBar = new System.Windows.Forms.TrackBar();
            this.addBtn = new System.Windows.Forms.Button();
            this.worstFitRad = new System.Windows.Forms.RadioButton();
            this.bestFitRad = new System.Windows.Forms.RadioButton();
            this.firstFitRad = new System.Windows.Forms.RadioButton();
            this.processSizeTxt = new System.Windows.Forms.TextBox();
            this.processSizeLbl = new System.Windows.Forms.Label();
            this.processNameTxt = new System.Windows.Forms.TextBox();
            this.processNameLbl = new System.Windows.Forms.Label();
            this.holeSizeTxt = new System.Windows.Forms.TextBox();
            this.holeSizeLbl = new System.Windows.Forms.Label();
            this.holeStartAddressTxt = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.memorySizeTxt = new System.Windows.Forms.TextBox();
            this.holeStartAddressLbl = new System.Windows.Forms.Label();
            this.memorySizeLbl = new System.Windows.Forms.Label();
            this.outputPnl = new System.Windows.Forms.Panel();
            this.compactBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outResizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // outResizeLbl
            // 
            this.outResizeLbl.AutoSize = true;
            this.outResizeLbl.BackColor = System.Drawing.Color.Transparent;
            this.outResizeLbl.Enabled = false;
            this.outResizeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outResizeLbl.Location = new System.Drawing.Point(178, 427);
            this.outResizeLbl.Name = "outResizeLbl";
            this.outResizeLbl.Size = new System.Drawing.Size(124, 25);
            this.outResizeLbl.TabIndex = 17;
            this.outResizeLbl.Text = "Output Size";
            this.outResizeLbl.Visible = false;
            // 
            // outResizeBar
            // 
            this.outResizeBar.Enabled = false;
            this.outResizeBar.Location = new System.Drawing.Point(12, 393);
            this.outResizeBar.Maximum = 100;
            this.outResizeBar.Minimum = 1;
            this.outResizeBar.Name = "outResizeBar";
            this.outResizeBar.Size = new System.Drawing.Size(460, 45);
            this.outResizeBar.TabIndex = 16;
            this.outResizeBar.Value = 15;
            this.outResizeBar.Visible = false;
            this.outResizeBar.Scroll += new System.EventHandler(this.outResizeBar_Scroll);
            // 
            // addBtn
            // 
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(397, 64);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 15;
            this.addBtn.Text = "Add Hole";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Visible = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // worstFitRad
            // 
            this.worstFitRad.AutoSize = true;
            this.worstFitRad.Enabled = false;
            this.worstFitRad.Location = new System.Drawing.Point(145, 93);
            this.worstFitRad.Name = "worstFitRad";
            this.worstFitRad.Size = new System.Drawing.Size(67, 17);
            this.worstFitRad.TabIndex = 14;
            this.worstFitRad.TabStop = true;
            this.worstFitRad.Text = "Worst Fit";
            this.worstFitRad.UseVisualStyleBackColor = true;
            this.worstFitRad.Visible = false;
            // 
            // bestFitRad
            // 
            this.bestFitRad.AutoSize = true;
            this.bestFitRad.Enabled = false;
            this.bestFitRad.Location = new System.Drawing.Point(79, 93);
            this.bestFitRad.Name = "bestFitRad";
            this.bestFitRad.Size = new System.Drawing.Size(60, 17);
            this.bestFitRad.TabIndex = 13;
            this.bestFitRad.TabStop = true;
            this.bestFitRad.Text = "Best Fit";
            this.bestFitRad.UseVisualStyleBackColor = true;
            this.bestFitRad.Visible = false;
            // 
            // firstFitRad
            // 
            this.firstFitRad.AutoSize = true;
            this.firstFitRad.Checked = true;
            this.firstFitRad.Enabled = false;
            this.firstFitRad.Location = new System.Drawing.Point(15, 93);
            this.firstFitRad.Name = "firstFitRad";
            this.firstFitRad.Size = new System.Drawing.Size(58, 17);
            this.firstFitRad.TabIndex = 12;
            this.firstFitRad.TabStop = true;
            this.firstFitRad.Text = "First Fit";
            this.firstFitRad.UseVisualStyleBackColor = true;
            this.firstFitRad.Visible = false;
            // 
            // processSizeTxt
            // 
            this.processSizeTxt.Enabled = false;
            this.processSizeTxt.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.processSizeTxt.Location = new System.Drawing.Point(349, 64);
            this.processSizeTxt.Name = "processSizeTxt";
            this.processSizeTxt.Size = new System.Drawing.Size(123, 20);
            this.processSizeTxt.TabIndex = 11;
            this.processSizeTxt.Text = "Process Size";
            this.processSizeTxt.Visible = false;
            this.processSizeTxt.Enter += new System.EventHandler(this.processSizeTxt_Enter);
            this.processSizeTxt.Leave += new System.EventHandler(this.processSizeTxt_Leave);
            // 
            // processSizeLbl
            // 
            this.processSizeLbl.AutoSize = true;
            this.processSizeLbl.Enabled = false;
            this.processSizeLbl.Location = new System.Drawing.Point(253, 67);
            this.processSizeLbl.Name = "processSizeLbl";
            this.processSizeLbl.Size = new System.Drawing.Size(90, 13);
            this.processSizeLbl.TabIndex = 10;
            this.processSizeLbl.Text = "Process #1 Size: ";
            this.processSizeLbl.Visible = false;
            // 
            // processNameTxt
            // 
            this.processNameTxt.Enabled = false;
            this.processNameTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.processNameTxt.Location = new System.Drawing.Point(116, 64);
            this.processNameTxt.Name = "processNameTxt";
            this.processNameTxt.Size = new System.Drawing.Size(131, 20);
            this.processNameTxt.TabIndex = 9;
            this.processNameTxt.Text = "P1";
            this.processNameTxt.Visible = false;
            this.processNameTxt.Enter += new System.EventHandler(this.processNameTxt_Enter);
            this.processNameTxt.Leave += new System.EventHandler(this.processNameTxt_Leave);
            // 
            // processNameLbl
            // 
            this.processNameLbl.AutoSize = true;
            this.processNameLbl.Enabled = false;
            this.processNameLbl.Location = new System.Drawing.Point(12, 67);
            this.processNameLbl.Name = "processNameLbl";
            this.processNameLbl.Size = new System.Drawing.Size(98, 13);
            this.processNameLbl.TabIndex = 8;
            this.processNameLbl.Text = "Process #1 Name: ";
            this.processNameLbl.Visible = false;
            // 
            // holeSizeTxt
            // 
            this.holeSizeTxt.Enabled = false;
            this.holeSizeTxt.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.holeSizeTxt.Location = new System.Drawing.Point(349, 38);
            this.holeSizeTxt.Name = "holeSizeTxt";
            this.holeSizeTxt.Size = new System.Drawing.Size(123, 20);
            this.holeSizeTxt.TabIndex = 7;
            this.holeSizeTxt.Text = "Hole Size";
            this.holeSizeTxt.Visible = false;
            this.holeSizeTxt.Enter += new System.EventHandler(this.holeSizeTxt_Enter);
            this.holeSizeTxt.Leave += new System.EventHandler(this.holeSizeTxt_Leave);
            // 
            // holeSizeLbl
            // 
            this.holeSizeLbl.AutoSize = true;
            this.holeSizeLbl.Enabled = false;
            this.holeSizeLbl.Location = new System.Drawing.Point(269, 41);
            this.holeSizeLbl.Name = "holeSizeLbl";
            this.holeSizeLbl.Size = new System.Drawing.Size(74, 13);
            this.holeSizeLbl.TabIndex = 6;
            this.holeSizeLbl.Text = "Hole #1 Size: ";
            this.holeSizeLbl.Visible = false;
            // 
            // holeStartAddressTxt
            // 
            this.holeStartAddressTxt.Enabled = false;
            this.holeStartAddressTxt.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.holeStartAddressTxt.Location = new System.Drawing.Point(135, 38);
            this.holeStartAddressTxt.Name = "holeStartAddressTxt";
            this.holeStartAddressTxt.Size = new System.Drawing.Size(112, 20);
            this.holeStartAddressTxt.TabIndex = 5;
            this.holeStartAddressTxt.Text = "Hole Start Address";
            this.holeStartAddressTxt.Visible = false;
            this.holeStartAddressTxt.Enter += new System.EventHandler(this.holeStartAddressTxt_Enter);
            this.holeStartAddressTxt.Leave += new System.EventHandler(this.holeStartAddressTxt_Leave);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(397, 38);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // memorySizeTxt
            // 
            this.memorySizeTxt.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.memorySizeTxt.Location = new System.Drawing.Point(94, 12);
            this.memorySizeTxt.Name = "memorySizeTxt";
            this.memorySizeTxt.Size = new System.Drawing.Size(378, 20);
            this.memorySizeTxt.TabIndex = 2;
            this.memorySizeTxt.Text = "Memory Size";
            this.memorySizeTxt.Enter += new System.EventHandler(this.memorySizeTxt_Enter);
            this.memorySizeTxt.Leave += new System.EventHandler(this.memorySizeTxt_Leave);
            // 
            // holeStartAddressLbl
            // 
            this.holeStartAddressLbl.AutoSize = true;
            this.holeStartAddressLbl.Enabled = false;
            this.holeStartAddressLbl.Location = new System.Drawing.Point(12, 41);
            this.holeStartAddressLbl.Name = "holeStartAddressLbl";
            this.holeStartAddressLbl.Size = new System.Drawing.Size(117, 13);
            this.holeStartAddressLbl.TabIndex = 1;
            this.holeStartAddressLbl.Text = "Hole #1 Start Address: ";
            this.holeStartAddressLbl.Visible = false;
            // 
            // memorySizeLbl
            // 
            this.memorySizeLbl.AutoSize = true;
            this.memorySizeLbl.Location = new System.Drawing.Point(12, 15);
            this.memorySizeLbl.Name = "memorySizeLbl";
            this.memorySizeLbl.Size = new System.Drawing.Size(70, 13);
            this.memorySizeLbl.TabIndex = 0;
            this.memorySizeLbl.Text = "Memory Size:";
            // 
            // outputPnl
            // 
            this.outputPnl.Location = new System.Drawing.Point(478, 12);
            this.outputPnl.Name = "outputPnl";
            this.outputPnl.Size = new System.Drawing.Size(228, 437);
            this.outputPnl.TabIndex = 1;
            // 
            // compactBtn
            // 
            this.compactBtn.Enabled = false;
            this.compactBtn.Location = new System.Drawing.Point(316, 90);
            this.compactBtn.Name = "compactBtn";
            this.compactBtn.Size = new System.Drawing.Size(75, 23);
            this.compactBtn.TabIndex = 18;
            this.compactBtn.Text = "Compact";
            this.compactBtn.UseVisualStyleBackColor = true;
            this.compactBtn.Visible = false;
            this.compactBtn.Click += new System.EventHandler(this.compactBtn_Click);
            // 
            // memAllocator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 461);
            this.Controls.Add(this.compactBtn);
            this.Controls.Add(this.outResizeLbl);
            this.Controls.Add(this.outputPnl);
            this.Controls.Add(this.outResizeBar);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.memorySizeLbl);
            this.Controls.Add(this.worstFitRad);
            this.Controls.Add(this.holeStartAddressLbl);
            this.Controls.Add(this.bestFitRad);
            this.Controls.Add(this.memorySizeTxt);
            this.Controls.Add(this.firstFitRad);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.processSizeTxt);
            this.Controls.Add(this.holeStartAddressTxt);
            this.Controls.Add(this.processSizeLbl);
            this.Controls.Add(this.holeSizeLbl);
            this.Controls.Add(this.processNameTxt);
            this.Controls.Add(this.holeSizeTxt);
            this.Controls.Add(this.processNameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "memAllocator";
            this.Text = "Memory Allocator";
            ((System.ComponentModel.ISupportInitialize)(this.outResizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label holeStartAddressLbl;
        private System.Windows.Forms.Label memorySizeLbl;
        private System.Windows.Forms.TextBox memorySizeTxt;
        private System.Windows.Forms.TextBox holeSizeTxt;
        private System.Windows.Forms.Label holeSizeLbl;
        private System.Windows.Forms.TextBox holeStartAddressTxt;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox processSizeTxt;
        private System.Windows.Forms.Label processSizeLbl;
        private System.Windows.Forms.TextBox processNameTxt;
        private System.Windows.Forms.Label processNameLbl;
        private System.Windows.Forms.RadioButton worstFitRad;
        private System.Windows.Forms.RadioButton bestFitRad;
        private System.Windows.Forms.RadioButton firstFitRad;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label outResizeLbl;
        private System.Windows.Forms.TrackBar outResizeBar;
        private System.Windows.Forms.Panel outputPnl;
        private System.Windows.Forms.Button compactBtn;
    }
}

