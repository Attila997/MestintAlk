class Csucs
{
	public Allapot allapot;
	public Operator eloallito;
	public Csucs szulo;
	public double heurisztika;

	public Csucs(Allapot allapot, Operator eloallito, Csucs szulo, double heurisztika)
	{
		this.allapot = allapot;
		this.eloallito = eloallito;
		this.szulo = szulo;
		this.heurisztika = heurisztika;
	}
}
