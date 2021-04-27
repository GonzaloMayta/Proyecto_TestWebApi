using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Business;
using WebApi.Models.Transferencias;

namespace WebApi.Domain
{
    public  class TransferenciaDomain
    {

        public static TransferenciaModels transferecia(TransferenciaModels t)
        {
            return Transferencia.transferencia(t);
        }

    }
}
