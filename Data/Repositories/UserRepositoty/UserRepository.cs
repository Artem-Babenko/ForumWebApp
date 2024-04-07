using ForumWebApp.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public class UserRepository : BaseRepository, IUserRepository 
{
    public UserRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }

    public UserEntity? Get(int id)
    {
        UserEntity? user = null;
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [dbo].[User]" +
                                      "WHERE [Id] = @Id";

                command.Parameters.Add(new SqlParameter("Id", id));

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new UserEntity()
                    {
                        Id = Convert.ToInt32(reader[nameof(UserEntity.Id)]),
                        Name = Convert.ToString(reader[nameof(UserEntity.Name)]) ?? "",
                        Surname = Convert.ToString(reader[nameof(UserEntity.Surname)]) ?? "",
                        Age = Convert.ToInt32(reader[nameof(UserEntity.Age)]),
                        CreateOn = Convert.ToDateTime(reader[nameof(UserEntity.CreateOn)])
                    };
                }
            }

            connection.Close();
        }
        return user;
    }

    public IList<UserEntity> GetAll()
    {
        var users = new List<UserEntity>();
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [dbo].[User]";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var user = new UserEntity()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]) ?? "",
                        Surname = Convert.ToString(reader["Surname"]) ?? "",
                        Age = Convert.ToInt32(reader["Age"]),
                        CreateOn = Convert.ToDateTime(reader["CreateOn"])
                    };
                    users.Add(user);
                }
            }

            connection.Close();
        }
        return users;
    }

    public UserEntity Add(UserEntity entity)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using(var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[User] ([Name], [Surname], [Age], [CreateOn]) " +
                                      "VALUES (@Name, @Surname, @Age, @NowDate) " +
                                      "SELECT [Id], [CreateOn] FROM [User] " +
                                      "WHERE [Id] = SCOPE_IDENTITY()";

                command.Parameters.Add(new SqlParameter("Name", entity.Name));
                command.Parameters.Add(new SqlParameter("Surname", entity.Surname));
                command.Parameters.Add(new SqlParameter("Age", entity.Age));
                command.Parameters.Add(new SqlParameter("NowDate", DateTime.Now));

                using var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    entity.Id = Convert.ToInt32(reader["Id"]);
                    entity.CreateOn = Convert.ToDateTime(reader["CreateOn"]);
                }
            }

            connection.Close();
        }

        return entity;
    }

    public bool Update(UserEntity user)
    {
        var isUpdated = false;
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE [dbo].[User] " +
                                      "SET [Name] = @Name," +
                                      "[Surname] = @Surname," +
                                      "[Age] = @Age " +
                                      "WHERE [Id] = @Id";

                command.Parameters.Add(new SqlParameter("Id", user.Id));
                command.Parameters.Add(new SqlParameter("Name", user.Name));
                command.Parameters.Add(new SqlParameter("Surname", user.Surname));
                command.Parameters.Add(new SqlParameter("Age", user.Age));

                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected == 1) isUpdated = true;
            }

            connection.Close();
        }
        return isUpdated;
    }

    public bool Delete(int id)
    {
        var isDeleted = false;
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM [User] " +
                                      "WHERE [Id] = @Id " +
                                      "SELECT * FROM [User] " +
                                      "WHERE [Id] = @Id";
                command.Parameters.Add(new SqlParameter("Id", id));

                using var reader = command.ExecuteReader();
                if (!reader.HasRows) isDeleted = true;
            }

            connection.Close();
        }
        return isDeleted;
    }
}
