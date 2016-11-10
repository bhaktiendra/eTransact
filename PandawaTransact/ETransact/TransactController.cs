using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETransact
{
    public class TransactController
    {
        // Menu CRUD
        public void AddMenu(Menu menu)
        {
            using (var context = new PandawaTransactionEntities())
            {
                context.Menus.Add(menu);
                context.SaveChanges();
            }
        }

        public void DeleteMenu(Menu menu)
        {
            
        }
    }
}
