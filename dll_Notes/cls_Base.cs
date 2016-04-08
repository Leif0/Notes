using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll_Notes;
using Npgsql;
using NpgsqlTypes;

namespace Notes
{
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

        public List<cls_Devoir> CreerDevoirs(Dictionary<int, cls_Matiere> pMatieres)
        {
            cls_Modele l_Modele = new cls_Modele();
            
            List<cls_Devoir> l_Devoirs = new List<cls_Devoir>();

            foreach (cls_Matiere l_Matiere in pMatieres.Values)
            {
                List<cls_Devoir> l_DevoirsMatiere = CreerDevoirsMatiere(l_Matiere);

                for (int j = 0; j < l_DevoirsMatiere.Count; j++)
                {
                    l_Devoirs.Add(l_DevoirsMatiere[j]);
                }
            }
            return l_Devoirs;
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
        /// <param name="pDevoirs"></param>
        /// <param name="pEleves"></param>
        /// <param name="pSemestre"></param>
        /// <returns></returns>
        public List<cls_Note> CreerNotes(List<cls_Devoir> pDevoirs, Dictionary<int, cls_Eleve> pEleves, cls_Semestre pSemestre)
        {
            List<cls_Note> l_Notes = new List<cls_Note>();

            int[] l_IdDevoirs = new int[pDevoirs.Count];

            string l_IdDevoirsString = "(";

            for (int i = 0; i < pDevoirs.Count; i++)
            {
                l_IdDevoirsString += pDevoirs[i].Id;
                if (i != pDevoirs.Count-1)
                {
                    l_IdDevoirsString += ", ";
                }
            }
        
            l_IdDevoirsString += ")";

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

                        cls_Devoir l_Devoir = pDevoirs.Find(
                            delegate(cls_Devoir devoir)
                            {
                                return devoir.Id == l_IdDevoir;
                            }
                        );

                        cls_Eleve l_Eleve = pEleves[l_IdEleve];

                        double l_NoteValeur = l_Reader.GetDouble(2);
                        cls_Note l_Note = new cls_Note(l_NoteValeur, l_Eleve, l_Devoir, pSemestre);
                        l_Notes.Add(l_Note);
                    }
                }
            }
            return l_Notes;
        }

        public void ModifierEleve(cls_Eleve pEleve)
        {
            NpgsqlCommand cmd =
                new NpgsqlCommand("UPDATE eleve SET \"prenom\" = :Prenom, \"nom\" = :Nom, \"date_naissance\" = :DateNaissance WHERE \"id\" = " +
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
