﻿using System;
using System.Collections.Generic;

namespace WebApplication16.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
