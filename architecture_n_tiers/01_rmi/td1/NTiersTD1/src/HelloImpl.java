
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class HelloImpl extends UnicastRemoteObject implements Hello
{
	public HelloImpl() throws RemoteException{}
	
	public String sayHello() throws RemoteException
	{
		return "";
	}
	
	public void printHello() throws RemoteException
	{
		System.out.println("");
	}
}