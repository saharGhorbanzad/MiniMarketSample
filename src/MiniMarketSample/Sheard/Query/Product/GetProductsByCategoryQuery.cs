using MediatR;
using Sheard.Command.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheard.Query.Product
{
    public class GetProductsByCategoryQuery:IRequest<IEnumerable<InsertProductCommand>>
    {
        public Guid? CategoryId { get; set; }
    }
}
