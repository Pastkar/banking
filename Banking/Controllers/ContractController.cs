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
    public class ContractController : Controller
    {
        private readonly IServicesContractBL _contractService;
        private readonly IMapper _mapper;
        public ContractController(IMapper mapper, IServicesContractBL contractService)
        {
            _contractService = contractService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            List<ContractGetModel> list = null;
            list = _mapper.Map<List<ContractGetModel>>(await _contractService.ReadAllAsync());
            if (list == null)
                return NotFound();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetContactsByUserId_{id}")]
        public async Task<IActionResult> GetContactsByUserId(int id)
        {
            List<ContractGetModel> list = null;
            list = _mapper.Map<List<ContractGetModel>>(await _contractService.ContractsGetByUserId(id));
            if (list == null)
                return NotFound();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetContactsByStartUpId_{id}")]
        public async Task<IActionResult> GetContactsByStartUpId(int id)
        {
            List<ContractGetModel> list = null;
            list = _mapper.Map<List<ContractGetModel>>(await _contractService.ContractsGetByStartUpId(id));
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        [Route("PostContract")]
        public async Task<IActionResult> PostContractAsync([FromBody] ContractCreateModel model)
        {
            if (model == null)
                return BadRequest();
            var result = _mapper.Map<ContractCreateBL>(model);
            await _contractService.CreateAsync(result);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("GetContractById_{id}")]
        public async Task<IActionResult> GetContractByIdAsync(int id)
        {
            var result = _mapper.Map<ClientGetModel>(await _contractService.ReadByIdAsync(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteContractById_{id}")]
        public async Task<IActionResult> DeleteContractAsync(int id)
        {
            if (await _contractService.ReadByIdAsync(id) == null)
                return NotFound();
            await _contractService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet]
        [Route("AddPeymentById_{id}")]
        public async Task<IActionResult> UpdateContractAsync(int id)
        {
            if (await _contractService.ReadByIdAsync(id) == null)
                return NotFound();
            await _contractService.CreatePayments(id);
            return Ok(true);    
        }
    }
}
