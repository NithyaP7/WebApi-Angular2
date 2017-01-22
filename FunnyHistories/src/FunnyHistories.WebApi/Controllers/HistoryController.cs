using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FunnyHistories.Core.Models.Histories;
using AutoMapper;
using GoGiftApi.Core.Dtos;
using Microsoft.AspNetCore.Cors;
using FunnyHistories.WebApi.Repositories;
using FunnyHistories.WebApi.Helper;

namespace FunnyHistories.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly ILogger _logger;
        private IMapper _mapper { get; set; }
        private IHistoryRepository _historyItems { get; set; }

        public HistoryController(IHistoryRepository historyItems, ILogger<HistoryController> logger, IMapper mapper)
        {
            _historyItems = historyItems;
            _logger = logger;
            _mapper = mapper;
        }

        // POST api/test/
        [HttpGet]
        public HistoryOutputs GetAll()
        {
            _logger.LogInformation(LoggingEvents.LIST_ITEMS, "Getting test data ");
            var histories = _historyItems.GetAll();
            return new HistoryOutputs { histories = _mapper.Map<IList<HistoryDto>>(histories) };
        }

        //POST api/test/5
        [HttpGet("{id}", Name = "GetTest")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation(LoggingEvents.LIST_ITEMS, "Getting test", id);
            var history = _historyItems.Find(id);
            var historyDto = _mapper.Map<HistoryDto>(history);
            if (history == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(historyDto);
        }

        // POST api/test
        [HttpPost]
        public IActionResult Create([FromBody] History item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _historyItems.Add(item);
            return CreatedAtRoute("GetHistory", new { id = item.Id }, item);
        }

        // POST api/test/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] History item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _historyItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _historyItems.Update(item);
            return new NoContentResult();
        }

        // POST api/test/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _historyItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _historyItems.Remove(id);
            return new NoContentResult();
        }

    }
}
