


import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public abstract class Server
{
	private static final String JAVA_PROPERTY_HOST = "java.rmi.server.hostname";
	private static final String JAVA_PROPERTY_HOST_VALUE = "localhost";
	
	private static final String JAVA_PROPERTY_POLICY = "java.security.policy";
	private static final String JAVA_SECURITY_POLICY_SERVER = "./server.policy";
	
	private static final String JAVA_PROPERTY_CODEBASE = "java.rmi.codebase";
	private static final String JAVA_POLICY_CODEBASE_VALUE = "file:../../../TP1Client/bin";
	
	private static final int DEFAULT_PORT = 1099;
	private static final String DEFAULT_REGISTRY_KEY = "cabinet";
	
	private static final String MESSAGE_REGISTRY_CREATED = "Registry created";
	private static final String MESSAGE_REGISTRY_BINDED = "Registry binded";
	
	private static final String ERROR_MESSAGE_REGISTRY_NOT_FOUND = "Registry not found";
	
	public static void main(String args[]) throws RemoteException
	{
		System.setProperty(JAVA_PROPERTY_HOST, JAVA_PROPERTY_HOST_VALUE);
		System.setProperty(JAVA_PROPERTY_POLICY, JAVA_SECURITY_POLICY_SERVER);
		System.setProperty(JAVA_PROPERTY_CODEBASE, JAVA_POLICY_CODEBASE_VALUE);
		
		if(System.getSecurityManager() == null)
	        System.setSecurityManager(new SecurityManager());
	
		Registry t_registry = LocateRegistry.createRegistry(DEFAULT_PORT);

		System.out.println(MESSAGE_REGISTRY_CREATED + " [PORT : " + DEFAULT_PORT + "]");
		
		if(t_registry == null)
		{
			System.err.println(ERROR_MESSAGE_REGISTRY_NOT_FOUND);
			
			System.exit(1);
		}
		
		InterfaceCabinet t_cabinet = new Cabinet();
		
		t_cabinet.addAnimal(new Animal("test", "test", "test", new Breed("test", 42), new MedicalFile("test")));
		
		t_registry.rebind(DEFAULT_REGISTRY_KEY, t_cabinet);
		
		System.out.println(MESSAGE_REGISTRY_BINDED + " [KEY : " + DEFAULT_REGISTRY_KEY + "]");
	}
}
