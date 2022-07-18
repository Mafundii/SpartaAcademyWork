namespace ExceptionsTests
{
    public class GradeTests
    {

        //Tests for values less than 0
        [TestCase(-1)]
        [TestCase(-100)]
        public void WhenMarkIsLessThan0_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {           
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Allowed range 0-100"));            
            Assert.That(() => Program.Grade(mark), Throws.InstanceOf<Exception>().With.Message.Contain("Allowed range 0-100"));
        }

        //Tests for values more than 100
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        public void WhenMarkIsMoreThan100_Grade_ThrowsAnArgumentOutOfRangeException(int mark)
        {
            Assert.That(() => Program.Grade(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Allowed range 0-100"));
        }



    }
}