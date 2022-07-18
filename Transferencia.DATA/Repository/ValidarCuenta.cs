using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public  class ValidarCuenta : AbstractValidator<CUENTA>
    {
        public ValidarCuenta()
        {
            RuleFor(model => model.NUM_CTA).NotNull().NotEmpty();

            RuleFor(model => model.CEDULA_CLIENTE).NotNull().NotEmpty();

            RuleFor(model => model.MONEDA).NotNull().NotEmpty();

            RuleFor(model => model.SALDO).NotNull().NotEmpty();

            RuleFor(model => model.COD_BANCO).NotNull().NotEmpty();


          
        }

    }
}
