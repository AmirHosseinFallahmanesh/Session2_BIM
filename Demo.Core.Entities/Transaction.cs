using System;

namespace Demo.Core.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            InsertDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime InsertDate { get; set; }

        
    

    }
}
