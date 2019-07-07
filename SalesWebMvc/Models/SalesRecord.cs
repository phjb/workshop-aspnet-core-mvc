using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double Ammont { get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(int id, DateTime date, double ammont, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Ammont = ammont;
            Status = status;
            Seller = seller;
        }
    }


}
