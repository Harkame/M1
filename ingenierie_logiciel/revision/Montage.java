
public class Montage extends Composant
{
	void equiv(Montage a, String s)
	{
		System.out.println("Equiv de montage");
	}
	
	void diff()
	{
		System.out.println("tototo");
	}
	
	public static void main(String[] args)
	{
		Composant m1 = new ComposantSimple();
		
		Montage m2 = new Montage();
		
		Composant m3 = new Montage();
		
		m2.equiv(m1, "toto");
		m2.equiv(m2, "toto");
		m2.equiv(m3, "toto");
		m2.equiv((Montage) m3, "toto");
		m3.equiv(m1, "tootot");
		m3.equiv(m2, "olggk");
		m3.equiv(m3, "jgtjg");
		m3.equiv((Montage) m3, "jgjgj");
	}
}