import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.ArrayList;
import java.util.Scanner;

public class Client
{
	private Client() {}
	
	public static void main(String[] Args)
	{
		try {
			Registry registry = LocateRegistry.getRegistry(2000);
			CabinetVeterinaire miniCab = (CabinetVeterinaire) registry.lookup("miniCab");
			ArrayList<Dossier> dossierTintin = miniCab.getDossierByOwnerName("Tintin");
			
			
			System.out.println("registry.class : " + registry.getClass().toString());
			System.out.println("miniCab.class : " + miniCab.getClass().toString());
			System.out.println("dossierIntin.class : " + dossierTintin.getClass().toString());	
			System.out.println("dossierIntin.get(0).class : " + dossierTintin.get(0).getClass().toString());

			for(Dossier d : dossierTintin)
				System.out.println(d.getAnimalName());
			
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		
		System.out.println("Please press enter");
		new Scanner(System.in).nextLine();
	}
}
