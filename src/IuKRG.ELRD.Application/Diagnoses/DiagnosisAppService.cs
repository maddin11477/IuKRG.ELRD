﻿using System;
using IuKRG.ELRD.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Diagnoses
{
    public class DiagnosisAppService :
        CrudAppService<
            Diagnosis,                          // diagnosis entity
            DiagnosisDto,                       // data transfer object
            Guid,                               // primary key
            PagedAndSortedResultRequestDto,     // display and sort object
            CreateUpdateDiagnosisDto>,          // add / edit object
        IDiagnosisAppService
    {
        public DiagnosisAppService(IRepository<Diagnosis, Guid> repository) : base(repository)
        {
            GetPolicyName = ELRDPermissions.Basedata.Default;
            CreatePolicyName = ELRDPermissions.Basedata.DiagnosisCU;
            DeletePolicyName = ELRDPermissions.Basedata.DiagnosisD;
        }
    }
}
