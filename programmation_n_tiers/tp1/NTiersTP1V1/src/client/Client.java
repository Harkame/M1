package client;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

import model.InterfaceAnimal;
import model.InterfaceBreed;

public class Client
{
	private Client(){}
	
	public static void main(String [] args)
	{
		try
		{
			Registry registry = LocateRegistry.getRegistry(1099);
			
			InterfaceAnimal stub = (InterfaceAnimal)registry.lookup("turtle");
			
			InterfaceBreed breed = stub.getBreed();
			
			System.out.println("Infos : " + breed.getInfos());
;
		}
		catch(Exception e)
		{
			System.err.println("Clientexception:"+e.toString());
			e.printStackTrace();
		}
	}
}