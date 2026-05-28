namespace HED_Editor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnVybratSoubor = new Button();
            btnNahratData = new Button();
            btnUlozit = new Button();
            btnOffset = new Button();
            checkBackup = new CheckBox();
            dropdownColumns = new ComboBox();
            offsetInt = new NumericUpDown();
            textPath = new TextBox();
            dgvData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)offsetInt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnVybratSoubor
            // 
            btnVybratSoubor.Location = new Point(370, 11);
            btnVybratSoubor.Name = "btnVybratSoubor";
            btnVybratSoubor.Size = new Size(75, 23);
            btnVybratSoubor.TabIndex = 0;
            btnVybratSoubor.Text = "Vybrat";
            btnVybratSoubor.UseVisualStyleBackColor = true;
            btnVybratSoubor.Click += btnVybratSoubor_Click;
            // 
            // btnNahratData
            // 
            btnNahratData.Location = new Point(451, 11);
            btnNahratData.Name = "btnNahratData";
            btnNahratData.Size = new Size(75, 23);
            btnNahratData.TabIndex = 1;
            btnNahratData.Text = "Načíst";
            btnNahratData.UseVisualStyleBackColor = true;
            btnNahratData.Click += btnNahratData_Click;
            // 
            // btnUlozit
            // 
            btnUlozit.Location = new Point(532, 11);
            btnUlozit.Name = "btnUlozit";
            btnUlozit.Size = new Size(75, 23);
            btnUlozit.TabIndex = 2;
            btnUlozit.Text = "Uložit";
            btnUlozit.UseVisualStyleBackColor = true;
            btnUlozit.Click += btnUlozit_Click;
            // 
            // btnOffset
            // 
            btnOffset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOffset.Location = new Point(1356, 9);
            btnOffset.Name = "btnOffset";
            btnOffset.Size = new Size(75, 23);
            btnOffset.TabIndex = 3;
            btnOffset.Text = "Použít";
            btnOffset.UseVisualStyleBackColor = true;
            btnOffset.Click += btnOffset_Click;
            // 
            // checkBackup
            // 
            checkBackup.AutoSize = true;
            checkBackup.Location = new Point(613, 14);
            checkBackup.Name = "checkBackup";
            checkBackup.Size = new Size(62, 19);
            checkBackup.TabIndex = 4;
            checkBackup.Text = "Záloha";
            checkBackup.UseVisualStyleBackColor = true;
            // 
            // dropdownColumns
            // 
            dropdownColumns.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dropdownColumns.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownColumns.FormattingEnabled = true;
            dropdownColumns.Location = new Point(1180, 9);
            dropdownColumns.Name = "dropdownColumns";
            dropdownColumns.Size = new Size(121, 23);
            dropdownColumns.TabIndex = 5;
            // 
            // offsetInt
            // 
            offsetInt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            offsetInt.Location = new Point(1307, 9);
            offsetInt.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            offsetInt.Name = "offsetInt";
            offsetInt.Size = new Size(43, 23);
            offsetInt.TabIndex = 6;
            // 
            // textPath
            // 
            textPath.Location = new Point(12, 10);
            textPath.Name = "textPath";
            textPath.Size = new Size(354, 23);
            textPath.TabIndex = 7;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(12, 39);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(1421, 561);
            dgvData.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 612);
            Controls.Add(dgvData);
            Controls.Add(textPath);
            Controls.Add(offsetInt);
            Controls.Add(dropdownColumns);
            Controls.Add(checkBackup);
            Controls.Add(btnOffset);
            Controls.Add(btnUlozit);
            Controls.Add(btnNahratData);
            Controls.Add(btnVybratSoubor);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(958, 100);
            Name = "Form1";
            Text = "HED Editor";
            ((System.ComponentModel.ISupportInitialize)offsetInt).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVybratSoubor;
        private Button btnNahratData;
        private Button btnUlozit;
        private Button btnOffset;
        private CheckBox checkBackup;
        private ComboBox dropdownColumns;
        private NumericUpDown offsetInt;
        private TextBox textPath;
        private DataGridView dgvData;
    }
}
