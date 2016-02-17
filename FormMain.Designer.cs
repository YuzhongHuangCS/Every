namespace Every {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddRepo = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tabPageRevision = new System.Windows.Forms.TabPage();
            this.tabPageRemote = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.listViewMain, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonAddRepo, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControlMain, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(624, 321);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // listViewMain
            // 
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Path,
            this.Status});
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.Location = new System.Drawing.Point(4, 62);
            this.listViewMain.Margin = new System.Windows.Forms.Padding(4);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(616, 149);
            this.listViewMain.TabIndex = 0;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.Click += new System.EventHandler(this.listViewMain_Click);
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 540;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAddRepo
            // 
            this.buttonAddRepo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRepo.Location = new System.Drawing.Point(4, 4);
            this.buttonAddRepo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddRepo.Name = "buttonAddRepo";
            this.buttonAddRepo.Size = new System.Drawing.Size(616, 50);
            this.buttonAddRepo.TabIndex = 1;
            this.buttonAddRepo.Text = "Add Repository";
            this.buttonAddRepo.UseVisualStyleBackColor = true;
            this.buttonAddRepo.Click += new System.EventHandler(this.buttonAddRepo_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageStatus);
            this.tabControlMain.Controls.Add(this.tabPageConfig);
            this.tabControlMain.Controls.Add(this.tabPageRevision);
            this.tabControlMain.Controls.Add(this.tabPageRemote);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 218);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(618, 100);
            this.tabControlMain.TabIndex = 2;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Location = new System.Drawing.Point(4, 28);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(610, 68);
            this.tabPageStatus.TabIndex = 0;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Location = new System.Drawing.Point(4, 28);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(610, 68);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageRevision
            // 
            this.tabPageRevision.Location = new System.Drawing.Point(4, 28);
            this.tabPageRevision.Name = "tabPageRevision";
            this.tabPageRevision.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRevision.Size = new System.Drawing.Size(610, 68);
            this.tabPageRevision.TabIndex = 2;
            this.tabPageRevision.Text = "Revision";
            this.tabPageRevision.UseVisualStyleBackColor = true;
            // 
            // tabPageRemote
            // 
            this.tabPageRemote.Location = new System.Drawing.Point(4, 28);
            this.tabPageRemote.Name = "tabPageRemote";
            this.tabPageRemote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemote.Size = new System.Drawing.Size(610, 68);
            this.tabPageRemote.TabIndex = 3;
            this.tabPageRemote.Text = "Remote";
            this.tabPageRemote.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Every";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.Button buttonAddRepo;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.TabPage tabPageRevision;
        private System.Windows.Forms.TabPage tabPageRemote;
    }
}