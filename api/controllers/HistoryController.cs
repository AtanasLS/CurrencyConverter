using api.transferModels;
using api.transferModels.HistoryDto;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.controllers
{
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly HistoryService _historyService;

        public HistoryController(HistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        [Route ("/currency")]
        public ResponseDto GetAllHistories()
        {
            return new ResponseDto()
            {
                MessageToClient = "Successfully got all the histories!",
                ResponseData = _historyService.GetAllHistories()
            };
        }

        [HttpPost]
        [Route("/createCurrency")]
        public ResponseDto CreateHistory([FromBody] HistoryDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient  = "Succesfully created new entry of history conversion",
                ResponseData = _historyService.CreateHistory(dto.SourceCurrency, dto.TargetCurrency,
                                                             dto.ValueCurrency)
            };
        }
    }

}