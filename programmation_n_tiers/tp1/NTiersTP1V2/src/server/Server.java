package server;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

import model.Animal;
import model.Cabinet;

public class Server
{
	public Server(){}
	
	@SuppressWarnings("deprecation")
	public static void main(String args[])
	{
		try
		{
			//System.setProperty("java.security.policy", "/auto_home/ldaviaud/workspace/server.policy");
			
			//System.setSecurityManager(new RMISecurityManager());
			
			Cabinet c = new Cabinet();

			System.out.println("Create animal");
			
			Registry registry = LocateRegistry.createRegistry(1099);

			System.out.println("Create registry");
			
			if(registry == null)
			{
				System.err.println("RmiRegistrynotfound");
				
				return;
			}
			
			registry.rebind("turtle", c);
			
			System.err.println("Server ready");
		}
		catch(Exception e)
		{
			System.err.println("Server exception:" + e.toString());
			e.printStackTrace();
		}
	}
}
