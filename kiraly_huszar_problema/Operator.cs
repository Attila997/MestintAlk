class Operator
{
	public int i, j;
	//0 = király, 1 = huszár
	public int babu;

	public Operator(int i, int j, int babu)
	{
		this.i = i;
		this.j = j;
		this.babu = babu;
	}

	public bool alkalmazhato(Allapot allapot)
	{
		Problema p = new Problema();
		BestFirst bestFirst = new BestFirst();

		if (babu == 0)
		{
			int sorKulonb = allapot.kiraly[0] - i;
			int oszlopKulonb = allapot.kiraly[1] - j;
			return ((sorKulonb >= -1 && sorKulonb <= 1) && (oszlopKulonb >= -1 && oszlopKulonb <= 1));
		}
		else if (babu == 1)
		{
			int sorKulonb = allapot.huszar[0] - i;
			int oszlopKulonb = allapot.huszar[1] - j;
			return ((sorKulonb == 2 || sorKulonb == -2) && (oszlopKulonb == 1 || oszlopKulonb == -1) ||
					(oszlopKulonb == 2 || oszlopKulonb == -2) && (sorKulonb == 1 || sorKulonb == -1));
		}
		else return false;
	}

	public Allapot lepes(Allapot allapot)
	{
		Allapot ujAllapot = new Allapot(allapot);
		if (babu == 0)
		{
			ujAllapot.kiraly[0] = i;
			ujAllapot.kiraly[1] = j;
		}
		else if (babu == 1)
		{
			ujAllapot.huszar[0] = i;
			ujAllapot.huszar[1] = j;
		}

		return ujAllapot;
	}

	public override string ToString()
	{
		return babu + "-->(" + i + ", " + j + ')';
	}
}

