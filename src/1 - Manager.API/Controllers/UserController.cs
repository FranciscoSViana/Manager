using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Manager.API.ViewModels;
using Manager.API.Utilities;
using Manager.Core.Exceptions;
using Manager.Services.Interfaces;
using Manager.Services.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreate = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio criado com sucesso!",
                    Success = true,
                    Data = userCreate
                });
            } catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            } catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(updateUserViewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if (user == null) {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma usu�rio foi encontrado com o ID informado!",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rios encontrado coms sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma usu�rio foi encontrado com o e-mail informado!",
                        Success = true,
                        Data = user
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _userService.SearchByName(name);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma usu�rio foi encontrado com o nome informado!",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allUsers = await _userService.SearchByEmail(email);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma usu�rio foi encontrado com o nome informado!",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usu�rio encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}