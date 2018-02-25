package client;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

import model.InterfaceAnimal;
import model.InterfaceBreed;
import model.InterfaceCabinet;

public class Client
{
	private Client(){}
	
	public static void main(String [] args)
	{
		try
		{
			Registry registry = LocateRegistry.getRegistry(1099);
			
			InterfaceCabinet stub = (InterfaceCabinet) registry.lookup("turtle");
			
			InterfaceAnimal ia = stub.getAnimal("tutu");
			
			System.out.println(ia.getInfos());
;
		}
		catch(Exception e)
		{
			System.err.println("Clientexception:"+e.toString());
			e.printStackTrace();
		}
	}
}