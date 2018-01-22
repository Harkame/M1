package model;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceCabinet extends Remote
{
	public InterfaceAnimal getAnimal(String p_animal_name) throws RemoteException;
}
