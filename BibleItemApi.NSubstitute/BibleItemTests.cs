using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using NSubstitute;
using WebAppV3.Controllers;
using WebAppV3.Models;

namespace BibleItemApi.NSubstitute
{
    public class BibleItemTests
    {
        
        [Fact]
        public async Task GetCorrectBible()
        {
            // Arrange
            int counr = 5;
            var fakeBible = A.CollectionOfDummy<BibleItem>(counr).AsEnumerable();
            var dataStore = A.Fake<BibleContext>();
            var cancelToken = A.Fake<CancellationTokenSource>();
            var cancellationToken = cancelToken.Token;
            A.CallTo(() => dataStore.BibleItems.ToListAsync(cancellationToken)).Returns(fakeBible as List<BibleItem>);
            var controller = new BibleItemController(dataStore);
            // Act
            var actionResult = await controller.GetBibleItems();
            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnBibles = result.Value as IEnumerable<BibleItem>;
            Assert.Equal(counr,returnBibles.Count());
        }
        
    }
}