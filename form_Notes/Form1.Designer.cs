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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Generer = new System.Windows.Forms.Button();
            this.cbx_ChoixGroupe = new System.Windows.Forms.ComboBox();
            this.btn_OuvrirDossier = new System.Windows.Forms.Button();
            this.btn_ChoixDossier = new System.Windows.Forms.Button();
            this.lbl_Emplacement = new System.Windows.Forms.Label();
            this.lbl_ChoisirGroupe = new System.Windows.Forms.Label();
            this.lbl_GenerateurBulletins = new System.Windows.Forms.Label();
            this.btn_SelectionnerTout = new System.Windows.Forms.Button();
            this.dtg_Eleves = new System.Windows.Forms.DataGridView();
            this.flp_Log = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Devoirs = new System.Windows.Forms.DataGridView();
            this.btn_AjouterMatiere = new System.Windows.Forms.Button();
            this.clsMatiereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_AjouterDevoir = new System.Windows.Forms.Button();
            this.dgv_Matieres = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Eleves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devoirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsMatiereBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matieres)).BeginInit();
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
            this.btn_Generer.Location = new System.Drawing.Point(15, 210);
            this.btn_Generer.Name = "btn_Generer";
            this.btn_Generer.Size = new System.Drawing.Size(266, 43);
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
            this.cbx_ChoixGroupe.Location = new System.Drawing.Point(12, 64);
            this.cbx_ChoixGroupe.Name = "cbx_ChoixGroupe";
            this.cbx_ChoixGroupe.Size = new System.Drawing.Size(260, 24);
            this.cbx_ChoixGroupe.TabIndex = 2;
            this.cbx_ChoixGroupe.SelectedValueChanged += new System.EventHandler(this.cbx_ChoixGroupe_SelectedValueChanged);
            // 
            // btn_OuvrirDossier
            // 
            this.btn_OuvrirDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OuvrirDossier.FlatAppearance.BorderSize = 0;
            this.btn_OuvrirDossier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(200)))), ((int)(((byte)(93)))));
            this.btn_OuvrirDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OuvrirDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OuvrirDossier.ForeColor = System.Drawing.Color.White;
            this.btn_OuvrirDossier.Image = ((System.Drawing.Image)(resources.GetObject("btn_OuvrirDossier.Image")));
            this.btn_OuvrirDossier.Location = new System.Drawing.Point(233, 161);
            this.btn_OuvrirDossier.Name = "btn_OuvrirDossier";
            this.btn_OuvrirDossier.Size = new System.Drawing.Size(51, 43);
            this.btn_OuvrirDossier.TabIndex = 3;
            this.btn_OuvrirDossier.UseVisualStyleBackColor = false;
            this.btn_OuvrirDossier.Click += new System.EventHandler(this.btn_OuvrirDossier_Click_1);
            // 
            // btn_ChoixDossier
            // 
            this.btn_ChoixDossier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ChoixDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChoixDossier.Location = new System.Drawing.Point(12, 161);
            this.btn_ChoixDossier.Name = "btn_ChoixDossier";
            this.btn_ChoixDossier.Size = new System.Drawing.Size(209, 43);
            this.btn_ChoixDossier.TabIndex = 4;
            this.btn_ChoixDossier.Text = "Choix dossier d\'enregistrement";
            this.btn_ChoixDossier.UseVisualStyleBackColor = true;
            this.btn_ChoixDossier.Click += new System.EventHandler(this.btn_ChoixDossier_Click);
            this.btn_ChoixDossier.MouseEnter += new System.EventHandler(this.btn_ChoixDossier_MouseEnter);
            this.btn_ChoixDossier.MouseLeave += new System.EventHandler(this.btn_ChoixDossier_MouseLeave);
            // 
            // lbl_Emplacement
            // 
            this.lbl_Emplacement.AutoSize = true;
            this.lbl_Emplacement.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_Emplacement.Location = new System.Drawing.Point(72, 138);
            this.lbl_Emplacement.Name = "lbl_Emplacement";
            this.lbl_Emplacement.Size = new System.Drawing.Size(151, 13);
            this.lbl_Emplacement.TabIndex = 5;
            this.lbl_Emplacement.Text = "Emplacement des fichiers PDF";
            // 
            // lbl_ChoisirGroupe
            // 
            this.lbl_ChoisirGroupe.Location = new System.Drawing.Point(0, 32);
            this.lbl_ChoisirGroupe.Name = "lbl_ChoisirGroupe";
            this.lbl_ChoisirGroupe.Size = new System.Drawing.Size(281, 28);
            this.lbl_ChoisirGroupe.TabIndex = 6;
            this.lbl_ChoisirGroupe.Text = "Sélectionner un groupe";
            this.lbl_ChoisirGroupe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GenerateurBulletins
            // 
            this.lbl_GenerateurBulletins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(111)))), ((int)(((byte)(126)))));
            this.lbl_GenerateurBulletins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GenerateurBulletins.ForeColor = System.Drawing.Color.White;
            this.lbl_GenerateurBulletins.Location = new System.Drawing.Point(0, -1);
            this.lbl_GenerateurBulletins.Name = "lbl_GenerateurBulletins";
            this.lbl_GenerateurBulletins.Size = new System.Drawing.Size(986, 31);
            this.lbl_GenerateurBulletins.TabIndex = 8;
            this.lbl_GenerateurBulletins.Text = "Générateur de bulletins";
            this.lbl_GenerateurBulletins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelectionnerTout
            // 
            this.btn_SelectionnerTout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(146)))), ((int)(((byte)(163)))));
            this.btn_SelectionnerTout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SelectionnerTout.FlatAppearance.BorderSize = 0;
            this.btn_SelectionnerTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectionnerTout.ForeColor = System.Drawing.Color.White;
            this.btn_SelectionnerTout.Location = new System.Drawing.Point(524, 256);
            this.btn_SelectionnerTout.Name = "btn_SelectionnerTout";
            this.btn_SelectionnerTout.Size = new System.Drawing.Size(219, 23);
            this.btn_SelectionnerTout.TabIndex = 10;
            this.btn_SelectionnerTout.Text = "Sélectionner tous les élèves";
            this.btn_SelectionnerTout.UseVisualStyleBackColor = false;
            this.btn_SelectionnerTout.Click += new System.EventHandler(this.btn_SelectionnerTout_Click);
            // 
            // dtg_Eleves
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtg_Eleves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_Eleves.BackgroundColor = System.Drawing.Color.Black;
            this.dtg_Eleves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_Eleves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_Eleves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_Eleves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_Eleves.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_Eleves.GridColor = System.Drawing.SystemColors.GrayText;
            this.dtg_Eleves.Location = new System.Drawing.Point(290, 64);
            this.dtg_Eleves.Name = "dtg_Eleves";
            this.dtg_Eleves.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtg_Eleves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_Eleves.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_Eleves.Size = new System.Drawing.Size(685, 181);
            this.dtg_Eleves.TabIndex = 12;
            this.dtg_Eleves.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtg_Eleves_CellValidating);
            // 
            // flp_Log
            // 
            this.flp_Log.AutoScroll = true;
            this.flp_Log.BackColor = System.Drawing.Color.Black;
            this.flp_Log.Location = new System.Drawing.Point(12, 352);
            this.flp_Log.Name = "flp_Log";
            this.flp_Log.Size = new System.Drawing.Size(269, 99);
            this.flp_Log.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(12, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Devoirs
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_Devoirs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Devoirs.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_Devoirs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Devoirs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Devoirs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Devoirs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Devoirs.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Devoirs.GridColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Devoirs.Location = new System.Drawing.Point(290, 314);
            this.dgv_Devoirs.Name = "dgv_Devoirs";
            this.dgv_Devoirs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Devoirs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Devoirs.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Devoirs.Size = new System.Drawing.Size(685, 93);
            this.dgv_Devoirs.TabIndex = 14;
            // 
            // btn_AjouterMatiere
            // 
            this.btn_AjouterMatiere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(146)))), ((int)(((byte)(163)))));
            this.btn_AjouterMatiere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterMatiere.FlatAppearance.BorderSize = 0;
            this.btn_AjouterMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterMatiere.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterMatiere.Location = new System.Drawing.Point(15, 270);
            this.btn_AjouterMatiere.Name = "btn_AjouterMatiere";
            this.btn_AjouterMatiere.Size = new System.Drawing.Size(130, 23);
            this.btn_AjouterMatiere.TabIndex = 15;
            this.btn_AjouterMatiere.Text = "Ajouter matière";
            this.btn_AjouterMatiere.UseVisualStyleBackColor = false;
            this.btn_AjouterMatiere.Click += new System.EventHandler(this.btn_AjouterMatiere_Click);
            // 
            // clsMatiereBindingSource
            // 
            this.clsMatiereBindingSource.DataSource = typeof(Notes.cls_Matiere);
            // 
            // btn_AjouterDevoir
            // 
            this.btn_AjouterDevoir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(146)))), ((int)(((byte)(163)))));
            this.btn_AjouterDevoir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterDevoir.FlatAppearance.BorderSize = 0;
            this.btn_AjouterDevoir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterDevoir.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterDevoir.Location = new System.Drawing.Point(151, 270);
            this.btn_AjouterDevoir.Name = "btn_AjouterDevoir";
            this.btn_AjouterDevoir.Size = new System.Drawing.Size(130, 23);
            this.btn_AjouterDevoir.TabIndex = 16;
            this.btn_AjouterDevoir.Text = "Ajouter Devoir";
            this.btn_AjouterDevoir.UseVisualStyleBackColor = false;
            // 
            // dgv_Matieres
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_Matieres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Matieres.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_Matieres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Matieres.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Matieres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Matieres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Matieres.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Matieres.GridColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Matieres.Location = new System.Drawing.Point(290, 451);
            this.dgv_Matieres.Name = "dgv_Matieres";
            this.dgv_Matieres.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Matieres.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Matieres.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Matieres.Size = new System.Drawing.Size(685, 81);
            this.dgv_Matieres.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(287, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(685, 28);
            this.label2.TabIndex = 18;
            this.label2.Text = "Élèves";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(287, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(685, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Devoirs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(287, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(685, 28);
            this.label4.TabIndex = 20;
            this.label4.Text = "Matières";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(986, 720);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_Matieres);
            this.Controls.Add(this.btn_AjouterDevoir);
            this.Controls.Add(this.btn_AjouterMatiere);
            this.Controls.Add(this.dgv_Devoirs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flp_Log);
            this.Controls.Add(this.dtg_Eleves);
            this.Controls.Add(this.btn_SelectionnerTout);
            this.Controls.Add(this.lbl_GenerateurBulletins);
            this.Controls.Add(this.lbl_ChoisirGroupe);
            this.Controls.Add(this.lbl_Emplacement);
            this.Controls.Add(this.btn_ChoixDossier);
            this.Controls.Add(this.btn_OuvrirDossier);
            this.Controls.Add(this.cbx_ChoixGroupe);
            this.Controls.Add(this.btn_Generer);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Générateur de bulletins";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Eleves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devoirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsMatiereBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matieres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Generer;
        private System.Windows.Forms.ComboBox cbx_ChoixGroupe;
        private System.Windows.Forms.Button btn_OuvrirDossier;
        private System.Windows.Forms.Button btn_ChoixDossier;
        private System.Windows.Forms.Label lbl_Emplacement;
        private System.Windows.Forms.Label lbl_ChoisirGroupe;
        private System.Windows.Forms.Label lbl_GenerateurBulletins;
        private System.Windows.Forms.Button btn_SelectionnerTout;
        private System.Windows.Forms.DataGridView dtg_Eleves;
        private System.Windows.Forms.FlowLayoutPanel flp_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource clsMatiereBindingSource;
        private System.Windows.Forms.DataGridView dgv_Devoirs;
        private System.Windows.Forms.Button btn_AjouterMatiere;
        private System.Windows.Forms.Button btn_AjouterDevoir;
        private System.Windows.Forms.DataGridView dgv_Matieres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

