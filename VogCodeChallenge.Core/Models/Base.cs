using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VogCodeChallenge.Core.Models
{
    public class Base
    {
        [Key]
        public int ID { get; set; }
        public string EnteredBy { get; set; } = "System";
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
