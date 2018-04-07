using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpecRequestCore.Controllers;
using SpecRequestCore.Models;
using SpecRequestCore.Repositories;
using Xunit;

namespace SpecRequestCore.Tests
{
    public class RequestStatusAdminControllerTests
    {
        [Fact]
        public void CanLoadDataFromRepository()
        {
            Mock<IRequestStatusRepository> mock = new Mock<IRequestStatusRepository>();
            mock.Setup(m => m.RequestStatuses)
                .Returns((new RequestStatus[]
                {
                    new RequestStatus()
                    {
                        Id = 1,
                        Status = "Received",
                    },
                    new RequestStatus()
                    {
                        Id = 2,
                        Status = "Assigned",
                    },
                    new RequestStatus()
                    {
                        Id = 3,
                        Status = "Assigned",
                    }
                }).AsQueryable<RequestStatus>());

            var controller = new RequestStatusAdminController(mock.Object);

            var model = controller.Index().ViewData.Model as IEnumerable<RequestStatus>;

            Assert.Equal(3, model.Count());

        }
    }
}
