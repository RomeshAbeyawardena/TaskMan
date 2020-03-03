﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectTaskReferenceService
    {
        bool TryGetReferences(string references, out IEnumerable<ProjectTaskReference> projectTaskReferences);
        Task<ProjectTaskReference> Save(ProjectTaskReference projectTaskReference, bool saveChanges, CancellationToken cancellationToken);
    }
}