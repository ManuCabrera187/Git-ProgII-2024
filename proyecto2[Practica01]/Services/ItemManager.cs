using proyecto2_Practica01_.Data.Contracts;
using proyecto2_Practica01_.Data.Implementations;
using proyecto2_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Services
{
    public class ItemManager
    {
        private IItemRepository _repositorio;

        public ItemManager()
        {
            _repositorio = new ItemRepository();
        }

        public List<Item> GetItems()
        {
            return _repositorio.GetAll();
        }

        public Item GetItemById(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool SaveItem(Item oItem)
        {
            return _repositorio.Save(oItem);
        }
        public bool DeleteItem(int id)
        {
            return _repositorio.Delete(id);
        }
    }
}
