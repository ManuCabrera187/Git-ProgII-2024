using proyecto2_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Data.Contracts
{
    public interface IBillRepository
    {
        bool Save(Bill oBill);
        List<Bill> GetAll();
        Bill GetById(int id);
    }
}
