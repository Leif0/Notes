using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll_Notes;
using Npgsql;
using NpgsqlTypes;

namespace Notes
{
    /// <summary>
    /// Classe controleur, permet d'accéder aux données dans la base
    /// </summary>
    public class cls_Base
    {
        private string c_Server;
        private string c_Username;
        private string c_Password;
        private string c_Database;
        private NpgsqlConnection c_Conn;

        /// <summary>
        /// Instanciation de l'objet cls_Base avec les paramètres de connexion
        /// </summary>
        /// <param name="pServer">Adresse du serveur distant ou local</param>
        /// <param name="pUsername">Identifiant de connexion à la base</param>
        /// <param name="pPassword">Mot de passe de connexion à la base</param>
        /// <param name="pDatabase">Nom de la base de donnée</param>
        public cls_Base(string pServer, string pUsername, string pPassword, string pDatabase)
        {
            c_Server = pServer;
            c_Username = pUsername;
            c_Password = pPassword;
            c_Database = pDatabase;

            Connexion();
        }

        /// <summary>
        /// Ouvre une connexion au serveur
        /// </summary>
        public void Connexion()
        {
            string chaineConnexion = "Host=" + c_Server + ";Username=" + c_Username +
                                     ";Password=" + c_Password + ";Database=" + c_Database;
            c_Conn = new NpgsqlConnection(chaineConnexion);
            c_Conn.Open();
        }

        /// <summary>
        /// Ajoute une nouvelle matière dans la base de donnée
        /// </summary>
        /// <param name="pMatiere"></param>
        public void addMatiere(cls_Matiere pMatiere)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "INSERT INTO matiere (id, libelle, id_groupe, coefficient, professeur) VALUES (" + pMatiere.Id + ",'" + pMatiere.Libelle + "', " + pMatiere.Groupe.Id + "," + pMatiere.Coefficient + ",'" + pMatiere.Professeur +"')";
                int resultat = cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Met à jour une matière dans la base de donnée
        /// </summary>
        /// <param name="pMatiere">Matière</param>
        public void updateMatiere(cls_Matiere pMatiere)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "UPDATE matiere SET libelle='" + pMatiere.Libelle + "', id_groupe=" + 
                    pMatiere.Groupe.Id + ", coefficient=" + pMatiere.Coefficient + ", professeur='" + 
                    pMatiere.Professeur + "' WHERE id=" + pMatiere.Id;
                int resultat = cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Ajoute un devoir à la base de données
        /// </summary>
        /// <param name="pDevoir">Devoir</param>
        public void addDevoir(cls_Devoir pDevoir)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                string l_DateDevoir = pDevoir.getDateDevoir().ToShortDateString();

