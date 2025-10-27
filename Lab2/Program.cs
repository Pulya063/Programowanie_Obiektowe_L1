class Zwierze
{
	protected string imie;
	public Zwierze(string name)
	{
		imie = name;
	}

	public virtual void DajGlos()
	{
		Console.WriteLine(". . .");
	}

	public static void Powiedz_Cos(Zwierze z)
	{
		z.DajGlos();
	}

}

class Pies : Zwierze
{
	public Pies(string n) : base(n) { }
	public override void DajGlos()
	{
		Console.WriteLine($"{imie} robi woof woof!");
	}
}

class Kot: Zwierze
{
	public Kot(string imie) : base(imie) { }
	public override void DajGlos()
	{
        Console.WriteLine($"{imie} robi meow meow!");
	}
}

class Waz: Zwierze
	{
	public Waz(string imie) : base(imie) { }
	public override void DajGlos()
	{
		Console.WriteLine($"{imie} robi sssss!");
	}
}

abstract class Pracownik
{
	public string imie { get; set; }

    public Pracownik(string n)
	{
		imie = n;
	}

	public abstract void Pracuj();
}

class Piekarz : Pracownik
{
	public Piekarz(string n) : base(n) { }
	public override void Pracuj()
	{
		Console.WriteLine("Trwa pieczenie");
	}
}

class A
{
	public A()
	{
			Console.WriteLine("Konstruktor A");
	}
}

class B : A
{
	public B() : base()
	{
		Console.WriteLine("Konstruktor B");
	}
}

class C : B
{
	public C() : base()
	{
		Console.WriteLine("Konstruktor C");
	}
}

class Program()
{
	public static void Main()
	{
		Zwierze pies = new Pies("Burek");
		Zwierze kot = new Kot("Mruczek");
		Zwierze waz = new Waz("Kaa");
		pies.DajGlos();
		kot.DajGlos();
		waz.DajGlos();

		Pracownik piekarz = new Piekarz("Jan");
		piekarz.Pracuj();

		A a = new A();
		B b = new B();
		C c = new C();
	}
}