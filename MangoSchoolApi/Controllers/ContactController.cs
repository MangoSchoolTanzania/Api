using MangoSchoolApi.Models.ViewModel;
using MangoSchoolApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MangoSchoolApi.Controllers
{
    [ApiController,Route("v1/Contact/")]
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
            return Ok(await _IContactRepository.GetContact(id));
        }

        [HttpGet, Authorize,Route("GetAll")]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _IContactRepository.GetContacts());
        }

        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody]ContactViewModel ContactVM)
        {
            return Ok(await _IContactRepository.PostContact(ContactVM));
        }

        [HttpPut,Authorize]
        public async Task<IActionResult> PutContact([FromBody] ContactViewModel ContactVM)
        {
            return Ok(await _IContactRepository.PutContact(ContactVM));
        }

        [HttpDelete,Authorize,Route("Delete/{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute]int id)
        {
            return Ok(await _IContactRepository.DeleteContact(id));
        }
    }
}
