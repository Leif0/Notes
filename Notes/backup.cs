/*using System;
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
        private PdfDocument c_bulletin;
        private string c_titre;
        private cls_Groupe c_Groupe;

        public cls_Pdf(cls_Groupe pGroupe)
        {
            c_Groupe = pGroupe;

            foreach (var eleve in c_Groupe.getListeEleve())
            {
                CreerDocument();

            }
        }

        public void CreerDocument()
        {
            // Créer un nouveau document
            c_bulletin = new PdfDocument();
            c_bulletin.Info.Title = "Bulletin pdf";

            // Ajoute une page
            PdfPage page = bulletin.AddPage();
        }

        public void CreerPDF(cls_Groupe pGroupe)
        {
            string dossierProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            Creation();
            foreach (var eleve in pGroupe.getListeEleve())
            {
                // Objet pour dessiner
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Font et brush
                XFont fontBig = new XFont("Verdana", 16, XFontStyle.BoldItalic);
                XFont fontNormal = new XFont("Verdana", 12, XFontStyle.Regular);
                XFont fontNormalBold = new XFont("Verdana", 12, XFontStyle.Bold);
                XFont fontSmall = new XFont("Verdana", 10, XFontStyle.Regular);
                XFont fontSmallBold = new XFont("Verdana", 10, XFontStyle.Bold);
                XFont fontSmallItalic = new XFont("Verdana", 8, XFontStyle.Italic);

                XBrush brush = XBrushes.Black;

                // Position pour chaque élément
                XRect positionNomLycee = new XRect(80, 30, 0, 0);
                XRect positionAnneeScolaire = new XRect(page.Width - 300, 40, 200, 0);
                XRect positionTitre = new XRect(page.Width - 300, 80, 300, 0);

                // Nom du lycée en haut à gauche
                gfx.DrawString("CFAI Loire", fontNormal, brush, positionNomLycee, XStringFormats.Center);

                // Logo
                XImage logo = XImage.FromFile(dossierProjet + "/Images/logo-formation-industries-loire.png");
                gfx.DrawImage(logo, new XPoint(40, 60));

                // Année scolaire en haut à droite
                gfx.DrawString("Année Scolaire : 2015-2016", fontSmall, brush, positionAnneeScolaire);

                // Titre
                gfx.DrawString("Bulletin du 1er trimestre", fontBig, brush, positionTitre);

                // Rectangle adresse
                XPen pen = new XPen(XColors.Black, 1);
                XSize size = new XSize(4, 4);
                XRect positionRectangleAdresse = new XRect(page.Width - 300, positionTitre.Top + 40, 250, 100);
                gfx.DrawRoundedRectangle(pen, positionRectangleAdresse, size);

                XRect positionTexteAdresse = new XRect(positionRectangleAdresse.Left + 20,
                    positionRectangleAdresse.Top + 20, positionRectangleAdresse.Width, 0);

                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Left;

                string nom = eleve.getNom();
                string prenom = eleve.getPrenom();
                string adresse = eleve.getAdresse();

                // Texte adress
                string adresseComplete = "M. " + nom + " " + prenom + "\n" + adresse;

                tf.DrawString(adresseComplete, fontSmall, brush, positionTexteAdresse, XStringFormats.TopLeft);

                // Dessine le tableau

                // Largeur de chaque colonne du tableau
                int[] colonnesLargeur = { 150, 50, 50, 250 };

                // Largeur du tableau (taille de la page - marge)
                int largeurTotalTableau = (int)page.Width - 40;
                int hauteurLigne = 50;

                // Position de début du tableau par rapport au haut de la page
                int debutTableau = 250;

                // Cumul pour le nombre de matières
                int numMatiere = 0;

                // Position de la dernière ligne du tableau, valeur assignée plus tard
                int derniereLigneTop = 0;

                // Header du tableau

                XRect header = new XRect(20, debutTableau + 8, largeurTotalTableau, hauteurLigne - 10);
                XPen headerPen = new XPen(XColors.DeepSkyBlue, 4);
                gfx.DrawRectangle(headerPen, header);

                // Texte header

                gfx.DrawString("Matière", fontSmallBold, brush, new XPoint(30, debutTableau + 30));
                gfx.DrawString("Elève", fontSmallBold, brush, new XPoint(180, debutTableau + 30));
                gfx.DrawString("Groupe", fontSmallBold, brush, new XPoint(240, debutTableau + 30));
                gfx.DrawString("Appréciations des professeurs", fontSmallBold, brush, new XPoint(300, debutTableau + 30));

                // Lignes du tableau

                foreach (cls_Matiere matiere in pGroupe.getMatiere())
                {
                    numMatiere++;

                    int positionTop = debutTableau + numMatiere * hauteurLigne;

                    // Rectangle pour la matière
                    XRect newLigne = new XRect(20, positionTop, largeurTotalTableau, hauteurLigne);
                    gfx.DrawRectangle(pen, newLigne);

                    // Texte matière
                    gfx.DrawString(matiere.getLibelle(), fontNormal, brush,
                        new XPoint(30, debutTableau + numMatiere * hauteurLigne + 20));

                    // Nom professeur
                    gfx.DrawString(matiere.getProfesseur(), fontSmallItalic, brush,
                        new XPoint(30, debutTableau + numMatiere * hauteurLigne + 40));

                    // Moyenne eleve pour cette matière
                    double moyenne = eleve.MoyenneMatiere(matiere);
                    gfx.DrawString(Math.Round(moyenne, 2).ToString(), fontSmallBold, brush,
                        new XPoint(180, debutTableau + numMatiere * hauteurLigne + 30));

                    // Moyenne groupe
                    double moyenneGroupe = pGroupe.MoyenneGroupePourMatiere(matiere);
                    gfx.DrawString(Math.Round(moyenneGroupe, 2).ToString(), fontSmallBold, brush,
                        new XPoint(250, debutTableau + numMatiere * hauteurLigne + 30));


                    // La position de la dernière ligne
                    derniereLigneTop = positionTop;
                }

                // Rectangle pour la moyenne générale
                XRect moyenneGenerale = new XRect(20, derniereLigneTop + hauteurLigne, largeurTotalTableau,
                    hauteurLigne / 2);
                gfx.DrawRectangle(pen, moyenneGenerale);

                // Texte moyenne générale
                gfx.DrawString("Moyenne générale : " + Math.Round(eleve.Moyenne(), 2), fontSmallBold, brush,
                    new XPoint(30, moyenneGenerale.Top + 15));

                // Date
                string aujourdhui = DateTime.Now.ToString("dd/MM/yyyy");
                gfx.DrawString(aujourdhui, fontSmallBold, brush,
                    new XPoint(largeurTotalTableau - 100, moyenneGenerale.Top + 50));

                // Cachet
                XImage cachet = XImage.FromFile(dossierProjet + "/Images/cachet.jpg");
                gfx.DrawImage(cachet, largeurTotalTableau - 140, moyenneGenerale.Top + 60, 120, 120);

                // Sauvegarde le PDF
                string filename = "Bulletin" + eleve.getNom() + eleve.getPrenom() + ".pdf";
                bulletin.Save(filename);

                // Ouvre le fichier
                Process.Start(filename);
            }
        }
    }
}
*/