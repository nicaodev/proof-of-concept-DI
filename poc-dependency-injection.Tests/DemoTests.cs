using Microsoft.AspNetCore.Mvc;
using Moq;
using poc_dependency_injection.API.Controllers;
using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Application.Services;
using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Tests
{
    public class DemoControlelerTests
    {
        private readonly Mock<IScopedService> _mockScopedService1;
        private readonly Mock<IScopedService> _mockScopedService2;
        private readonly demoController _controller;

        public DemoControlelerTests()
        {
            
        }
        [Fact]
        public async Task GetResult_ShouldReturnSameGuidAndDateTime_ForScopedInstance()
        {
            // Arrange: Cria uma inst�ncia do servi�o Scoped
            var scopedService = new ScopedService();

            // Act: Chama o m�todo GetResult duas vezes na mesma inst�ncia
            var result1 = await scopedService.GetResult();
            var result2 = await scopedService.GetResult();

            // Assert: Verifica se o Guid e DateTime s�o os mesmos para ambas as chamadas
            Assert.Equal(result1.Id, result2.Id);
            Assert.Equal(result1.DateTime, result2.DateTime);
        }

        [Fact]
        public async Task GetResult_ShouldReturnSameGuidAndDateTime_ForSingletonInstance()
        {
            // Arrange: Cria uma inst�ncia do servi�o Singleton
            var singletonService = new SingletonService();

            // Act: Chama o m�todo GetResult duas vezes na mesma inst�ncia
            var result1 = await singletonService.GetResult();
            var result2 = await singletonService.GetResult();

            // Assert: Verifica se o Guid e DateTime s�o os mesmos para ambas as chamadas
            Assert.Equal(result1.Id, result2.Id);
            Assert.Equal(result1.DateTime, result2.DateTime);
        }

        [Fact]
        public async Task GetResult_ShouldReturnDifferentGuidAndDateTime_ForTransientInstances()
        {
            // Arrange: Cria duas inst�ncias separadas do servi�o Transient
            var transientService1 = new TransientService();
            var transientService2 = new TransientService();

            // Act: Chama o m�todo GetResult em cada inst�ncia
            var result1 = await transientService1.GetResult();
            var result2 = await transientService2.GetResult();

            // Assert: Verifica se os GUIDs e DateTime s�o diferentes para inst�ncias diferentes
            Assert.NotEqual(result1.Id, result2.Id);
            Assert.NotEqual(result1.DateTime, result2.DateTime);
        }
    }
}