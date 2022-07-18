using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranferencia.MODEL;

namespace Transferencia.DATA.Repository
{
   public   class ValidarCliente : AbstractValidator<CLIENTE>
    {

        public ValidarCliente()
        {
            RuleFor(model => model.cedula).NotNull().NotEmpty();
            RuleFor(model => model.tipo_doc).NotNull().NotEmpty();
            RuleFor(model => model.nombre_apellido).NotNull().NotEmpty();
           
        }

    }
}
