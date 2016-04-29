namespace form_Notes
{
    partial class frm_AjouterModifierEleve
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
            this.lbl_Nom = new System.Windows.Forms.Label();
            this.tbx_Nom = new System.Windows.Forms.TextBox();
            this.tbx_Prenom = new System.Windows.Forms.TextBox();
            this.lbl_Prenom = new System.Windows.Forms.Label();
            this.lbl_DateDeNaissance = new System.Windows.Forms.Label();
            this.lbl_Groupe = new System.Windows.Forms.Label();
            this.lbl_Adresse = new System.Windows.Forms.Label();
            this.rtb_Adresse = new System.Windows.Forms.RichTextBox();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.cbx_Groupe = new System.Windows.Forms.ComboBox();
            this.dtp_DateDeNaissance = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbl_Nom
            // 
            this.lbl_Nom.AutoSize = true;
            this.lbl_Nom.Location = new System.Drawing.Point(12, 9);
            this.lbl_Nom.Name = "lbl_Nom";
            this.lbl_Nom.Size = new System.Drawing.Size(29, 13);
            this.lbl_Nom.TabIndex = 0;
            this.lbl_Nom.Text = "Nom";
            // 
            // tbx_Nom
            // 
            this.tbx_Nom.Location = new System.Drawing.Point(114, 9);
            this.tbx_Nom.Name = "tbx_Nom";
            this.tbx_Nom.Size = new System.Drawing.Size(196, 20);
            this.tbx_Nom.TabIndex = 1;
            // 
            // tbx_Prenom
            // 
            this.tbx_Prenom.Location = new System.Drawing.Point(114, 35);
            this.tbx_Prenom.Name = "tbx_Prenom";
            this.tbx_Prenom.Size = new System.Drawing.Size(196, 20);
            this.tbx_Prenom.TabIndex = 3;
            // 
            // lbl_Prenom
            // 
            this.lbl_Prenom.AutoSize = true;
            this.lbl_Prenom.Location = new System.Drawing.Point(12, 35);
            this.lbl_Prenom.Name = "lbl_Prenom";
            this.lbl_Prenom.Size = new System.Drawing.Size(43, 13);
            this.lbl_Prenom.TabIndex = 2;
            this.lbl_Prenom.Text = "Prénom";
            // 
            // lbl_DateDeNaissance
            // 
            this.lbl_DateDeNaissance.AutoSize = true;
            this.lbl_DateDeNaissance.Location = new System.Drawing.Point(12, 61);
            this.lbl_DateDeNaissance.Name = "lbl_DateDeNaissance";
            this.lbl_DateDeNaissance.Size = new System.Drawing.Size(96, 13);
            this.lbl_DateDeNaissance.TabIndex = 4;
            this.lbl_DateDeNaissance.Text = "Date de naissance";
            // 
            // lbl_Groupe
            // 
            this.lbl_Groupe.AutoSize = true;
            this.lbl_Groupe.Location = new System.Drawing.Point(12, 87);
            this.lbl_Groupe.Name = "lbl_Groupe";
            this.lbl_Groupe.Size = new System.Drawing.Size(42, 13);
            this.lbl_Groupe.TabIndex = 6;
            this.lbl_Groupe.Text = "Groupe";
            // 
            // lbl_Adresse
            // 
            this.lbl_Adresse.AutoSize = true;
            this.lbl_Adresse.Location = new System.Drawing.Point(12, 113);
            this.lbl_Adresse.Name = "lbl_Adresse";
            this.lbl_Adresse.Size = new System.Drawing.Size(45, 13);
            this.lbl_Adresse.TabIndex = 8;
            this.lbl_Adresse.Text = "Adresse";
            // 
            // rtb_Adresse
            // 
            this.rtb_Adresse.Location = new System.Drawing.Point(114, 113);
            this.rtb_Adresse.Name = "rtb_Adresse";
            this.rtb_Adresse.Size = new System.Drawing.Size(196, 54);
            this.rtb_Adresse.TabIndex = 9;
            this.rtb_Adresse.Text = "";
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(12, 217);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(297, 32);
            this.btn_Valider.TabIndex = 10;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // cbx_Groupe
            // 
            this.cbx_Groupe.FormattingEnabled = true;
            this.cbx_Groupe.Location = new System.Drawing.Point(114, 87);
            this.cbx_Groupe.Name = "cbx_Groupe";
            this.cbx_Groupe.Size = new System.Drawing.Size(196, 21);
            this.cbx_Groupe.TabIndex = 11;
            // 
            // dtp_DateDeNaissance
            // 
            this.dtp_DateDeNaissance.Location = new System.Drawing.Point(114, 61);
            this.dtp_DateDeNaissance.Name = "dtp_DateDeNaissance";
            this.dtp_DateDeNaissance.Size = new System.Drawing.Size(196, 20);
            this.dtp_DateDeNaissance.TabIndex = 12;
            // 
            // frm_AjouterModifierEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 261);
            this.Controls.Add(this.dtp_DateDeNaissance);
            this.Controls.Add(this.cbx_Groupe);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.rtb_Adresse);
            this.Controls.Add(this.lbl_Adresse);
            this.Controls.Add(this.lbl_Groupe);
            this.Controls.Add(this.lbl_DateDeNaissance);
            this.Controls.Add(this.tbx_Prenom);
            this.Controls.Add(this.lbl_Prenom);
            this.Controls.Add(this.tbx_Nom);
            this.Controls.Add(this.lbl_Nom);
            this.Name = "frm_AjouterModifierEleve";
            this.Text = "Ajouter/modifier un élève";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Nom;
        private System.Windows.Forms.TextBox tbx_Nom;
        private System.Windows.Forms.TextBox tbx_Prenom;
        private System.Windows.Forms.Label lbl_Prenom;
        private System.Windows.Forms.Label lbl_DateDeNaissance;
        private System.Windows.Forms.Label lbl_Groupe;
        private System.Windows.Forms.Label lbl_Adresse;
        private System.Windows.Forms.RichTextBox rtb_Adresse;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.ComboBox cbx_Groupe;
        private System.Windows.Forms.DateTimePicker dtp_DateDeNaissance;
    }
}