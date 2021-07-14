using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using Hackathon.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimisoaraInventoryTestProject
{
    [TestClass]
    public class PinTypeServiceTests
    {
        static MapperConfiguration configuration;
        static IMapper pinTypeMapper;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
             configuration = new MapperConfiguration(options => { options.CreateMap<PinTypes, PinTypesDto>(); });
             pinTypeMapper = configuration.CreateMapper();
        } 

        [TestMethod]
        public async Task TestGetEmptyPinTypeList()
        {
            var repositoryMockup = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockup, pinTypeMapper);

            var result = await pinTypeService.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<PinTypesDto>));
            var firstElement = result.FirstOrDefault();
            Assert.IsNull(firstElement);
        }

        [TestMethod]
        public async Task TestGetSinglePinType()
        {
            var repositoryMockup = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockup, pinTypeMapper);

            repositoryMockup.AddPin();
            var result = await pinTypeService.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<PinTypesDto>));
            var firstElement = result.FirstOrDefault();
            Assert.AreEqual(0, firstElement.Id);
        }

        [TestMethod]
        public async Task TestGetMultiplePinTypes()
        {
            var repositoryMockup = new PinTypeRepositoryMockup();
            var pinTypeService = new PinTypesService(repositoryMockup, pinTypeMapper);

            repositoryMockup.AddPin();
            repositoryMockup.AddPin();
            var result = await pinTypeService.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<PinTypesDto>));
            Assert.AreEqual(2, result.Count);
        }
    }
    public class PinTypeRepositoryMockup : IPinTypesRepository
    {
        List<PinTypes> dummyData = new List<PinTypes>();
        
        public Task<List<PinTypes>> GetAllAsync()
        {
            return Task.Run(() => { return dummyData; });
        }
        public void AddPin()
        {
            var dummyPinType = new PinTypes();
            dummyPinType.Id = dummyData.Count;
            dummyPinType.Name = "DummyName";
            dummyData.Add(dummyPinType);
        }
    }
}