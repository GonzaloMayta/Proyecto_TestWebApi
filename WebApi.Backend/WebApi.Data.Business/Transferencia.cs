using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Access.DAL;
using WebApi.Models.Transferencias;

namespace WebApi.Data.Business
{
    public class Transferencia
    {

        public static TransferenciaModels transferencia(TransferenciaModels t)
        {
            return TransferenciaDAL.transferencia(t);
        }
    }
}
