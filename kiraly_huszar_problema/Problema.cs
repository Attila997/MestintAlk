using System.Collections.Generic;

class Problema
{
	public List<Operator> operatorok { get; set; } = new List<Operator>();

	public Problema()
	{
		for (int i = 1; i <= 8; i++)
		{
			for (int j = 1; j <= 8; j++)
			{
				operatorok.Add(new Operator(i, j, 0));
				operatorok.Add(new Operator(i, j, 1));
			}
		}
	}

	public Allapot kezdo()
	{
		return new Allapot();
	}

}

