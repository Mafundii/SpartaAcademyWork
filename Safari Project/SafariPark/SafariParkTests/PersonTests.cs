namespace SafariParkTests

{
    public class Tests
    {


        [TestCase("Cathy", "French", "Cathy French")]
        public void GetFullName(string firstName, string lastName, string expectedResult)
        {
            Person subject = new Person(firstName, lastName);
            var result = subject.FullName;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        public void AgeTest()
        {

        }

        [Test]
        public void Point3dTest()
        {
            //Arrange
            var subject = new Point3d(1, 2, 3);
            //Act
            var result = subject.SumOfPoints();
            //Assert
            Assert.That(subject.x, Is.EqualTo(1));
            Assert.That(subject.y, Is.EqualTo(2));
            Assert.That(subject.z, Is.EqualTo(3));
            Assert.That(result, Is.EqualTo(6));
        }

     
    }
}