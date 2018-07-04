
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PIIApi.Models;

namespace PIIApi.Controllers
{
    [Route("api/[controller]")]
    public class PiiApiController : Controller
    {
        private readonly TextEntriesContext _dbContext;

        public PiiApiController(TextEntriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        // [Route] api/pii
        [HttpGet]
        public List<TextItem> GetAll()
        {
            return _dbContext.TextItems.ToList();
        }

        // [Route] api/pii/{id}
        [HttpGet("{id}", Name = "GetTextItem")]
        public IActionResult GetById(int id)
        {
            var item = _dbContext.TextItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // [Route] api/pii
        [HttpPost]
        public ActionResult Create([FromBody] string text)
        {
            if (text == null)
            {
                return BadRequest();
            }

            var ssnDetector = new SsnDetector();
            var textItem = new TextItem();

            textItem.hasPii = ssnDetector.FindSocialSecurityNumber(text);
            textItem.TextBody = text;

            _dbContext.TextItems.Add(textItem);
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetTextItem", new { id = textItem.ID }, textItem);

        }
    }
}
