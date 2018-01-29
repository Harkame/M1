

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Veterinary extends UnicastRemoteObject implements InterfaceVeterinary
{
	private static final long serialVersionUID = 1L;

	public Veterinary() throws RemoteException
	{
		
	}
	
	@Override
	public void alert(String p_alert) throws RemoteException
	{
		System.out.println("[ALERT] : " + p_alert);
	}
}
