
namespace SQL_STUDENTS2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.IdlTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.buttonCombo = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelMenu.Controls.Add(this.buttonCombo);
            this.panelMenu.Controls.Add(this.buttonDelete);
            this.panelMenu.Controls.Add(this.buttonUpdate);
            this.panelMenu.Controls.Add(this.buttonInsert);
            this.panelMenu.Controls.Add(this.buttonFind);
            this.panelMenu.Controls.Add(this.buttonSelect);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(212, 507);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(0, 329);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonDelete.Size = new System.Drawing.Size(212, 63);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete information";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(0, 266);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonUpdate.Size = new System.Drawing.Size(212, 63);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Change information";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonInsert.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInsert.FlatAppearance.BorderSize = 0;
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInsert.ForeColor = System.Drawing.Color.White;
            this.buttonInsert.Location = new System.Drawing.Point(0, 203);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonInsert.Size = new System.Drawing.Size(212, 63);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "Insert information";
            this.buttonInsert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFind.FlatAppearance.BorderSize = 0;
            this.buttonFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.ForeColor = System.Drawing.Color.White;
            this.buttonFind.Location = new System.Drawing.Point(0, 140);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonFind.Size = new System.Drawing.Size(212, 63);
            this.buttonFind.TabIndex = 2;
            this.buttonFind.Text = "Find people";
            this.buttonFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSelect.FlatAppearance.BorderSize = 0;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelect.ForeColor = System.Drawing.Color.White;
            this.buttonSelect.Location = new System.Drawing.Point(0, 77);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonSelect.Size = new System.Drawing.Size(212, 63);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "View table";
            this.buttonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(212, 77);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelTitle.Controls.Add(this.IdlTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(212, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(893, 77);
            this.panelTitle.TabIndex = 1;
            // 
            // IdlTitle
            // 
            this.IdlTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdlTitle.AutoSize = true;
            this.IdlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdlTitle.ForeColor = System.Drawing.Color.White;
            this.IdlTitle.Location = new System.Drawing.Point(393, 28);
            this.IdlTitle.Name = "IdlTitle";
            this.IdlTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IdlTitle.Size = new System.Drawing.Size(95, 31);
            this.IdlTitle.TabIndex = 0;
            this.IdlTitle.Text = "HOME";
            this.IdlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(212, 77);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(893, 430);
            this.panelDesktop.TabIndex = 2;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // buttonCombo
            // 
            this.buttonCombo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonCombo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCombo.FlatAppearance.BorderSize = 0;
            this.buttonCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCombo.ForeColor = System.Drawing.Color.White;
            this.buttonCombo.Location = new System.Drawing.Point(0, 392);
            this.buttonCombo.Name = "buttonCombo";
            this.buttonCombo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonCombo.Size = new System.Drawing.Size(212, 63);
            this.buttonCombo.TabIndex = 6;
            this.buttonCombo.Text = "Table change information";
            this.buttonCombo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCombo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCombo.UseVisualStyleBackColor = false;
            this.buttonCombo.Click += new System.EventHandler(this.buttonCombo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 507);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Telephone Raindbow UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panelMenu.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label IdlTitle;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button buttonCombo;
    }
}

