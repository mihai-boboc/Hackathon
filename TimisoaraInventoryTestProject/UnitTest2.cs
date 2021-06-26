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
    public class UnitTest2
    {
        [TestMethod]
        public async Task TestMethod2()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<PinTypes, PinTypesDto>(); });
            var pinTypeMapper = configuration.CreateMapper();
            var repositoryMockUp = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockUp, pinTypeMapper);
            var pinTypeController = new PinTypesController(pinTypeService);

            var result = await pinTypeController.ReturnAll();
            Assert.IsNotNull(result);
        }
    }
}
