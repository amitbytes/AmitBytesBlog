using System;
using System.Collections.Generic;
using System.Text;

namespace AmitBytesBlog.Entity
{

    public enum SortOrder
    {
        ASC=1,
        DESC=2
    }

    public class PageListParameters
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SearchValue { get; set; }
        public SortOrder SortDir { get; set; }

    }
}
