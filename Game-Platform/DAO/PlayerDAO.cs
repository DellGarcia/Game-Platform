using Game_Platform.Database;
using Game_Platform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Game_Platform.DAO
{
    public class PlayerDAO
    { 
        private readonly ConnectionFactory connection = new ConnectionFactory();

        public void Insert(Player player)
        {
            try
            {
                connection.Open();

                SqlCommand query = new SqlCommand(
                    "INSERT INTO tbPlayer(usuario, senha, email, vitorias, derrotas)" +
                        "VALUES(@user, @password, @email, @vitorias, @derrotas)", connection.Connection);


                query.Parameters.AddWithValue("@user", player.Username);
                query.Parameters.AddWithValue("@password", player.Password);
                query.Parameters.AddWithValue("@email", player.Email);
                query.Parameters.AddWithValue("@vitorias", player.Vitorias);
                query.Parameters.AddWithValue("@derrotas", player.Derrotas);
                query.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Não foi possível inserir o Jogador");
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(Player player)
        {

        }

        public void Delete(Player player)
        {

        }


        public List<Player> SelectAll()
        {
            try
            {
                connection.Open();

                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM tbPlayer", connection.Connection);
                DataTable table = new DataTable();

                query.Fill(table);

                DataRowCollection rows = table.Rows;
                List<Player> players = new List<Player>();

                foreach (DataRow row in rows)
                {
                    Player player = new Player
                    {
                        Username = row.Field<String>("usuario"),
                        Email = row.Field<String>("email"),
                        Password = row.Field<String>("senha"),
                        Vitorias = row.Field<int>("vitorias"),
                        Derrotas = row.Field<int>("derrotas")
                    };

                    players.Add(player);
                }

                return players;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                System.Windows.MessageBox.Show("Não foi possível realizar o SELECT na tabela de Clientes.");
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public Player Select(String username)
        {
            try
            {
                connection.Open();

                SqlDataAdapter query = new SqlDataAdapter($"SELECT * FROM tbPlayer WHERE usuario = {username}", connection.Connection);
                DataTable table = new DataTable();

                query.Fill(table);

                DataRow row = table.Rows[0];

                Player player = new Player
                {
                    Username = row.Field<String>("usuario"),
                    Email = row.Field<String>("email"),
                    Password = row.Field<String>("senha"),
                    Vitorias = row.Field<int>("vitorias"),
                    Derrotas = row.Field<int>("derrotas")
                };

                return player;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Não foi possível realizar o SELECT na tabela de Clientes.");
            }
            finally
            {
                connection.Close();
            }

            return null;
        }
    }
}
