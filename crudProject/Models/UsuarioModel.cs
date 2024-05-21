using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace crudProject.Models
{
   
    public class UsuarioModel : IDisposable
    {
        private SqlConnection connection;

        public UsuarioModel()
        {
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDContato;Integrated Security=True";
        
            connection = new SqlConnection(conn);
            connection.Open();
        
        }
        public void Dispose()
        {
            connection.Close();
        }

        public void Create(UsuarioWeb usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Usuarios VALUES (@nome, @email)";

            cmd.Parameters.AddWithValue("@nome", usuario.nome);
            cmd.Parameters.AddWithValue("@email", usuario.email);

            cmd.ExecuteNonQuery();
        }
        public List<UsuarioWeb> Read()
        {
            List<UsuarioWeb> lista = new List<UsuarioWeb>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Usuarios";

            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                UsuarioWeb usuario = new UsuarioWeb();
                usuario.id = (int)reader["ID"];
                usuario.nome = (string)reader["nome"];
                usuario.email = (string)reader["email"];

                lista.Add(usuario);
            }
            return lista;
        }
        public void Update (UsuarioWeb usuario)
        {
            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection= connection;
            cmd.CommandText = @"UPDATE Usuario SET nome = @nome, email=@email WHERE id = @id";

            cmd.Parameters.AddWithValue("@nome", usuario.nome);
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.Parameters.AddWithValue("@id", usuario.id);

            cmd.ExecuteNonQuery();

        } 
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= connection;
            cmd.CommandText = @"DELETE FROM Usuario WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();  
        }
    }

   
}
