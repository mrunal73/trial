public class DatabaseManager
{
    private const string ConnectionString = "Server=LAPTOP-PEUA1J81\SQLEXPRESS;Database=UserInfo;User ID=sa;Password=aspen@123;";


    public bool RegisterUser(string username, string email, string password)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", HashPassword(password));

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    public bool AuthenticateUser(string username, string password)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                string storedHash = command.ExecuteScalar() as string;

                // Implement password verification logic (e.g., using a hashing library)
                return VerifyPassword(password, storedHash);
            }
        }
    }

    // Additional methods for password hashing and verification
    private string HashPassword(string password)
    {
        // Implement password hashing logic (e.g., using a hashing library)
        throw new NotImplementedException();
    }

    private bool VerifyPassword(string inputPassword, string storedHash)
    {
        // Implement password verification logic (e.g., using a hashing library)
        throw new NotImplementedException();
    }
}
