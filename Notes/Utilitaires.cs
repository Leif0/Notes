using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Utilitaires
    {
        private static System.Timers.Timer c_Timer;

        public enum alignement
        {
            Gauche,
            Centrer,
            Droite
        };

        public enum espacement
        {
            Avant,
            Apres,
            AvantEtApres
        };

        /// <summary>
        /// Ecris en couleur puis revient à la couleur normal. Possibilité d'aligner le texte.
        /// </summary>
        /// <param name="pBackground">Couleur du fond</param>
        /// <param name="pForeground">Couleur du texte</param>
        /// <param name="pTexte">Texte à afficher</param>
        /// <param name="pAlignement">Alignement du texte</param>
        /// <param name="pEspacement">Espacement avant et après le texte</param>
        public static void WriteColor(ConsoleColor pBackground, ConsoleColor pForeground, string pTexte, alignement pAlignement, espacement pEspacement)
        {
            if (pAlignement == alignement.Centrer)
            {
                if (pEspacement == espacement.Avant || pEspacement == espacement.AvantEtApres)
                {
                    Console.Write("\n");
                }
                Console.Write(new string(' ', (Console.WindowWidth - pTexte.Length)/2));
                Console.BackgroundColor = pBackground;
                Console.ForegroundColor = pForeground;
                Console.WriteLine(pTexte);

                if (pEspacement == espacement.Apres || pEspacement == espacement.AvantEtApres)
                {
                    Console.Write("\n");
                }
            }
            else
            {
                if (pEspacement == espacement.Avant || pEspacement == espacement.AvantEtApres)
                {
                    Console.Write("\n");
                }
                Console.BackgroundColor = pBackground;
                Console.ForegroundColor = pForeground;
                Console.Write(pTexte);

                if (pEspacement == espacement.Apres || pEspacement == espacement.AvantEtApres)
                {
                    Console.Write("\n");
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Affiche un séparateur en console
        /// </summary>
        public static void Separateur()
        {
            Console.Write("\n");
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("\n");
        }
        /// <summary>
        /// Ecrit du texte pour prévenir avant ouverture des pdf
        /// </summary>
        /// <param name="pTexte">Texte à afficher</param>
        /// <param name="pGroupe">Groupe pour lequel générer les pdf</param>
        public static void EcrireTimerEtCreerPdf(string pTexte, cls_Groupe pGroupe)
        {
            Console.Write("\n");
            Console.Write(new string(' ', (Console.WindowWidth - pTexte.Length) / 2));
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            c_Timer = new System.Timers.Timer(40);
            c_Timer.Elapsed += delegate
            {
                if (pTexte.Length > 0)
                {
                    Console.Write(pTexte[0]);
                    pTexte = pTexte.Substring(1, pTexte.Length - 1);
                }
                else
                {
                    c_Timer.Stop();
                    c_Timer.Dispose();
                    Console.Write("\n");
                    // Génère le pdf et l'ouvre directement

                    cls_Pdf pdf = new cls_Pdf(pGroupe);
                }
            };
            c_Timer.AutoReset = true;
            c_Timer.Enabled = true;
        }
    }
}
