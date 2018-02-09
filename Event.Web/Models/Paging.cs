using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Models
{
    public class Paging
    {
        public Paging()
        {
            PageSize = 8;
            CurrentPage = 1;
        }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get { return ((TotalItems - 1) / PageSize) + 1; } }
        public bool isFirst { get { return CurrentPage == 1 ? true : false; } }
        public bool isLast { get { return (TotalItems % PageSize <= PageSize) ? true : false; } }


    }
}
