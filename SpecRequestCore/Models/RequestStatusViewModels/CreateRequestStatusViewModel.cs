using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Models.RequestStatusViewModels
{
    public class CreateRequestStatusViewModel
    {
        [Required]
        public string Status { get; set; }
    }
}
