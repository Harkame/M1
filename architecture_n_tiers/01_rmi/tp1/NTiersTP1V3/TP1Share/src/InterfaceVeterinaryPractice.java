

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceVeterinaryPractice extends Remote
{
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException;
	
	public void addAnimal(InterfaceAnimal p_animal_to_add) throws RemoteException;
	
	public void removeAnimal(String p_animal_name) throws RemoteException;
	
	public void addVeterinary(InterfaceVeterinary p_veterinary_to_add) throws RemoteException;
}
