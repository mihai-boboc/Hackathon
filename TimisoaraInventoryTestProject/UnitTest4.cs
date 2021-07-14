using AutoMapper;
using Hackathon.Controllers;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using Hackathon.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TimisoaraInventoryTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public async Task TestMethod4()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<Status, StatusDto>(); });
            var statusMapper = configuration.CreateMapper();
            var repositoryMockUp = new StatusRepositoryMockup();
            var statusService = new StatusService(repositoryMockUp, statusMapper);
            var statusController = new StatusController(statusService);

            var result = await statusController.ReturnAll();
            Assert.IsNotNull(result);
        }
    }
}
