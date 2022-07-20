using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
    public class ValidarBanco : AbstractValidator<BANCO>
    {

        public ValidarBanco()
        {
            RuleFor(model => model.NOMBRE_BANCO).NotNull().NotEmpty().Length(8);
            RuleFor(model => model.codigo_banco).NotNull().NotEmpty();
            RuleFor(model => model.DIRECCION).NotNull().NotEmpty();
           

        }


    }
}
