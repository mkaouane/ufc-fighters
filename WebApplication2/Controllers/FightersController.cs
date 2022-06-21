using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication2.Services;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightersController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public FightersController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Fighters>> Get() {
            return await _mongoDBService.GetAsync();

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fighters fighters) {
            await _mongoDBService.CreateAsync(fighters);
            return CreatedAtAction(nameof(Get), new { id = fighters.Id }, fighters);
        }


    }
}
