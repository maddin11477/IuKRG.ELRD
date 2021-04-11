using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace IuKRG.ELRD.Units
{
    public class UnitAppService_Tests : ELRDApplicationTestBase
    {
        private readonly IUnitAppService _unitAppService;

        public UnitAppService_Tests()
        {
            _unitAppService = GetRequiredService<IUnitAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Units()
        {
            //Act
            var result = await _unitAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(u => u.Callsign == @"RK BNEST 71/1");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Unit()
        {
            //Act
            var result = await _unitAppService.CreateAsync(
                new CreateUpdateUnitDto
                {
                    Callsign = @"RK TEST 71/1",
                    CrewCount = 2,
                    Type = UnitType.Divers
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Callsign.ShouldBe("RK TEST 71/1");
        }

        [Fact]
        public async Task Should_Not_Create_A_Unit_Without_Callsign()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _unitAppService.CreateAsync(
                    new CreateUpdateUnitDto
                    {
                        Callsign = "",
                        CrewCount = 100,
                        Type = UnitType.Divers
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Callsign"));
        }
    }
}
