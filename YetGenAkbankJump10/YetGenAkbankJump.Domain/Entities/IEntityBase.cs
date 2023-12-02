using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetGenAkbankJump.Domain.Entities
{
	public interface IEntityBase<TKey>
	{
		public TKey Id { get; set; }
	}
}
