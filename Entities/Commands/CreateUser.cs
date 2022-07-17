using System;

namespace Entities.Commands
{
    public class CreateUser
    {
        public CreateUser(Guid CorrelationId, string Name)
        {
            this.CorrelationId = CorrelationId;
            this.Name = Name;
        }

        public Guid CorrelationId { get; }
        public string Name { get; }
    }
}
