﻿using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    [Produces("application/json")]
    public class CompaniesController : ControllerHelper
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddCompanyModel model)
        {
            try
            {
                var company = await _service.AddCompanyAsync(model, UserId);

                return Ok(company);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCompanyDropDown(int userId, int? index = null)
        {
            try
            {
                var dropDown = await _service.GetCompanyItemsAsync(userId, index);

                return Ok(dropDown);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
