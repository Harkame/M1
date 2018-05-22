import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Scanner;
public class Client
{
	private static final String DEFAULT_REGISTRY_KEY = "veterinary_practice";

	public static void main(String [] args)
	{	
		/*
		System.setProperty("java.security.policy", "file:D:\\workspace\\RMI\\TP1Client\\client.policy");
		System.setProperty("java.rmi.server.codebase","file:D:\\workspace\\RMI\\TP1Server\\bin\\");
	
		System.setSecurityManager(new SecurityManager());
		*/
		
		Scanner t_keyboard = new Scanner(System.in);
		
		try
		{
			System.out.println("[Connection...]");
			
			Registry t_registry = LocateRegistry.getRegistry(1100);
			
			System.out.println("[Connected]");

			System.out.println("[Get VeterinaryPractice]");	
			InterfaceVeterinaryPractice t_veterinary_practice = (InterfaceVeterinaryPractice) t_registry.lookup(DEFAULT_REGISTRY_KEY);
			System.out.println("[VeterinaryPractice getted]");
			
			System.out.println("[Add veterinary]");
			InterfaceVeterinary t_veterinary = new Veterinary("Toto");
			t_veterinary_practice.addVeterinary(t_veterinary);
			System.out.println("[Veterinary added]");
			
			System.out.println("[Add animal]");
			System.out.print("Animal name : ");
			String t_animal_name = t_keyboard.nextLine();
			System.out.println("");
			t_veterinary_practice.addAnimal(new Animal(t_animal_name, "Jean-Kevin", "Pokemon", new Breed("Eau", 42), new MedicalFile("Ok.")));	
			System.out.println("[Animal added]");
			
			System.out.println("[Get animal]");		
			InterfaceAnimal t_animal = t_veterinary_practice.getAnimal(t_animal_name);	
			System.out.println(t_animal.getInfos());	
			System.out.println("[Animal getted]");

			System.out.println("[Add animal with SubBreed (Client only)]");
			System.out.print("Animal name : ");
			t_animal_name = t_keyboard.nextLine();
			System.out.println("");
			t_veterinary_practice.addAnimal(new Animal(t_animal_name, "Jean-Kevin", "Pokemon", new SubBreed("Eau", 42), new MedicalFile("Ok.")));
			System.out.println("[Animal added]");
			
			System.out.println("Please, press enter to continue");
			t_keyboard.nextLine();
			t_keyboard.close();
			System.exit(0);
		}	
		catch(Exception t_exception)
		{
			t_exception.printStackTrace();
		}
	}
}