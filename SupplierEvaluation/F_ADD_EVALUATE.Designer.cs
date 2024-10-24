namespace SupplierEvaluation
{
    partial class F_ADD_EVALUATE
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lbCreateBy = new System.Windows.Forms.Label();
            this.lbPoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inpDate = new System.Windows.Forms.DateTimePicker();
            this.inpComment = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbBuyer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(575, 41);
            this.panel1.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(18, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(557, 41);
            this.label7.TabIndex = 40;
            this.label7.Text = "ประเมินผลการจัดส่ง";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCreateBy
            // 
            this.lbCreateBy.AutoSize = true;
            this.lbCreateBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbCreateBy.Location = new System.Drawing.Point(152, 294);
            this.lbCreateBy.Name = "lbCreateBy";
            this.lbCreateBy.Size = new System.Drawing.Size(13, 17);
            this.lbCreateBy.TabIndex = 10;
            this.lbCreateBy.Text = "-";
            // 
            // lbPoint
            // 
            this.lbPoint.AutoSize = true;
            this.lbPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbPoint.Location = new System.Drawing.Point(151, 166);
            this.lbPoint.Name = "lbPoint";
            this.lbPoint.Size = new System.Drawing.Size(13, 17);
            this.lbPoint.TabIndex = 8;
            this.lbPoint.Tag = "";
            this.lbPoint.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(57, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "SUPPLIER : ";
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(150, 128);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(320, 25);
            this.cbType.TabIndex = 7;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            this.cbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbType_KeyPress);
            // 
            // cbSupplier
            // 
            this.cbSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(149, 58);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(320, 25);
            this.cbSupplier.TabIndex = 13;
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            this.cbSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSupplier_KeyPress);
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSaveData.ForeColor = System.Drawing.Color.Snow;
            this.btnSaveData.Location = new System.Drawing.Point(148, 330);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(322, 63);
            this.btnSaveData.TabIndex = 6;
            this.btnSaveData.Text = "SAVE DATA";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(50, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 5;
            this.label5.Tag = "";
            this.label5.Text = "COMMENT : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(45, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "CREATE BY : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(19, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 3;
            this.label3.Tag = "";
            this.label3.Text = "DEDUCT POINT : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(86, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "TYPE : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(86, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "DATE : ";
            // 
            // inpDate
            // 
            this.inpDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.inpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.inpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inpDate.Location = new System.Drawing.Point(150, 92);
            this.inpDate.Name = "inpDate";
            this.inpDate.Size = new System.Drawing.Size(320, 23);
            this.inpDate.TabIndex = 0;
            // 
            // inpComment
            // 
            this.inpComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.inpComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.inpComment.Location = new System.Drawing.Point(150, 202);
            this.inpComment.Multiline = true;
            this.inpComment.Name = "inpComment";
            this.inpComment.Size = new System.Drawing.Size(320, 78);
            this.inpComment.TabIndex = 9;
            this.inpComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inpComment_KeyUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.cbBuyer);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.inpComment);
            this.panel2.Controls.Add(this.inpDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnSaveData);
            this.panel2.Controls.Add(this.cbSupplier);
            this.panel2.Controls.Add(this.cbType);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbPoint);
            this.panel2.Controls.Add(this.lbCreateBy);
            this.panel2.Location = new System.Drawing.Point(1, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 411);
            this.panel2.TabIndex = 42;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cbBuyer
            // 
            this.cbBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cbBuyer.FormattingEnabled = true;
            this.cbBuyer.Location = new System.Drawing.Point(149, 25);
            this.cbBuyer.Name = "cbBuyer";
            this.cbBuyer.Size = new System.Drawing.Size(320, 25);
            this.cbBuyer.TabIndex = 15;
            this.cbBuyer.SelectedIndexChanged += new System.EventHandler(this.cbBuyer_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(77, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "BUYER : ";
            // 
            // F_ADD_EVALUATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 448);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "F_ADD_EVALUATE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "หน้าต่างประเมินผล";
            this.Load += new System.EventHandler(this.F_ADD_EVALUATE_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbCreateBy;
        private System.Windows.Forms.Label lbPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker inpDate;
        private System.Windows.Forms.TextBox inpComment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbBuyer;
        private System.Windows.Forms.Label label8;
    }
}