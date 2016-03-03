using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Utilitaires
    {
        /// <summary>
        /// Ecrit en couleur dans la console puis reviens à la couleur normale.
        /// </summary>
        /// <param name="pBackground">Couleur de fond</param>
        /// <param name="pForeground">Couleur du texte</param>
        /// <param name="pTexte">Chaine de caractère à afficher</param>
        public static void WriteColor(ConsoleColor pBackground, ConsoleColor pForeground, string pTexte)
        {
            Console.BackgroundColor = pBackground;
            Console.ForegroundColor = pForeground;
            Console.Write(pTexte);
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
