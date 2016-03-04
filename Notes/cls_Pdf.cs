using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;

namespace Notes
{
    public class cls_Pdf
    {
        private PdfDocument c_Bulletin;
        private PdfPage     c_Page;

        // Dossier du projet pour chemin absolu
        private string      c_DossierProjet;

        private cls_Groupe  c_Groupe;
        private cls_Eleve   c_Eleve;
        private cls_Semestre c_Semestre;

        // Objet pour dessiner
        private XGraphics c_Gfx;

        // Font
        private XTextFormatter c_tf;
        private XFont c_FontBig;
        private XFont c_FontNormal;
        private XFont c_FontNormalBold;
        private XFont c_FontSmall;
        private XFont c_FontExtraSmall;
        private XFont c_FontSmallBold;
        private XFont c_FontSmallItalic;

        // Brushs
        private XBrush  c_Brush;
        private XPen    c_Pen;
        private XPen    c_PenThin;
        private XPen    c_HeaderPen;

        // Positions
        private XRect  c_PositionNomLycee;
        private XRect  c_PositionAnneeScolaire;
        private XRect  c_PositionTitre;
        private XRect  c_PositionHeaderTableau;
        private XPoint c_PositionLogo;
        private XRect  c_PositionMoyenneGenerale;
        private XRect  c_PositionRectangleAdresse;
        private XRect  c_PositionTexteAdresse;

        private XPoint c_ColonneMatiere;
        private XPoint c_ColonneMoyenneEleve;
        private XPoint c_ColonneMoyenneGroupe;
        private XPoint c_ColonneAppreciation;

        // Variables pour le dessin du tableau
        private int     c_NumMatiere;
        private int     c_DebutTableau;
        private int     c_LargeurTotalTableau;
        private int     c_HauteurLigne;
        private int     c_DerniereLigneTop;

        private string c_NomEtablissement;

        /// <summary>
        /// Créer tous les bulletins PDF de tous les élèves du groupe pour le semestre choisi. 
        /// Le PDF est crée au moment de l'initialisation.
        /// </summary>
        /// <param name="pGroupe">Groupe</param>
        public cls_Pdf(cls_Groupe pGroupe, cls_Semestre pSemestre)
        {
            // Génère les pdfs pour tous les élèves de ce groupe
            c_Groupe = pGroupe;
            c_Semestre = pSemestre;

            // Pour chaque élève, on modifie les variables, on dessine le PDF, puis on le sauvegarde
            foreach (cls_Eleve l_eleve in c_Groupe.getListeEleve())
            {
                c_Eleve = l_eleve;
                CreerPdf();
            }
        }

        /// <summary>
        /// Créer un bulletin PDF pour un seul élève
        /// Le PDF est crée au moment de l'initialisation.
        /// </summary>
        /// <param name="pEleve">L'élève pour lequel on doit générer le bulletin</param>
        /// <param name="pSemestre">Le semestre</param>
        public cls_Pdf(cls_Eleve pEleve, cls_Semestre pSemestre)
        {
            // Génère les pdfs pour tous les élèves de ce groupe
            c_Semestre = pSemestre;

            // Met l'élève dans la classe car il est utilisé plus tard
            c_Eleve = pEleve;
        }

        public void CreerPdf()
        {
            // Recupère le dossier courant pour les images
            c_DossierProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // Créer un nouveau document pdf vide
            CreerDocument();

            // Initialiser les brushs, les pens et les fonts
            InitialiserOutils();

            // Initialisation des variables de position et de taille
            InitialiserVariables();

            // Ajoute le haut du document : nom de l'établissement, titre année scolaire
            DessinerHautDocument();

            // Ajoute l'adresse dans un cadre en haut
            DessinerAdresse();

            // Dessine le tableau
            DessinerTableau();

            // Dessine les lignes à l'intérieur du tableau, contenant les noms des matières,
            // les professeurs, et les notes
            DessinerLignesTableau();

            // Dessine les traits verticaux des colonnes
            DessinerColonnes();

            // Ajoute la moyenne générale pour l'élève en bas du tableau
            DessinerMoyenneGenerale();

            // Ajoute le cachet de l'établissement et la date
            DessinerCachetEtDate();

            // Sauvegarde le pdf au format NomPrenom.pdf et l'ouvre directement
            SauvegarderEtOuvrirPdf();
        }

