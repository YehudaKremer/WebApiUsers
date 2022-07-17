using Entities.Commands;
using Entities.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRequestClient<CreateUser> createUserclient;
        public IBus Bus { get; }

        public UsersController(IRequestClient<CreateUser> createUserclient, IBus bus)
        {
            this.createUserclient = createUserclient;
            Bus = bus;
        }


        //[HttpPost]
        //public async Task<int> CreateUser(string UserName)
        //{
        //    var respone = await createUserclient.GetResponse<UesrCreated>(new CreateUser(NewId.NextGuid(), UserName));

        //    return respone.Message.UserId;
        //}

        [HttpPost]
        public async Task<bool> CreateUser2(string UserName)
        {
            await Bus.Send(new CreateUser(NewId.NextGuid(), UserName));

            return true;
        }
    }
}
