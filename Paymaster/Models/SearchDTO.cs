﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paymaster.Models
{
    public abstract class SearchDTO
    {

    }

    public class EmployeeSearchDTO:SearchDTO
    {
        public string Socsec { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
    }
}