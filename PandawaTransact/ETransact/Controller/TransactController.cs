using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ETransact.Controller
{
    public class TransactController
    {
        private string ServerName;

        public TransactController(string serverName)
        {
            this.ServerName = serverName;

            // check if database exist
            this.IsDatabaseExist();
            this.IsTableExist();
        }

        // Menu CRUD
        public void AddMenu(Menu menu)
        {
            using (var context = new Entities())
            {
                // alter db connection string
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Menus.Add(menu);
                context.SaveChanges();
            }
        }

        public void DeleteMenu(Menu menu)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Menus.Remove(menu);
                context.SaveChanges();
            }
        }

        public void EditMenu(Menu menu)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
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

            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                menuList = context.Menus.ToList<Menu>();
            }

            return menuList;
        }

        // Transaksi CRUD
        public void CreateTransaksi(Transaksi transaksi)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Transaksis.Add(transaksi);
                context.SaveChanges();
            }
        }

        public void RemoveTransaksi(Transaksi transaksi)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Transaksis.Remove(transaksi);
                context.SaveChanges();
            }
        }

        public IList<Transaksi> ReadTransaksi()
        {
            IList<Transaksi> transaksiList = new List<Transaksi>();

            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                transaksiList = context.Transaksis.ToList<Transaksi>();
            }

            return transaksiList;
        }

        // Metode CRUD
        public void CreateMetode(Metode metode)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Metodes.Add(metode);
                context.SaveChanges();
            }
        }

        public void RemoveMetode(Metode metode)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                context.Metodes.Remove(metode);
                context.SaveChanges();
            }
        }

        public void EditMetode(Metode metode)
        {
            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
                var editedMetode = context.Metodes.Where(m => m.Id == metode.Id).First();

                editedMetode.Nama = metode.Nama;
                editedMetode.Harga = metode.Harga;

                context.SaveChanges();
            }
        }

        public IList<Metode> ReadMetode()
        {
            IList<Metode> metodeList = new List<Metode>();

            using (var context = new Entities())
            {
                context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("ELLYNDA", this.ServerName);
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

            string script = File.ReadAllText(@"D:\Project\eTransact-master\PandawaTransact\Queries\CreateDatabase.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(script, connection))
                    {
                        connection.Open();

                        // execute the query
                        command.ExecuteNonQuery();

                        connection.Close();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                var test = e.Message;
                result = false;
            }

            return result;
        }

        private bool IsTableExist()
        {
            bool result = false;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = this.ServerName;
            builder["integrated Security"] = true;

            string projectPath = Environment.CurrentDirectory;

            string script = File.ReadAllText(projectPath + @"\Queries\CreateTables.sql");

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(script, connection))
                    {
                        connection.Open();

                        // execute the query
                        command.ExecuteNonQuery();

                        connection.Close();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                var test = e.Message;
                result = false;
            }

            return result;
        }
    }
}
