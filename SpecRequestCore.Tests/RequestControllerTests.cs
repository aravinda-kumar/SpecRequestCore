using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SpecRequestCore.Controllers;
using SpecRequestCore.Repositories;
using SpecRequestCore.Models;
using Xunit;


namespace SpecRequestCore.Tests
{
    public class RequestControllerTests
    {
        [Fact]
        public void CanLoadDataFromRepository()
        {
            Mock<IRequestRepository> mock = new Mock<IRequestRepository>();
            mock.Setup(m => m.Requests)
                .Returns((new Request[]
                {
                    new Request()
                    {
                        Id = 1,
                        Name = "Section 744",
                        Description = "Fix adlfgkhqwoetihqehnioin12i3o5u qeoruh12 35jksbdfoih o1235ohasdjlnag",
                        RequestCreated = DateTime.Now
                    }
                }).AsQueryable<Request>());

            var controller = new RequestController(mock.Object);

            var result = controller.Index().ViewData.Model as IEnumerable<Request>;

            Assert.Single(result);
            Assert.Equal(1, result.First().Id);
            Assert.Equal("Section 744", result.First().Name);
        }
    }
}
