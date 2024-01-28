using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository userRepository;

        [SetUp] 
        public void SetUp() 
        {
            this.userRepository = new UserRepository();
        }

        [Test]
        [TestCase("username1", "password1", true)]
        [TestCase("admin", "admin", true)]
        [TestCase("username", "password", false)]
        public async Task Authenticate_Valid_UserDetails_Returns_Valid_Response(string username, string password, bool expectedResponse) 
        {
            // arrange
            // act
            var result = await this.userRepository.Authenticate(username, password);

            // assert
            Assert.That(result, Is.EqualTo(expectedResponse));

        }
    }
}
