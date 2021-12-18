using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Entities
{

    public class Account
    {
        public int AccountId { get; set; }

     //   [Column(TypeName ="nvarchar(25)")]
        public string Name { get; set; }
        public string CartNumber { get; set; }
        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
