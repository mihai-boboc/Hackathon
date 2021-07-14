using AutoMapper;
using Hackathon.Controllers;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimisoaraInventoryTestProject
{
    [TestClass]
    public class PinTypeControllerTest
    {
        [TestMethod]
        public async Task TestGetAllMethod()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<PinTypes, PinTypesDto>(); });
            var pinTypeMapper = configuration.CreateMapper();
            var repositoryMockUp = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockUp, pinTypeMapper);
            var pinTypeController = new PinTypesController(pinTypeService);
            
            OkObjectResult result = (OkObjectResult)await pinTypeController.ReturnAll();
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Value, typeof(List<PinTypesDto>));
            var responseContent = (List<PinTypesDto>)result.Value;
            var firstElement = responseContent.FirstOrDefault();
            Assert.IsNull(firstElement);

            repositoryMockUp.AddPin();
            result = (OkObjectResult)await pinTypeController.ReturnAll();
            Assert.IsNotNull(result);
            responseContent = (List<PinTypesDto>)result.Value;
            Assert.IsInstanceOfType(responseContent, typeof(List<PinTypesDto>));
            firstElement = responseContent.FirstOrDefault();
            Assert.AreEqual(0, firstElement.Id);

            repositoryMockUp.AddPin();
            result = (OkObjectResult)await pinTypeController.ReturnAll();
            Assert.IsNotNull(result);
            responseContent = (List<PinTypesDto>)result.Value;
            Assert.IsInstanceOfType(responseContent, typeof(List<PinTypesDto>));
            Assert.AreEqual(2, responseContent.Count);
        }
    }
}
