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
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<PinTypes, PinTypesDto>(); });
            var repositoryMockup = new PinTypeRepositoryMockup();
            var pinTypeMapper = configuration.CreateMapper();
            var pinTypeService = new PinTypesService(repositoryMockup, pinTypeMapper);
            var result = await pinTypeService.GetAllAsync();
            Assert.IsNotNull(result);
            /*task.RunSynchronously();
            var result = task.Result;*/
            Assert.IsInstanceOfType(result, typeof(List<PinTypesDto>));
            var firstElement = result.FirstOrDefault();
            Assert.IsNotNull(firstElement);
            Assert.AreEqual(1, firstElement.Id);
        }
    }
    public class PinTypeRepositoryMockup : IPinTypesRepository
    {
        public Task<List<PinTypes>> GetAllAsync()
        {
            var dummyData = new List<PinTypes>();
            var dummyPinType = new PinTypes();
            dummyPinType.Id = 001;
            dummyPinType.Name = "DummyName";
            dummyData.Add(dummyPinType);
            return Task.Run(() => { return dummyData; });
        }
    }
}