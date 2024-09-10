using proyecto2_Practica01_.Data.Contracts;
using proyecto2_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto2_Practica01_.Utils;

namespace proyecto2_Practica01_.Data.Implementations
{
    public class BillRepository : IBillRepository
    {
        public List<Bill> GetAll()
        {
            List<Bill> lst = new List<Bill>();
            Bill oBill = null;
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("sp_GetBills", null);
            foreach (DataRow row in t.Rows)
            {
                if (oBill == null || oBill.Id != Convert.ToUInt32(row["id_bill"].ToString()))
                {
                    oBill = new Bill();
                    oBill.Client = row["client"].ToString();
                    oBill.Date = Convert.ToDateTime(row["fecha"].ToString());
                    oBill.Id = Convert.ToInt32(row["id_bill"].ToString());
                    oBill.AddDetail(ReadDetail(row));
                    lst.Add(oBill);
                }
                else
                {
                    oBill.AddDetail(ReadDetail(row));
                }
            }
            return lst;
        }

        private BillDetail ReadDetail(DataRow row)
        {
            BillDetail detail = new BillDetail();
            detail.Item = new Item
            {
                Id = Convert.ToInt32(row["id_item"].ToString()),
                Name = row["name"].ToString(),
                UnitPrice = Convert.ToDouble(row["unit_price"].ToString()),
            };
            detail.Price = Convert.ToSingle(row["precio"].ToString());
            detail.Amount = Convert.ToInt32(row["amount"].ToString());
            return detail;
        }

        public Bill GetById(int id)
        {
            Bill oBill = null;
            var helper = DataHelper.GetInstance();
            var parameter = new ParameterSQL("@id_bill", id);
            var parameters = new List<ParameterSQL>();
            parameters.Add(parameter);

            var t = helper.ExecuteSPQuery("sp_GetBillById", parameters);
            foreach (DataRow row in t.Rows)
            {
                if (oBill == null)
                {
                    oBill = new Bill();
                    oBill.Client = row["client"].ToString();
                    oBill.Date = Convert.ToDateTime(row["fecha"].ToString());
                    oBill.Id = Convert.ToInt32(row["id_bill"].ToString());
                    oBill.AddDetail(ReadDetail(row));
                }
                else
                {
                    oBill.AddDetail(ReadDetail(row));
                }
            }
            return oBill;
        }

        public bool Save(Bill oBill)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("sp_InsertBill", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", oBill.Date);
                cmd.Parameters.AddWithValue("@client", oBill.Client);
                
                SqlParameter param = new SqlParameter("@id_bill", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int billId = (int)param.Value;

                int nroDetail = 1;
                foreach (var detail in oBill.GetDetails())
                {
                    var cmdDetail = new SqlCommand("sp_InsertDetail", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@id_bill", billId);
                    cmdDetail.Parameters.AddWithValue("@id_bill_detail", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@amount", detail.Amount);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);

                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
