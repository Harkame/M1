

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceVeterinary extends Remote
{
	public void alert(String p_alert)  throws RemoteException;;
}
