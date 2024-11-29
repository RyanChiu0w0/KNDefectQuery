namespace KN報廢率查詢
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxInputArea = new System.Windows.Forms.GroupBox();
            this.button7point5Output = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.radioButtonPartNoDate = new System.Windows.Forms.RadioButton();
            this.radioButtonLot = new System.Windows.Forms.RadioButton();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagePercent = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.QueryQuantity = new System.Windows.Forms.ToolStripStatusLabel();
            this.QueryQuantityStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pageDefectRate = new System.Windows.Forms.TabPage();
            this.dgvDefectRate = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDefectRateOutput = new System.Windows.Forms.Button();
            this.buttonDefectRateSubmit = new System.Windows.Forms.Button();
            this.textBoxLot = new System.Windows.Forms.TextBox();
            this.radioButtonOut = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonIn = new System.Windows.Forms.RadioButton();
            this.groupBoxInputArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pagePercent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pageDefectRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectRate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInputArea
            // 
            this.groupBoxInputArea.Controls.Add(this.button7point5Output);
            this.groupBoxInputArea.Controls.Add(this.label2);
            this.groupBoxInputArea.Controls.Add(this.label1);
            this.groupBoxInputArea.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxInputArea.Controls.Add(this.buttonSubmit);
            this.groupBoxInputArea.Controls.Add(this.dateTimePickerStart);
            this.groupBoxInputArea.Controls.Add(this.textBoxInput);
            this.groupBoxInputArea.Controls.Add(this.radioButtonPartNoDate);
            this.groupBoxInputArea.Controls.Add(this.radioButtonLot);
            this.groupBoxInputArea.Location = new System.Drawing.Point(8, 6);
            this.groupBoxInputArea.Name = "groupBoxInputArea";
            this.groupBoxInputArea.Size = new System.Drawing.Size(743, 115);
            this.groupBoxInputArea.TabIndex = 0;
            this.groupBoxInputArea.TabStop = false;
            this.groupBoxInputArea.Text = "InputArea";
            // 
            // button7point5Output
            // 
            this.button7point5Output.Location = new System.Drawing.Point(653, 85);
            this.button7point5Output.Name = "button7point5Output";
            this.button7point5Output.Size = new System.Drawing.Size(75, 23);
            this.button7point5Output.TabIndex = 4;
            this.button7point5Output.Text = "資料輸出";
            this.button7point5Output.UseVisualStyleBackColor = true;
            this.button7point5Output.Click += new System.EventHandler(this.button7point5Output_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "截止日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "起始日期";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(528, 48);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerEnd.TabIndex = 5;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(468, 85);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "查詢";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(528, 20);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(121, 25);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(158, 22);
            this.textBoxInput.TabIndex = 2;
            // 
            // radioButtonPartNoDate
            // 
            this.radioButtonPartNoDate.AutoSize = true;
            this.radioButtonPartNoDate.Location = new System.Drawing.Point(22, 54);
            this.radioButtonPartNoDate.Name = "radioButtonPartNoDate";
            this.radioButtonPartNoDate.Size = new System.Drawing.Size(83, 16);
            this.radioButtonPartNoDate.TabIndex = 1;
            this.radioButtonPartNoDate.Text = "板號及日期";
            this.radioButtonPartNoDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonLot
            // 
            this.radioButtonLot.AutoSize = true;
            this.radioButtonLot.Checked = true;
            this.radioButtonLot.Location = new System.Drawing.Point(22, 26);
            this.radioButtonLot.Name = "radioButtonLot";
            this.radioButtonLot.Size = new System.Drawing.Size(47, 16);
            this.radioButtonLot.TabIndex = 0;
            this.radioButtonLot.TabStop = true;
            this.radioButtonLot.Text = "批號";
            this.radioButtonLot.UseVisualStyleBackColor = true;
            // 
            // dgvOutput
            // 
            this.dgvOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(8, 127);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.RowTemplate.Height = 24;
            this.dgvOutput.Size = new System.Drawing.Size(744, 332);
            this.dgvOutput.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.pagePercent);
            this.tabControl.Controls.Add(this.pageDefectRate);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(767, 514);
            this.tabControl.TabIndex = 3;
            // 
            // pagePercent
            // 
            this.pagePercent.Controls.Add(this.statusStrip);
            this.pagePercent.Controls.Add(this.groupBoxInputArea);
            this.pagePercent.Controls.Add(this.dgvOutput);
            this.pagePercent.Location = new System.Drawing.Point(4, 22);
            this.pagePercent.Name = "pagePercent";
            this.pagePercent.Padding = new System.Windows.Forms.Padding(3);
            this.pagePercent.Size = new System.Drawing.Size(759, 488);
            this.pagePercent.TabIndex = 0;
            this.pagePercent.Text = "7.5%";
            this.pagePercent.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueryQuantity,
            this.QueryQuantityStatus});
            this.statusStrip.Location = new System.Drawing.Point(3, 463);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(753, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // QueryQuantity
            // 
            this.QueryQuantity.Name = "QueryQuantity";
            this.QueryQuantity.Size = new System.Drawing.Size(67, 17);
            this.QueryQuantity.Text = "已查詢批數";
            // 
            // QueryQuantityStatus
            // 
            this.QueryQuantityStatus.Name = "QueryQuantityStatus";
            this.QueryQuantityStatus.Size = new System.Drawing.Size(28, 17);
            this.QueryQuantityStatus.Text = "- / -";
            // 
            // pageDefectRate
            // 
            this.pageDefectRate.Controls.Add(this.dgvDefectRate);
            this.pageDefectRate.Controls.Add(this.groupBox1);
            this.pageDefectRate.Location = new System.Drawing.Point(4, 22);
            this.pageDefectRate.Name = "pageDefectRate";
            this.pageDefectRate.Padding = new System.Windows.Forms.Padding(3);
            this.pageDefectRate.Size = new System.Drawing.Size(759, 488);
            this.pageDefectRate.TabIndex = 1;
            this.pageDefectRate.Text = "缺陷比例";
            this.pageDefectRate.UseVisualStyleBackColor = true;
            // 
            // dgvDefectRate
            // 
            this.dgvDefectRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDefectRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectRate.Location = new System.Drawing.Point(8, 127);
            this.dgvDefectRate.Name = "dgvDefectRate";
            this.dgvDefectRate.RowTemplate.Height = 24;
            this.dgvDefectRate.Size = new System.Drawing.Size(744, 332);
            this.dgvDefectRate.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDefectRateOutput);
            this.groupBox1.Controls.Add(this.buttonDefectRateSubmit);
            this.groupBox1.Controls.Add(this.textBoxLot);
            this.groupBox1.Controls.Add(this.radioButtonOut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButtonIn);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 115);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "InputArea";
            // 
            // buttonDefectRateOutput
            // 
            this.buttonDefectRateOutput.Location = new System.Drawing.Point(662, 86);
            this.buttonDefectRateOutput.Name = "buttonDefectRateOutput";
            this.buttonDefectRateOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonDefectRateOutput.TabIndex = 6;
            this.buttonDefectRateOutput.Text = "資料輸出";
            this.buttonDefectRateOutput.UseVisualStyleBackColor = true;
            this.buttonDefectRateOutput.Click += new System.EventHandler(this.buttonDefectRateOutput_Click);
            // 
            // buttonDefectRateSubmit
            // 
            this.buttonDefectRateSubmit.Location = new System.Drawing.Point(468, 86);
            this.buttonDefectRateSubmit.Name = "buttonDefectRateSubmit";
            this.buttonDefectRateSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonDefectRateSubmit.TabIndex = 4;
            this.buttonDefectRateSubmit.Text = "查詢";
            this.buttonDefectRateSubmit.UseVisualStyleBackColor = true;
            this.buttonDefectRateSubmit.Click += new System.EventHandler(this.buttonLotStockSubmit_Click);
            // 
            // textBoxLot
            // 
            this.textBoxLot.Location = new System.Drawing.Point(56, 21);
            this.textBoxLot.Name = "textBoxLot";
            this.textBoxLot.Size = new System.Drawing.Size(158, 22);
            this.textBoxLot.TabIndex = 5;
            // 
            // radioButtonOut
            // 
            this.radioButtonOut.AutoSize = true;
            this.radioButtonOut.Location = new System.Drawing.Point(233, 52);
            this.radioButtonOut.Name = "radioButtonOut";
            this.radioButtonOut.Size = new System.Drawing.Size(59, 16);
            this.radioButtonOut.TabIndex = 4;
            this.radioButtonOut.Text = "未入庫";
            this.radioButtonOut.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "批號";
            // 
            // radioButtonIn
            // 
            this.radioButtonIn.AutoSize = true;
            this.radioButtonIn.Checked = true;
            this.radioButtonIn.Location = new System.Drawing.Point(233, 24);
            this.radioButtonIn.Name = "radioButtonIn";
            this.radioButtonIn.Size = new System.Drawing.Size(47, 16);
            this.radioButtonIn.TabIndex = 3;
            this.radioButtonIn.TabStop = true;
            this.radioButtonIn.Text = "入庫";
            this.radioButtonIn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 513);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "KN報廢率查詢";
            this.groupBoxInputArea.ResumeLayout(false);
            this.groupBoxInputArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pagePercent.ResumeLayout(false);
            this.pagePercent.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pageDefectRate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectRate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInputArea;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.RadioButton radioButtonPartNoDate;
        private System.Windows.Forms.RadioButton radioButtonLot;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagePercent;
        private System.Windows.Forms.TabPage pageDefectRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDefectRateSubmit;
        private System.Windows.Forms.TextBox textBoxLot;
        private System.Windows.Forms.RadioButton radioButtonOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonIn;
        private System.Windows.Forms.DataGridView dgvDefectRate;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel QueryQuantity;
        private System.Windows.Forms.ToolStripStatusLabel QueryQuantityStatus;
        private System.Windows.Forms.Button button7point5Output;
        private System.Windows.Forms.Button buttonDefectRateOutput;
    }
}

