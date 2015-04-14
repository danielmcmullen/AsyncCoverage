using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCoverage
{
	public interface IAdditionHandler
	{
		Task<int> Add(int value1, int value2);
	}
}