                cmd.CommandText = "INSERT INTO devoir (id, libelle, date_devoir, id_matiere) VALUES (" + pDevoir.Id +
                                  ",'" + pDevoir.Libelle + "', '" + l_DateDevoir + "', " +
                                  pDevoir.getMatiere().Id + ")"; 
                int resultat = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Met à jour un devoir dans la base de donnée
        /// </summary>
        /// <param name="pDevoir">Un devoir</param>
        public void updateDevoir(cls_Devoir pDevoir)
        {
            string l_UpdateQuery = "UPDATE devoir SET libelle = @libelle, date_devoir = @date_devoir, " +
                                  "id_matiere = @id_matiere WHERE id = @id_devoir;";
            using (NpgsqlCommand cmd = new NpgsqlCommand(l_UpdateQuery, c_Conn))
            {
                cmd.Parameters.AddWithValue("libelle", pDevoir.Libelle);
                cmd.Parameters.AddWithValue("date_devoir", NpgsqlTypes.NpgsqlDbType.Date, 0, pDevoir.getDateDevoir());
                cmd.Parameters.AddWithValue("id_matiere", pDevoir.getMatiere().Id);
                cmd.Parameters.AddWithValue("id_devoir", pDevoir.Id);

                int resultat = cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Ajoute une note à la base de données
        /// </summary>
        /// <param name="pNote">Note</param>
        public int addNote(cls_Note pNote)
        {
            string l_requete = "INSERT INTO noter (id_devoir, id_eleve, note) VALUES (@id_devoir, @id_eleve, @note)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_requete, c_Conn))
            {
                cmd.Parameters.AddWithValue("id_devoir", pNote.getDevoir().Id);
                cmd.Parameters.AddWithValue("id_eleve", pNote.getEleve().Id);
                cmd.Parameters.AddWithValue("note", pNote.getValeur());

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }

        /// <summary>
        /// Met à jour une note dans la base de donnée
        /// </summary>
        /// <param name="pNote">Une note</param>
        public int updateNote(cls_Devoir pDevoir, cls_Eleve pEleve, double pNote)
        {
            string l_UpdateQuery = "UPDATE noter SET note = @note WHERE id_devoir = @id_devoir AND id_eleve = @id_eleve;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_UpdateQuery, c_Conn))
            {
                cmd.Parameters.AddWithValue("note", pNote);
                cmd.Parameters.AddWithValue("id_devoir", pDevoir.Id);
                cmd.Parameters.AddWithValue("id_eleve", pEleve.Id);

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }
        /// <summary>
        /// Supprime une note de la base de données
        /// </summary>
        /// <param name="pNote">Note à supprimer</param>
        /// <returns>Nombre de lignes affectées</returns>
        public int supprimerNote(cls_Note pNote)
        {
            string l_Query = "DELETE from noter WHERE id_devoir = @id_devoir AND id_eleve = @id_eleve;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_Query, c_Conn))
            {
                cmd.Parameters.AddWithValue("id_devoir", pNote.getDevoir().Id);
                cmd.Parameters.AddWithValue("id_eleve", pNote.getEleve().Id);

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }

        /// <summary>
        /// Supprime une matière de la base de données
        /// </summary>
        /// <param name="pMatiere">Matière à supprimer</param>
        /// <returns>Nombre de lignes affectées</returns>
        public int supprimerMatiere(cls_Matiere pMatiere)
        {
            string l_Query = "DELETE FROM matiere WHERE id = @id;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_Query, c_Conn))
            {
                cmd.Parameters.AddWithValue("id", pMatiere.Id);

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }

        /// <summary>
        /// Ajoute un élève dans la base de donnée
        /// </summary>
        /// <param name="pEleve">Élève à ajouter</param>
        public int addEleve(cls_Eleve pEleve)
        {
            string l_UpdateQuery = "INSERT INTO eleve (id, nom, prenom, date_naissance, id_groupe, adresse) " +
                                   "VALUES (@id, @nom, @prenom, @date_naissance, @id_groupe, @adresse)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_UpdateQuery, c_Conn))
            {
                cmd.Parameters.AddWithValue("id", pEleve.Id);
                cmd.Parameters.AddWithValue("nom", pEleve.getNom());
                cmd.Parameters.AddWithValue("prenom", pEleve.getPrenom());
                cmd.Parameters.AddWithValue("date_naissance", pEleve.getDateNaissance());
                cmd.Parameters.AddWithValue("id_groupe", pEleve.getGroupe().Id);
                cmd.Parameters.AddWithValue("adresse", pEleve.getAdresse());
                cmd.Parameters.AddWithValue("id_eleve", pEleve.Id);

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }

        /// <summary>
        /// Met à jour un élève dans la base de donnée
        /// </summary>
        /// <param name="pEleve">Un élève</param>
        public int updateEleve(cls_Eleve pEleve)
        {
            string l_UpdateQuery = "UPDATE eleve SET nom = @nom, prenom = @prenom, " +
                                  "date_naissance = @date_naissance, id_groupe = @id_groupe, " +
                                   " adresse = @adresse WHERE id = @id_eleve;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(l_UpdateQuery, c_Conn))
            {
                cmd.Parameters.AddWithValue("nom", pEleve.getNom());
                cmd.Parameters.AddWithValue("prenom", pEleve.getPrenom());
                cmd.Parameters.AddWithValue("date_naissance", pEleve.getDateNaissance());
                cmd.Parameters.AddWithValue("id_groupe", pEleve.getGroupe().Id);
                cmd.Parameters.AddWithValue("adresse", pEleve.getAdresse());
                cmd.Parameters.AddWithValue("id_eleve", pEleve.Id);

                int resultat = cmd.ExecuteNonQuery();
                return resultat;
            }
        }

        /// <summary>
        /// Créer une liste de tous les enseignants
        /// </summary>
        /// <returns>Liste de cls_Groupe</returns>
        public Dictionary<int, cls_Enseignant> CreerEnseignants()
        {
            Dictionary<int, cls_Enseignant> l_Enseignants = new Dictionary<int, cls_Enseignant>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT id, nom, prenom, date_entree, numero_telephone, email FROM enseignant";

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_Id = l_Reader.GetInt32(0);
                        string l_Nom = l_Reader.GetString(1);
                        string l_Prenom = l_Reader.GetString(2);
                        DateTime l_DateEntree = l_Reader.GetDateTime(3);
                        string l_NumeroTelephone = l_Reader.GetString(4);
                        string l_Email = l_Reader.GetString(5);

                        cls_Enseignant l_Enseignant = new cls_Enseignant(l_Nom, l_Prenom, l_DateEntree, l_NumeroTelephone, l_Email, l_Id);

                        l_Enseignants.Add(l_Id, l_Enseignant);
                    }
                }
            }
            return l_Enseignants;
        }

        /// <summary>
        /// Créer une liste de tous les groupes
        /// </summary>
        /// <returns>Liste de cls_Groupe</returns>
        public Dictionary<int, cls_Groupe> CreerGroupes()
        {
            Dictionary <int, cls_Groupe> l_Groupes = new Dictionary<int, cls_Groupe>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT id, libelle FROM groupe";

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_Id = l_Reader.GetInt32(0);
                        string l_Libelle = l_Reader.GetString(1);

                        cls_Groupe l_Groupe = new cls_Groupe(l_Libelle, l_Id);
                        l_Groupes.Add(l_Id, l_Groupe);
                    }
                }
            }
            return l_Groupes;
        }

        /// <summary>
        /// Créer une liste de tous les élèves
        /// </summary>
        /// <returns>Liste de cls_Eleve</returns>
        public Dictionary<int, cls_Eleve> CreerEleves(cls_Groupe pGroupe)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT id, nom, prenom, date_naissance, adresse FROM eleve WHERE id_groupe = " + pGroupe.Id;

                Dictionary<int, cls_Eleve> l_Eleves = new Dictionary<int, cls_Eleve>();

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_Id = l_Reader.GetInt32(0);
                        string l_Nom = l_Reader.GetString(1);
                        string l_Prenom = l_Reader.GetString(2);
                        DateTime l_DateNaissance = l_Reader.GetDateTime(3);
                        string l_Adresse = l_Reader.GetString(4);

                        cls_Eleve l_Eleve = new cls_Eleve(l_Nom, l_Prenom, l_DateNaissance, pGroupe, l_Adresse, l_Id);
                        l_Eleves.Add(l_Id, l_Eleve);
                    }
                }
                return l_Eleves;
            }
        }

        /// <summary>
        /// Créer une liste de toutes les matières
        /// </summary>
        /// <returns>Liste de cls_Matiere</returns>
        public Dictionary<int, cls_Matiere> CreerMatieres(cls_Groupe pGroupe)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT matiere.id, matiere.libelle, groupe.id as id_groupe, groupe.libelle as libelle_groupe, matiere.coefficient, matiere.professeur  FROM matiere, groupe WHERE matiere.id_groupe = groupe.id AND id_groupe = " + pGroupe.Id;

                Dictionary<int, cls_Matiere> l_Matieres = new Dictionary<int, cls_Matiere>();

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_IdMatiere = l_Reader.GetInt32(0);
                        string l_Libelle = l_Reader.GetString(1);
                        int l_IdGroupe = l_Reader.GetInt32(2);
                        string l_LibelleGroupe = l_Reader.GetString(3);
                        int l_CoefficientMatiere = l_Reader.GetInt32(4);
                        string l_ProfesseurMatiere = l_Reader.GetString(5);

                        cls_Matiere l_Matiere = new cls_Matiere(l_Libelle, pGroupe, l_CoefficientMatiere, l_ProfesseurMatiere, l_IdMatiere);
                        l_Matieres.Add(l_IdMatiere, l_Matiere);
                    }
                }
                return l_Matieres;
            }
        }

        /// <summary>
        /// Créer le dictionnaire de devoirs en mémoire pour toues les matières
        /// </summary>
        /// <param name="pMatieres">Dictionnaire de matières</param>
        /// <returns></returns>
        public Dictionary<int, cls_Devoir> CreerDevoirs(Dictionary<int, cls_Matiere> pMatieres)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {

                int[] l_IdMatieres = pMatieres.Keys.ToArray();
                string l_IdMatieresString = "(";

                cls_Matiere dernier = pMatieres.Values.Last();
                foreach (cls_Matiere l_Matiere in pMatieres.Values)
                {
                    l_IdMatieresString += l_Matiere.Id;
                    if (!l_Matiere.Equals(dernier))
                    {
                        l_IdMatieresString += ", ";
                    }
                }
                l_IdMatieresString += " )";

                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT id, libelle, date_devoir, id_matiere FROM devoir WHERE id_matiere IN " + l_IdMatieresString;

                Dictionary<int, cls_Devoir> l_Devoirs = new Dictionary<int, cls_Devoir>();

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_IdDevoir = l_Reader.GetInt32(0);
                        string l_Libelle = l_Reader.GetString(1);
                        DateTime l_DateDevoir = l_Reader.GetDateTime(2);
                        int l_IdMatiere = l_Reader.GetInt32(3);

                        cls_Devoir l_Devoir = new cls_Devoir(l_Libelle, l_DateDevoir, pMatieres[l_IdMatiere], l_IdDevoir);
                        l_Devoirs.Add(l_IdDevoir, l_Devoir);

                        //pMatieres[l_IdMatiere].ajouterDevoir(l_Devoir);
                    }
                }
                return l_Devoirs;
            }
        }

        /// <summary>
        /// Créer une liste de tous les devoirs pour une matière
        /// </summary>
        /// <returns>Liste de cls_Devoir</returns>
        public List<cls_Devoir> CreerDevoirsMatiere(cls_Matiere pMatiere)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT devoir.id, devoir.libelle, devoir.date_devoir, matiere.libelle as libelle_matiere FROM devoir, matiere WHERE devoir.id_matiere = matiere.id AND matiere.libelle='"+ pMatiere.Libelle + "'";

                List<cls_Devoir> l_Devoirs = new List<cls_Devoir>();

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_IdDevoir = l_Reader.GetInt32(0);
                        string l_LibelleDevoir = l_Reader.GetString(1);
                        DateTime l_DateDevoir = l_Reader.GetDateTime(2);
                        string l_LibelleMatiere = l_Reader.GetString(3);

                        cls_Devoir l_Devoir = new cls_Devoir(l_LibelleDevoir, l_DateDevoir, pMatiere, l_IdDevoir);

                        l_Devoirs.Add(l_Devoir);
                    }
                }
                return l_Devoirs;
            }
        }
        
        /// <summary>
        /// Créer la liste des notes pour un devoir
        /// </summary>
        /// <param name="pDevoirs">Dictionnaire de devoirs</param>
        /// <param name="pEleves">Dictionnaire d'élèves</param>
        /// <param name="pSemestre">Semestre</param>
        /// <returns></returns>
        public List<cls_Note> CreerNotes(Dictionary<int, cls_Devoir> pDevoirs, Dictionary<int, cls_Eleve> pEleves, cls_Semestre pSemestre)
        {
            List<cls_Note> l_Notes = new List<cls_Note>();

            // Créer une chaine du type (x, y, z) utilisé dans la requete, pour filtrer par id de devoir

            int[] l_IdDevoirs = pDevoirs.Keys.ToArray();
            string l_IdDevoirsString = "(";

            cls_Devoir dernier = pDevoirs.Values.Last();
            foreach (cls_Devoir l_Devoir in pDevoirs.Values)
            {
                l_IdDevoirsString += l_Devoir.Id;
                if (!l_Devoir.Equals(dernier))
                {
                    l_IdDevoirsString += ", ";
                }
            }
        
            l_IdDevoirsString += ")";

            // On fait la requete

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = c_Conn;
                cmd.CommandText = "SELECT id_devoir, id_eleve, note FROM noter WHERE id_devoir IN " + l_IdDevoirsString;

                using (NpgsqlDataReader l_Reader = cmd.ExecuteReader())
                {
                    while (l_Reader.Read())
                    {
                        int l_IdDevoir = l_Reader.GetInt32(0);
                        int l_IdEleve = l_Reader.GetInt32(1);

                        cls_Devoir l_Devoir = pDevoirs[l_IdDevoir];

                        cls_Eleve l_Eleve = pEleves[l_IdEleve];

                        double l_NoteValeur = l_Reader.GetDouble(2);
                        cls_Note l_Note = new cls_Note(l_NoteValeur, l_Eleve, l_Devoir, pSemestre, l_IdDevoir);
                        l_Notes.Add(l_Note);
                    }
                }
            }
            return l_Notes;
        }

        /// <summary>
        /// Met à jour un élève en base de données
        /// </summary>
        /// <param name="pEleve">Elève à modifier</param>
        public void ModifierEleve(cls_Eleve pEleve)
        {
            NpgsqlCommand cmd =
                new NpgsqlCommand("UPDATE eleve SET \"prenom\" = :Prenom, \"nom\" = :Nom, " +
                                  "\"date_naissance\" = :DateNaissance WHERE \"id\" = " +
                                    pEleve.Id + ";");
            cmd.Parameters.Add(new NpgsqlParameter("Prenom", NpgsqlDbType.Text));
            cmd.Parameters.Add(new NpgsqlParameter("Nom", NpgsqlDbType.Text));
            cmd.Parameters.Add(new NpgsqlParameter("DateNaissance", NpgsqlDbType.Date));

            cmd.Connection = c_Conn;

            cmd.Parameters[0].Value = pEleve.getPrenom();
            cmd.Parameters[1].Value = pEleve.getNom();
            cmd.Parameters[2].Value = pEleve.getDateNaissance();

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Détruit un objet
        /// </summary>
        public void DetruitObjet()
         {
             if (c_Conn != null)
             {
                 c_Conn.Dispose();
                 c_Conn = null;
             }
         }
    }
}
