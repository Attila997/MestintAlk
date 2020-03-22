using System;

class Allapot
{
	public int[] kiraly = new int[2];
	public int[] huszar = new int[2];

	public Allapot()
	{
		this.kiraly[0] = 6;
		this.kiraly[1] = 2;
		this.huszar[0] = 6;
		this.huszar[1] = 3;
	}

	public Allapot(Allapot allapot)
	{
		this.kiraly[0] = allapot.kiraly[0];
		this.kiraly[1] = allapot.kiraly[1];
		this.huszar[0] = allapot.huszar[0];
		this.huszar[1] = allapot.huszar[1];
	}


	public bool cel()
	{
		return ((kiraly[0] == 8 && kiraly[1] == 7) || (huszar[0] == 8 && huszar[1] == 7));
	}

	public override string ToString()
	{
		return "Allapot{" +
				" kiraly : (" + kiraly[0] + ", " + kiraly[1] +
				") huszar : (" + huszar[0] + ", " + huszar[1] +
				")}";
	}

	public override int GetHashCode()
	{
		return Int32.Parse(kiraly[0].ToString() + kiraly[1].ToString() + huszar[0].ToString() + huszar[1].ToString());
	}

	public bool Equals(Allapot obj)
	{
		return GetHashCode() == obj.GetHashCode();
	}

}

