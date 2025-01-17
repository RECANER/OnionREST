﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 6;
        }

        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 6 ? 6 : pageSize;
        }
    }
}
