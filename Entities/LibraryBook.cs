﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemEF.Entities
{
    internal class LibraryBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        
    }
}
