import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Scanner;

public class Client
{
	private static final String JAVA_PROPERTY_LINE_SEPARATOR = "line.separator";
	
	private static final String JAVA_PROPERTY_POLICY = "java.security.policy";
	private static final String JAVA_PROPERTY_CODEBASE = "java.rmi.codebase";
	
	private static final String JAVA_SECURITY_POLICY_SERVER = "server.policy";
	private static final String JAVA_SECURITY_POLICY_CLIENT = "client.policy";
	
	private static final String JAVA_POLICY_CODEBASE_VALUE = "/auto_home/harkame/workspace/TPNTiersV3/bin/";
	
	private static final int DEFAULT_PORT = 1099;
	private static final String DEFAULT_REGISTRY_KEY = "cabinet";
	
	private static final String MESSAGE_REGISTRY_CREATED = "Registry created";
	private static final String MESSAGE_REGISTRY_BINDED = "Registry binded";
	
	private static final String ERROR_MESSAGE_REGISTRY_NOT_FOUND = "Registry not found";
	
	private static final String ERROR_MESSAGE_EXCEPTION = "Error : ";
	
	private static final String ASK_MESSAGE_METHOD_ADD = "add";
	private static final String ASK_MESSAGE_METHOD_REMOVE = "remove";
	
	private static final String ASK_MESSAGE_METHOD = "add/remove : ";
	private static final String ASK_MESSAGE_RANGE_A = "range a : ";
	private static final String ASK_MESSAGE_RANGE_B = "range b : ";
	
	private Client(){}
	
	public static void main(String [] args)
	{	
		try
		{
			
			Registry t_registry = LocateRegistry.getRegistry(1100);
			
			System.out.println("Connected");
			
			InterfaceCabinet t_cabinet = (InterfaceCabinet) t_registry.lookup("cabinet");
			
			InterfaceVeterinary t_veterinary = new Veterinary();
			
			t_cabinet.addVeterinary(t_veterinary);
			
			InterfaceAnimal t_animal = new Animal(null, null, null, new Breed("toto", 42), new MedicalFile("toto"));
			
			t_cabinet.addAnimal(t_animal);
			
			System.out.println("Animal sended");
			
			//InterfaceSubBreed t_subbreed = new SubBreed("titi", 47);
			
			//t_cabinet.yolo(t_subbreed);
			
			System.out.println("SubBreed sended");
			
			Scanner t_keyboard = new Scanner(System.in);
			
			while(true)
			{
				System.out.print("Action : ");
				
				switch(t_keyboard.nextLine())
				{
					case "add":
						System.out.println("");
						System.out.print("Name : ");
						t_cabinet.addAnimal(new Animal(t_keyboard.nextLine(), null, null, new Breed(null, 0), null));
						break;
						
					case "remove":
						System.out.println("");
						System.out.print("Name : ");
						t_cabinet.addAnimal(new Animal(t_keyboard.nextLine(), null, null, new Breed(null, 0), null));
					break;
					
					default:
						t_keyboard.close();
					break;
				}
				
				System.out.println("");
			}

		}
		catch(Exception t_exception)
		{
			System.err.println("Clientexception:"+ t_exception.toString());
			t_exception.printStackTrace();
		}
	}
}