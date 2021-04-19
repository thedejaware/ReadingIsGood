﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIG.API.Model
{
    public class ResponseModel
    {

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
        public int StatusCode { get; set; }
    }
}

