


import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceAnimal extends Remote
{
	public String getInfos() throws RemoteException;
	
	public String getName() throws RemoteException;
	
	public InterfaceBreed getBreed() throws RemoteException;
	
	public InterfaceMedicalFile getMedicalFile() throws RemoteException;
}