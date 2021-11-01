using Microsoft.Data.SqlClient;
using System.Data;

namespace P3TournamentPlanner.Server {
    public class DatabaseQuerys {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GeneralDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void RunQuery(string query)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public T SelectQuery<T>(string query, string col)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while(reader.Read())
                    {
                        T eksempel = (T)reader[col];
                        return eksempel;
                    }   
                }
                finally
                {
                    connection.Close();
                }
            }
            return default(T);
        }

        public DataTable PullTable(string quary) {

            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(quary, connection);
                connection.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
                connection.Close();
                da.Dispose();
                return table;
            }

        }
    }
}
