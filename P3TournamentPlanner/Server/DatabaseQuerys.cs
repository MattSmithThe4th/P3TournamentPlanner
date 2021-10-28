using Microsoft.Data.SqlClient;

namespace P3TournamentPlanner.Server {
    public class DatabaseQuerys {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TourneyTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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

        public T SelectQuery<T>(string query)
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
                        T eksempel = (T)reader["playerName"];
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
    }
}
