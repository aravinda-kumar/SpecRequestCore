using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                        RequestCreated = DateTime.Now,
                        UserId = "123-abc" // fake guid
                    }
                }).AsQueryable<Request>());

            var controller = new RequestController(mock.Object, null);

            var result = controller.Index().Result as ViewResult;
            
            var model = result.ViewData.Model as IEnumerable<Request>;

            Assert.Single(model);
            Assert.Equal(1, model.First().Id);
            Assert.Equal("Section 744", model.First().Name);
        }
    }
}
