
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Cabinet extends UnicastRemoteObject implements InterfaceCabinet
{
	private static final long serialVersionUID = 1L;
	
	private Map<String, InterfaceAnimal> a_animals;
	private List<InterfaceVeterinary> a_veterinarys;
	
	public Cabinet() throws RemoteException
	{
		a_animals = new HashMap<String, InterfaceAnimal>();
		
		a_veterinarys = new ArrayList<InterfaceVeterinary>();
	}
	
	@Override
	public void addAnimal(InterfaceAnimal p_animal_to_add) throws RemoteException
	{
		System.out.println(p_animal_to_add.getInfos());
		
		a_animals.put(p_animal_to_add.getName(), p_animal_to_add);
		
		
		int t_seuil = 0;
		
		switch(a_animals.size())
		{
			case 1 :
				t_seuil = 1;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
				
			case 2:
				t_seuil = 2;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
				
			case 3:
				t_seuil = 3;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
		}
	}
	
	@Override
	public void removeAnimal(InterfaceAnimal p_animal_to_remove) throws RemoteException
	{
		a_animals.remove(p_animal_to_remove).getName();
		
		int t_seuil = 0;
		
		switch(a_animals.size())
		{
			case 1 :
				t_seuil = 1;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
				
			case 2:
				t_seuil = 2;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
				
			case 3:
				t_seuil = 3;
				
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " Seuil " + t_seuil);
			break;
		}
	}
	
	@Override
	public void addVeterinary(InterfaceVeterinary p_veterinary_to_add) throws RemoteException
	{
		a_veterinarys.add(p_veterinary_to_add);
	}
	
	@Override
	public void removeVeterinary(InterfaceVeterinary p_veterinary_to_remove) throws RemoteException
	{
		a_veterinarys.remove(p_veterinary_to_remove);
	}
		
	@Override
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException
	{
		return a_animals.get(p_animal_name);
	}
	
	public void yolo(InterfaceBreed p_breed) throws RemoteException
	{
		System.out.println("LeYolo");
		System.out.println(p_breed.getInfos());
	}
}
