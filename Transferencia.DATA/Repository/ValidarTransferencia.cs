using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Transferencia.DATA.Repository
{
    public class ValidarTransferencia : AbstractValidator<TRANFERENCIA>
    {
        public ValidarTransferencia()
        {
            RuleFor(model => model.cedula_cliente).NotNull().NotEmpty();
            RuleFor(model => model.num_cta).NotNull().NotEmpty();
            RuleFor(model => model.num_cuenta_destino).NotNull().NotEmpty();
            RuleFor(model => model.num_cuenta_origen).NotNull().NotEmpty();

            string[] condiciones = new string[] {


               "PENDIENTE","TRANFERIDO","RECHAZADO"
            };
            RuleFor(model =>model.estado).NotNull().NotEmpty().Must(x => condiciones.Contains(x));
        }


    }

}