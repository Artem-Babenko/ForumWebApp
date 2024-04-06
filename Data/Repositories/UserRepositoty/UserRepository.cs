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
                        Id = Convert.ToInt32(reader[nameof(UserEntity.Id)]),
                        Name = Convert.ToString(reader[nameof(UserEntity.Name)]) ?? "null name",
                        Surname = Convert.ToString(reader[nameof(UserEntity.Surname)]) ?? "",
                        Age = Convert.ToInt32(reader[nameof(UserEntity.Age)]),
                        CreateOn = Convert.ToDateTime(reader[nameof(UserEntity.CreateOn)])
                    };
                    users.Add(user);
                }
            }

            connection.Close();
        }
        return users;
    }

    public void Update(UserEntity user)
    {

    }

    public void Delete(int id)
    {

    }
}
