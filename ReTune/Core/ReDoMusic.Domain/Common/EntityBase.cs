using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDoMusic.Domain.Common
{
    public class EntityBase<TKey> : ICreatedBy, IDeletedOn, IModifiedOn
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get ; set; }
        public DateTime? DeletedOn { get ; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
