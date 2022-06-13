using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using CommonModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IServicesClientBL _clientService;
        private readonly IMapper _mapper;
        public ClientController(IMapper mapper, IServicesClientBL clientService)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetClients")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<ClientGetModel> list = null;
                list = _mapper.Map<List<ClientGetModel>>(await _clientService.ReadAllAsync());
                if (list == null)
                    return NotFound();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        [HttpPost]
        [Route("PostClient")]
        public async Task<IActionResult> PostClientAsync([FromBody] ClientCreateModel model)
        {
            if (model == null)
                return BadRequest();
            var result = _mapper.Map<ClientCreateBL>(model);
            await _clientService.CreateAsync(result);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("GetClientById_{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = _mapper.Map<ClientGetModel>(await _clientService.ReadByIdAsync(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetClientByName_{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = _mapper.Map<ClientGetModel>(await _clientService.ReadByNameAsync(name));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteClientById_{id}")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            if (await _clientService.ReadByIdAsync(id) == null)
                return NotFound();
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        [Route("PutClientById_{id}")]
        public async Task<IActionResult> UpdateClientAsync(int id, [FromBody] ClientCreateModel model)
        {
            if (await _clientService.ReadByIdAsync(id) == null)
                return NotFound();
            await _clientService.UpdateAsync(_mapper.Map<ClientCreateBL>(model), id);
            return Ok();
        }
    }
}
