using System;
using System.Collections.Generic;
using System.Linq;

class BestFirst
{
	public int Utes(Allapot a, Problema p)
	{
		var operatorok = p.operatorok;
		var returnValue = 500;
		foreach (var o in operatorok)
		{
			if (o.babu == 1)
			{
				if (o.alkalmazhato(a))
				{
					Allapot ujHuszarAllapot = o.lepes(a);
					if (ujHuszarAllapot.huszar.SequenceEqual(a.kiraly))
					{
						returnValue = 0;
					}
				}
			}
			else if (o.babu == 0)
			{
				if (o.alkalmazhato(a))
				{
					Allapot ujKiralyAllapot = o.lepes(a);
					if (ujKiralyAllapot.kiraly.SequenceEqual(a.huszar))
					{
						returnValue = 1;
					}
				}
			}

		}
		return returnValue;

	}

	public List<Operator> keres(Problema p, Heurisztika h)
	{
		LinkedList<Csucs> nyiltak = new LinkedList<Csucs>();
		LinkedList<Csucs> zartak = new LinkedList<Csucs>();

		int aktualisBabu = 500;
		int babu = Utes(p.kezdo(), p);
		h.heurisztika = h.heur(p.kezdo(), babu);

		nyiltak.AddLast(new Csucs(p.kezdo(), null, null, h.heurisztika));

		while (true)
		{
			if (!nyiltak.Any())
			{
				return null;
			}

			Csucs kivalasztott = null;

			foreach (Csucs c in nyiltak)
			{
				//0 = király, 1 = huszár 500=rossz
				int cBabu = Utes(c.allapot, p);
				if (cBabu != 500)
				{
					c.heurisztika = h.heur(c.allapot, cBabu);
					if ((kivalasztott == null || kivalasztott.heurisztika > c.heurisztika))
					{
						kivalasztott = c;
						aktualisBabu = cBabu;
					}
				}
				else continue;
			}

			if (kivalasztott.allapot.cel())
			{
				LinkedList<Operator> megoldas = new LinkedList<Operator>();
				for (Csucs c = kivalasztott; c.szulo != null; c = c.szulo)
				{
					megoldas.AddFirst(c.eloallito);
				}
				return megoldas.ToList();
			}

			nyiltak.Remove(kivalasztott);
			zartak.AddLast(kivalasztott);
			
			if (aktualisBabu != 500)
			{
				foreach (Operator o in p.operatorok)
				{

					if (o.babu == aktualisBabu)
					{
						if (o.alkalmazhato(kivalasztott.allapot))
						{
							Allapot uj = o.lepes(kivalasztott.allapot);

							bool voltMar = false;
							foreach (Csucs c in nyiltak)
							{
								if (c.allapot.GetHashCode() == uj.GetHashCode())
								{
									voltMar = true;
									break;
								}
							}
							if (!voltMar)
							{
								foreach (Csucs c in zartak)
								{
									if (c.allapot.GetHashCode() == uj.GetHashCode())
									{
										voltMar = true;
										break;
									}
								}
							}

							if (!voltMar)
							{
								nyiltak.AddLast(new Csucs(uj, o, kivalasztott, h.heur(uj, aktualisBabu)));
							}
						}
					}
					else continue;
				}
			}
		}
	}

	static void Main(string[] args)
	{
		Problema p = new Problema();
		Heurisztika h = new Heurisztika();
		BestFirst bestFirst = new BestFirst();
		List<Operator> megoldas = bestFirst.keres(p, h);

		megoldas.ForEach(Console.WriteLine);
		Console.WriteLine("Befejezéshez nyomj meg egy gombot!");
		Console.ReadKey();
	}
}

