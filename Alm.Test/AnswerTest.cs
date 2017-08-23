using System;
using Xunit;

namespace Alm.Test
{
    public class SomeTests
    {
		[Fact]
		public void TryGetTheAnswer()
		{
			var computer = new MegaComputer();
			Assert.Throws<ArgumentNullException>(() => computer.Ask(null));
		}

		[Fact]
		public void QuestionTest()
		{
			new Question(null);
			new Question("hello");
		}

		[Fact]
		public void AnswerTest()
		{
			new Answer(0);
			new Answer(42);
		}
    }
}
