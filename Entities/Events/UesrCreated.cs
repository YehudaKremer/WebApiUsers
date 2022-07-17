using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class UesrCreated
    {
        public UesrCreated(Guid CorrelationId, int userId)
        {
            this.CorrelationId = CorrelationId;
            UserId = userId;
        }

        public Guid CorrelationId { get; }
        public int UserId { get; }
    }
}
