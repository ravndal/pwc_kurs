using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace PwC.Course.HttpStufff.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var services = new ServiceCollection()
            .AddTransient<IDateService>((sp) =>
            {
                var mockDateService = new Mock<IDateService>();
                mockDateService
                    .Setup(s => s.GetCurrentDate())
                    .Returns(new DateTime(2023, 11, 1));
                return mockDateService.Object;
            });
        
        var sp = services.BuildServiceProvider();
        
        var dateService = sp.GetRequiredService<IDateService>();
        
        
        // arrange
        var date = dateService.GetCurrentDate();
        
        // act
        date = date.AddDays(30);

        // assert
        Assert.Equal(2023, date.Year);
    }
}

public interface IDateService
{
    DateTime GetCurrentDate();
}

file class DateService :IDateService
{
    public DateTime GetCurrentDate() => DateTime.Now;
}