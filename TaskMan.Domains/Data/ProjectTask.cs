﻿using DNI.Shared.Contracts.Enumerations;
using DNI.Shared.Services.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Data
{
    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }
        public Project Project { get; set; }
        public Task Task { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public DateTimeOffset? Due { get; set; }
        
        [Modifier(ModifierFlag.Created)]
        public DateTimeOffset Created { get; set; }

        [Modifier(ModifierFlag.Created 
                    | ModifierFlag.Modified)]
        public DateTimeOffset Modified { get; set; }
    }
}
