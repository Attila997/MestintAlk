using System;
using System.Windows;

class Heurisztika
{
	public double heurisztika;

	public double heur(Allapot a, int babu)
	{
		double diff;

		if (babu == 0)
		{
			int[] cel = new int[2] { 8, 7 };
			diff = Math.Sqrt((cel[0] - a.kiraly[0]) * (cel[0] - a.kiraly[0])) + ((cel[1] - a.kiraly[1]) * (cel[1] - a.kiraly[1]));
		}
		else
		{
			int[] cel = new int[2] { 8, 7 };
			diff = Math.Sqrt((cel[0] - a.huszar[0]) * (cel[0] - a.huszar[0])) + ((cel[1] - a.huszar[1]) * (cel[1] - a.huszar[1]));
		}
		return diff;
	}
}

