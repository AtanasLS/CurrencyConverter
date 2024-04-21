using api.controllers;
using api.transferModels;
using api.transferModels.HistoryDto;
using infrastructure.repositories;
using NUnit.Framework.Legacy;
using service;

namespace Test
{
    [TestFixture]
    public class CurrencyConverterApiTests
    {
        private HistoryController _historyController;
        [SetUp]
        public void Setup()
        {
            _historyController = new HistoryController(new HistoryService(new HistoryRepository(Helper.dataSource)));
        }

        [Test]
        public void GetAllHistories()
        {
            var result = _historyController.GetAllHistories();

            Assert.That(result.MessageToClient, Is.EqualTo("Successfully got all the histories!"));

        }
        [Test]
        public void CreateHistory()
        {
            //Arange
             var historyDto = new HistoryDto
            {
                SourceCurrency = "USD",
                TargetCurrency = "EUR",
                ValueCurrency = (int)100m
            };
            
            //act
            var result = _historyController.CreateHistory(historyDto);

            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsInstanceOf<ResponseDto>(result);
            ClassicAssert.AreEqual("Succesfully created new entry of history conversion", result.MessageToClient);
        }

        [TearDown]
        public void TearDown()
        {
            _historyController.Dispose();
        }
    }
}