        /// <summary>
        /// Créer le document Pdf et la page
        /// </summary>
        public void CreerDocument()
        {
            // Créer un nouveau document
            c_Bulletin = new PdfDocument();
            c_Bulletin.Info.Title = "Bulletin - " + (DateTime.Now.Year - 1) + " - " + DateTime.Now.Year;

            // Ajoute une page
            c_Page = c_Bulletin.AddPage();
        }

        /// <summary>
        /// Initialise les outils nécessaires au dessin dans le Pdf.
        /// Créer les polices, l'objet XGraphics, et les pinceaux
        /// </summary>
        public void InitialiserOutils()
        {
            // Objet pour dessiner
            c_Gfx = XGraphics.FromPdfPage(c_Page);

            // Font et brush
            c_tf = new XTextFormatter(c_Gfx);
            c_tf.Alignment = XParagraphAlignment.Left;

            c_FontBig         = new XFont("Verdana", 14, XFontStyle.BoldItalic);
            c_FontNormal      = new XFont("Verdana", 11, XFontStyle.Regular);
            c_FontNormalBold  = new XFont("Verdana", 11, XFontStyle.Bold);
            c_FontExtraSmall  = new XFont("Verdana",  8, XFontStyle.Regular);
            c_FontSmall       = new XFont("Verdana", 9, XFontStyle.Regular);
            c_FontSmallBold   = new XFont("Verdana", 9, XFontStyle.Bold);
            c_FontSmallItalic = new XFont("Verdana",  8, XFontStyle.Italic);

            // Brushs et pens
            c_Brush     = XBrushes.Black;
            c_Pen       = new XPen(XColors.Black, 1);
            c_PenThin   = new XPen(XColors.Gray, 0.5f);
            c_HeaderPen = new XPen(XColors.DeepSkyBlue, 4);
        }

        /// <summary>
        /// Initialise les variables utilisés pour le positionnement des éléments
        /// mais aussi la hauteur des lignes, taille du tableau, etc.
        /// </summary>
        private void InitialiserVariables()
        {
            // Position de début du tableau par rapport au haut de la page
            c_DebutTableau = 250;

            c_HauteurLigne = 50;

            // Cumul pour le nombre de matières
            c_NumMatiere = 0;

            // Position de la dernière ligne du tableau, modifié plus tard dans la boucle
            c_DerniereLigneTop = 0;

            // Largeur du tableau (taille de la page - marge)
            c_LargeurTotalTableau = (int)c_Page.Width - 40;

            c_NomEtablissement = "CFAI Loire";

            // Position pour chaque élément
            c_PositionNomLycee         = new XRect(80, 30, 0, 0);
            c_PositionAnneeScolaire    = new XRect(c_Page.Width - 300, 40, 200, 0);
            c_PositionTitre            = new XRect(c_Page.Width - 300, 80, 300, 0);
            c_PositionHeaderTableau    = new XRect(20, c_DebutTableau + 8, c_LargeurTotalTableau, c_HauteurLigne - 10);
            c_PositionLogo             = new XPoint(40, 60);
            c_PositionRectangleAdresse = new XRect(c_Page.Width - 300, c_PositionTitre.Top + 40, 250, 100);
            c_PositionTexteAdresse     = new XRect(c_PositionRectangleAdresse.Left + 20,
                c_PositionRectangleAdresse.Top + 20, c_PositionRectangleAdresse.Width, 0);

            c_ColonneMatiere        = new XPoint(170, c_DebutTableau + 50);
            c_ColonneMoyenneEleve   = new XPoint(220, c_DebutTableau + 50);
            c_ColonneMoyenneGroupe  = new XPoint(220+45, c_DebutTableau + 50);
 
        }

