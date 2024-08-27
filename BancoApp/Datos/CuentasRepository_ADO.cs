using BancoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Datos
{
    public class CuentasRepository_ADO : ICuentasRepository
    {
        //crud 
        //llamar metodo del helper para conectar con bd
        //mapear
        private SqlConnection _connection;

        public CuentasRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }
        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public List<Cuenta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cuenta GetById()
        {
            throw new NotImplementedException();
        }
    }
}
