using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace SAE2._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Affiche("Ligne");
        }

        static void Affiche(string table)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MySqlConnection MaCnx = new MySqlConnection(@chaineDeConnection);

            string sql = $"SELECT * FROM {table}";

            try
            {
                MaCnx.Open();

                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        Debug.Print(rdr.GetValue(i).ToString());
                    }
                }

                MaCnx.Dispose();
                MaCnx.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Supp(string cle, string ligne, string table, MySqlConnection MaCnx)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MaCnx = new MySqlConnection(chaineDeConnection);

            string sql = $"DELETE FROM {table} WHERE {cle} = {ligne}";

            try
            {
                MaCnx.Open();

                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                cmd.ExecuteNonQuery();

                MaCnx.Dispose();
                MaCnx.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static int NbCol(string table, MySqlConnection MaCnx)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MaCnx = new MySqlConnection(chaineDeConnection);

            string sql = $"SELECT * FROM {table}";
            int a = 0;
            try
            {
                MaCnx.Open();

                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();

                a = rdr.FieldCount;

                MaCnx.Dispose();
                MaCnx.Close();
                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        static List<string> ListeCol(string table, MySqlConnection MaCnx)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MaCnx = new MySqlConnection(chaineDeConnection);

            string sql = $"SELECT * FROM {table}";

            try
            {
                MaCnx.Open();

                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                MySqlDataReader rdr = cmd.ExecuteReader();
                List<string> b = new List<string>();

                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    b.Add(rdr.GetName(i).ToString());
                }

                MaCnx.Dispose();
                MaCnx.Close();
                return b;
            }
            catch (Exception ex)
            {
                List<string> b = new List<string>();
                b.Add("");
                Console.WriteLine(ex.ToString());
                return b;
            }

        }

        static void Ajout(string table, List<string> a, List<string> b, MySqlConnection MaCnx)
        {
            string serveur = "10.1.139.236";
            string login = "f1";
            string passwd = "mdp";
            string BD = "basef1";
            string chaineDeConnection = $"server={serveur};uid={login};pwd={passwd};database={BD}";

            MaCnx = new MySqlConnection(chaineDeConnection);

            try
            {
                MaCnx.Open();

                string c = "";
                string d = "";

                foreach (string s in a)
                {
                    if (c == "")
                    {
                        c = s;
                    }
                    else
                    {
                        c += "" + s;
                    }

                }
                foreach (string s in b)
                {
                    if (d == "")
                    {
                        d = s;
                    }
                    else
                    {
                        d += "" + s;
                    }

                }


                string sql = $"INSERT INTO {table}({c}) VALUES ({d})";
                MySqlCommand cmd = new MySqlCommand(sql, MaCnx);
                cmd.ExecuteNonQuery();

                MaCnx.Dispose();
                MaCnx.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
