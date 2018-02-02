

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class MedicalFile extends UnicastRemoteObject implements InterfaceMedicalFile
{
	private static final long serialVersionUID = 1L;
	
	private String a_state;
	
	public MedicalFile(String p_state) throws RemoteException
	{
		a_state = p_state;
	}
	
	@Override
	public String toString()
	{
		return "Dossier : " + a_state;
	}

	@Override
	public void setState(String p_new_state) throws RemoteException
	{
		a_state = p_new_state;
	}

	@Override
	public String getState() throws RemoteException
	{
		return a_state;
	}
}
