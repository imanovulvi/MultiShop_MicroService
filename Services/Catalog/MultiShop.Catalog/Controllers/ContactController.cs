using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Contact;
using MultiShop.Catalog.Services.Contact;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IContactService Contact;

        public ContactController(IMapper mapper, IContactService Contact)
        {
            this.mapper = mapper;
            this.Contact = Contact;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await Contact.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await Contact.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDTO create)
        {
            await Contact.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDTO update)
        {
            await Contact.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await Contact.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
