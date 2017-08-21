using System;
using Xunit;

namespace Alm.Test
{
    public class AnswerTest	
    {
		[Fact]
		public void TryGetTheAnswer()
		{
			var computer = new MegaComputer();
			Assert.Throws<ArgumentNullException>(() => computer.Ask(null));
		}
    }
}
