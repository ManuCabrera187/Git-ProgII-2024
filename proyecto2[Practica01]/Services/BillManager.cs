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
    public class BillManager
    {
        private IBillRepository _repository;

        public BillManager()
        {
            _repository = new BillRepository();
        }

        public List<Bill> GetBill()
        {
            return _repository.GetAll();
        }

        public Bill GetBillById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveBill(Bill oBill)
        {
            return _repository.Save(oBill);
        }
    }
}
