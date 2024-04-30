﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Commons
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }

        public List<T>? Items { get; set; }
    }
}
