using SafariParkApp;

namespace AirplaneTests
{
    public class Tests
    {
        [Test]
        public void GivenMove2AndAltitude500_Airplane_ShouldReturnStringWithCorrespondingValues()
        {
            Airplane a = new(200, 100, "JetsRUs");
            a.Ascend(500);
            var result = a.Move(2);

            Assert.That(result, Is.EqualTo("Moving along 2 times at an altitude of 500 metres"));

        }

        [Test]
        public void GivenANegativeMoveValue_Airplane_ShouldReturnArgumentOutOfRangeException()
        {
            Airplane a = new(200, 100, "JetsRUs");         

            Assert.That(() => a.Move(-2), Throws.TypeOf<ArgumentOutOfRangeException>());

        }

    


    }
}