import java.rmi.registry.Registry;
import java.rmi.registry.LocateRegistry;

public class Server
{
	public Server(){}
	
	public static void main(String args[])
	{
		try
		{
			HelloImpl obj=new HelloImpl();
			//Registryregistry=LocateRegistry.createRegistry(1099);
			Registry registry = LocateRegistry.getRegistry(); //Suppose que le registre existe (1099 sans parametre).
			//Doit etre lancer a l'avance
			//Doit etre lancer a l'avance
			if(registry==null)
			{
				System.err.println("RmiRegistrynotfound");
				System.err.println("RmiRegistrynotfound");
			}
			else
			{
				registry.bind("Hello",obj);
				System.err.println("Serverready");
			}
		}catch(Exception e)
		{
			System.err.println("Serverexception:"+e.toString());
			e.printStackTrace();
		}
	}
}
