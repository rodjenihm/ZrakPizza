﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZrakPizza.DataAccess.Entities
{
    public class Variant : Product
    {
        public VariantOption VariantOption { get; set; }
    }
}
