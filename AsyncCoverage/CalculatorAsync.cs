using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsyncCoverage
{
	public class CalculatorAsync
	{
		private IAdditionHandler _additionAsync;

		public CalculatorAsync(IAdditionHandler additionAsync)
		{
			_additionAsync = additionAsync;
		}

		public async Task<int> Add(int value1, int value2)
		{
			var results = await _additionAsync.Add(value1, value2);
			return results;
		}

		public Task<int> AddDecompiled(int value1, int value2)
		{
			CalculatorAsync.d__0 stateMachine = new d__0();
			stateMachine._this = this;
			stateMachine.value1 = value1;
			stateMachine.value2 = value2;
			stateMachine._builder = AsyncTaskMethodBuilder<int>.Create();
			stateMachine._state = -1;
			stateMachine._builder.Start<CalculatorAsync.d__0>(ref stateMachine);
			return stateMachine._builder.Task;
		}

		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct d__0 : IAsyncStateMachine
		{
			public int _state;
			public AsyncTaskMethodBuilder<int> _builder;
			public CalculatorAsync _this;
			public int value1;
			public int value2;
			public int _results1;
			private TaskAwaiter<int> _awaiter2;
			private object _stack;

			void IAsyncStateMachine.MoveNext()
			{
				int result1 = 0;
				try
				{
					bool flag = true;
					TaskAwaiter<int> awaiter;
					switch (this._state)
					{
						case -3:
							goto label_6;
						case 0:
							awaiter = this._awaiter2;
							this._awaiter2 = new TaskAwaiter<int>();
							this._state = -1;
							break;
						default:
							awaiter = this._this._additionAsync.Add(this.value1, this.value2).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								this._state = 0;
								this._awaiter2 = awaiter;
								this._builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, CalculatorAsync.d__0>(ref awaiter, ref this);
								flag = false;
								return;
							}
							break;
					}
					int result2 = awaiter.GetResult();
					awaiter = new TaskAwaiter<int>();
					this._results1 = result2;
					result1 = this._results1;
				}
				catch (Exception ex)
				{
					this._state = -2;
					this._builder.SetException(ex);
					return;
				}
			label_6:
				this._state = -2;
				this._builder.SetResult(result1);
			}

			[DebuggerHidden]
			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
			{
				this._builder.SetStateMachine(param0);
			}
		}
	}
}
