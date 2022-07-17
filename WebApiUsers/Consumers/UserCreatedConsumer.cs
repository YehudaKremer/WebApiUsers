using Entities.Events;
using MassTransit;
using System.Threading.Tasks;

namespace WebApiUsers.Consumers
{
    public class UserCreatedConsumer : IConsumer<UesrCreated>
    {

        public async Task Consume(ConsumeContext<UesrCreated> context)
        {
            System.Console.WriteLine(context.Message.UserId);
        }

    }
}
