namespace form_Notes
{
    partial class frm_ListeEnseignants
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
            this.cbx_Enseignants = new System.Windows.Forms.ComboBox();
            this.lbl_Enseignant = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.dtp_DateEntree = new System.Windows.Forms.DateTimePicker();
            this.lbl_DateEntree = new System.Windows.Forms.Label();
            this.lbl_Anciennete = new System.Windows.Forms.Label();
            this.tbx_Anciennete = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbx_Enseignants
            // 
            this.cbx_Enseignants.FormattingEnabled = true;
            this.cbx_Enseignants.Location = new System.Drawing.Point(89, 11);
            this.cbx_Enseignants.Name = "cbx_Enseignants";
            this.cbx_Enseignants.Size = new System.Drawing.Size(183, 21);
            this.cbx_Enseignants.TabIndex = 0;
            this.cbx_Enseignants.SelectedIndexChanged += new System.EventHandler(this.cbx_Enseignants_SelectedIndexChanged);
            // 
            // lbl_Enseignant
            // 
            this.lbl_Enseignant.AutoSize = true;
            this.lbl_Enseignant.Location = new System.Drawing.Point(12, 14);
            this.lbl_Enseignant.Name = "lbl_Enseignant";
            this.lbl_Enseignant.Size = new System.Drawing.Size(60, 13);
            this.lbl_Enseignant.TabIndex = 1;
            this.lbl_Enseignant.Text = "Enseignant";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(12, 54);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 2;
            this.lbl_Email.Text = "Email";
            // 
            // tbx_Email
            // 
            this.tbx_Email.Enabled = false;
            this.tbx_Email.Location = new System.Drawing.Point(89, 51);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(183, 20);
            this.tbx_Email.TabIndex = 3;
            // 
            // dtp_DateEntree
            // 
            this.dtp_DateEntree.Enabled = false;
            this.dtp_DateEntree.Location = new System.Drawing.Point(89, 88);
            this.dtp_DateEntree.Name = "dtp_DateEntree";
            this.dtp_DateEntree.Size = new System.Drawing.Size(183, 20);
            this.dtp_DateEntree.TabIndex = 4;
            // 
            // lbl_DateEntree
            // 
            this.lbl_DateEntree.AutoSize = true;
            this.lbl_DateEntree.Location = new System.Drawing.Point(12, 94);
            this.lbl_DateEntree.Name = "lbl_DateEntree";
            this.lbl_DateEntree.Size = new System.Drawing.Size(71, 13);
            this.lbl_DateEntree.TabIndex = 5;
            this.lbl_DateEntree.Text = "Date d\'entrée";
            // 
            // lbl_Anciennete
            // 
            this.lbl_Anciennete.AutoSize = true;
            this.lbl_Anciennete.Location = new System.Drawing.Point(12, 128);
            this.lbl_Anciennete.Name = "lbl_Anciennete";
            this.lbl_Anciennete.Size = new System.Drawing.Size(61, 13);
            this.lbl_Anciennete.TabIndex = 6;
            this.lbl_Anciennete.Text = "Ancienneté";
            // 
            // tbx_Anciennete
            // 
            this.tbx_Anciennete.Enabled = false;
            this.tbx_Anciennete.Location = new System.Drawing.Point(89, 125);
            this.tbx_Anciennete.Name = "tbx_Anciennete";
            this.tbx_Anciennete.Size = new System.Drawing.Size(183, 20);
            this.tbx_Anciennete.TabIndex = 7;
            // 
            // frm_ListeEnseignants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tbx_Anciennete);
            this.Controls.Add(this.lbl_Anciennete);
            this.Controls.Add(this.lbl_DateEntree);
            this.Controls.Add(this.dtp_DateEntree);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Enseignant);
            this.Controls.Add(this.cbx_Enseignants);
            this.Name = "frm_ListeEnseignants";
            this.Text = "Liste des enseignants";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Enseignants;
        private System.Windows.Forms.Label lbl_Enseignant;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.DateTimePicker dtp_DateEntree;
        private System.Windows.Forms.Label lbl_DateEntree;
        private System.Windows.Forms.Label lbl_Anciennete;
        private System.Windows.Forms.TextBox tbx_Anciennete;
    }
}