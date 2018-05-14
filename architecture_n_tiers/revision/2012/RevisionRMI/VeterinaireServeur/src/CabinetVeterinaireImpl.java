import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

public class CabinetVeterinaireImpl extends UnicastRemoteObject implements CabinetVeterinaire
{	
	private static final long	serialVersionUID	= 1L;
	//private ArrayList<Dossier>	dossiers			= new ArrayList<Dossier>();
	private ArrayList<DossierImpl>	dossiers			= new ArrayList<DossierImpl>();
	public CabinetVeterinaireImpl() throws RemoteException
	{
	}

	public void addDossier(DossierImpl d)
	{
		dossiers.add(d);
	}

	public ArrayList<Dossier> getDossierByOwnerName(String ownerName) throws RemoteException
	{
		ArrayList<Dossier> result = new ArrayList<Dossier>();
		for(Dossier d : dossiers)
		{
			if(d.getOwnerName().equals(ownerName))
			{
				result.add(d);
			}
		}
		return result;
	}

	@Override
	public UnTruc getUnTreuc() throws RemoteException
	{
		return new UnTrucImpl();
	}

	@Override
	public Dossier getDossier() throws RemoteException
	{
		return new DossierImpl("UnTruc", "Marchin");
	}
}