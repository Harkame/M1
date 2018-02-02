

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceMedicalFile extends Remote
{
	public void setState(String p_new_state) throws RemoteException;
	
	public String getState() throws RemoteException;
}
