using API.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepairItBack.Data;
using RepairItBack.DTOs;
using RepairItBack.DTOs.Response;
using RepairItBack.Entities;
using RepairItBack.Extentions;
using RepairItBack.Helpers;
using RepairItBack.Interfaces;

namespace RepairItBack.Controllers
{   
  
    [Authorize]
    public class CommandeController : BaseController
    {   
        private readonly IUnitOfWork _uniteOfwork ;
         private readonly UserManager<AppUser> _usermanager;  
        private readonly IReparateurService _reparateurService;
        private readonly IMapper _mapper;
        public CommandeController(IUnitOfWork uniteOfwork, IReparateurService reparateurService, UserManager<AppUser> usermanager, IMapper mapper)
        {
            _uniteOfwork = uniteOfwork;
            _reparateurService = reparateurService;
            _usermanager = usermanager;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<IEnumerable<Commande>>> findAll([FromQuery] PaginationParams paginationParams){

            var commandes = await  _uniteOfwork.commandeRepository.findAll(paginationParams);
            Response.AddPaginationHeader(commandes.CurrentPage, commandes.PageSize,
                commandes.TotalCount, commandes.TotalPages);

                
            return Ok( commandes);
        }

        [HttpGet]
         [Authorize(Policy = "RequiredReparateurRole")]
        public async Task<ActionResult<IEnumerable<Commande>>> findAllOuwn(){
            int idUser = User.GetUserId();

            return Ok( await  _uniteOfwork.commandeRepository.findOuwn(idUser));
        }

        [HttpPost]
        [Authorize(Policy = "RequiredGuestRole")]
        public async Task<ActionResult<Commande>> createNewCommande([FromBody] CommandeDto commandeDto ){
            var user = await _uniteOfwork.UserRepository.getByid(User.GetUserId());
            var reparateur = await _reparateurService.findReparateurById(commandeDto.ReparateurId);

            if(reparateur ==null) return NotFound(new ApiException(404,"reparateur not found ")); 
          
            var commande = _mapper.Map<Commande>(commandeDto);
            commande.ClientId = user.Id;
            commande.Client = user;
            commande.ReparateurId = reparateur.Id;
            commande.Reparateur = reparateur;
            await _uniteOfwork.commandeRepository.AddCommande(commande);
            if( !await _uniteOfwork.Complete()) return BadRequest();
          
             return Ok(_mapper.Map<CommandeResponse>(commande));

        }



    }
}