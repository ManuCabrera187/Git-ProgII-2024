using proyecto2_Practica01_.Data.Contracts;
using proyecto2_Practica01_.Domain;
using proyecto2_Practica01_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Data.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private SqlConnection _connection;

        public ItemRepository()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public bool Delete(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@id_item", id));
            int rows = DataHelper.GetInstance().ExecuteSPDML("sp_DeleteItem", parameters);
            return rows == 1;
        }

        public List<Item> GetAll()
        {
            List<Item> lst = new List<Item>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("sp_GetAllItems", null);
            foreach (DataRow row in t.Rows)
            {
                int idItem = Convert.ToInt32(row["id_item"]);
                string nameItem = row["name"].ToString();
                double unitPriceItem = Convert.ToDouble(row["unit_price"]);

                Item oItem = new Item()
                {
                    Id = idItem,
                    Name = nameItem,
                    UnitPrice = unitPriceItem
                };
                lst.Add(oItem);
            }
            return lst;
        }

        public Item GetById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@id_item", id));
            DataTable t = DataHelper.GetInstance().ExecuteSPQuery("sp_GetItemById", parameters);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int idItem = Convert.ToInt32(row["id_item"]);
                string nameItem = row["name"].ToString();
                double unitPriceItem = Convert.ToDouble(row["unit_price"]);

                Item oItem = new Item()
                {
                    Id = idItem,
                    Name = nameItem,
                    UnitPrice = unitPriceItem
                };
                return oItem;

            }
            return null;
        }

        public bool Save(Item oItem)
        {
            bool result = true;
            string query = "sp_SaveItem";

            try
            {
                if (oItem != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", oItem.Id);
                    cmd.Parameters.AddWithValue("@name", oItem.Name);
                    cmd.Parameters.AddWithValue("@unit_price", oItem.UnitPrice);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
