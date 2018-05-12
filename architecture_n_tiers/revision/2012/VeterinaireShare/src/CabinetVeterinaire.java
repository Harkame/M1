import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

public interface CabinetVeterinaire extends Remote
{
	ArrayList<Dossier> getDossierByOwnerName(String ownerNam) throws RemoteException;
}
