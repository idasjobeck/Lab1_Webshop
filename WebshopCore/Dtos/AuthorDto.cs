﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class AuthorDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
