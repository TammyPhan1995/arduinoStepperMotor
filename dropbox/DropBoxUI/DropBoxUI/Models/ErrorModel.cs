﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxUI.Models
{
    public class ErrorModel
    {
        public String timestamp { get; set; }

        public int status { get; set; }

        public String error { get; set; }

        public String message { get; set; }
    }
}
