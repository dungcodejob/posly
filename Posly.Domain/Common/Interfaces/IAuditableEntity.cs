using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posly.Domain.Common.Interfaces
{
    public interface IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAtUtc { get; init; }
        public DateTime? UpdatedAtUtc { get; set; }
    }
}
