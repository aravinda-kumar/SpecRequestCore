using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Models.RequestViewModels
{
    public class CreateRequestViewModel
    {
        public CreateRequestViewModel()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
