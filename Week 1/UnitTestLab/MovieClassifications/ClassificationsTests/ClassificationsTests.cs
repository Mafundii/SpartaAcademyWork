using UnitTestsLab;

namespace ClassificationsTests
{

    public class Tests
    {

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void GivenAgeLessThan0_AvailableCLassifications_ThrowsArgumentOutOfRange(int age)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.AvailableClassifications(age));
        }
       
        [TestCase(6, "U and PG films are available.")]
        [TestCase(11, "U and PG films are available.")]        
        public void GivenAgeUnder12_AvailableClassifications_ReturnsCorrectString(int age,  string availableFilms)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(availableFilms)); 
        }

        [TestCase(12, "U, PG and 12 films are available.")]
        [TestCase(13, "U, PG and 12 films are available.")]
        [TestCase(14, "U, PG and 12 films are available.")]
        public void GivenAgeUnder15Over12_AvailableClassifications_ReturnsCorrectString(int age, string availableFilms)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(availableFilms));
        }

        [TestCase(15, "U, PG, 12 and 15 films are available.")]
        [TestCase(16, "U, PG, 12 and 15 films are available.")]
        [TestCase(17, "U, PG, 12 and 15 films are available.")]
        public void GivenAgeUnder18Over15_AvailableClassifications_ReturnsCorrectString(int age, string availableFilms)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(availableFilms));
        }

        [TestCase(18, "All films are available")]
        [TestCase(19, "All films are available")]
        [TestCase(int.MaxValue, "All films are available")]
        public void GivenAgeOver18_AvailableClassifications_ReturnsCorrectString(int age, string availableFilms)
        {
            Assert.That(Program.AvailableClassifications(age), Is.EqualTo(availableFilms));
        }
    }
}