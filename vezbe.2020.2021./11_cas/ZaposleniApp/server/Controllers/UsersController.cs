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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace server.Controllers
{
    [AllowAnonymous]
    public class UsersController : BaseAPIController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISlikeService _slikeService;

        public UsersController(IUserRepository userRepository, IMapper mapper,
                            ISlikeService slikeService)
        {
            _slikeService = slikeService;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<KorisnikDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<KorisnikDto>>(users));
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<KorisnikDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<KorisnikDto>(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(KorisnikEditDto korisnikEditDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(korisnikEditDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsyc()) return NoContent();

            return BadRequest("Neuspešno unošenje izmena");
        }

        [HttpPost("dodaj-sliku")]
        public async Task<ActionResult<PhotoDto>> DodajSliku(IFormFile file)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var rezultat = await _slikeService.DodajSlikuAsync(file);

            if (rezultat.Error != null) return BadRequest(rezultat.Error.Message);

            var slika = new Photo
            {
                Url = rezultat.SecureUrl.AbsoluteUri,
                PublicId = rezultat.PublicId
            };

            if (user.Slike.Count == 0)
            {
                slika.GlavnaSlika = true;
            }

            user.Slike.Add(slika);

            if (await _userRepository.SaveAllAsyc())
                return CreatedAtRoute("GetUser", new { username = user.UserName } ,_mapper.Map<PhotoDto>(slika));

            return BadRequest("Problem u dodavanju slike.");
        }

        [HttpPut("postavi-glavnu-sliku/{photoId}")]
        public async Task<ActionResult> PostaviGlavnuSLiku(int photoId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var slika = user.Slike.FirstOrDefault(x => x.Id == photoId);

            if (slika.GlavnaSlika) return BadRequest("Ova slika je vec glavna.");

            var trenutnoGlavna = user.Slike.FirstOrDefault(x => x.GlavnaSlika);
            if (trenutnoGlavna != null) trenutnoGlavna.GlavnaSlika = false;
            slika.GlavnaSlika = true;

            if (await _userRepository.SaveAllAsyc()) return NoContent();

            return BadRequest("Promena glavne slike nije bila uspešna.");
        }

        [HttpDelete("obrisi-sliku/{photoId}")]
        public async Task<ActionResult> ObrisiSliku(int photoId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var slika = user.Slike.FirstOrDefault(x => x.Id == photoId);

            if (slika == null) return NotFound();

            if (slika.GlavnaSlika) return BadRequest("Ova slika je glavna");

            if (slika.PublicId != null) 
            {
                var rezultat = await _slikeService.ObrisiSlikuAsync(slika.PublicId);
                if (rezultat.Error != null) return BadRequest(rezultat.Error.Message);
            }

            user.Slike.Remove(slika);

            if (await _userRepository.SaveAllAsyc()) return Ok();

            return BadRequest("Neuspesno brisanje slike");
        }
    }
}