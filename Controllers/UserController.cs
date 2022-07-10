using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairItBack.Data;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Extentions;

namespace RepairItBack.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; }
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("current-user")]
        public async Task<ActionResult<AppUser>> findCurentUser()
        {
            var userId = User.GetUserId();
            var user = await _unitOfWork.UserRepository.getByid(userId);

            if (user == null) return NotFound();
            
            return Ok(_mapper.Map<ReparateurWithDetailsResponse>(user));
        }
    }
}