using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETransact.Controller
{
    public class TransactController
    {
        // Menu CRUD
        public void AddMenu(Menu menu)
        {
            using (var context = new TransactionEntities())
            {
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

    }
}
