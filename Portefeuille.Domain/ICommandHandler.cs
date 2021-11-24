using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain
{
    public interface ICommandHandler<TCommand>
      where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
