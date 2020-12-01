using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using server.Interfaces;
using server.DTO;
using AutoMapper;

namespace server.Controllers
{
    [AllowAnonymous]
    public class UsersController : BaseAPIController
    {
        private readonly IUserRepository  _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<KorisnikDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<KorisnikDto>>(users));
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<KorisnikDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<KorisnikDto>(user);
        }
    }
}