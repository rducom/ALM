using System;

namespace Alm
{
	public class MegaComputer
	{
		public Answer Ask(Question question)
		{
			if (question == null)
				throw new ArgumentNullException(nameof(question));

			bool match = question.Text.Equals(GoodData.TheQuestion, StringComparison.InvariantCultureIgnoreCase);

			return match ? new Answer(GoodData.TheAnswer) : new Answer(GoodData.AnotherAnswer);
		}
	}
}