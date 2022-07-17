using Entities.Commands;
using Entities.Events;
using Entities.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Consumers
{
    public class CreateUserTESTConsumer : IConsumer<CreateUser>
    {
        List<User> Users = new List<User>();

        public async Task Consume(ConsumeContext<CreateUser> context)
        {
            var newUser = new User
            {
                Name = context.Message.Name
            };

            Users.Add(newUser);

            newUser.ID = Users.Count();

            await context.Publish(new UesrCreated(context.Message.CorrelationId, newUser.ID));
        }

    }
}
