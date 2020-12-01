using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeTestGaiaNext.Domain.Entities;
using PracticeTestGaiaNext.Domain.Enums;

namespace PracticeTestGaiaNext.Test
{
    [TestClass]
    [TestCategory("Domain - Customers Test")]
    public class CustomersTests
    {
        [TestMethod]
        public void Deve_retornar_igual_quando_customer_preenchido()
        {

            Customer customer = new Customer(1, "Teste S/A", CompanySize.Grande);

            Assert.AreEqual(1, customer.Id);
            Assert.AreEqual("Teste S/A", customer.Name);
            Assert.AreEqual(CompanySize.Grande, customer.CompanySize);
        }

        [TestMethod]
        public void Deve_retornar_nulo_quando_customer_nao_preenchido()
        {

            Customer customer = new Customer(1, "Teste S/A", CompanySize.Grande);

            Assert.IsNotNull(customer);
        }
    }
}
