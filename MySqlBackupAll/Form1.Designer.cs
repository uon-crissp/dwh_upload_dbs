namespace MySqlBackupAll
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
            this.btSetFolder = new System.Windows.Forms.Button();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btRestore = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeidentify = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnRefreshETL = new System.Windows.Forms.Button();
            this.btnMasterTable = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSetFolder
            // 
            this.btSetFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btSetFolder.Location = new System.Drawing.Point(4, 3);
            this.btSetFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSetFolder.Name = "btSetFolder";
            this.btSetFolder.Size = new System.Drawing.Size(109, 25);
            this.btSetFolder.TabIndex = 0;
            this.btSetFolder.Text = "Select Folder";
            this.btSetFolder.UseVisualStyleBackColor = true;
            this.btSetFolder.Click += new System.EventHandler(this.btSetFolder_Click);
            // 
            // lbFolder
            // 
            this.lbFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbFolder.AutoSize = true;
            this.lbFolder.Location = new System.Drawing.Point(120, 8);
            this.lbFolder.Name = "lbFolder";
            this.lbFolder.Size = new System.Drawing.Size(125, 14);
            this.lbFolder.TabIndex = 1;
            this.lbFolder.Text = "No Folder Selected";
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(4, 3);
            this.btRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(150, 23);
            this.btRestore.TabIndex = 3;
            this.btRestore.Text = "Restore Databases";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.BackColor = System.Drawing.Color.Azure;
            this.txtProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgress.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgress.ForeColor = System.Drawing.Color.Black;
            this.txtProgress.Location = new System.Drawing.Point(4, 104);
            this.txtProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(970, 313);
            this.txtProgress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "MySQL Connection String:";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConnStr.Location = new System.Drawing.Point(179, 2);
            this.txtConnStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(771, 22);
            this.txtConnStr.TabIndex = 11;
            this.txtConnStr.Text = "server=localhost;user=root;pwd=root;convertzerodatetime=true;charset=utf8;Allow U" +
    "ser Variables=True";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProgress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 420);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btSetFolder);
            this.flowLayoutPanel1.Controls.Add(this.lbFolder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(850, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.txtConnStr);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 39);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(970, 30);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btRestore);
            this.flowLayoutPanel3.Controls.Add(this.btnDeidentify);
            this.flowLayoutPanel3.Controls.Add(this.btnInitialize);
            this.flowLayoutPanel3.Controls.Add(this.btnRefreshETL);
            this.flowLayoutPanel3.Controls.Add(this.btnMasterTable);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1, 73);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(856, 28);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // btnDeidentify
            // 
            this.btnDeidentify.Location = new System.Drawing.Point(161, 2);
            this.btnDeidentify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeidentify.Name = "btnDeidentify";
            this.btnDeidentify.Size = new System.Drawing.Size(150, 23);
            this.btnDeidentify.TabIndex = 5;
            this.btnDeidentify.Text = "Deidentify DBs";
            this.btnDeidentify.UseVisualStyleBackColor = true;
            this.btnDeidentify.Click += new System.EventHandler(this.btnDeidentify_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(317, 2);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(150, 23);
            this.btnInitialize.TabIndex = 4;
            this.btnInitialize.Text = "Initialize Databases";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnRefreshETL
            // 
            this.btnRefreshETL.Location = new System.Drawing.Point(473, 2);
            this.btnRefreshETL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefreshETL.Name = "btnRefreshETL";
            this.btnRefreshETL.Size = new System.Drawing.Size(150, 23);
            this.btnRefreshETL.TabIndex = 6;
            this.btnRefreshETL.Text = "Refresh ETL";
            this.btnRefreshETL.UseVisualStyleBackColor = true;
            this.btnRefreshETL.Click += new System.EventHandler(this.btnRefreshETL_Click);
            // 
            // btnMasterTable
            // 
            this.btnMasterTable.Location = new System.Drawing.Point(629, 2);
            this.btnMasterTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMasterTable.Name = "btnMasterTable";
            this.btnMasterTable.Size = new System.Drawing.Size(150, 23);
            this.btnMasterTable.TabIndex = 7;
            this.btnMasterTable.Text = "Create Master Table";
            this.btnMasterTable.UseVisualStyleBackColor = true;
            this.btnMasterTable.Click += new System.EventHandler(this.btnMasterTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 420);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore MySQL Databases";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSetFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnDeidentify;
        private System.Windows.Forms.Button btnRefreshETL;
        private System.Windows.Forms.Button btnMasterTable;
    }
}