        /// <summary>
        /// Dessine le haut du document : Nom de l'établissement, logo, année scolaire et titre
        /// </summary>
        public void DessinerHautDocument()
        {
            // Nom du lycée en haut à gauche
            c_Gfx.DrawString(c_NomEtablissement, c_FontNormal, c_Brush, c_PositionNomLycee, XStringFormats.Center);

            // Logo
            XImage logo = XImage.FromFile(c_DossierProjet + "/Images/logo-formation-industries-loire.png");
            c_Gfx.DrawImage(logo, c_PositionLogo);

            // Année scolaire en haut à droite
            int l_AnneeDebut = c_Semestre.getDebut().Year;
            string l_TexteAnnee = "Année scolaire " + (l_AnneeDebut-1) + " - " + l_AnneeDebut;
            c_Gfx.DrawString(l_TexteAnnee, c_FontSmall, c_Brush, c_PositionAnneeScolaire);

            // Titre
            int l_Semestre = c_Semestre.getNumero();

            // Texte du semestre, premier ou deuxième

            string l_TexteSemestre;

            if (l_Semestre == 1)
            {
                l_TexteSemestre = "Bulletin du premier semestre " + c_Semestre.getDebut().Year.ToString();
            }
            else
            {
                l_TexteSemestre = "Bulletin du second semestre " + c_Semestre.getDebut().Year.ToString();
            }

            c_Gfx.DrawString(l_TexteSemestre, c_FontBig, c_Brush, c_PositionTitre);
        }

        /// <summary>
        /// Dessine un rectangle et l'adresse à l'intérieur
        /// </summary>
        public void DessinerAdresse()
        {
            // Rectangle adresse
            XSize size = new XSize(4, 4);
            c_Gfx.DrawRoundedRectangle(c_Pen, c_PositionRectangleAdresse, size);

            // Texte adresse
            string adresseComplete = "M. " + c_Eleve.getNom() + " " + c_Eleve.getPrenom() + "\n" + c_Eleve.getAdresse();

            c_tf.DrawString(adresseComplete, c_FontNormal, c_Brush, c_PositionTexteAdresse, XStringFormats.TopLeft);
        }

        /// <summary>
        /// Dessine le header du tableau et le texte
        /// </summary>
        public void DessinerTableau()
        {
            // Header du tableau
            c_Gfx.DrawRectangle(c_HeaderPen, c_PositionHeaderTableau);

            // Texte header

            c_Gfx.DrawString("Matière", c_FontSmallBold, c_Brush, new XPoint( 30, c_DebutTableau + 35));
            c_Gfx.DrawString("Elève",   c_FontSmallBold, c_Brush, new XPoint(180, c_DebutTableau + 35));
            c_Gfx.DrawString("Moyenne", c_FontSmallBold, c_Brush, new XPoint(255, c_DebutTableau + 20));
            c_Gfx.DrawString("Groupe",  c_FontSmallBold, c_Brush, new XPoint(225, c_DebutTableau + 35));
            c_Gfx.DrawString("Min.",    c_FontSmallBold, c_Brush, new XPoint(280, c_DebutTableau + 35));
            c_Gfx.DrawString("Max.",    c_FontSmallBold, c_Brush, new XPoint(310, c_DebutTableau + 35));
            c_Gfx.DrawString("Appréciations des professeurs", c_FontSmallBold, c_Brush, new XPoint(350, c_DebutTableau + 35));
        }

