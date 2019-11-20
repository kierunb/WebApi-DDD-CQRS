using FluentAssertions;
using Xunit;

namespace WebApi_DDD_CQRS.Tests
{
    public class Sample
    {
        [Fact]
        public void Test1()
        {
            "test".Should().NotBeNullOrEmpty();
        }
    }
}
