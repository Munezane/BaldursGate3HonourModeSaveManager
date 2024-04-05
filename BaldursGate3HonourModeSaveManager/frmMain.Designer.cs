

namespace BaldursGate3HonourModeSaveManager
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSaves = new DataGridView();
            SavePreview = new DataGridViewImageColumn();
            SaveCreatedAt = new DataGridViewTextBoxColumn();
            SaveName = new DataGridViewTextBoxColumn();
            RestoreSave = new DataGridViewButtonColumn();
            fbdMain = new FolderBrowserDialog();
            txtPathToHonourModeSave = new TextBox();
            btnPathToHonourSave = new Button();
            lblPathToHonourSave = new Label();
            lblBackupSaveLocation = new Label();
            btnBackupSaveLocation = new Button();
            txtBackupSaveLocation = new TextBox();
            btnUndoSaveRestore = new Button();
            btnBackupCurrentSave = new Button();
            lblBackups = new Label();
            btnRefreshBackupGrid = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSaves).BeginInit();
            SuspendLayout();
            // 
            // dgvSaves
            // 
            dgvSaves.AutoGenerateColumns = false;
            dgvSaves.AllowUserToAddRows = false;
            dgvSaves.AllowUserToDeleteRows = false;
            dgvSaves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaves.Columns.AddRange(new DataGridViewColumn[] { SavePreview, SaveCreatedAt, SaveName, RestoreSave });
            dgvSaves.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSaves.Enabled = false;
            dgvSaves.Location = new Point(12, 219);
            dgvSaves.MultiSelect = false;
            dgvSaves.Name = "dgvSaves";
            dgvSaves.ReadOnly = true;
            dgvSaves.Size = new Size(776, 189);
            dgvSaves.TabIndex = 6;
            dgvSaves.CellContentClick += dgvSaves_CellContentClick;
            dgvSaves.DataBindingComplete += dgvSaves_DataBindingComplete;
            // 
            // SavePreview
            // 
            SavePreview.HeaderText = "Image";
            SavePreview.Name = "SavePreview";
            SavePreview.ReadOnly = true;
            // 
            // SaveCreatedAt
            // 
            SaveCreatedAt.DataPropertyName = "DateCreatedString";
            SaveCreatedAt.HeaderText = "Created at";
            SaveCreatedAt.Name = "SaveCreatedAt";
            SaveCreatedAt.ReadOnly = true;
            SaveCreatedAt.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // SaveName
            // 
            SaveName.DataPropertyName = "Path";
            SaveName.HeaderText = "Name";
            SaveName.Name = "SaveName";
            SaveName.ReadOnly = true;
            SaveName.Width = 400;
            // 
            // RestoreSave
            // 
            RestoreSave.HeaderText = "Restore Save";
            RestoreSave.Name = "RestoreSave";
            RestoreSave.ReadOnly = true;
            RestoreSave.Text = "Restore save";
            RestoreSave.UseColumnTextForButtonValue = true;
            // 
            // fbdMain
            // 
            fbdMain.ShowHiddenFiles = true;
            // 
            // txtPathToHonourModeSave
            // 
            txtPathToHonourModeSave.Location = new Point(12, 37);
            txtPathToHonourModeSave.Name = "txtPathToHonourModeSave";
            txtPathToHonourModeSave.ReadOnly = true;
            txtPathToHonourModeSave.Size = new Size(696, 23);
            txtPathToHonourModeSave.TabIndex = 0;
            // 
            // btnPathToHonourSave
            // 
            btnPathToHonourSave.Location = new Point(714, 37);
            btnPathToHonourSave.Name = "btnPathToHonourSave";
            btnPathToHonourSave.Size = new Size(75, 23);
            btnPathToHonourSave.TabIndex = 1;
            btnPathToHonourSave.Text = "Browse...";
            btnPathToHonourSave.UseVisualStyleBackColor = true;
            btnPathToHonourSave.Click += btnPathToHonourSave_Click;
            // 
            // lblPathToHonourSave
            // 
            lblPathToHonourSave.AutoSize = true;
            lblPathToHonourSave.Location = new Point(17, 14);
            lblPathToHonourSave.Name = "lblPathToHonourSave";
            lblPathToHonourSave.Size = new Size(172, 15);
            lblPathToHonourSave.TabIndex = 2;
            lblPathToHonourSave.Text = "Your honor mode save location";
            // 
            // lblBackupSaveLocation
            // 
            lblBackupSaveLocation.AutoSize = true;
            lblBackupSaveLocation.Location = new Point(17, 91);
            lblBackupSaveLocation.Name = "lblBackupSaveLocation";
            lblBackupSaveLocation.Size = new Size(145, 15);
            lblBackupSaveLocation.TabIndex = 3;
            lblBackupSaveLocation.Text = "Your backup save location";
            // 
            // btnBackupSaveLocation
            // 
            btnBackupSaveLocation.Location = new Point(714, 120);
            btnBackupSaveLocation.Name = "btnBackupSaveLocation";
            btnBackupSaveLocation.Size = new Size(75, 23);
            btnBackupSaveLocation.TabIndex = 5;
            btnBackupSaveLocation.Text = "Browse...";
            btnBackupSaveLocation.UseVisualStyleBackColor = true;
            btnBackupSaveLocation.Click += btnBackupSaveLocation_Click;
            // 
            // txtBackupSaveLocation
            // 
            txtBackupSaveLocation.Location = new Point(12, 120);
            txtBackupSaveLocation.Name = "txtBackupSaveLocation";
            txtBackupSaveLocation.ReadOnly = true;
            txtBackupSaveLocation.Size = new Size(696, 23);
            txtBackupSaveLocation.TabIndex = 4;
            // 
            // btnUndoSaveRestore
            // 
            btnUndoSaveRestore.Enabled = false;
            btnUndoSaveRestore.Location = new Point(14, 423);
            btnUndoSaveRestore.Name = "btnUndoSaveRestore";
            btnUndoSaveRestore.Size = new Size(148, 23);
            btnUndoSaveRestore.TabIndex = 7;
            btnUndoSaveRestore.Text = "Undo save restore...";
            btnUndoSaveRestore.UseVisualStyleBackColor = true;
            // 
            // btnBackupCurrentSave
            // 
            btnBackupCurrentSave.Enabled = false;
            btnBackupCurrentSave.Location = new Point(12, 165);
            btnBackupCurrentSave.Name = "btnBackupCurrentSave";
            btnBackupCurrentSave.Size = new Size(148, 23);
            btnBackupCurrentSave.TabIndex = 8;
            btnBackupCurrentSave.Text = "Backup current save";
            btnBackupCurrentSave.UseVisualStyleBackColor = true;
            btnBackupCurrentSave.Click += btnBackupCurrentSave_Click;
            // 
            // lblBackups
            // 
            lblBackups.AutoSize = true;
            lblBackups.Location = new Point(12, 201);
            lblBackups.Name = "lblBackups";
            lblBackups.Size = new Size(51, 15);
            lblBackups.TabIndex = 9;
            lblBackups.Text = "Backups";
            // 
            // btnRefreshBackupGrid
            // 
            btnRefreshBackupGrid.Enabled = false;
            btnRefreshBackupGrid.Location = new Point(640, 165);
            btnRefreshBackupGrid.Name = "btnRefreshBackupGrid";
            btnRefreshBackupGrid.Size = new Size(148, 23);
            btnRefreshBackupGrid.TabIndex = 10;
            btnRefreshBackupGrid.Text = "Refresh grid";
            btnRefreshBackupGrid.UseVisualStyleBackColor = true;
            btnRefreshBackupGrid.Click += btnRefreshBackupGrid_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 459);
            Controls.Add(btnRefreshBackupGrid);
            Controls.Add(lblBackups);
            Controls.Add(btnBackupCurrentSave);
            Controls.Add(btnUndoSaveRestore);
            Controls.Add(dgvSaves);
            Controls.Add(btnBackupSaveLocation);
            Controls.Add(txtBackupSaveLocation);
            Controls.Add(lblBackupSaveLocation);
            Controls.Add(lblPathToHonourSave);
            Controls.Add(btnPathToHonourSave);
            Controls.Add(txtPathToHonourModeSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            Text = "Baldur's Gate 3 Honour Mode Save Manager";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSaves).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private FolderBrowserDialog fbdMain;
        private TextBox txtPathToHonourModeSave;
        private Button btnPathToHonourSave;
        private Label lblPathToHonourSave;
        private Label lblBackupSaveLocation;
        private Button btnBackupSaveLocation;
        private TextBox txtBackupSaveLocation;
        private DataGridView dgvSaves;
        private Button btnUndoSaveRestore;
        private Button btnBackupCurrentSave;
        private Label lblBackups;
        private Button btnRefreshBackupGrid;
        private DataGridViewImageColumn SavePreview;
        private DataGridViewTextBoxColumn SaveCreatedAt;
        private DataGridViewTextBoxColumn SaveName;
        private DataGridViewButtonColumn RestoreSave;
    }
}
