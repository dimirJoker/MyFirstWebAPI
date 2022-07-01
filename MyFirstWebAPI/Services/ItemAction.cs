using MyFirstWebAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyFirstWebAPI.Services
{
    public class ItemAction
    {
        private static MySqlConnectionStringBuilder _connectionStringBuilder = new()
        {
            Server = "localhost",
            Database = "itemsdb",
            UserID = "root",
            Password = "root"
        };

        private static MySqlConnection _connection = new(_connectionStringBuilder.ConnectionString);

        public List<Item> GetAllItems()
        {
            List<Item> itemsTable = new();

            using (_connection)
            {
                MySqlCommand command = new($"select * from itemstable", _connection);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        itemsTable.Add(new Item
                        {
                            Id = (uint)reader[0],
                            Name = (string)reader[1],
                            Salary = (float)reader[2],
                            Image = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return itemsTable;
        }

        public bool Insert(Item item)
        {
            using (_connection)
            {
                MySqlCommand command = new("insert into itemstable (Name, Salary, Image) values (@name, @salary, @image)", _connection);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@salary", item.Salary);
                command.Parameters.AddWithValue("@image", item.Image);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Item GetItemById(uint id)
        {
            Item item = null;

            using (_connection)
            {
                MySqlCommand command = new("select * from itemstable where Id = @id", _connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item = new Item
                        {
                            Id = (uint)reader[0],
                            Name = (string)reader[1],
                            Salary = (float)reader[2],
                            Image = (string)reader[3]
                        };
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return item;
        }

        public bool Update(Item item)
        {
            using (_connection)
            {
                MySqlCommand command = new("update itemstable set Name=@name, Salary=@salary, Image=@image where Id=@id", _connection);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@salary", item.Salary);
                command.Parameters.AddWithValue("@id", item.Id);
                command.Parameters.AddWithValue("@image", item.Image);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(uint id)
        {
            using (_connection)
            {
                MySqlCommand command = new("delete from itemstable where Id=@id", _connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    _connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}