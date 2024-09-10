using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Domain
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        private List<BillDetail> details;

        public List<BillDetail> GetDetails()
        {
            return details;
        }

        public Bill()
        {
            details = new List<BillDetail>();
        }

        public void AddDetail(BillDetail detail)
        {
            if (detail != null)
                details.Add(detail);
        }

        public void RemoveDetail(int index)
        {
            details.RemoveAt(index);
        }

        public double Total()
        {
            double total = 0;
            foreach (var detail in details)
            {
                total += detail.SubTotal();
            }

            return total;
        }
    }
}
