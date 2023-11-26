using MangoSchoolApi.Repository;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MangoSchoolApi.Controllers
{
    [ApiController,Route("Contact")]
    public class ContactController : ControllerBase
    {
        public readonly IContactRepository _IContactRepository;
        public ContactController(IContactRepository IContactRepository)
        {
            _IContactRepository = IContactRepository;
        }

        [HttpGet,Authorize,Route("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            return Ok(_IContactRepository.GetContact(id));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(_IContactRepository.GetContacts());
        }

        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody]ContactViewModel ContactVM)
        {
            return Ok(_IContactRepository.PostContact(ContactVM));
        }

        [HttpPut,Authorize]
        public async Task<IActionResult> PutContact([FromBody] ContactViewModel ContactVM)
        {
            return Ok(_IContactRepository.PutContact(ContactVM));
        }

        public async Task<IActionResult> DeleteContact([FromBody] ContactViewModel ContactVM)
        {
            return Ok(_IContactRepository.DeleteContact(ContactVM));
        }
    }
}
