import java.rmi.Remote;
import java.rmi.RemoteException;

public interface Dossier extends Remote
{
	public String getOwnerName() throws RemoteException;
	public String getAnimalName() throws RemoteException;
}
