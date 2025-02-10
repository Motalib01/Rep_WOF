using Application.Entites;
using Application.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Rep_WOF.Dtos;
using Rep_WOF.Extentions;

namespace Rep_WOF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(await _unitOfWork.Users.GetAllAsync());
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            // Map UserDto to User entity
            var user = _mapper.Map<User>(userDto);

            // Add the user entity to the database
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Ok(userDto);
        }
    }
}
