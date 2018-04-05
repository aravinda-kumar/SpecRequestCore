﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpecRequestCore.Models.RoleAdminViewModels
{
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
