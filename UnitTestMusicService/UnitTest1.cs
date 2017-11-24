using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTestMusicService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAytistRepository()
        {
            var mockA = new List<Artist>();
            mockA.Add(new Artist
            {
                Id = 1,
                Created = DateTime.Today,
                LastModified = DateTime.Today,
                Name = "Muse"
            });
            mockA.Add(new Artist
            {
                Id = 1,
                Created = DateTime.Today,
                LastModified = DateTime.Today,
                Name = "Muse"
            });

            var employeeRepositoryMock = Init.MockArtistRepository;
            //employeeRepositoryMock.Setup
            //      (x => x.GetAll()).Returns(Task.FromResult(mockA.));

            var response = Init.TestHttpClient.GetAsync("api/Employees").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<Artist>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockA[0].Id, responseData[0].Id);

        }

        [TestMethod]
        public void TestAlbumRepository()
        {
        }
        [TestMethod]
        public void TestSongRepository()
        {
        }
    }
}
