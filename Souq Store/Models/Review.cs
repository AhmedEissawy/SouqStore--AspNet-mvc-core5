using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
