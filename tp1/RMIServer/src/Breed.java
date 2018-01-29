


import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Breed extends UnicastRemoteObject implements InterfaceBreed
{
	private String a_name;
	private int a_life;
	
	public Breed(String p_name, int p_life) throws RemoteException
	{
		a_name = p_name;
		a_life = p_life;
	}
	
	@Override
	public String toString()
	{
		StringBuilder r_to_string = new StringBuilder();
		
		r_to_string.append(a_name);
		r_to_string.append(System.getProperty("line.separator"));
		
		r_to_string.append(a_life);
		r_to_string.append(System.getProperty("line.separator"));
		
		return r_to_string.toString();
	}
	
	@Override
	public String getInfos() throws RemoteException
	{
		return toString();
	}
}