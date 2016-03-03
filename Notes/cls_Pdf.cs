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

        // Objet pour dessiner
        private XGraphics c_Gfx;

        // Font
        private XFont c_FontBig;
        private XFont c_FontNormal;
        private XFont c_FontNormalBold;
        private XFont c_FontSmall;
        private XFont c_FontSmallBold;
        private XFont c_FontSmallItalic;

        // Brushs
        private XBrush  c_Brush;
        private XPen    c_Pen;
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

        // Variables pour le dessin du tableau
        private int     c_NumMatiere;
        private int     c_DebutTableau;
        private int     c_LargeurTotalTableau;
        private int     c_HauteurLigne;
        private int     c_DerniereLigneTop;

        private string c_NomEtablissement;


        public cls_Pdf(cls_Groupe pGroupe)
        {
            // Recupère le dossier courant pour les images
            c_DossierProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // Génère les pdfs pour tous les élèves de ce groupe
            c_Groupe = pGroupe;

            // Pour chaque élève, on modifie les variables, on dessine le PDF, puis on le sauvegarde
            foreach (cls_Eleve eleve in c_Groupe.getListeEleve())
            {
                // Met l'élève dans la classe car il est utilisé plus tard
                c_Eleve = eleve;

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

                // Ajoute la moyenne générale pour l'élève en bas du tableau
                DessinerMoyenneGenerale();

                // Ajoute le cachet de l'établissement et la date
                DessinerCachetEtDate();

                // Sauvegarde le pdf au format NomPrenom.pdf et l'ouvre directement
                SauvegarderEtOuvrirPdf();
            }
        }

        public void CreerDocument()
        {
            // Créer un nouveau document
            c_Bulletin = new PdfDocument();
            c_Bulletin.Info.Title = "Bulletin - " + (DateTime.Now.Year - 1) + " - " + DateTime.Now.Year;

            // Ajoute une page
            c_Page = c_Bulletin.AddPage();
        }

        public void InitialiserOutils()
        {
            // Objet pour dessiner
            c_Gfx = XGraphics.FromPdfPage(c_Page);

            // Font et brush
            c_FontBig         = new XFont("Verdana", 16, XFontStyle.BoldItalic);
            c_FontNormal      = new XFont("Verdana", 12, XFontStyle.Regular);
            c_FontNormalBold  = new XFont("Verdana", 12, XFontStyle.Bold);
            c_FontSmall       = new XFont("Verdana", 10, XFontStyle.Regular);
            c_FontSmallBold   = new XFont("Verdana", 10, XFontStyle.Bold);
            c_FontSmallItalic = new XFont("Verdana",  8, XFontStyle.Italic);

            // Brushs et pens
            c_Brush     = XBrushes.Black;
            c_Pen       = new XPen(XColors.Black, 1);
            c_HeaderPen = new XPen(XColors.DeepSkyBlue, 4);
        }

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
        }

        public void DessinerHautDocument()
        {
            // Nom du lycée en haut à gauche
            c_Gfx.DrawString(c_NomEtablissement, c_FontNormal, c_Brush, c_PositionNomLycee, XStringFormats.Center);

            // Logo
            XImage logo = XImage.FromFile(c_DossierProjet + "/Images/logo-formation-industries-loire.png");
            c_Gfx.DrawImage(logo, c_PositionLogo);

            // Année scolaire en haut à droite
            c_Gfx.DrawString("Année Scolaire : 2015-2016", c_FontSmall, c_Brush, c_PositionAnneeScolaire);

            // Titre
            c_Gfx.DrawString("Bulletin du 1er trimestre", c_FontBig, c_Brush, c_PositionTitre);
        }

        public void DessinerAdresse()
        {
            // Rectangle adresse
            XSize size = new XSize(4, 4);
            c_Gfx.DrawRoundedRectangle(c_Pen, c_PositionRectangleAdresse, size);

            XTextFormatter tf = new XTextFormatter(c_Gfx);
            tf.Alignment = XParagraphAlignment.Left;

            // Texte adresse
            string adresseComplete = "M. " + c_Eleve.getNom() + " " + c_Eleve.getPrenom() + "\n" + c_Eleve.getAdresse();

            tf.DrawString(adresseComplete, c_FontSmall, c_Brush, c_PositionTexteAdresse, XStringFormats.TopLeft);
        }

        public void DessinerTableau()
        {
            // Header du tableau
            c_Gfx.DrawRectangle(c_HeaderPen, c_PositionHeaderTableau);

            // Texte header

            c_Gfx.DrawString("Matière", c_FontSmallBold, c_Brush, new XPoint(30, c_DebutTableau + 30));
            c_Gfx.DrawString("Elève", c_FontSmallBold, c_Brush, new XPoint(180, c_DebutTableau + 30));
            c_Gfx.DrawString("Groupe", c_FontSmallBold, c_Brush, new XPoint(240, c_DebutTableau + 30));
            c_Gfx.DrawString("Appréciations des professeurs", c_FontSmallBold, c_Brush, new XPoint(300, c_DebutTableau + 30));
        }

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

                // Moyenne groupe
                double moyenneGroupe = c_Groupe.MoyenneGroupePourMatiere(matiere);
                c_Gfx.DrawString(Math.Round(moyenneGroupe, 2).ToString(), c_FontSmallBold, c_Brush,
                    new XPoint(250, c_DebutTableau + c_NumMatiere * c_HauteurLigne + 30));


                // La position de la dernière ligne
                c_DerniereLigneTop = positionTop;
            }
        }

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
