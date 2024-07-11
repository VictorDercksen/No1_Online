﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("LoadingPoints")]
    public class LoadingPoint
    {
        public int Id { get; set; }
        
        public string? Street { get; set; }

        public string? Suburb { get; set; }

        public string? City { get; set; }
        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

       
        public DateTime? Revision { get; set; }

        

    }
}
