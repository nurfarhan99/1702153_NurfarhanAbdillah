﻿
using pv03_1702153_Nurfarhan.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pv03_1702153_Nurfarhan.Respository
    {
        class Delete
        {
            string cs = @"server=localhost;
                    userid=root;
                    database=provis_masterdetail;
                    SslMode=none";

            MySqlConnection conn;
            MySqlDataReader rdr;

            public TodoDelete()
            {
                conn = null;
                rdr = null;
            }

            public List<Todo> getByNim(string nim)
            {
                List<Todo> listTodo = new List<Todo>();

                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM todo WHERE nimMhs = '" + nim + "';";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Todo temp = new Todo();
                    temp.Id = rdr.GetInt32(0);
                    temp.NimMhs = rdr.GetString(1);
                    temp.Nama = rdr.GetString(2);
                    temp.Kategori = rdr.GetString(3);

                    listTodo.Add(temp);
                }
                conn.Close();
                return listTodo;

            }


            public void addTodo(Todo todo)
            {
                string cs = @"server=
                    localhost;
                    userid=root;
                    database=provis_masterdetail;
                    SslMode=none";

                MySqlConnection conn = null;

                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM todo WHERE id ='" + nim + "';";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Id", todo.Id);
                    cmd.Parameters.AddWithValue("@Nim", todo.NimMhs);
                    cmd.Parameters.AddWithValue("@Nama", todo.Nama);
                    cmd.Parameters.AddWithValue("@Kategori", todo.Kategori);
                    cmd.ExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }

        }
    }



