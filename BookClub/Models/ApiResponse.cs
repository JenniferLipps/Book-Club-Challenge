using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookClub.Models
{
    public class ApiResponse
    {
        [XmlElement("GoodreadsResponse")]
        public ApiResponseResult GoodreadsResponse { get; set; }
    }

    public class ApiResponseResult
    {
        [XmlElement("search")]
        public ApiResponseSearch Search { get; set; }
    }

    public class ApiResponseSearch
    {
        [XmlElement("query")]
        public ApiResponseSearchQuery Query { get; set; }
    }

    public class ApiResponseSearchQuery
    {
        [XmlElement("results")]
        public ApiResponseSearchQueryResult Results { get; set; }
    }

    public class ApiResponseSearchQueryResult
    {
        [XmlElement("work")]
        public ApiReponseSearchQueryResultWork Work { get; set; }
    }

    public class ApiReponseSearchQueryResultWork
    {
        [XmlElement("best_book")]
        public ApiBook best_book { get; set; }
    }
}
