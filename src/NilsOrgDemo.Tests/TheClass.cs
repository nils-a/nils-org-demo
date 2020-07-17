using Shouldly;

using Xunit;

namespace NilsOrgDemo.Test
{
    public class TheClass
    {
        [Fact]
        public void Should_contain_a_method()
        {
            var sut = new Class1();

            var actual = sut.Method();

            actual.ShouldBeTrue();
        }
    }
}