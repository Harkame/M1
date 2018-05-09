

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Server
{
	private static final String JAVA_PROPERTY_POLICY = "java.security.policy";

	private static final String JAVA_SECURITY_POLICY_SERVER = "..\\server.policy";
	private static final int DEFAULT_PORT = 1100;
	private static final String DEFAULT_REGISTRY_KEY = "veterinary_practice";

	private static final String MESSAGE_REGISTRY_CREATED = "Registry created";
	private static final String MESSAGE_REGISTRY_BINDED = "Registry binded";

	private static final String ERROR_MESSAGE_REGISTRY_NOT_FOUND = "Registry not found";

	private static final String ERROR_MESSAGE_EXCEPTION = "Error : ";

	public static void main(String args[])
	{
		/*
		System.setProperty("java.security.policy", "file:D:\\workspace\\RMI\\TP1Server\\client.policy");
		System.setProperty("java.rmi.server.codebase","file:D:\\workspace\\RMI\\TP1Client\\bin\\");

		System.setSecurityManager(new SecurityManager());
		*/

		try
		{
			//System.setProperty(JAVA_PROPERTY_POLICY, JAVA_SECURITY_POLICY_SERVER);
			//System.setProperty(JAVA_PROPERTY_CODEBASE, JAVA_POLICY_CODEBASE_VALUE);

			//System.setSecurityManager(new SecurityManager());

			Registry t_registry = LocateRegistry.createRegistry(DEFAULT_PORT);

			System.out.println(MESSAGE_REGISTRY_CREATED);

			if(t_registry == null)
			{
				System.err.println(ERROR_MESSAGE_REGISTRY_NOT_FOUND);

				return;
			}

			InterfaceVeterinaryPractice t_veterinary_practice = new VeterinaryPractice();

			t_registry.rebind(DEFAULT_REGISTRY_KEY, t_veterinary_practice);

			System.out.println(MESSAGE_REGISTRY_BINDED);

		}
		catch(Exception t_exception)
		{
			System.err.println(ERROR_MESSAGE_EXCEPTION + t_exception.toString());
			t_exception.printStackTrace();
		}
	}
}
