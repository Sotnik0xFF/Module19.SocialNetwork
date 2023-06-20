using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private const string UserStatement = @$"
            id as {nameof(UserEntity.Id)},
            firstname as {nameof(UserEntity.FirstName)},
            lastname as {nameof(UserEntity.LastName)},
            password as {nameof(UserEntity.Password)},
            email as {nameof(UserEntity.Email)},
            photo as {nameof(UserEntity.Photo)},
            favorite_book as {nameof(UserEntity.FavoriteBook)},
            favorite_movie as {nameof(UserEntity.FavoriteMovie)}";

    public int Create(UserEntity userEntity)
    {
        string sql = @$"
                INSERT INTO users (firstname, lastname, password, email)
                VALUES (
                    @{nameof(UserEntity.FirstName)},
                    @{nameof(UserEntity.LastName)},
                    @{nameof(UserEntity.Password)},
                    @{nameof(UserEntity.Email)})";

        return Execute(sql, userEntity);
    }

    public int DeleteById(int id)
    {
        string sql = $@"
                DELETE FROM users
                WHERE id = @UserId";

        return Execute(sql, new { UserId = id });
    }

    public IEnumerable<UserEntity> FindAll()
    {
        string sql = $@"
                SELECT {UserStatement}
                FROM users";

        return Query<UserEntity>(sql);
    }

    public UserEntity? FindByEmail(string email)
    {
        string sql = $@"
                SELECT {UserStatement}
                FROM users
                WHERE email = @UserEmail";

        return QueryFirstOrDefault<UserEntity>(sql, new { UserEmail = email });
    }

    public UserEntity? FindById(int id)
    {
        string sql = $@"
                SELECT {UserStatement}
                FROM users
                WHERE id = @UserId";

        return QueryFirstOrDefault<UserEntity>(sql, new { UserId = id });
    }

    public int Update(UserEntity userEntity)
    {
        string sql = $@"
                UPDATE users 
                SET
                    id = @{nameof(UserEntity.Id)},
                    firstname = @{nameof(UserEntity.FirstName)},
                    lastname = @{nameof(UserEntity.LastName)},
                    password = @{nameof(UserEntity.Password)},
                    email = @{nameof(UserEntity.Email)},
                    photo = @{nameof(UserEntity.Photo)},
                    favorite_book = @{nameof(UserEntity.FavoriteBook)},
                    favorite_movie = @{nameof(UserEntity.FavoriteMovie)}
                WHERE id = @{nameof(UserEntity.Id)}";

        return Execute(sql, userEntity);
    }
}
