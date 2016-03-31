﻿using System;
using System.Collections.Generic;

namespace Notes
{
    class Program
    {

        static void Main(string[] args)
        {
            // Créer l'objet base de donnée et les groupes
            cls_Base l_Base = new cls_Base("localhost", "postgres", "123456", "notes");

            // Créer les groupes
            List<cls_Groupe> l_Groupes = l_Base.CreerGroupes();

            // Un seul semestre en dur
            cls_Semestre l_Semestre1 = new cls_Semestre(1, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));

            // Créer les élèves
            List<cls_Eleve> l_Eleves = l_Base.CreerEleves(l_Groupes[0]);

            // Créer les matières
            List<cls_Matiere> l_Matieres = l_Base.CreerMatieres(l_Groupes[0]);

            // Créer les devoirs
            List<cls_Devoir> l_Devoirs = l_Base.CreerDevoirs(l_Matieres);
            
            // Créer les notes
            List<cls_Note> l_Notes = l_Base.CreerNotes(l_Devoirs, l_Eleves, l_Semestre1);


            /********************
            * Affichage console *
            *********************/

            // Eleves

            Utilitaires.WriteColor(ConsoleColor.DarkBlue, 
                                   ConsoleColor.White, 
                                   "Élèves", 
                                   Utilitaires.alignement.Centrer, 
                                   Utilitaires.espacement.AvantEtApres);

            foreach (cls_Eleve l_Eleve in l_Eleves)
            {
                Console.WriteLine(l_Eleve.getPrenom() + " est dans le groupe " + l_Eleve.getGroupe().getLibelle());
            }

            // Matières

            Utilitaires.WriteColor(ConsoleColor.DarkRed, 
                                   ConsoleColor.White, 
                                   "Matières", 
                                   Utilitaires.alignement.Centrer, 
                                   Utilitaires.espacement.AvantEtApres);

            foreach (cls_Matiere l_Matiere in l_Matieres)
            {
                Console.WriteLine(l_Matiere.getLibelle() + " est une matière coeff " + l_Matiere.getCoefficient() + " et le professeur de la matière est " + l_Matiere.getProfesseur());
            }

            // Devoirs

            Utilitaires.WriteColor(ConsoleColor.DarkCyan, 
                                   ConsoleColor.White, 
                                   "Devoirs", 
                                   Utilitaires.alignement.Centrer, 
                                   Utilitaires.espacement.AvantEtApres);

            foreach (cls_Devoir l_Devoir in l_Devoirs)
            {
                Console.WriteLine(l_Devoir.getLibelle() + " est un devoir qui a eu lieu le " + l_Devoir.getDateDevoir().Day + "/" + l_Devoir.getDateDevoir().Month + "/" + l_Devoir.getDateDevoir().Year + " dans la matière " + l_Devoir.getMatiere().getLibelle());
            }

            // Notes

            Utilitaires.WriteColor(ConsoleColor.DarkGreen, 
                                   ConsoleColor.White, 
                                   "Notes", 
                                   Utilitaires.alignement.Centrer, 
                                   Utilitaires.espacement.AvantEtApres);

            foreach (cls_Note l_Note in l_Notes)
            {
                Console.WriteLine(l_Note.getEleve().getPrenom() + " " + l_Note.getEleve().getNom() + " a eu la note de " + l_Note.getValeur() + " en " + l_Note.getDevoir().getMatiere().getLibelle());
            }

            // Génération des fichiers pdfs

            Utilitaires.EcrireTimerEtCreerPdf("Génération des fichiers PDF et ouverture...", l_Groupes[0]);

            Console.ReadLine();
        }
    }
}
