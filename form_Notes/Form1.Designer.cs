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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Generer = new System.Windows.Forms.Button();
            this.cbx_ChoixGroupe = new System.Windows.Forms.ComboBox();
            this.btn_OuvrirDossier = new System.Windows.Forms.Button();
            this.btn_ChoixDossier = new System.Windows.Forms.Button();
            this.lbl_Emplacement = new System.Windows.Forms.Label();
            this.lbl_ChoisirGroupe = new System.Windows.Forms.Label();
            this.lbl_GenerateurBulletins = new System.Windows.Forms.Label();
            this.btn_SelectionnerTout = new System.Windows.Forms.Button();
            this.dgv_Eleves = new System.Windows.Forms.DataGridView();
            this.flp_Log = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Devoirs = new System.Windows.Forms.DataGridView();
            this.btn_AjouterMatiere = new System.Windows.Forms.Button();
            this.btn_AjouterDevoir = new System.Windows.Forms.Button();
            this.dgv_Matieres = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ModifierMatiere = new System.Windows.Forms.Button();
            this.btn_ModifierDevoir = new System.Windows.Forms.Button();
            this.tc_ElevesDevoirs = new System.Windows.Forms.TabControl();
            this.tp_Eleves = new System.Windows.Forms.TabPage();
            this.tp_Devoirs = new System.Windows.Forms.TabPage();
            this.tp_Matieres = new System.Windows.Forms.TabPage();
            this.tp_Notes = new System.Windows.Forms.TabPage();
            this.dgv_Notes = new System.Windows.Forms.DataGridView();
            this.btn_AjouterEleve = new System.Windows.Forms.Button();
            this.btn_ModifierEleve = new System.Windows.Forms.Button();
            this.btn_AjouterNote = new System.Windows.Forms.Button();
            this.btn_ModifierNote = new System.Windows.Forms.Button();
            this.btn_SupprimerNote = new System.Windows.Forms.Button();
            this.btn_SupprimerMatiere = new System.Windows.Forms.Button();
            this.btn_ListeEnseignants = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Eleves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devoirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matieres)).BeginInit();
            this.tc_ElevesDevoirs.SuspendLayout();
            this.tp_Eleves.SuspendLayout();
            this.tp_Devoirs.SuspendLayout();
            this.tp_Matieres.SuspendLayout();
            this.tp_Notes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Generer
            // 
            this.btn_Generer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_Generer.FlatAppearance.BorderSize = 0;
            this.btn_Generer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Generer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generer.ForeColor = System.Drawing.Color.White;
            this.btn_Generer.Location = new System.Drawing.Point(719, 480);
            this.btn_Generer.Name = "btn_Generer";
            this.btn_Generer.Size = new System.Drawing.Size(79, 53);
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
            this.cbx_ChoixGroupe.Location = new System.Drawing.Point(8, 63);
            this.cbx_ChoixGroupe.Name = "cbx_ChoixGroupe";
            this.cbx_ChoixGroupe.Size = new System.Drawing.Size(835, 24);
            this.cbx_ChoixGroupe.TabIndex = 2;
            this.cbx_ChoixGroupe.SelectedValueChanged += new System.EventHandler(this.cbx_ChoixGroupe_SelectedValueChanged);
            // 
            // btn_OuvrirDossier
            // 
            this.btn_OuvrirDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OuvrirDossier.FlatAppearance.BorderSize = 0;
            this.btn_OuvrirDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OuvrirDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OuvrirDossier.ForeColor = System.Drawing.Color.White;
            this.btn_OuvrirDossier.Image = ((System.Drawing.Image)(resources.GetObject("btn_OuvrirDossier.Image")));
            this.btn_OuvrirDossier.Location = new System.Drawing.Point(804, 480);
            this.btn_OuvrirDossier.Name = "btn_OuvrirDossier";
            this.btn_OuvrirDossier.Size = new System.Drawing.Size(45, 52);
            this.btn_OuvrirDossier.TabIndex = 3;
            this.btn_OuvrirDossier.UseVisualStyleBackColor = false;
            this.btn_OuvrirDossier.Click += new System.EventHandler(this.btn_OuvrirDossier_Click_1);
            // 
            // btn_ChoixDossier
            // 
            this.btn_ChoixDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btn_ChoixDossier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ChoixDossier.FlatAppearance.BorderSize = 0;
            this.btn_ChoixDossier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChoixDossier.Location = new System.Drawing.Point(719, 434);
            this.btn_ChoixDossier.Name = "btn_ChoixDossier";
            this.btn_ChoixDossier.Size = new System.Drawing.Size(130, 40);
            this.btn_ChoixDossier.TabIndex = 4;
            this.btn_ChoixDossier.Text = "Choix dossier d\'enregistrement";
            this.btn_ChoixDossier.UseVisualStyleBackColor = false;
            this.btn_ChoixDossier.Click += new System.EventHandler(this.btn_ChoixDossier_Click);
            this.btn_ChoixDossier.MouseEnter += new System.EventHandler(this.btn_ChoixDossier_MouseEnter);
            this.btn_ChoixDossier.MouseLeave += new System.EventHandler(this.btn_ChoixDossier_MouseLeave);
            // 
            // lbl_Emplacement
            // 
            this.lbl_Emplacement.AutoSize = true;
            this.lbl_Emplacement.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Emplacement.Location = new System.Drawing.Point(370, 540);
            this.lbl_Emplacement.Name = "lbl_Emplacement";
            this.lbl_Emplacement.Size = new System.Drawing.Size(151, 13);
            this.lbl_Emplacement.TabIndex = 5;
            this.lbl_Emplacement.Text = "Emplacement des fichiers PDF";
            // 
            // lbl_ChoisirGroupe
            // 
            this.lbl_ChoisirGroupe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lbl_ChoisirGroupe.Location = new System.Drawing.Point(9, 40);
            this.lbl_ChoisirGroupe.Name = "lbl_ChoisirGroupe";
            this.lbl_ChoisirGroupe.Size = new System.Drawing.Size(837, 20);
            this.lbl_ChoisirGroupe.TabIndex = 6;
            this.lbl_ChoisirGroupe.Text = "Sélectionner un groupe";
            this.lbl_ChoisirGroupe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GenerateurBulletins
            // 
            this.lbl_GenerateurBulletins.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_GenerateurBulletins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GenerateurBulletins.ForeColor = System.Drawing.Color.White;
            this.lbl_GenerateurBulletins.Location = new System.Drawing.Point(8, 9);
            this.lbl_GenerateurBulletins.Name = "lbl_GenerateurBulletins";
            this.lbl_GenerateurBulletins.Size = new System.Drawing.Size(834, 31);
            this.lbl_GenerateurBulletins.TabIndex = 8;
            this.lbl_GenerateurBulletins.Text = "Générateur de bulletins";
            this.lbl_GenerateurBulletins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelectionnerTout
            // 
            this.btn_SelectionnerTout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_SelectionnerTout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SelectionnerTout.FlatAppearance.BorderSize = 0;
            this.btn_SelectionnerTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectionnerTout.ForeColor = System.Drawing.Color.White;
            this.btn_SelectionnerTout.Location = new System.Drawing.Point(719, 122);
            this.btn_SelectionnerTout.Name = "btn_SelectionnerTout";
            this.btn_SelectionnerTout.Size = new System.Drawing.Size(130, 46);
            this.btn_SelectionnerTout.TabIndex = 10;
            this.btn_SelectionnerTout.Text = "Sélectionner tous les élèves";
            this.btn_SelectionnerTout.UseVisualStyleBackColor = false;
            this.btn_SelectionnerTout.Click += new System.EventHandler(this.btn_SelectionnerTout_Click);
            // 
            // dgv_Eleves
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Eleves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Eleves.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Eleves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Eleves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Eleves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Eleves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Eleves.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Eleves.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_Eleves.Location = new System.Drawing.Point(6, 6);
            this.dgv_Eleves.Name = "dgv_Eleves";
            this.dgv_Eleves.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Eleves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Eleves.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Eleves.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Eleves.Size = new System.Drawing.Size(685, 400);
            this.dgv_Eleves.TabIndex = 12;
            this.dgv_Eleves.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtg_Eleves_CellValidating);
            // 
            // flp_Log
            // 
            this.flp_Log.AutoScroll = true;
            this.flp_Log.BackColor = System.Drawing.Color.White;
            this.flp_Log.ForeColor = System.Drawing.Color.DimGray;
            this.flp_Log.Location = new System.Drawing.Point(8, 561);
            this.flp_Log.Name = "flp_Log";
            this.flp_Log.Size = new System.Drawing.Size(841, 34);
            this.flp_Log.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(5, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Devoirs
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Devoirs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Devoirs.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Devoirs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Devoirs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Devoirs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Devoirs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Devoirs.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Devoirs.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_Devoirs.Location = new System.Drawing.Point(6, 6);
            this.dgv_Devoirs.Name = "dgv_Devoirs";
            this.dgv_Devoirs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Devoirs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Devoirs.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Devoirs.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Devoirs.Size = new System.Drawing.Size(682, 388);
            this.dgv_Devoirs.TabIndex = 14;
            // 
            // btn_AjouterMatiere
            // 
            this.btn_AjouterMatiere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_AjouterMatiere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_AjouterMatiere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterMatiere.FlatAppearance.BorderSize = 0;
            this.btn_AjouterMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterMatiere.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterMatiere.Image = ((System.Drawing.Image)(resources.GetObject("btn_AjouterMatiere.Image")));
            this.btn_AjouterMatiere.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AjouterMatiere.Location = new System.Drawing.Point(719, 174);
            this.btn_AjouterMatiere.Name = "btn_AjouterMatiere";
            this.btn_AjouterMatiere.Size = new System.Drawing.Size(130, 39);
            this.btn_AjouterMatiere.TabIndex = 15;
            this.btn_AjouterMatiere.Text = "Ajouter matière";
            this.btn_AjouterMatiere.UseVisualStyleBackColor = false;
            this.btn_AjouterMatiere.Click += new System.EventHandler(this.btn_AjouterMatiere_Click);
            // 
            // btn_AjouterDevoir
            // 
            this.btn_AjouterDevoir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_AjouterDevoir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterDevoir.FlatAppearance.BorderSize = 0;
            this.btn_AjouterDevoir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterDevoir.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterDevoir.Image = ((System.Drawing.Image)(resources.GetObject("btn_AjouterDevoir.Image")));
            this.btn_AjouterDevoir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AjouterDevoir.Location = new System.Drawing.Point(719, 174);
            this.btn_AjouterDevoir.Name = "btn_AjouterDevoir";
            this.btn_AjouterDevoir.Size = new System.Drawing.Size(130, 39);
            this.btn_AjouterDevoir.TabIndex = 16;
            this.btn_AjouterDevoir.Text = "Ajouter Devoir";
            this.btn_AjouterDevoir.UseVisualStyleBackColor = false;
            this.btn_AjouterDevoir.Click += new System.EventHandler(this.btn_AjouterDevoir_Click);
            // 
            // dgv_Matieres
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Matieres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Matieres.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Matieres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Matieres.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Matieres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Matieres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Matieres.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_Matieres.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_Matieres.Location = new System.Drawing.Point(6, 6);
            this.dgv_Matieres.Name = "dgv_Matieres";
            this.dgv_Matieres.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Matieres.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Matieres.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Matieres.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_Matieres.Size = new System.Drawing.Size(682, 388);
            this.dgv_Matieres.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(701, 28);
            this.label2.TabIndex = 18;
            this.label2.Text = "Élèves";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(701, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Devoirs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ModifierMatiere
            // 
            this.btn_ModifierMatiere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(125)))), ((int)(((byte)(9)))));
            this.btn_ModifierMatiere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ModifierMatiere.FlatAppearance.BorderSize = 0;
            this.btn_ModifierMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModifierMatiere.ForeColor = System.Drawing.Color.White;
            this.btn_ModifierMatiere.Image = ((System.Drawing.Image)(resources.GetObject("btn_ModifierMatiere.Image")));
            this.btn_ModifierMatiere.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ModifierMatiere.Location = new System.Drawing.Point(719, 283);
            this.btn_ModifierMatiere.Name = "btn_ModifierMatiere";
            this.btn_ModifierMatiere.Size = new System.Drawing.Size(130, 39);
            this.btn_ModifierMatiere.TabIndex = 21;
            this.btn_ModifierMatiere.Text = "Modifier matière";
            this.btn_ModifierMatiere.UseVisualStyleBackColor = false;
            this.btn_ModifierMatiere.Click += new System.EventHandler(this.btn_ModifierMatiere_Click);
            // 
            // btn_ModifierDevoir
            // 
            this.btn_ModifierDevoir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(125)))), ((int)(((byte)(9)))));
            this.btn_ModifierDevoir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ModifierDevoir.FlatAppearance.BorderSize = 0;
            this.btn_ModifierDevoir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModifierDevoir.ForeColor = System.Drawing.Color.White;
            this.btn_ModifierDevoir.Image = ((System.Drawing.Image)(resources.GetObject("btn_ModifierDevoir.Image")));
            this.btn_ModifierDevoir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ModifierDevoir.Location = new System.Drawing.Point(719, 283);
            this.btn_ModifierDevoir.Name = "btn_ModifierDevoir";
            this.btn_ModifierDevoir.Size = new System.Drawing.Size(130, 39);
            this.btn_ModifierDevoir.TabIndex = 22;
            this.btn_ModifierDevoir.Text = "Modifier devoir";
            this.btn_ModifierDevoir.UseVisualStyleBackColor = false;
            this.btn_ModifierDevoir.Click += new System.EventHandler(this.btn_ModifierDevoir_Click);
            // 
            // tc_ElevesDevoirs
            // 
            this.tc_ElevesDevoirs.Controls.Add(this.tp_Eleves);
            this.tc_ElevesDevoirs.Controls.Add(this.tp_Devoirs);
            this.tc_ElevesDevoirs.Controls.Add(this.tp_Matieres);
            this.tc_ElevesDevoirs.Controls.Add(this.tp_Notes);
            this.tc_ElevesDevoirs.Location = new System.Drawing.Point(8, 97);
            this.tc_ElevesDevoirs.Name = "tc_ElevesDevoirs";
            this.tc_ElevesDevoirs.SelectedIndex = 0;
            this.tc_ElevesDevoirs.Size = new System.Drawing.Size(705, 439);
            this.tc_ElevesDevoirs.TabIndex = 23;
            this.tc_ElevesDevoirs.SelectedIndexChanged += new System.EventHandler(this.tc_ElevesDevoirs_SelectedIndexChanged);
            // 
            // tp_Eleves
            // 
            this.tp_Eleves.Controls.Add(this.dgv_Eleves);
            this.tp_Eleves.Location = new System.Drawing.Point(4, 22);
            this.tp_Eleves.Name = "tp_Eleves";
            this.tp_Eleves.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Eleves.Size = new System.Drawing.Size(697, 413);
            this.tp_Eleves.TabIndex = 0;
            this.tp_Eleves.Text = "Élèves";
            this.tp_Eleves.UseVisualStyleBackColor = true;
            // 
            // tp_Devoirs
            // 
            this.tp_Devoirs.Controls.Add(this.dgv_Devoirs);
            this.tp_Devoirs.Location = new System.Drawing.Point(4, 22);
            this.tp_Devoirs.Name = "tp_Devoirs";
            this.tp_Devoirs.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Devoirs.Size = new System.Drawing.Size(697, 413);
            this.tp_Devoirs.TabIndex = 1;
            this.tp_Devoirs.Text = "Devoirs";
            this.tp_Devoirs.UseVisualStyleBackColor = true;
            // 
            // tp_Matieres
            // 
            this.tp_Matieres.Controls.Add(this.dgv_Matieres);
            this.tp_Matieres.Location = new System.Drawing.Point(4, 22);
            this.tp_Matieres.Name = "tp_Matieres";
            this.tp_Matieres.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Matieres.Size = new System.Drawing.Size(697, 413);
            this.tp_Matieres.TabIndex = 2;
            this.tp_Matieres.Text = "Matières";
            this.tp_Matieres.UseVisualStyleBackColor = true;
            // 
            // tp_Notes
            // 
            this.tp_Notes.Controls.Add(this.dgv_Notes);
            this.tp_Notes.Location = new System.Drawing.Point(4, 22);
            this.tp_Notes.Name = "tp_Notes";
            this.tp_Notes.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Notes.Size = new System.Drawing.Size(697, 413);
            this.tp_Notes.TabIndex = 3;
            this.tp_Notes.Text = "Notes";
            this.tp_Notes.UseVisualStyleBackColor = true;
            // 
            // dgv_Notes
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Notes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_Notes.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Notes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Notes.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_Notes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_Notes.Location = new System.Drawing.Point(6, 6);
            this.dgv_Notes.Name = "dgv_Notes";
            this.dgv_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_Notes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notes.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Notes.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_Notes.Size = new System.Drawing.Size(682, 388);
            this.dgv_Notes.TabIndex = 18;
            // 
            // btn_AjouterEleve
            // 
            this.btn_AjouterEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_AjouterEleve.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterEleve.FlatAppearance.BorderSize = 0;
            this.btn_AjouterEleve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterEleve.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterEleve.Image = ((System.Drawing.Image)(resources.GetObject("btn_AjouterEleve.Image")));
            this.btn_AjouterEleve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AjouterEleve.Location = new System.Drawing.Point(719, 174);
            this.btn_AjouterEleve.Name = "btn_AjouterEleve";
            this.btn_AjouterEleve.Size = new System.Drawing.Size(130, 39);
            this.btn_AjouterEleve.TabIndex = 24;
            this.btn_AjouterEleve.Text = "Ajouter élève";
            this.btn_AjouterEleve.UseVisualStyleBackColor = false;
            this.btn_AjouterEleve.Click += new System.EventHandler(this.btn_AjouterEleve_Click);
            // 
            // btn_ModifierEleve
            // 
            this.btn_ModifierEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(125)))), ((int)(((byte)(9)))));
            this.btn_ModifierEleve.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ModifierEleve.FlatAppearance.BorderSize = 0;
            this.btn_ModifierEleve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModifierEleve.ForeColor = System.Drawing.Color.White;
            this.btn_ModifierEleve.Image = ((System.Drawing.Image)(resources.GetObject("btn_ModifierEleve.Image")));
            this.btn_ModifierEleve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ModifierEleve.Location = new System.Drawing.Point(719, 283);
            this.btn_ModifierEleve.Name = "btn_ModifierEleve";
            this.btn_ModifierEleve.Size = new System.Drawing.Size(130, 39);
            this.btn_ModifierEleve.TabIndex = 25;
            this.btn_ModifierEleve.Text = "Modifier élève";
            this.btn_ModifierEleve.UseVisualStyleBackColor = false;
            this.btn_ModifierEleve.Click += new System.EventHandler(this.btn_ModifierEleve_Click);
            // 
            // btn_AjouterNote
            // 
            this.btn_AjouterNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_AjouterNote.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AjouterNote.FlatAppearance.BorderSize = 0;
            this.btn_AjouterNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AjouterNote.ForeColor = System.Drawing.Color.White;
            this.btn_AjouterNote.Image = ((System.Drawing.Image)(resources.GetObject("btn_AjouterNote.Image")));
            this.btn_AjouterNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AjouterNote.Location = new System.Drawing.Point(719, 174);
            this.btn_AjouterNote.Name = "btn_AjouterNote";
            this.btn_AjouterNote.Size = new System.Drawing.Size(130, 39);
            this.btn_AjouterNote.TabIndex = 26;
            this.btn_AjouterNote.Text = "Ajouter note";
            this.btn_AjouterNote.UseVisualStyleBackColor = false;
            this.btn_AjouterNote.Click += new System.EventHandler(this.btn_AjouterNote_Click);
            // 
            // btn_ModifierNote
            // 
            this.btn_ModifierNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(125)))), ((int)(((byte)(9)))));
            this.btn_ModifierNote.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ModifierNote.FlatAppearance.BorderSize = 0;
            this.btn_ModifierNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModifierNote.ForeColor = System.Drawing.Color.White;
            this.btn_ModifierNote.Image = ((System.Drawing.Image)(resources.GetObject("btn_ModifierNote.Image")));
            this.btn_ModifierNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ModifierNote.Location = new System.Drawing.Point(719, 283);
            this.btn_ModifierNote.Name = "btn_ModifierNote";
            this.btn_ModifierNote.Size = new System.Drawing.Size(130, 39);
            this.btn_ModifierNote.TabIndex = 27;
            this.btn_ModifierNote.Text = "Modifier note";
            this.btn_ModifierNote.UseVisualStyleBackColor = false;
            this.btn_ModifierNote.Click += new System.EventHandler(this.btn_ModifierNote_Click);
            // 
            // btn_SupprimerNote
            // 
            this.btn_SupprimerNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(87)))), ((int)(((byte)(63)))));
            this.btn_SupprimerNote.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SupprimerNote.FlatAppearance.BorderSize = 0;
            this.btn_SupprimerNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SupprimerNote.ForeColor = System.Drawing.Color.White;
            this.btn_SupprimerNote.Image = ((System.Drawing.Image)(resources.GetObject("btn_SupprimerNote.Image")));
            this.btn_SupprimerNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SupprimerNote.Location = new System.Drawing.Point(719, 337);
            this.btn_SupprimerNote.Name = "btn_SupprimerNote";
            this.btn_SupprimerNote.Size = new System.Drawing.Size(130, 39);
            this.btn_SupprimerNote.TabIndex = 28;
            this.btn_SupprimerNote.Text = "Supprimer note";
            this.btn_SupprimerNote.UseVisualStyleBackColor = false;
            this.btn_SupprimerNote.Click += new System.EventHandler(this.btn_SupprimerNote_Click);
            // 
            // btn_SupprimerMatiere
            // 
            this.btn_SupprimerMatiere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(87)))), ((int)(((byte)(63)))));
            this.btn_SupprimerMatiere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SupprimerMatiere.FlatAppearance.BorderSize = 0;
            this.btn_SupprimerMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SupprimerMatiere.ForeColor = System.Drawing.Color.White;
            this.btn_SupprimerMatiere.Image = ((System.Drawing.Image)(resources.GetObject("btn_SupprimerMatiere.Image")));
            this.btn_SupprimerMatiere.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SupprimerMatiere.Location = new System.Drawing.Point(719, 337);
            this.btn_SupprimerMatiere.Name = "btn_SupprimerMatiere";
            this.btn_SupprimerMatiere.Size = new System.Drawing.Size(130, 39);
            this.btn_SupprimerMatiere.TabIndex = 29;
            this.btn_SupprimerMatiere.Text = "Supprimer matière";
            this.btn_SupprimerMatiere.UseVisualStyleBackColor = false;
            this.btn_SupprimerMatiere.Click += new System.EventHandler(this.btn_SupprimerMatiere_Click_1);
            // 
            // btn_ListeEnseignants
            // 
            this.btn_ListeEnseignants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(193)))), ((int)(((byte)(82)))));
            this.btn_ListeEnseignants.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ListeEnseignants.FlatAppearance.BorderSize = 0;
            this.btn_ListeEnseignants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ListeEnseignants.ForeColor = System.Drawing.Color.White;
            this.btn_ListeEnseignants.Location = new System.Drawing.Point(719, 382);
            this.btn_ListeEnseignants.Name = "btn_ListeEnseignants";
            this.btn_ListeEnseignants.Size = new System.Drawing.Size(130, 46);
            this.btn_ListeEnseignants.TabIndex = 30;
            this.btn_ListeEnseignants.Text = "Afficher liste enseignants";
            this.btn_ListeEnseignants.UseVisualStyleBackColor = false;
            this.btn_ListeEnseignants.Click += new System.EventHandler(this.btn_ListeEnseignants_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(854, 607);
            this.Controls.Add(this.btn_ListeEnseignants);
            this.Controls.Add(this.btn_SupprimerMatiere);
            this.Controls.Add(this.btn_SupprimerNote);
            this.Controls.Add(this.btn_ModifierNote);
            this.Controls.Add(this.btn_AjouterNote);
            this.Controls.Add(this.btn_ModifierEleve);
            this.Controls.Add(this.btn_ModifierDevoir);
            this.Controls.Add(this.btn_AjouterEleve);
            this.Controls.Add(this.lbl_Emplacement);
            this.Controls.Add(this.tc_ElevesDevoirs);
            this.Controls.Add(this.btn_ModifierMatiere);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AjouterDevoir);
            this.Controls.Add(this.btn_AjouterMatiere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flp_Log);
            this.Controls.Add(this.btn_SelectionnerTout);
            this.Controls.Add(this.lbl_GenerateurBulletins);
            this.Controls.Add(this.lbl_ChoisirGroupe);
            this.Controls.Add(this.btn_ChoixDossier);
            this.Controls.Add(this.btn_OuvrirDossier);
            this.Controls.Add(this.cbx_ChoixGroupe);
            this.Controls.Add(this.btn_Generer);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Générateur de bulletins";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Eleves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devoirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Matieres)).EndInit();
            this.tc_ElevesDevoirs.ResumeLayout(false);
            this.tp_Eleves.ResumeLayout(false);
            this.tp_Devoirs.ResumeLayout(false);
            this.tp_Matieres.ResumeLayout(false);
            this.tp_Notes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notes)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_Eleves;
        private System.Windows.Forms.FlowLayoutPanel flp_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Devoirs;
        private System.Windows.Forms.Button btn_AjouterMatiere;
        private System.Windows.Forms.Button btn_AjouterDevoir;
        private System.Windows.Forms.DataGridView dgv_Matieres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ModifierMatiere;
        private System.Windows.Forms.Button btn_ModifierDevoir;
        private System.Windows.Forms.TabControl tc_ElevesDevoirs;
        private System.Windows.Forms.TabPage tp_Eleves;
        private System.Windows.Forms.TabPage tp_Devoirs;
        private System.Windows.Forms.TabPage tp_Matieres;
        private System.Windows.Forms.TabPage tp_Notes;
        private System.Windows.Forms.DataGridView dgv_Notes;
        private System.Windows.Forms.Button btn_AjouterEleve;
        private System.Windows.Forms.Button btn_ModifierEleve;
        private System.Windows.Forms.Button btn_AjouterNote;
        private System.Windows.Forms.Button btn_ModifierNote;
        private System.Windows.Forms.Button btn_SupprimerNote;
        private System.Windows.Forms.Button btn_SupprimerMatiere;
        private System.Windows.Forms.Button btn_ListeEnseignants;
    }
}

