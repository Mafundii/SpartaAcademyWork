using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using System.Collections.Generic;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;
        private Mock<ICustomerService> mockCustomerService;
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            mockCustomerService = new Mock<ICustomerService>();
            customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            _sut = new CustomerManager(mockCustomerService.Object);
        }

        #region Moq as Dummy
        [Test]
        public void BeAbleToBeConstructed()
        {
            _sut = new CustomerManager(null);
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void BeAbleToBeConstructed_WithMoq()
        {
            //Use Moq to create dummy object which implements ICustomerService
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            //Act - retrieve ICustomerService object associated with the Moq
            //Mock.Object has no functionality
            _sut = new CustomerManager(mockCustomerService.Object);

            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }
        #endregion

        #region Stubs
        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValidId()
        {
            //Creating a test double for implementing ICustomerService interface
            //Then configure it to reutrn desired values
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA"
            };

            //Setup service so it returns desired value
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("MANDA", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result);

        }
        #endregion

        [Test]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_WithInvalidId()
        {
            //Creating a test double for implementing ICustomerService interface
            //Then configure it to reutrn desired values
            var mockCustomerService = new Mock<ICustomerService>();

            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            //Setup service so it returns desired value
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns((Customer)null);

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;
            var result = _sut.Update("MANDA", "Nishant Mandal", "UK", "London", null);

            //Assert
            Assert.That(!result);
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.Null);
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }

        #region Delete Tests
        [Test]
        public void ReturnTrue_WhenDeleteIsCalledWithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = customer;
            Assert.That(_sut.Delete(customer.CustomerId));
        }

        [Test]
        public void SetSelectedCustomerToNull_WhenDeleteIsCalledWithValidId()
        {
            _sut.SelectedCustomer = null;
            Assert.That(_sut.SelectedCustomer, Is.Null);
        }

        [Test]
        public void ReturnFalse_WhenDeleteIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
    
            mockCustomerService.Setup(cs => cs.GetCustomerById("FAKEID")).Returns((Customer)null);
            Assert.That(!_sut.Delete("FAKEID"));
        }

        [Test]
        public void NotChangeTheSelectedCustomer_WhenDeleteIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer
            {
                CustomerId = "MANDA",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("FAKEID")).Returns((Customer)null);
            mockCustomerService.Setup(cs => cs.GetCustomerById(customer.CustomerId)).Returns(customer);
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SetSelectedCustomer(customer);
            _sut.Delete("FAKEID");
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }
        #endregion

        #region Homework 
        [Test]
        public void CallRetrieveAll_ReturnsListOfCustomers()
        {
            List<Customer> customers = new List<Customer>() { new Customer(), new Customer() };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(customers);

            var result = _sut.RetrieveAll();

            Assert.That(result, Is.EqualTo(customers));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void CallSetSelectedCustomer_ReturnsCustomer()
        {
            _sut.SetSelectedCustomer(customer);
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
        }

        [Test]
        public void CallCreate_CallsExpectedMethods()
        {
            mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.CreateCustomer(customer));
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            _sut.SetSelectedCustomer(customer);

            Assert.That(_sut.SelectedCustomer, Is.EqualTo("Nish Mandal"));
        }

        [Test]
        public void CallDelete_CallsExpectedMethods()
        {
            mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDA")).Returns(customer);
            mockCustomerService.Setup(cs => cs.RemoveCustomer(customer));
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.SetSelectedCustomer(customer);

            Assert.That(!_sut.Delete(customer.CustomerId));
            Assert.That(_sut.SelectedCustomer, Is.Null);
        }

        #endregion

    }
}

