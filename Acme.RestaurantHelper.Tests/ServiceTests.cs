using Acme.RestaurantHelper.Models;
using Acme.RestaurantHelper.Models.Enums;
using Acme.RestaurantHelper.Services;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Net.Http;

namespace Acme.RestaurantHelper.Tests
{
    public class ServiceTests
    {
        private WeatherClient _weatherClient;

        [SetUp]
        public void Initialize() 
        {
            var appSettingsMock = new Mock<IOptions<AppSettings>>();
            var httpClientMock = new Mock<IHttpClientFactory>();
            _weatherClient = new WeatherClient(appSettingsMock.Object, httpClientMock.Object);
        }

        [Test]
        public void TC01_GivenATempertureOver75_WhenCallingToDetermineContactMethod_ThenTheCorrectMethodIsReturned()
        {
            // Given
            var temp = 76;
            var conditions = "clear";

            // When
            var result = _weatherClient.GetContactMethod(temp, conditions);

            //Then
            Assert.AreEqual(ContactMethodEnum.TextMessage, result);
        }

        [Test]
        public void TC02_GivenATempertureBetween55And75_WhenCallingToDetermineContactMethod_ThenTheCorrectMethodIsReturned()
        {
            // Given
            var temp = 56;

            // When
            var result = _weatherClient.GetContactMethod(temp);

            //Then
            Assert.AreEqual(ContactMethodEnum.Email, result);
        }

        [Test]
        public void TC03_GivenATempertureLessThan55_WhenCallingToDetermineContactMethod_ThenTheCorrectMethodIsReturned()
        {
            // Given
            var temp = 54;

            // When
            var result = _weatherClient.GetContactMethod(temp);

            //Then
            Assert.AreEqual(ContactMethodEnum.PhoneCall, result);
        }

        [Test]
        public void TC04_GivenARainyDay_WhenCallingToDetermineContactMethod_ThenTheCorrectMethodIsReturned()
        {
            // Given
            var temp = 75;
            var conditions = "raining";

            // When
            var result = _weatherClient.GetContactMethod(temp, conditions);

            //Then
            Assert.AreEqual(ContactMethodEnum.PhoneCall, result);
        }
    }
}