        /// <summary>
        /// Dessine les différents lignes du tableau.
        /// Une ligne = une matière
        /// </summary>
        private void DessinerLignesTableau()
        {
            // Lignes du tableau

            foreach (cls_Matiere matiere in c_Groupe.getMatiere())
            {
                c_NumMatiere++;

                int positionTop = c_DebutTableau + c_NumMatiere * c_HauteurLigne;

                // Rectangle pour la matière
                XRect newLigne = new XRect(20, positionTop, c_LargeurTotalTableau, c_HauteurLigne);
                c_Gfx.DrawRectangle(c_Pen, newLigne);

                // Texte matière
                c_Gfx.DrawString(matiere.getLibelle(), c_FontNormal, c_Brush,
                    new XPoint(30, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 20));

                // Nom professeur
                c_Gfx.DrawString(matiere.getProfesseur(), c_FontSmallItalic, c_Brush,
                    new XPoint(30, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 40));

                // Moyenne eleve pour cette matière
                double moyenne = c_Eleve.MoyenneMatiere(matiere);
                c_Gfx.DrawString(Math.Round(moyenne, 2).ToString(), c_FontSmallBold, c_Brush,
                    new XPoint(180, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 30));

                // Appreciation pour cette matière
                string l_Appreciation = c_Eleve.getAppreciation(matiere).getTexte();
                int l_LongueurMaxAppreciation = 100;

                if (l_Appreciation.Length > l_LongueurMaxAppreciation)
                {
                    l_Appreciation = l_Appreciation.Substring(0, l_LongueurMaxAppreciation);
                }

                XRect l_PositionAppreciation = new XRect(340, c_DebutTableau + c_NumMatiere*c_HauteurLigne
                    +15, 240, c_HauteurLigne + 10);

                c_tf.DrawString(l_Appreciation, c_FontExtraSmall, c_Brush, l_PositionAppreciation, XStringFormats.TopLeft);

                // Moyenne groupe
                double moyenneGroupe = c_Groupe.MoyenneGroupePourMatiere(matiere);
                c_Gfx.DrawString(Math.Round(moyenneGroupe, 2).ToString(), c_FontSmall, c_Brush,
                    new XPoint(230, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 30));

                // Moyenne minimum du groupe
                double l_MoyenneMinimumMatiere = c_Groupe.getMoyenneMinimumPourMatiere(matiere);
                c_Gfx.DrawString(Math.Round(l_MoyenneMinimumMatiere, 2).ToString(), c_FontSmall, c_Brush,
                    new XPoint(280, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 30));

                // Moyenne maximum du groupe
                double l_MoyenneMaximumMatiere = c_Groupe.getMoyenneMaximumPourMatiere(matiere);
                c_Gfx.DrawString(Math.Round(l_MoyenneMaximumMatiere, 2).ToString(), c_FontSmall, c_Brush,
                    new XPoint(300, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 30));

                // La position de la dernière ligne
                c_DerniereLigneTop = positionTop;
            }
        }

        /// <summary>
        /// Dessine les lignes des colonnes
        /// </summary>
        public void DessinerColonnes()
        {
            double l_FinLigneY = c_DerniereLigneTop + c_HauteurLigne;
            c_Gfx.DrawLine(c_PenThin, c_ColonneMatiere, new XPoint(c_ColonneMatiere.X, l_FinLigneY));
            c_Gfx.DrawLine(c_PenThin, c_ColonneMoyenneEleve, new XPoint(c_ColonneMoyenneEleve.X, l_FinLigneY));
            c_Gfx.DrawLine(c_PenThin, c_ColonneMoyenneGroupe, new XPoint(c_ColonneMoyenneGroupe.X, l_FinLigneY));
        }

        /// <summary>
        /// Dessine la moyenne générale à la fin du tableau, après la dernière ligne
        /// </summary>
        public void DessinerMoyenneGenerale()
        {
            // Doit être fait une fois qu'on connais la position de la dernière ligne !
            c_PositionMoyenneGenerale = new XRect(20, c_DerniereLigneTop + c_HauteurLigne, c_LargeurTotalTableau, c_HauteurLigne / 2);

            // Rectangle pour la moyenne générale
            c_Gfx.DrawRectangle(c_Pen, c_PositionMoyenneGenerale);

            // Texte moyenne générale
            c_Gfx.DrawString("Moyenne générale : " + Math.Round(c_Eleve.Moyenne(), 2), c_FontSmallBold, c_Brush,
                new XPoint(30, c_PositionMoyenneGenerale.Top + 15));
        }

        /// <summary>
        /// Dessine un cachet et la date d'aujourd'hui en bas du document
        /// </summary>
        public void DessinerCachetEtDate()
        {
            // Date
            string aujourdhui = DateTime.Now.ToString("dd/MM/yyyy");
            c_Gfx.DrawString(aujourdhui, c_FontSmallBold, c_Brush,
                new XPoint(c_LargeurTotalTableau - 100, c_PositionMoyenneGenerale.Top + 50));

            // Cachet
            XImage cachet = XImage.FromFile(c_DossierProjet + "/Images/cachet.jpg");
            c_Gfx.DrawImage(cachet, c_LargeurTotalTableau - 140, c_PositionMoyenneGenerale.Top + 60, 120, 120);
        }

        /// <summary>
        /// Sauvegarde le fichier PDF au format BulletinNomPrenom.pdf et l'ouvre directement
        /// </summary>
        public void SauvegarderEtOuvrirPdf()
        {
            // Sauvegarde le PDF
            string filename = "Bulletin" + c_Eleve.getNom() + c_Eleve.getPrenom() + ".pdf";
            c_Bulletin.Save(filename);

            // Ouvre le fichier
            Process.Start(filename);
        }
    }
}
