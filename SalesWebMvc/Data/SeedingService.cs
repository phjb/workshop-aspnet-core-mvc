using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            /* VERIFICA SE JÁ EXISTE DADOS NO DB */
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                
                return;
            }

            Department d1 = new Department(1,"Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1,"Paulo","paulo@email.com", new DateTime(1990,01,01),1000.0,d1);

            SalesRecord r1 = new SalesRecord(1,new DateTime(2019,07,06),50.0,SalesStatus.Billed,s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        }
    }
}
