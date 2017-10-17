using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using GlobalWeather.Infrastructure.Extensions;

namespace GlobalWeather.Domain.Services.Tests
{
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod()]
        public void XML_Parser_Should_Process_Data_Correctly()
        {
            //ARRANGE
            var test = "<ArrayOfMyObject><MyObject><name>Test1</name></MyObject><MyObject><name>Test2</name></MyObject></ArrayOfMyObject>";


            //ASSERT
            var result = test.ParseXML<List<MyObject>>();

            //ACT
            Assert.IsNotNull(result, "XML Parser should return correct data.");
        }


        [Serializable]
        [XmlRoot("MyObject")]
        public class MyObject
        {
            public string name;
            public string extraValue;
        }
    }
}