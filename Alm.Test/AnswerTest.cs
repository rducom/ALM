using Xunit;

namespace Alm.Test
{
    public class AnswerTest	
    {
		[Fact]
		public void TryGetTheAnswer()
		{
			var s = new SuperbClass();
			Assert.Equal(42, s.TheAnswer());
		}
    }
}
