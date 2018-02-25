
import java.rmi.RemoteException;

public class SubBreed extends Breed implements InterfaceSubBreed
{
	private int a_attribut;

	public SubBreed(String p_name, int p_life) throws RemoteException
	{
		super(p_name, p_life);
		
		a_attribut = 42;
	}

	@Override
	public String getInfos() throws RemoteException
	{
		StringBuilder r_string_builder = new StringBuilder();
		
		r_string_builder.append(super.getInfos());
		r_string_builder.append(System.getProperty("line.separator"));
		
		r_string_builder.append("[SUBBREED] " + a_attribut);
		r_string_builder.append(System.getProperty("line.separator"));
		
		return r_string_builder.toString();
	}

	@Override
	public void foo() throws RemoteException
	{
		System.out.println("Subbreed oo");
	}
}
