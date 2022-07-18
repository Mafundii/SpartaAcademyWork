namespace VehicleTests
{
    public class Tests
    {
        [Test]
        public void WhenVahiclePositionMovesTwice_ItsPositionIs20()
        {
            Vehicle v = new Vehicle();
            var result = v.Move(2);
            Assert.That(v.Position, Is.EqualTo(20));
            Assert.That(result, Is.EqualTo("Moving along 2 times"));
        }
   
    }
} 