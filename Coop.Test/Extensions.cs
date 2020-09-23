using Coop.Global;
using Xunit;

namespace Coop.Test
{
    public class Extensions
    {
        [Fact]
        public void WhenAlphabeticConversionEqualsToZero()
        {
            Assert.Equal(0, "aabbcc".ToInt32());
        }

        [Fact]
        public void WhenStringToDoubleConversionToNumber()
        {
            Assert.Equal(25.5, "25.5".ToDouble());
        }

        [Fact]
        public void WhenAlphabeticConversionEqualsDoubleZero()
        {
            Assert.Equal(0.0, "aabbcc".ToDouble());
        }

        [Fact]
        public void WhenStringToIntConversionToNumber()
        {
            Assert.Equal(25, "25".ToInt32());
        }

        [Fact]
        public void NegativeValueKeepPositive()
        {
            Assert.Equal(0, (-1).KeepPositive());
        }
    }
}