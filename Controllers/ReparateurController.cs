
using API.Errors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairItBack.Data;
using RepairItBack.DTOs;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Extentions;
using RepairItBack.Helpers;
using RepairItBack.Interfaces;

namespace RepairItBack.Controllers
{   
    public class ReparateurController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
         private readonly IMapper _mapper;
        public IReparateurService _reparateurService { get; }

        public ReparateurController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper ,IReparateurService reparateurService)
        {
            _reparateurService = reparateurService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public  async Task<IEnumerable<ReparateurResponse>> getAllReparateur([FromQuery] PaginationParams paginationParams){

            
            var users= await _reparateurService.findAllReparateur(paginationParams);
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);
            return users;
        }
        [HttpGet("best4")]
        public  async Task<IEnumerable<ReparateurResponse>> getBest4()
        {
            var roleUsers = await _userManager.Users.Where(u => u.UserRoles.Any(r => r.Role.Name == "Reparateur"))
                            .OrderByDescending(x=>x.Rating)
                            .ProjectTo<ReparateurResponse>(_mapper.ConfigurationProvider)
                            .Take(4)
                            .ToListAsync();
            return roleUsers;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UpgrateToReparateur(){
            var user =await _unitOfWork.UserRepository.getByid(User.GetUserId());
            
            if(user ==null) return BadRequest();
            
            var result = await _userManager.AddToRoleAsync(user,"Reparateur");
            
            if(!result.Succeeded) return BadRequest(new ApiException(400,"User already have this role", "Conflixt exception"));
            
            await _unitOfWork.Complete();
            
            return NoContent();
         

            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReparateurWithDetailsResponse>> findByid(int id){
          
            var user= await _reparateurService.findReparateurById(id);
            if(user ==null) return NotFound(new ApiException(404,"Reparateur Not found ",null));
          
            return _mapper.Map<ReparateurWithDetailsResponse>(user);
        }
    }
}