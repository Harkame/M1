package client;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Scanner;

import model.animal.breed.subbreed.InterfaceSubBreed;
import model.animal.breed.subbreed.SubBreed;

public class Client
{
	private Client(){}
	
	public static void main(String [] args)
	{
		try
		{
			Registry t_registry = LocateRegistry.getRegistry(1100);
			
			InterfaceCabinet t_cabinet = (InterfaceCabinet) t_registry.lookup("cabinet");
			
			InterfaceVeterinary t_veterinary = new Veterinary();
			
			t_cabinet.addVeterinary(t_veterinary);
			
			InterfaceAnimal t_animal = new Animal(null, null, null, new SubBreed("toto", 42), new MedicalFile("toto"));
			
			t_cabinet.addAnimal(t_animal);
			
			System.out.println("Animal sended");
			
			InterfaceSubBreed t_subbreed = new SubBreed("titi", 47);
			
			t_cabinet.yolo(t_subbreed);
			
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