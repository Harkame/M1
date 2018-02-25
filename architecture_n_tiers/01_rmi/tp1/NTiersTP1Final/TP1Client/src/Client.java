

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public abstract class Client
{
	private static final String JAVA_PROPERTY_HOST = "java.rmi.server.hostname";
	private static final String JAVA_PROPERTY_HOST_VALUE = "localhost";

	private static final String DEFAULT_REGISTRY_KEY = "cabinet";
	
	public static void main(String [] args) throws Exception
	{
		System.setProperty(JAVA_PROPERTY_HOST, JAVA_PROPERTY_HOST_VALUE);
		
		Registry t_registry = LocateRegistry.getRegistry(JAVA_PROPERTY_HOST_VALUE);
		
		System.out.println("Registry connected");
		
		InterfaceCabinet t_cabinet = (InterfaceCabinet) t_registry.lookup(DEFAULT_REGISTRY_KEY);
		
		System.out.println("Cabinet aqcuiered");
		
		InterfaceVeterinary t_veterinary = new Veterinary();
		
		t_cabinet.addVeterinary(t_veterinary);
		
		InterfaceAnimal t_animal;
		
		//send animal
		{
			t_animal = new Animal("toto", "titi", "pokemon", new Breed("bulbizard", 10), new MedicalFile("ok"));
			
			t_cabinet.addAnimal(t_animal);
			
			System.out.println("Animal sended");
		}
		
	
		//send subbreed (unknow class from model) (don't work)
		/*
		{
			InterfaceBreed t_subbreed = new SubBreed("toto", 42);
			
			t_cabinet.testBreed(t_subbreed);
		}
		*/
		
		//get animal by name
		/*
		{
			t_animal = t_cabinet.getAnimalByName("test");
			
			
			if(t_animal == null)
				System.out.println("Animal not found");
			else
			{
				System.out.println("Animal founded");

				System.out.println(t_animal.getInfos());
			}
		}
		*/
		
		//change state
		/*
		{
			t_animal.getMedicalFile().setState("new state");
			
			System.out.println(t_animal.getInfos());
		}
		*/
		
		//remove animal
		/*
		{

			t_cabinet.removeAnimal(t_animal);
		}
		*/
		
		System.out.println("Please, press enter to disconnect");
		
		System.in.read();
		
		t_cabinet.removeVeterinary(t_veterinary);
		
		System.exit(0);
	}
}