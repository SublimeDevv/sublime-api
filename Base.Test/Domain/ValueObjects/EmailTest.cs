using Base.Domain.ValueObjects;

namespace Base.Test.Domain.ValueObjects
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void CreateEmailValidEmailShouldCreateEmailObject()
        {
            var validEmail = "juanmen1404@gmail.com";
            _ = new Email(validEmail);
        }

    }
}
