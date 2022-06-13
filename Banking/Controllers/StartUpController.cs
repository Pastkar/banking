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
    public class StartUpController : Controller
    {
        private readonly IServicesStartUpBL _startUpService;
        private readonly IMapper _mapper;
        public StartUpController(IMapper mapper, IServicesStartUpBL companyService)
        {
            _startUpService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetStartUps")]
        public async Task<IActionResult> GetCompaniesAllAsync()
        {
            List<StartUpGetModel> list = null;
            list = _mapper.Map<List<StartUpGetModel>>(await _startUpService.ReadAllAsync());
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        [Route("PostStartUp")]
        public async Task<IActionResult> PostCompanyAsync([FromBody] StartUpCreateModel model)
        {
            if (model == null)
                return BadRequest();
            var result = _mapper.Map<StartUpCreateBL>(model);
            await _startUpService.CreateAsync(result);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("GetStartUpById_{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            var result = _mapper.Map<StartUpGetModel>(await _startUpService.ReadByIdAsync(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteStartUpById_{id}")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            if (await _startUpService.ReadByIdAsync(id) == null)
                return NotFound();
            await _startUpService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        [Route("PutStartUpById_{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] StartUpCreateModel model)
        {
            if (await _startUpService.ReadByIdAsync(id) == null)
                return NotFound();
            await _startUpService.UpdateAsync(_mapper.Map<StartUpCreateBL>(model), id);
            return Ok();
        }
    }
}
