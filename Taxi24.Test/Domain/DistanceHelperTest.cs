using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Interfaces;

namespace Taxi24.Test.Domain
{
    public class DistanceHelperTest : BaseTest
    {

        private IDistanceHelper distanceHelper;

        [SetUp]
        public void Setup()
        {
            base.SetUp();

            distanceHelper = (IDistanceHelper)_services.GetService(typeof(IDistanceHelper));
        }

        [Test]
        [TestCase(18.4923177, -69.8391991, 18.4867788, -69.8386928, 3)]
        [TestCase(18.4923177, -69.8391991, 18.4827567, -69.9414236, 11)]
        public void IsNear(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo, int km)
        {
            bool isNear = distanceHelper.IsNear(latitudeFrom, longitudeFrom, latitudeTo, longitudeTo, km);
            Assert.IsTrue(isNear);
        }

        [Test]
        [TestCase(18.4923177, -69.8391991, 18.5084341, -69.7922265, 3)]
        [TestCase(18.4923177, -69.8391991, 18.4827567, -69.9414236, 4)]
        public void IsNotNear(double latitudeFrom, double longitudeFrom, double latitudeTo, double longitudeTo, int km)
        {
            bool isNotNear = distanceHelper.IsNear(latitudeFrom, longitudeFrom, latitudeTo, longitudeTo, km);
            Assert.IsFalse(isNotNear);
        }
    }
}
