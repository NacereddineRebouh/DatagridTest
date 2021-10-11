using DatagridTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DatagridTest.DataAccess
{
    public class DatabaseAccess
    {
        public SQLiteConnection myConnection;
        public DatabaseAccess()
        {
            myConnection = new SQLiteConnection("Data Source=./Database/DatagridTest.db");

        }

        public void Delete_Records()
        {
            try
            {
                this.OpenConnection();
                SQLiteCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "Delete FROM Users";
                cmd.ExecuteNonQuery();
                Debug.WriteLine("'Users' Records has been deleted successfully !");
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete_Record(int id)
        {
            try
            {
                this.OpenConnection();
                SQLiteCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "Delete FROM Users where Id= @id";


                cmd.Parameters.Add("@id", System.Data.DbType.Int64).Value = id;
                cmd.ExecuteNonQuery();
                Debug.WriteLine("'Users' with id=" + id + " has been deleted successfully !");
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Users> Get_Users()
        {
            List<Users> dt = new List<Users>();
            try
            {
                this.OpenConnection();
                SQLiteCommand cmd = myConnection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Users";
                cmd.ExecuteNonQuery();

                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Debug.WriteLine(dr.GetValue(0).ToString() + dr.GetValue(1).ToString() + dr.GetValue(2).ToString() + dr.GetValue(3).ToString());
                    Users op = new Users(int.Parse(dr.GetValue(0).ToString()), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(4).ToString());
                    dt.Add(op);
                }
                this.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Thread.Sleep(60000);
            }
            return dt;
        }



        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
