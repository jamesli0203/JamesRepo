using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Music.Service;
using Music.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UnitTestMusicService
{
    [TestClass]
    public class Init
    {
        public static HttpClient TestHttpClient;
        public static Mock<ArtistRepository> MockArtistRepository;

        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        {
            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>()
              
               .UseEnvironment("IntegrationTest"));

            TestHttpClient = testServer.CreateClient();
        }

        public static void RegisterMockRepositories(IServiceCollection services)
        {
            MockArtistRepository = (new Mock<ArtistRepository>());
            services.AddSingleton(MockArtistRepository.Object);
        }
    }
}
