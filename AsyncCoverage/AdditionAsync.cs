using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AsyncCoverage
{
	[ExcludeFromCodeCoverage]
	public class AdditionAsync : IAdditionHandler
	{
		public async Task<int> Add(int value1, int value2)
		{
			var result = value1 + value2;
			await Task.Yield();
			return result;
		}
	}
}
