﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(50)]
        public string? LastModifiedBy { get; set; }
    }
}
