using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Models.RequestAdminViewModels
{
    public class EditRequestViewModel
    {
        public IEnumerable<RequestStatus> Statuses { get; set; }
        public IEnumerable<ApplicationUser> Reviewers { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayName("Request Status")]
        public int? RequestStatusId { get; set; }

        [DisplayName("Assigned To")]
        public string ReviewerId { get; set; }
    }
}
