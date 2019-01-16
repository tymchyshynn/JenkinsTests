using Atata;
using NUnit.Framework;
using PhpTravels.UITests.Components;

namespace PhpTravels.UITests
{
    public class HotelTests : UITestFixture
    {
        [Test, Category("First Test")]
        public void Hotel_Add()
        {
            System.Threading.Thread.Sleep(3000);
            Assert.True(true);
        }

        [Test, Category("Second Test")]
        public void Hotel_Edit()
        {   
            System.Threading.Thread.Sleep(5000);
            Assert.True(false);
        }

       
    }
}
