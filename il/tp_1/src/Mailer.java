//Use array of boolean, each boolean are yes | no to feature

public class Mailer
{
	BR a_br;
	Compactage a_compactage;
	
	public Mailer(boolean p_type_br)
	{
		if(p_type_br)
			a_br = new BRSimple();
		else
			a_br = new BRMultiple();
		
	}
	
	public static void main(String[] Args)
	{
		
	}
}

abstract class BR
{
	
}

class BRSimple extends BR
{
	
}

class BRMultiple extends BR
{
	
}

class Etiquetage
{
	
}

class EDefaut extends Etiquetage
{
	
}

class EPErso extends Etiquetage
{
	
}

class Gestionnaire
{
	
}

abstract class Compactage
{
	
}

class Auto extends Compactage
{
	
}

class Manuel extends Compactage
{
	
}
