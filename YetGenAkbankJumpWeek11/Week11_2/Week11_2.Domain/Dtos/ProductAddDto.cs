﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_2.Domain.Dtos
{
	public class ProductAddDto
	{
        public string Name { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}
