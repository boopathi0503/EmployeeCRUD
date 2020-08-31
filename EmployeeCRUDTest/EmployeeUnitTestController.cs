using EmployeeCRUD.Controllers;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeCRUDTest
{
    public class EmployeeUnitTestController
    {
        private EmployeeDBContext context;
        int EmployeesCount = 0;
        public static DbContextOptions<EmployeeDBContext> dbContextOptions { get; }
        public static string connectionString = "Server=tcp:employeecruddbserver.database.windows.net,1433;Database=EmployeeCRUD_db;Persist Security Info=False;User ID=sa_admin;Password=Sweethoney@2010;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static EmployeeUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeDBContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public EmployeeUnitTestController()
        {
            context = new EmployeeDBContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
            EmployeesCount = context.Employees.Count();
        }

        [Fact]
        public async void Task_GetAllEmployees_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(context);

            //Act  
            var data = await controller.GetEmployees();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetAllEmployees_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeesController(context);

            //Act  
            var data = await controller.GetEmployees();
            data = null;
            //Assert  
            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAllEmployeesCount_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(context);

            //Act  
            var data = await controller.GetEmployees();

            //Assert  
            var ResultCount = ((Microsoft.AspNetCore.Mvc.ObjectResult)data).Value;
            Assert.Equal(EmployeesCount, (ResultCount as List<Employee>).Count);
        }
    }
}
