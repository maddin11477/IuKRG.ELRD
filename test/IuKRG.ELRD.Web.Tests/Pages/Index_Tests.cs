using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace IuKRG.ELRD.Pages
{
    public class Index_Tests : ELRDWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
