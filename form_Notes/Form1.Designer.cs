namespace form_Notes
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Generer = new System.Windows.Forms.Button();
            this.cbx_ChoixGroupe = new System.Windows.Forms.ComboBox();
            this.btn_OuvrirDossier = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_ChoixDossier = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_Emplacement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Generer
            // 
            this.btn_Generer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(146)))), ((int)(((byte)(163)))));
            this.btn_Generer.FlatAppearance.BorderSize = 0;
            this.btn_Generer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(200)))), ((int)(((byte)(93)))));
            this.btn_Generer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Generer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generer.ForeColor = System.Drawing.Color.White;
            this.btn_Generer.Location = new System.Drawing.Point(12, 206);
            this.btn_Generer.Name = "btn_Generer";
            this.btn_Generer.Size = new System.Drawing.Size(203, 43);
            this.btn_Generer.TabIndex = 1;
            this.btn_Generer.Text = "GÉNÉRER PDF";
            this.btn_Generer.UseVisualStyleBackColor = false;
            this.btn_Generer.Click += new System.EventHandler(this.btn_Generer_Click);
            // 
            // cbx_ChoixGroupe
            // 
            this.cbx_ChoixGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ChoixGroupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ChoixGroupe.FormattingEnabled = true;
            this.cbx_ChoixGroupe.ItemHeight = 16;
            this.cbx_ChoixGroupe.Location = new System.Drawing.Point(12, 72);
            this.cbx_ChoixGroupe.Name = "cbx_ChoixGroupe";
            this.cbx_ChoixGroupe.Size = new System.Drawing.Size(260, 24);
            this.cbx_ChoixGroupe.TabIndex = 2;
            // 
            // btn_OuvrirDossier
            // 
            this.btn_OuvrirDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OuvrirDossier.FlatAppearance.BorderSize = 0;
            this.btn_OuvrirDossier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(200)))), ((int)(((byte)(93)))));
            this.btn_OuvrirDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OuvrirDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OuvrirDossier.ForeColor = System.Drawing.Color.White;
            this.btn_OuvrirDossier.Location = new System.Drawing.Point(221, 206);
            this.btn_OuvrirDossier.Name = "btn_OuvrirDossier";
            this.btn_OuvrirDossier.Size = new System.Drawing.Size(51, 43);
            this.btn_OuvrirDossier.TabIndex = 3;
            this.btn_OuvrirDossier.Text = "...";
            this.btn_OuvrirDossier.UseVisualStyleBackColor = false;
            this.btn_OuvrirDossier.Click += new System.EventHandler(this.btn_OuvrirDossier_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_ChoixDossier
            // 
            this.btn_ChoixDossier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ChoixDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChoixDossier.Location = new System.Drawing.Point(12, 177);
            this.btn_ChoixDossier.Name = "btn_ChoixDossier";
            this.btn_ChoixDossier.Size = new System.Drawing.Size(260, 23);
            this.btn_ChoixDossier.TabIndex = 4;
            this.btn_ChoixDossier.Text = "Choix dossier d\'enregistrement";
            this.btn_ChoixDossier.UseVisualStyleBackColor = true;
            this.btn_ChoixDossier.Click += new System.EventHandler(this.btn_ChoixDossier_Click);
            this.btn_ChoixDossier.MouseEnter += new System.EventHandler(this.btn_ChoixDossier_MouseEnter);
            this.btn_ChoixDossier.MouseLeave += new System.EventHandler(this.btn_ChoixDossier_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // lbl_Emplacement
            // 
            this.lbl_Emplacement.AutoSize = true;
            this.lbl_Emplacement.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_Emplacement.Location = new System.Drawing.Point(64, 156);
            this.lbl_Emplacement.Name = "lbl_Emplacement";
            this.lbl_Emplacement.Size = new System.Drawing.Size(151, 13);
            this.lbl_Emplacement.TabIndex = 5;
            this.lbl_Emplacement.Text = "Emplacement des fichiers PDF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbl_Emplacement);
            this.Controls.Add(this.btn_ChoixDossier);
            this.Controls.Add(this.btn_OuvrirDossier);
            this.Controls.Add(this.cbx_ChoixGroupe);
            this.Controls.Add(this.btn_Generer);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Générateur de bulletins";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Generer;
        private System.Windows.Forms.ComboBox cbx_ChoixGroupe;
        private System.Windows.Forms.Button btn_OuvrirDossier;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_ChoixDossier;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_Emplacement;
    }
}

