using BancoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Datos
{
    public interface ICuentasRepository
    {
        List<Cuenta> GetAll();
        Cuenta GetById();
        bool Add();
        bool Delete();
    }
}
