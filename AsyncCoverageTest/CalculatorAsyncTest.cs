using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncCoverage;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AsyncCoverageTest
{
	[TestFixture]
	public class CalculatorAsyncTest
	{
		[Test]
		public async void ValidResponseTest()
		{
			var expectedResult = 4;

			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2,2)).ReturnsAsync(4);

			var calculator = new CalculatorAsync(additionHandler.Object);
			var aTaskResponse = calculator.Add(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}

		[Test]
		public async void ResponseYieldTest()
		{
			var expectedResult = 4;

			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2, 2)).Returns(async () =>
			{
				await Task.Yield();
				return 4;
			});

			var calculator = new CalculatorAsync(additionHandler.Object);
			var aTaskResponse = calculator.Add(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}

		[Test]
		[ExpectedException("System.NullReferenceException")]
		public async void ErrorResponseTest()
		{
			var calculator = new CalculatorAsync(null);
			var aTaskResponse = calculator.Add(2, 2);
			var aResponse = await aTaskResponse;
		}


		[Test]
		[ExpectedException("System.InvalidOperationException")]
		public async void CancellationTest()
		{
			var expectedResult = 4;

			var tcs = new TaskCompletionSource<int>();
			tcs.SetResult(4);
			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2, 2)).Returns(tcs.Task);
			tcs.SetCanceled();

			var calculator = new CalculatorAsync(additionHandler.Object); 
			var aTaskResponse = calculator.Add(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}



		#region Decompiled Test

		[Test]
		public async void DecompiledValidResponseTest()
		{
			var expectedResult = 4;

			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2, 2)).ReturnsAsync(4);

			var calculator = new CalculatorAsync(additionHandler.Object);
			var aTaskResponse = calculator.AddDecompiled(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}

		[Test]
		public async void DecompiledValidResponseYieldTest()
		{
			var expectedResult = 4;

			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2, 2)).Returns(async () =>
			{
				await Task.Yield();
				return 4;
			});

			var calculator = new CalculatorAsync(additionHandler.Object);
			var aTaskResponse = calculator.AddDecompiled(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}

		[Test]
		[ExpectedException("System.NullReferenceException")]
		public async void DecompiledErrorResponseTest()
		{
			var calculator = new CalculatorAsync(null);
			var aTaskResponse = calculator.AddDecompiled(2, 2);
			var aResponse = await aTaskResponse;
		}


		[Test]
		[ExpectedException("System.InvalidOperationException")]
		public async void DecompiledCancellationTest()
		{
			var expectedResult = 4;

			var tcs = new TaskCompletionSource<int>();
			tcs.SetResult(4);
			var additionHandler = new Mock<IAdditionHandler>();

			additionHandler.Setup(x => x.Add(2, 2)).Returns(tcs.Task);
			tcs.SetCanceled();

			var calculator = new CalculatorAsync(additionHandler.Object);
			var aTaskResponse = calculator.AddDecompiled(2, 2);
			var aResponse = await aTaskResponse;
			Assert.AreEqual(expectedResult, aResponse);
		}
		#endregion
	}
}
