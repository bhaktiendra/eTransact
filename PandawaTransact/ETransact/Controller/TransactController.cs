using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ETransact.Controller
{
    public class TransactController
    {
        private string ServerName;

        public TransactController(string serverName)
        {
            this.ServerName = serverName;

            // check if database exist
            if(!this.IsDatabaseExist())
            {
                // database for transaction not found, create database

            }
        }

        // Menu CRUD
        public void AddMenu(Menu menu)
        {
            using (var context = new TransactionEntities())
            {
                // might need to alter db connection string
                var test = context.Database.Connection.ConnectionString;
                context.Menus.Add(menu);
                context.SaveChanges();
            }
        }

        public void DeleteMenu(Menu menu)
        {
            using (var context = new TransactionEntities())
            {
                context.Menus.Remove(menu);
                context.SaveChanges();
            }
        }

        public void EditMenu(Menu menu)
        {
            using (var context = new TransactionEntities())
            {
                var editedMenu = context.Menus.Where(m => m.Id == menu.Id).First();

                editedMenu.Nama = menu.Nama;
                editedMenu.Kategori = menu.Kategori;
                editedMenu.Metode = menu.Metode;
                editedMenu.Deskripsi = menu.Deskripsi;
                editedMenu.Diskon = menu.Diskon;
                editedMenu.Harga = menu.Harga;

                context.SaveChanges();
            }
        }

        public IList<Menu> ReadMenu()
        {
            IList<Menu> menuList = new List<Menu>();

            using (var context = new TransactionEntities())
            {
                menuList = context.Menus.ToList<Menu>();
            }

            return menuList;
        }

        // Transaksi CRUD
        public void CreateTransaksi(Transaksi transaksi)
        {
            using (var context = new TransactionEntities())
            {
                context.Transaksis.Add(transaksi);
                context.SaveChanges();
            }
        }

        public void RemoveTransaksi(Transaksi transaksi)
        {
            using (var context = new TransactionEntities())
            {
                context.Transaksis.Remove(transaksi);
                context.SaveChanges();
            }
        }

        public IList<Transaksi> ReadTransaksi()
        {
            IList<Transaksi> transaksiList = new List<Transaksi>();

            using (var context = new TransactionEntities())
            {
                transaksiList = context.Transaksis.ToList<Transaksi>();
            }

            return transaksiList;
        }

        // Metode CRUD
        public void CreateMetode(Metode metode)
        {
            using (var context = new TransactionEntities())
            {
                context.Metodes.Add(metode);
                context.SaveChanges();
            }
        }

        public void RemoveMetode(Metode metode)
        {
            using (var context = new TransactionEntities())
            {
                context.Metodes.Remove(metode);
                context.SaveChanges();
            }
        }

        public void EditMetode(Metode metode)
        {
            using (var context = new TransactionEntities())
            {
                var editedMetode = context.Metodes.Where(m => m.Id == metode.Id).First();

                editedMetode.Nama = metode.Nama;
                editedMetode.Harga = metode.Harga;

                context.SaveChanges();
            }
        }

        public IList<Metode> ReadMetode()
        {
            IList<Metode> metodeList = new List<Metode>();

            using (var context = new TransactionEntities())
            {
                metodeList = context.Metodes.ToList<Metode>();
            }

            return metodeList;
        }

        private bool IsDatabaseExist()
        {
            bool result = false;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = this.ServerName;
            builder["integrated Security"] = true;

            string databaseName = "PandawaTransaction";
            string query = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // execute the query
                        Object resultObj = command.ExecuteScalar();

                        int databaseID = 0;

                        // check the query exxecution result
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        connection.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private void CreateTransactDatabase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = this.ServerName;
            builder["integrated Security"] = true;

            // TODO : import query create db and tables
            string query = string.Format("");
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // execute the query
                        command.ExecuteScalar();

                        connection.Close();
                    }
                }
            }
            catch{}
        }

    }
}
