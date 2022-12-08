using CourierManagement.Database;
using CourierManagement.Entities;
using CourierManagement.Entities.Models;
using CourierManagement.Repository.Repositories;
using CourierManagement.Services.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace CourierManagement.Test
{
    public class CourierUnitTestController
    {
        private CourierRepository _courierRepository;
        private CourierService _courierService;
        public static DbContextOptions<CourierManagmentContext> dbContextOptions { get; set; }
        public static string connectionString = "Server=(local);Database=CourierManagement;Integrated Security=True;MultipleActiveResultSets=True;";
        static CourierUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<CourierManagmentContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public CourierUnitTestController()
        {
            var context = new CourierManagmentContext(dbContextOptions);
            _courierRepository = new CourierRepository(context);
            _courierService = new CourierService(_courierRepository, null);
        }

        [Fact]
        public async void Task_GetCourierById_OkResult()
        {
            //Arrange
            var projectId = 10;

            //Act
            var data = await _courierService.GetCourierById(projectId);

            //Assert
            Assert.IsType<ResponseModel<CourierModel>>(data);
        }

        [Fact]
        public async void Task_GetCourierById_BadResult()
        {
            //Arrange
            var projectId = 15;

            //Act
            var data = await _courierService.GetCourierById(projectId);

            //Assert
            Assert.IsType<ResponseModel<CourierModel>>(data);
        }


        [Fact]
        public async void Task_GetCouriersList()
        {
            //Act
            var data = await _courierService.GetCourierList();

            //Assert
            Assert.IsType<ResponseModel<List<CourierModel>>>(data);
        }
    }
}
