namespace InfraworksJSONFrontEnd
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInputTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportToJSON = new System.Windows.Forms.Button();
            this.btnImportFromExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.txtJSONFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSessionID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbShowLaneMarkings = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Road Style Wizard ";
            // 
            // dgvInputTable
            // 
            this.dgvInputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19});
            this.dgvInputTable.Location = new System.Drawing.Point(12, 171);
            this.dgvInputTable.Name = "dgvInputTable";
            this.dgvInputTable.Size = new System.Drawing.Size(1101, 338);
            this.dgvInputTable.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "RoadName";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Rev";
            this.Column2.MinimumWidth = 30;
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Desc";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Verge";
            this.Column4.MinimumWidth = 50;
            this.Column4.Name = "Column4";
            this.Column4.Width = 51;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "HS";
            this.Column5.MinimumWidth = 50;
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "L1";
            this.Column6.MinimumWidth = 50;
            this.Column6.Name = "Column6";
            this.Column6.Width = 51;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "L2";
            this.Column7.MinimumWidth = 50;
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "L3";
            this.Column8.MinimumWidth = 50;
            this.Column8.Name = "Column8";
            this.Column8.Width = 51;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "L4";
            this.Column9.MinimumWidth = 50;
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "HS";
            this.Column10.Name = "Column10";
            this.Column10.Width = 51;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "CR1";
            this.Column11.MinimumWidth = 50;
            this.Column11.Name = "Column11";
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "CR2";
            this.Column12.MinimumWidth = 50;
            this.Column12.Name = "Column12";
            this.Column12.Width = 51;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "HS";
            this.Column13.MinimumWidth = 50;
            this.Column13.Name = "Column13";
            this.Column13.Width = 50;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "L5";
            this.Column14.MinimumWidth = 50;
            this.Column14.Name = "Column14";
            this.Column14.Width = 51;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "L6";
            this.Column15.MinimumWidth = 50;
            this.Column15.Name = "Column15";
            this.Column15.Width = 50;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "L7";
            this.Column16.MinimumWidth = 50;
            this.Column16.Name = "Column16";
            this.Column16.Width = 51;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "L8";
            this.Column17.MinimumWidth = 50;
            this.Column17.Name = "Column17";
            this.Column17.Width = 50;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "HS";
            this.Column18.MinimumWidth = 50;
            this.Column18.Name = "Column18";
            this.Column18.Width = 51;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Verge";
            this.Column19.MinimumWidth = 50;
            this.Column19.Name = "Column19";
            this.Column19.Width = 50;
            // 
            // btnExportToJSON
            // 
            this.btnExportToJSON.Location = new System.Drawing.Point(16, 515);
            this.btnExportToJSON.Name = "btnExportToJSON";
            this.btnExportToJSON.Size = new System.Drawing.Size(72, 64);
            this.btnExportToJSON.TabIndex = 3;
            this.btnExportToJSON.Text = "Export to JSON";
            this.btnExportToJSON.UseVisualStyleBackColor = true;
            this.btnExportToJSON.Click += new System.EventHandler(this.BtnExportToJSON_Click);
            // 
            // btnImportFromExcel
            // 
            this.btnImportFromExcel.Location = new System.Drawing.Point(94, 515);
            this.btnImportFromExcel.Name = "btnImportFromExcel";
            this.btnImportFromExcel.Size = new System.Drawing.Size(72, 64);
            this.btnImportFromExcel.TabIndex = 3;
            this.btnImportFromExcel.Text = "Import From Excel";
            this.btnImportFromExcel.UseVisualStyleBackColor = true;
            this.btnImportFromExcel.Click += new System.EventHandler(this.BtnImportFromExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "City Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "JSON FilePath:";
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(484, 18);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(100, 22);
            this.txtCityName.TabIndex = 5;
            this.txtCityName.Text = "HAL";
            // 
            // txtJSONFileName
            // 
            this.txtJSONFileName.Location = new System.Drawing.Point(484, 71);
            this.txtJSONFileName.Name = "txtJSONFileName";
            this.txtJSONFileName.Size = new System.Drawing.Size(361, 22);
            this.txtJSONFileName.TabIndex = 5;
            this.txtJSONFileName.Text = "C:\\Users\\pcox\\Desktop\\C#Test.styles.json";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Session_ID:";
            // 
            // txtSessionID
            // 
            this.txtSessionID.Location = new System.Drawing.Point(484, 43);
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Size = new System.Drawing.Size(275, 22);
            this.txtSessionID.TabIndex = 5;
            this.txtSessionID.Text = "{0D947B14-261F-4D54-AEC5-289040C67073}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 4;
            // 
            // cbShowLaneMarkings
            // 
            this.cbShowLaneMarkings.AutoSize = true;
            this.cbShowLaneMarkings.Location = new System.Drawing.Point(324, 99);
            this.cbShowLaneMarkings.Name = "cbShowLaneMarkings";
            this.cbShowLaneMarkings.Size = new System.Drawing.Size(154, 20);
            this.cbShowLaneMarkings.TabIndex = 6;
            this.cbShowLaneMarkings.TabStop = true;
            this.cbShowLaneMarkings.Text = "Show Lane Markings?";
            this.cbShowLaneMarkings.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1227, 591);
            this.Controls.Add(this.cbShowLaneMarkings);
            this.Controls.Add(this.txtJSONFileName);
            this.Controls.Add(this.txtSessionID);
            this.Controls.Add(this.txtCityName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportFromExcel);
            this.Controls.Add(this.btnExportToJSON);
            this.Controls.Add(this.dgvInputTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Infraworks Road Component Wizard ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInputTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.Button btnExportToJSON;
        private System.Windows.Forms.Button btnImportFromExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.TextBox txtJSONFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSessionID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton cbShowLaneMarkings;
    }
}

