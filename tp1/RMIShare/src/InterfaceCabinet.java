

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceCabinet extends Remote
{
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException;
	
	public void addAnimal(InterfaceAnimal p_animal_to_add) throws RemoteException;
	
	public void removeAnimal(InterfaceAnimal p_animal_to_add) throws RemoteException;
	
	public void addVeterinary(InterfaceVeterinary p_veterinary_to_add) throws RemoteException;
	
	public void removeVeterinary(InterfaceVeterinary p_veterinary_to_remove) throws RemoteException;
	
	public void yolo(InterfaceBreed p_breed) throws RemoteException;
}
