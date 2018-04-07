using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Models
{
    public class RequestStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
