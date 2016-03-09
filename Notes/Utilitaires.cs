using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Utilitaires
    {
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
        /// Ecrit en couleur dans la console puis reviens à la couleur normale.
        /// </summary>
        /// <param name="pBackground">Couleur de fond</param>
        /// <param name="pForeground">Couleur du texte</param>
        /// <param name="pTexte">Chaine de caractère à afficher</param>
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
    }
}
