namespace SupplierEvaluation
{
    partial class F_MANAGE_DELIVERY
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_MANAGE_DELIVERY));
            this.gvEvaluate = new System.Windows.Forms.DataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbUser = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewEvaluate = new System.Windows.Forms.Button();
            this.lbAlert = new System.Windows.Forms.Label();
            this.ic_loading = new System.Windows.Forms.PictureBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnEvaluation = new System.Windows.Forms.Button();
            this.cbVender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddEvaluation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvaluate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ic_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // gvEvaluate
            // 
            this.gvEvaluate.AllowUserToAddRows = false;
            this.gvEvaluate.AllowUserToDeleteRows = false;
            this.gvEvaluate.AllowUserToResizeColumns = false;
            this.gvEvaluate.AllowUserToResizeRows = false;
            this.gvEvaluate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvEvaluate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColType,
            this.ColPoint,
            this.ColComment,
            this.ColCreateBy,
            this.colDelete});
            this.gvEvaluate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvEvaluate.Location = new System.Drawing.Point(18, 254);
            this.gvEvaluate.Name = "gvEvaluate";
            this.gvEvaluate.ReadOnly = true;
            this.gvEvaluate.RowHeadersVisible = false;
            this.gvEvaluate.Size = new System.Drawing.Size(786, 440);
            this.gvEvaluate.TabIndex = 41;
            this.gvEvaluate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvEvaluate_CellContentClick);
            // 
            // ColDate
            // 
            this.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColDate.Frozen = true;
            this.ColDate.HeaderText = "DATE";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            // 
            // ColType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColType.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColType.HeaderText = "TYPE";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            this.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPoint
            // 
            this.ColPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ColPoint.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPoint.HeaderText = "DEDUCT POINT";
            this.ColPoint.Name = "ColPoint";
            this.ColPoint.ReadOnly = true;
            this.ColPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPoint.Width = 150;
            // 
            // ColComment
            // 
            this.ColComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColComment.HeaderText = "COMMENT";
            this.ColComment.Name = "ColComment";
            this.ColComment.ReadOnly = true;
            this.ColComment.Width = 250;
            // 
            // ColCreateBy
            // 
            this.ColCreateBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColCreateBy.HeaderText = "CREATE BY";
            this.ColCreateBy.Name = "ColCreateBy";
            this.ColCreateBy.ReadOnly = true;
            this.ColCreateBy.Width = 125;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "DELETE";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbUser);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAddEvaluation);
            this.panel1.Controls.Add(this.gvEvaluate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(18, 0, 18, 18);
            this.panel1.Size = new System.Drawing.Size(822, 712);
            this.panel1.TabIndex = 42;
            // 
            // lbUser
            // 
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbUser.Location = new System.Drawing.Point(331, 7);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(466, 20);
            this.lbUser.TabIndex = 54;
            this.lbUser.Text = "-";
            this.lbUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(41, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Searching";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnViewEvaluate);
            this.panel2.Controls.Add(this.lbAlert);
            this.panel2.Controls.Add(this.ic_loading);
            this.panel2.Controls.Add(this.cbMonth);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbYear);
            this.panel2.Controls.Add(this.btnEvaluation);
            this.panel2.Controls.Add(this.cbVender);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(20, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 157);
            this.panel2.TabIndex = 52;
            // 
            // btnViewEvaluate
            // 
            this.btnViewEvaluate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnViewEvaluate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnViewEvaluate.ForeColor = System.Drawing.Color.White;
            this.btnViewEvaluate.Image = global::SupplierEvaluation.Properties.Resources.icons8_search_30;
            this.btnViewEvaluate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewEvaluate.Location = new System.Drawing.Point(345, 95);
            this.btnViewEvaluate.Name = "btnViewEvaluate";
            this.btnViewEvaluate.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnViewEvaluate.Size = new System.Drawing.Size(200, 47);
            this.btnViewEvaluate.TabIndex = 56;
            this.btnViewEvaluate.Text = "EVALUATE";
            this.btnViewEvaluate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewEvaluate.UseVisualStyleBackColor = false;
            this.btnViewEvaluate.Click += new System.EventHandler(this.btnViewEvaluate_Click);
            // 
            // lbAlert
            // 
            this.lbAlert.AutoSize = true;
            this.lbAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAlert.ForeColor = System.Drawing.Color.Red;
            this.lbAlert.Location = new System.Drawing.Point(109, 110);
            this.lbAlert.Name = "lbAlert";
            this.lbAlert.Size = new System.Drawing.Size(0, 20);
            this.lbAlert.TabIndex = 55;
            // 
            // ic_loading
            // 
            this.ic_loading.Image = global::SupplierEvaluation.Properties.Resources.ic_loading_2;
            this.ic_loading.Location = new System.Drawing.Point(296, 101);
            this.ic_loading.Name = "ic_loading";
            this.ic_loading.Size = new System.Drawing.Size(40, 37);
            this.ic_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ic_loading.TabIndex = 54;
            this.ic_loading.TabStop = false;
            this.ic_loading.Visible = false;
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(345, 62);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(380, 28);
            this.cbMonth.TabIndex = 46;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            this.cbMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMonth_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(269, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Month : ";
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(113, 63);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(138, 28);
            this.cbYear.TabIndex = 45;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            this.cbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbYear_KeyPress);
            // 
            // btnEvaluation
            // 
            this.btnEvaluation.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEvaluation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnEvaluation.Image = global::SupplierEvaluation.Properties.Resources.icons8_search_30;
            this.btnEvaluation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvaluation.Location = new System.Drawing.Point(551, 95);
            this.btnEvaluation.Name = "btnEvaluation";
            this.btnEvaluation.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnEvaluation.Size = new System.Drawing.Size(175, 47);
            this.btnEvaluation.TabIndex = 51;
            this.btnEvaluation.Text = "SEARCH";
            this.btnEvaluation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEvaluation.UseVisualStyleBackColor = false;
            this.btnEvaluation.Click += new System.EventHandler(this.btnEvaluation_Click);
            // 
            // cbVender
            // 
            this.cbVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cbVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbVender.FormattingEnabled = true;
            this.cbVender.Location = new System.Drawing.Point(113, 27);
            this.cbVender.Name = "cbVender";
            this.cbVender.Size = new System.Drawing.Size(612, 28);
            this.cbVender.TabIndex = 49;
            this.cbVender.SelectedIndexChanged += new System.EventHandler(this.cbVender_SelectedIndexChanged);
            this.cbVender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbVender_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(26, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "Supplier : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(52, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Year : ";
            // 
            // btnAddEvaluation
            // 
            this.btnAddEvaluation.BackColor = System.Drawing.Color.Green;
            this.btnAddEvaluation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddEvaluation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnAddEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnAddEvaluation.Image = global::SupplierEvaluation.Properties.Resources.ic_plus_white;
            this.btnAddEvaluation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEvaluation.Location = new System.Drawing.Point(18, 196);
            this.btnAddEvaluation.Name = "btnAddEvaluation";
            this.btnAddEvaluation.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAddEvaluation.Size = new System.Drawing.Size(254, 53);
            this.btnAddEvaluation.TabIndex = 42;
            this.btnAddEvaluation.Text = "INPUT MANUAL";
            this.btnAddEvaluation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEvaluation.UseVisualStyleBackColor = false;
            this.btnAddEvaluation.Click += new System.EventHandler(this.btnAddEvaluation_Click);
            // 
            // F_MANAGE_DELIVERY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(822, 712);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_MANAGE_DELIVERY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ประเมินผลการจัดส่ง";
            this.Load += new System.EventHandler(this.F_MANAGE_DELIVERY_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvEvaluate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ic_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gvEvaluate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddEvaluation;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbVender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEvaluation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ic_loading;
        private System.Windows.Forms.Label lbAlert;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateBy;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.Button btnViewEvaluate;
    }
}