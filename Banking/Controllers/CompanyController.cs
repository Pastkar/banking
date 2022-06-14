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
    public class CompanyController : Controller
    {
        private readonly IServicesCompany _companyService;
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper, IServicesCompany companyService)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetCompaniesAllAsync()
        {
            List<CompanyGetModel> list = null;
            list = _mapper.Map<List<CompanyGetModel>>(await _companyService.ReadAllAsync());
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        [Route("PostCompany")]
        public async Task<IActionResult> PostCompanyAsync([FromBody] CompanyCreateModel model)
        {
            if (model == null)
                return BadRequest();
            var result = _mapper.Map<CompanyCreateBL>(model);
            await _companyService.CreateAsync(result);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("GetCompanyById_{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            var result = _mapper.Map<CompanyGetModel>(await _companyService.ReadByIdAsync(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteCompanyById_{id}")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            if (await _companyService.ReadByIdAsync(id) == null)
                return NotFound();
            await _companyService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        [Route("PutCompanyById_{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyCreateModel model)
        {
            if (await _companyService.ReadByIdAsync(id) == null)
                return NotFound();
            await _companyService.UpdateAsync(_mapper.Map<CompanyCreateBL>(model), id);
            return Ok();
        }
        [HttpGet]
        [Route("GetCompanyByName_{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = _mapper.Map<CompanyGetModel>(await _companyService.ReadByNameAsync(name));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetStartUpsByCompanyId_{id}")]
        public async Task<IActionResult> GetStartUpsByCompanyId(int id)
        {
            var result = _mapper.Map<IEnumerable<StartUpGetModel>>(await _companyService.GetStartUpsByCompanyId(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
