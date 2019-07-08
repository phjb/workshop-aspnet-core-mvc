﻿using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Services;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartamentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
        
    }
}
