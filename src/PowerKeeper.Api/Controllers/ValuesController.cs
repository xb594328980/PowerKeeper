using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PowerKeeper.Application.Interfaces;
using PowerKeeper.Domain.Core.Bus;
using PowerKeeper.Domain.Core.Notifications;

namespace PowerKeeper.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ApiController
    {
        private readonly IStaffAppService _staffAppService;
        public ValuesController(INotificationHandler<DomainNotification> notifications,
            IStaffAppService staffAppService,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _staffAppService = staffAppService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _staffAppService.Get();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

   
    }
}
