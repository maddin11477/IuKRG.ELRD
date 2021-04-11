using IuKRG.ELRD.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace IuKRG.ELRD.Units
{
    public class UnitAppService : 
        CrudAppService<
            Unit,                               //Fahrzeug Entity
            UnitDto,                            //Objekt das angezeigt wird
            Guid,                               //Primärschlüssel
            PagedAndSortedResultRequestDto,     //Für Seiten und Sortieren
            CreateUpdateUnitDto>,                //Für neue oder Änderungen
        IUnitAppService
    {
        public UnitAppService(IRepository<Unit, Guid> repository)
            : base(repository)
        {
            GetPolicyName = ELRDPermissions.Units.Default;
            GetListPolicyName = ELRDPermissions.Units.Default;
            CreatePolicyName = ELRDPermissions.Units.Create;
            UpdatePolicyName = ELRDPermissions.Units.Edit;
            DeletePolicyName = ELRDPermissions.Units.Delete;
        }
    }
}
