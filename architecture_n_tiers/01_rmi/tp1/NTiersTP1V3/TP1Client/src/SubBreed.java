import java.rmi.RemoteException;

public class SubBreed extends Breed implements InterfaceSubBreed
{
	private static final long serialVersionUID = 1L;

	public SubBreed(String p_name, int p_life) throws RemoteException
	{
		super(p_name, p_life);
	}

	@Override
	public void yolo() throws RemoteException
	{
	}
}
