using CookieBakingApp;

namespace CookieBakingTests
{
    public class Tests
    {
        [Test]
        public void GivenRecipe_Returns_RecipeMessage()
        {
            //Arrange
            string message;
            string expectedMessage = "
                ";

            //Act
            message = Baker.RecipeMessage();

            //Assert
            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}