

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceBreed extends Remote
{
	public String getInfos() throws RemoteException;
}
