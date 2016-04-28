namespace form_Notes
{
    partial class frm_AjouterDevoir
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
            this.lbl_Libelle = new System.Windows.Forms.Label();
            this.lbl_DateDevoir = new System.Windows.Forms.Label();
            this.tbx_Libelle = new System.Windows.Forms.TextBox();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.dtp_DateDevoir = new System.Windows.Forms.DateTimePicker();
            this.lbl_Matiere = new System.Windows.Forms.Label();
            this.cbx_Matiere = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Libelle
            // 
            this.lbl_Libelle.AutoSize = true;
            this.lbl_Libelle.Location = new System.Drawing.Point(12, 9);
            this.lbl_Libelle.Name = "lbl_Libelle";
            this.lbl_Libelle.Size = new System.Drawing.Size(37, 13);
            this.lbl_Libelle.TabIndex = 0;
            this.lbl_Libelle.Text = "Libellé";
            // 
            // lbl_DateDevoir
            // 
            this.lbl_DateDevoir.AutoSize = true;
            this.lbl_DateDevoir.Location = new System.Drawing.Point(12, 41);
            this.lbl_DateDevoir.Name = "lbl_DateDevoir";
            this.lbl_DateDevoir.Size = new System.Drawing.Size(77, 13);
            this.lbl_DateDevoir.TabIndex = 1;
            this.lbl_DateDevoir.Text = "Date du devoir";
            // 
            // tbx_Libelle
            // 
            this.tbx_Libelle.Location = new System.Drawing.Point(95, 6);
            this.tbx_Libelle.Name = "tbx_Libelle";
            this.tbx_Libelle.Size = new System.Drawing.Size(184, 20);
            this.tbx_Libelle.TabIndex = 2;
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(12, 215);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(260, 34);
            this.btn_Valider.TabIndex = 4;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // dtp_DateDevoir
            // 
            this.dtp_DateDevoir.Location = new System.Drawing.Point(95, 38);
            this.dtp_DateDevoir.Name = "dtp_DateDevoir";
            this.dtp_DateDevoir.Size = new System.Drawing.Size(184, 20);
            this.dtp_DateDevoir.TabIndex = 5;
            // 
            // lbl_Matiere
            // 
            this.lbl_Matiere.AutoSize = true;
            this.lbl_Matiere.Location = new System.Drawing.Point(14, 72);
            this.lbl_Matiere.Name = "lbl_Matiere";
            this.lbl_Matiere.Size = new System.Drawing.Size(42, 13);
            this.lbl_Matiere.TabIndex = 6;
            this.lbl_Matiere.Text = "Matière";
            // 
            // cbx_Matiere
            // 
            this.cbx_Matiere.FormattingEnabled = true;
            this.cbx_Matiere.Location = new System.Drawing.Point(95, 70);
            this.cbx_Matiere.Name = "cbx_Matiere";
            this.cbx_Matiere.Size = new System.Drawing.Size(184, 21);
            this.cbx_Matiere.TabIndex = 7;
            // 
            // frm_AjouterDevoir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cbx_Matiere);
            this.Controls.Add(this.lbl_Matiere);
            this.Controls.Add(this.dtp_DateDevoir);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.tbx_Libelle);
            this.Controls.Add(this.lbl_DateDevoir);
            this.Controls.Add(this.lbl_Libelle);
            this.Name = "frm_AjouterDevoir";
            this.Text = "Ajouter un devoir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Libelle;
        private System.Windows.Forms.Label lbl_DateDevoir;
        private System.Windows.Forms.TextBox tbx_Libelle;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.DateTimePicker dtp_DateDevoir;
        private System.Windows.Forms.Label lbl_Matiere;
        private System.Windows.Forms.ComboBox cbx_Matiere;
    }
}