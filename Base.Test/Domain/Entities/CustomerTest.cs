using Base.Domain.Entities;

namespace Base.Test.Domain.Entities
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCustomerValidDataShouldCreateCustomerObject()
        {
            new Customer(null, null);
        }
    }
}
