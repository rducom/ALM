using System;

namespace Alm
{
	public class SuperbClass
	{
		public int TheAnswer() => 42;

		public string TheQuestion() => "the Ultimate Question of Life, The Universe, and Everything";
	}

	public class AnotherClass
	{
		public void IThrowExceptionsBaaadly(int answer)
		{
			if (answer != 42)
			{
				throw new Exception("Don't throw this please");
			}
		}
	}
}
