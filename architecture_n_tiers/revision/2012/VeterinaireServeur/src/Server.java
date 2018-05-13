import java.rmi.registry.Registry;
import java.rmi.registry.LocateRegistry;

public class Server
{
	public Server()
	{
	}

	public static void main(String args[])
	{
		try
		{
			CabinetVeterinaireImpl miniCab = new CabinetVeterinaireImpl();
			DossierImpl milou = new DossierImpl("Tintin", "Milou");
			DossierImpl idefix = new DossierImpl("Obelix", "Idefix");
			miniCab.addDossier(milou);
			miniCab.addDossier(idefix);
			//Registry registry = LocateRegistry.getRegistry(2000);
			Registry registry = LocateRegistry.createRegistry(2000);
			if(registry == null)
			{
				System.out.println("Rmi Registry notfound");
			}
			else
			{
				registry.bind("miniCab", miniCab);
				System.out.println("Server ready");
			}
		}
		catch(Exception e)
		{
			System.out.println("Server exception : " + e.toString());
			e.printStackTrace();
		}
	}
}
