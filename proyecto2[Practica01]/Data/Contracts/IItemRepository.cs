using proyecto2_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Data.Contracts
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        bool Save(Item oItem);
        bool Delete(int id);
    }
}
