using Moq;
using PortsCalculator.API.Controllers;
using PortsCalculator.App.UseCases;
using PortsCalculator.App.Models.Responses;
using PortsCalculator.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace PortsCalculator.Tests.Integration.Controllers
{
    [TestClass]
    public class DeviceControllerTests
    {
        // Injection
        //private algo _mockado

        [TestInitialize]
        public void Initialize()
        {
            //_Algo = mock
        }

        [TestMethod]
        public async Task GetDeviceById_DeviceNotFound_ReturnsNotFound()
        {
            // Arrange
            //fake object

            // Act
            //var result = await .GetDeviceById(deviceId);

            // Assert
            //NotFound
        }

        [TestMethod]
        public async Task GetDeviceById_DeviceFound_ReturnsOkWithDevice()
        {
            // Arrange
            //fake object

            // Act
            //var result = await .GetDeviceById(deviceId);

            // Assert
            //Ok
        }
    }
}