namespace form_Notes
{
    partial class frm_AjouterMatiere
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
            this.btn_Valider = new System.Windows.Forms.Button();
            this.lbl_Libelle = new System.Windows.Forms.Label();
            this.tbx_Libelle = new System.Windows.Forms.TextBox();
            this.lbl_Groupe = new System.Windows.Forms.Label();
            this.cbx_Groupes = new System.Windows.Forms.ComboBox();
            this.lbl_Coefficient = new System.Windows.Forms.Label();
            this.lbl_Professeur = new System.Windows.Forms.Label();
            this.tbx_Coefficient = new System.Windows.Forms.TextBox();
            this.tbx_Professeur = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(12, 127);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(260, 122);
            this.btn_Valider.TabIndex = 0;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // lbl_Libelle
            // 
            this.lbl_Libelle.AutoSize = true;
            this.lbl_Libelle.Location = new System.Drawing.Point(17, 24);
            this.lbl_Libelle.Name = "lbl_Libelle";
            this.lbl_Libelle.Size = new System.Drawing.Size(37, 13);
            this.lbl_Libelle.TabIndex = 1;
            this.lbl_Libelle.Text = "Libellé";
            // 
            // tbx_Libelle
            // 
            this.tbx_Libelle.Location = new System.Drawing.Point(72, 21);
            this.tbx_Libelle.Name = "tbx_Libelle";
            this.tbx_Libelle.Size = new System.Drawing.Size(200, 20);
            this.tbx_Libelle.TabIndex = 2;
            // 
            // lbl_Groupe
            // 
            this.lbl_Groupe.AutoSize = true;
            this.lbl_Groupe.Location = new System.Drawing.Point(17, 50);
            this.lbl_Groupe.Name = "lbl_Groupe";
            this.lbl_Groupe.Size = new System.Drawing.Size(42, 13);
            this.lbl_Groupe.TabIndex = 3;
            this.lbl_Groupe.Text = "Groupe";
            // 
            // cbx_Groupes
            // 
            this.cbx_Groupes.FormattingEnabled = true;
            this.cbx_Groupes.Location = new System.Drawing.Point(72, 47);
            this.cbx_Groupes.Name = "cbx_Groupes";
            this.cbx_Groupes.Size = new System.Drawing.Size(200, 21);
            this.cbx_Groupes.TabIndex = 4;
            // 
            // lbl_Coefficient
            // 
            this.lbl_Coefficient.AutoSize = true;
            this.lbl_Coefficient.Location = new System.Drawing.Point(9, 77);
            this.lbl_Coefficient.Name = "lbl_Coefficient";
            this.lbl_Coefficient.Size = new System.Drawing.Size(57, 13);
            this.lbl_Coefficient.TabIndex = 5;
            this.lbl_Coefficient.Text = "Coefficient";
            // 
            // lbl_Professeur
            // 
            this.lbl_Professeur.AutoSize = true;
            this.lbl_Professeur.Location = new System.Drawing.Point(9, 104);
            this.lbl_Professeur.Name = "lbl_Professeur";
            this.lbl_Professeur.Size = new System.Drawing.Size(57, 13);
            this.lbl_Professeur.TabIndex = 6;
            this.lbl_Professeur.Text = "Professeur";
            // 
            // tbx_Coefficient
            // 
            this.tbx_Coefficient.Location = new System.Drawing.Point(72, 74);
            this.tbx_Coefficient.Name = "tbx_Coefficient";
            this.tbx_Coefficient.Size = new System.Drawing.Size(200, 20);
            this.tbx_Coefficient.TabIndex = 7;
            // 
            // tbx_Professeur
            // 
            this.tbx_Professeur.Location = new System.Drawing.Point(72, 101);
            this.tbx_Professeur.Name = "tbx_Professeur";
            this.tbx_Professeur.Size = new System.Drawing.Size(200, 20);
            this.tbx_Professeur.TabIndex = 8;
            // 
            // frm_AjouterMatiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbx_Professeur);
            this.Controls.Add(this.tbx_Coefficient);
            this.Controls.Add(this.lbl_Professeur);
            this.Controls.Add(this.lbl_Coefficient);
            this.Controls.Add(this.cbx_Groupes);
            this.Controls.Add(this.lbl_Groupe);
            this.Controls.Add(this.tbx_Libelle);
            this.Controls.Add(this.lbl_Libelle);
            this.Controls.Add(this.btn_Valider);
            this.Name = "frm_AjouterMatiere";
            this.Text = "Ajouter une matière";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Label lbl_Libelle;
        private System.Windows.Forms.TextBox tbx_Libelle;
        private System.Windows.Forms.Label lbl_Groupe;
        private System.Windows.Forms.ComboBox cbx_Groupes;
        private System.Windows.Forms.Label lbl_Coefficient;
        private System.Windows.Forms.Label lbl_Professeur;
        private System.Windows.Forms.TextBox tbx_Coefficient;
        private System.Windows.Forms.TextBox tbx_Professeur;
    }
}