package model;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.HashMap;
import java.util.Map;

public class Cabinet extends UnicastRemoteObject implements InterfaceCabinet
{
	private Map<String, InterfaceAnimal> a_animals;
	
	public Cabinet() throws RemoteException
	{
		a_animals = new HashMap<String, InterfaceAnimal>();
		
		Animal t_animal_1 = new Animal("toto", "masterYolo", "Pokemon", "Bulbizouille", 42, "Alive");
		Animal t_animal_2 = new Animal("titi", "masterYolo", "Pokemon", "Bulbizouille", 42, "Alive");
		Animal t_animal_3 = new Animal("tutu", "masterYolo", "Pokemon", "Bulbizouille", 42, "Alive");
		
		a_animals.put(t_animal_1.getName(), t_animal_1);
		a_animals.put(t_animal_2.getName(), t_animal_2);
		a_animals.put(t_animal_3.getName(), t_animal_3);
	}

	@Override
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException
	{
		return a_animals.get(p_animal_name);
	}
}
