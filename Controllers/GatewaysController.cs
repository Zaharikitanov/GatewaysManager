using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GatewaysManager.Controllers
{
    public class GatewaysController : ControllerBase
    {
        //private IWebsiteService _service;
        //private IStatusCodeResultFactory _resultFactory;

        //public WebsiteController(IWebsiteService service, IStatusCodeResultFactory factory)
        //{
        //    _service = service;
        //    _resultFactory = factory;
        //}

        //[HttpPost]
        //public async Task<HttpStatusCode> Create(WebsiteInputData inputData)
        //{
        //    var createEntityOutcome = await _service.CreateEntityAsync(inputData);

        //    return _resultFactory.Create(createEntityOutcome);
        //}

        //[HttpGet("{id}")]
        //public async Task<WebsiteViewData> GetEntityById(Guid id)
        //{
        //    return await _service.GetEntityByIdAsync(id);
        //}

        //[HttpPut("{id}")]
        //public async Task<HttpStatusCode> Update(WebsiteInputData inputData, Guid id)
        //{
        //    var updateEntityOutcome = await _service.UpdateEntityAsync(inputData, id);

        //    return _resultFactory.Update(updateEntityOutcome);
        //}
    }
}