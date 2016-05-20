namespace form_Notes
{
    partial class frm_AjouterModifierNote
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
            this.lbl_Devoir = new System.Windows.Forms.Label();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.lbl_Eleve = new System.Windows.Forms.Label();
            this.cbx_Eleve = new System.Windows.Forms.ComboBox();
            this.cbx_Devoir = new System.Windows.Forms.ComboBox();
            this.lbl_Note = new System.Windows.Forms.Label();
            this.tbx_Note = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Devoir
            // 
            this.lbl_Devoir.AutoSize = true;
            this.lbl_Devoir.Location = new System.Drawing.Point(24, 17);
            this.lbl_Devoir.Name = "lbl_Devoir";
            this.lbl_Devoir.Size = new System.Drawing.Size(38, 13);
            this.lbl_Devoir.TabIndex = 0;
            this.lbl_Devoir.Text = "Devoir";
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(12, 187);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(260, 34);
            this.btn_Valider.TabIndex = 4;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // lbl_Eleve
            // 
            this.lbl_Eleve.AutoSize = true;
            this.lbl_Eleve.Location = new System.Drawing.Point(24, 52);
            this.lbl_Eleve.Name = "lbl_Eleve";
            this.lbl_Eleve.Size = new System.Drawing.Size(34, 13);
            this.lbl_Eleve.TabIndex = 6;
            this.lbl_Eleve.Text = "Élève";
            // 
            // cbx_Eleve
            // 
            this.cbx_Eleve.FormattingEnabled = true;
            this.cbx_Eleve.Location = new System.Drawing.Point(95, 49);
            this.cbx_Eleve.Name = "cbx_Eleve";
            this.cbx_Eleve.Size = new System.Drawing.Size(177, 21);
            this.cbx_Eleve.TabIndex = 7;
            // 
            // cbx_Devoir
            // 
            this.cbx_Devoir.FormattingEnabled = true;
            this.cbx_Devoir.Location = new System.Drawing.Point(95, 14);
            this.cbx_Devoir.Name = "cbx_Devoir";
            this.cbx_Devoir.Size = new System.Drawing.Size(177, 21);
            this.cbx_Devoir.TabIndex = 8;
            // 
            // lbl_Note
            // 
            this.lbl_Note.AutoSize = true;
            this.lbl_Note.Location = new System.Drawing.Point(24, 85);
            this.lbl_Note.Name = "lbl_Note";
            this.lbl_Note.Size = new System.Drawing.Size(30, 13);
            this.lbl_Note.TabIndex = 9;
            this.lbl_Note.Text = "Note";
            // 
            // tbx_Note
            // 
            this.tbx_Note.Location = new System.Drawing.Point(95, 85);
            this.tbx_Note.Name = "tbx_Note";
            this.tbx_Note.Size = new System.Drawing.Size(177, 20);
            this.tbx_Note.TabIndex = 10;
            // 
            // frm_AjouterModifierNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.tbx_Note);
            this.Controls.Add(this.lbl_Note);
            this.Controls.Add(this.cbx_Devoir);
            this.Controls.Add(this.cbx_Eleve);
            this.Controls.Add(this.lbl_Eleve);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.lbl_Devoir);
            this.Name = "frm_AjouterModifierNote";
            this.Text = "Ajouter/modifier une note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Devoir;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Label lbl_Eleve;
        private System.Windows.Forms.ComboBox cbx_Eleve;
        private System.Windows.Forms.ComboBox cbx_Devoir;
        private System.Windows.Forms.Label lbl_Note;
        private System.Windows.Forms.TextBox tbx_Note;
    }
}