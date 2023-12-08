using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampleApiBlog.CRUD;
using sampleApiBlog.Models;
using System.Security.AccessControl;

namespace sampleApiBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USERSController : ControllerBase
    {
        readonly private IRepository<Users> _users;

        public USERSController(IRepository<Users> users)
        {
            _users = users;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(new { data = _users.GetAll(), status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }

        [HttpPost]
        [Route("GetByPk")]
        public ActionResult GetByPk([FromQuery]long id)
        {
            try
            {
                var result = _users.GetByPk(id);
                return Ok(new { data = result, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(Users rUser)
        {
            try
            {
                var result = _users.Add(rUser);
                return Ok(new { data = result, status = true, message = "Kayıt Eklendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public ActionResult UpdateUser(Users rUser)
        {
            try
            {
                var result = _users.Update(rUser);
                return Ok(new { data = result, status = true, message="Kayıt Güncellendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }


        [HttpPost]
        [Route("RemoveUser")]
        public ActionResult RemoveUser(long id)
        {
            try
            {
                var result = _users.Remove(id);
                return Ok(new { data = result, status = true, message = "Kayıt Silindi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }
    }
}
