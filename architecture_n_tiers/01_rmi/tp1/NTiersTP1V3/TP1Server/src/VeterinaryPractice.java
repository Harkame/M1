
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

public class VeterinaryPractice extends UnicastRemoteObject implements InterfaceVeterinaryPractice
{
	private static final long serialVersionUID = 1L;
	
	private Map<String, InterfaceAnimal> a_animals;
	private Collection<InterfaceVeterinary> a_veterinarys;
	
	public VeterinaryPractice() throws RemoteException
	{
		a_animals = new HashMap<String, InterfaceAnimal>();
		
		a_veterinarys = new ArrayList<InterfaceVeterinary>();
	}
	
	@Override
	public void addAnimal(InterfaceAnimal p_animal_to_add) throws RemoteException
	{
		System.out.println("addAnimal");
		System.out.println(p_animal_to_add.getInfos());
		
		a_animals.put(p_animal_to_add.getName(), p_animal_to_add);

		switch(a_animals.size())
		{
			case 1 :
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + " population faible : " + a_animals.size() + " - " + p_animal_to_add.getName());
			break;
				
			case 2:
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + "  population moyenne " + a_animals.size() + " - " + p_animal_to_add.getName());
			break;
				
			case 3:
				for(InterfaceVeterinary t_veterinary : a_veterinarys)
					t_veterinary.alert(System.getProperty("line.separator") + "  population forte " + a_animals.size() + " - " + p_animal_to_add.getName());
			break;
			
			default:
				break;
		}
	}
	
	@Override
	public void removeAnimal(String p_animal_to_remove) throws RemoteException
	{
		System.out.println("removeAnimal");
		
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
		System.out.println("addVeterinary");
		
		a_veterinarys.add(p_veterinary_to_add);
	}
	
	@Override
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException
	{
		System.out.println("getAnimal");
		
		return a_animals.get(p_animal_name);
	}

}
