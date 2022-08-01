using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheard.Query.Category
{
    public class GetCategoryNameQuery:IRequest<string>
    {
        public Guid? CategoryId { get; set; }
    }
}
