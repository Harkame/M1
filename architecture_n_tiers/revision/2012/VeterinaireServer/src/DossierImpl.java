import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class DossierImpl extends UnicastRemoteObject implements Dossier
{
	private static final long serialVersionUID = 1L;
	
	private String ownerName;
	private String animalName;
	
	public DossierImpl(String ownerName, String animalName) throws RemoteException
	{
		super();
		this.ownerName = ownerName;
		this.animalName = animalName;
	}
	
	public String getOwnerName() throws RemoteException
	{
		return ownerName;
	}
	
	public String getAnimalName() throws RemoteException
	{
		return animalName;
	}
}
