using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairItBack.DTOs;
using RepairItBack.Entities;
using RepairItBack.Interfaces;

namespace RepairItBack.Controllers
{
   
    public class AuthController :BaseController
    
    {   
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _usermanager;   
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthController(UserManager<AppUser> usermanager, ITokenService tokenService, IMapper mapper, SignInManager<AppUser> signInManager )
        {
            _usermanager = usermanager;
            _tokenService = tokenService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public  async Task<ActionResult<UserDto>> login(LoginDto loginDto){
            var user = await _usermanager.Users.SingleOrDefaultAsync(x=>x.Email == loginDto.Email);
            if(user==null){
                return Unauthorized(new ApiException(401,"email is invalid","email not found"));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user,loginDto.Password,false);
            var roles = await _usermanager.GetRolesAsync(user);
            
            if(!result.Succeeded)return Unauthorized(new ApiException(401,"password is incorect"," password invalid"));
            
             return new UserDto(
                user.Id,
                user.FirstName+" "+user.LastName,
                roles,
                await _tokenService.CreateToken(user)
            
             );
        
        }

        [HttpPost("signup")]
        public async Task<ActionResult> signup(RegisterDto registerDto){
           if(await UserExists(registerDto.Email)) return BadRequest("Email Already taken");


            var user = _mapper.Map<AppUser>(registerDto);
            user.UserName = registerDto.FirstName;
            var result =await _usermanager.CreateAsync(user,registerDto.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _usermanager.AddToRoleAsync(user,"Guest");
            if(!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            return Ok();
            
       }
        private async Task<bool> UserExists(string Email)
        {
            return await _usermanager.Users.AnyAsync(x => x.Email == Email);
        }
    }
}