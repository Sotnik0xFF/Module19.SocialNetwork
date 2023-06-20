﻿using System.Data;
using System.Data.SQLite;
using System.Reflection;
using Dapper;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                connection.Execute("PRAGMA foreign_keys = '1'");
                return connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DB/social_network_bd.db; Version = 3");
        }
    }
}
