using Application.Entites;
using Application.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Rep_WOF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok(user);
        }
    }
}
