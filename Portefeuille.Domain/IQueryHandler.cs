using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain
{
    public interface IQueryHandler<TQuery, TResult>
         where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
