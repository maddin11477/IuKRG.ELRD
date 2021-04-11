using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD.Units
{
    public interface IUnitAppService :
        ICrudAppService<                    //Deiniert die CRUD Methoden
            UnitDto,                        //Objekt um die Einheiten Anzuzeigen
            Guid,                           //Primärschlüssel des Objectes
            PagedAndSortedResultRequestDto, //Für Seiten und Sortieren
            CreateUpdateUnitDto>            //Objekt für hinzufügen oder updates
    {
    }
}
