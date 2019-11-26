using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_DDD_CQRS.ResponseModels
{
    public class GetBookByIDResponseModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
    }
}
