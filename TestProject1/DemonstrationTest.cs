using FakeItEasy;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WebAppV3;
using WebAppV3.Controllers;
using WebAppV3.Models;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Giving_Correct_Addition()
        {
            // ARRANGE
            int answer = 3;
            var controller = new DemonstrationController();
            // ASSERT
            var result = controller.GetSum(2, 1) as OkObjectResult;
            var returnSum = result.Value;
            Assert.AreEqual(answer, returnSum);
        }
    }
}