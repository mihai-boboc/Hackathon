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
    public class UnitTest3
    {
        [TestMethod]
        public async Task TestMethod3()
        {
            var configuration = new MapperConfiguration(options => { options.CreateMap<Status, StatusDto>(); });
            var repositoryMockup = new StatusRepositoryMockup();
            var statusMapper = configuration.CreateMapper();
            var statusService = new StatusService(repositoryMockup, statusMapper);
            var result = await statusService.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<StatusDto>));
            var firstElement = result.FirstOrDefault();
            Assert.IsNotNull(firstElement);
            Assert.AreEqual(2, firstElement.Id);
        }
    }
    public class StatusRepositoryMockup : IStatusRepository
    {
        public Task<List<Status>> GetAllAsync()
        {
            var dummyData = new List<Status>();
            var dummyStatusType = new Status();
            dummyStatusType.Id = 2;
            dummyStatusType.Name = "DummyName";
            dummyData.Add(dummyStatusType);
            return Task.Run(() => { return dummyData; });
        }
    }

}
