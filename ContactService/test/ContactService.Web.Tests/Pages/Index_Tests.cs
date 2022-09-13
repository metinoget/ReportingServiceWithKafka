using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ContactService.Pages;

public class Index_Tests : ContactServiceWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
