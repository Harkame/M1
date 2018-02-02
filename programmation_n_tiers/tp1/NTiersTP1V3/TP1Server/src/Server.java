

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Server
{
	private static final String JAVA_PROPERTY_LINE_SEPARATOR = "line.separator";
	
	private static final String JAVA_PROPERTY_POLICY = "java.security.policy";
	private static final String JAVA_PROPERTY_CODEBASE = "java.rmi.codebase";
	
	private static final String JAVA_SECURITY_POLICY_SERVER = "server.policy";
	private static final String JAVA_SECURITY_POLICY_CLIENT = "client.policy";
	
	private static final String JAVA_POLICY_CODEBASE_VALUE = "/auto_home/harkame/workspace/TPNTiersV3/bin/";
	
	private static final int DEFAULT_PORT = 1100;
	private static final String DEFAULT_REGISTRY_KEY = "cabinet";
	
	private static final String MESSAGE_REGISTRY_CREATED = "Registry created";
	private static final String MESSAGE_REGISTRY_BINDED = "Registry binded";
	
	private static final String ERROR_MESSAGE_REGISTRY_NOT_FOUND = "Registry not found";
	
	private static final String ERROR_MESSAGE_EXCEPTION = "Error : ";
	
	private static final String ASK_MESSAGE_METHOD_ADD = "add";
	private static final String ASK_MESSAGE_METHOD_REMOVE = "remove";
	
	private static final String ASK_MESSAGE_METHOD = "add/remove : ";
	private static final String ASK_MESSAGE_RANGE_A = "range a : ";
	private static final String ASK_MESSAGE_RANGE_B = "range b : ";
	
	public Server(){}
	
	public static void main(String args[])
	{
		try
		{
			System.setProperty(JAVA_PROPERTY_POLICY, JAVA_SECURITY_POLICY_SERVER);
			//System.setProperty(JAVA_PROPERTY_CODEBASE, JAVA_POLICY_CODEBASE_VALUE);
			
			if(System.getSecurityManager() == null)
		        System.setSecurityManager(new SecurityManager());
		
			Registry t_registry = LocateRegistry.createRegistry(DEFAULT_PORT);

			System.out.println(MESSAGE_REGISTRY_CREATED);
			
			if(t_registry == null)
			{
				System.err.println(ERROR_MESSAGE_REGISTRY_NOT_FOUND);
				
				return;
			}
			
			InterfaceCabinet t_cabinet = new Cabinet();
			
			t_registry.rebind(DEFAULT_REGISTRY_KEY, t_cabinet);
			
			System.out.println(MESSAGE_REGISTRY_BINDED);
			
		}
		catch(Exception t_exception)
		{
			System.err.println(ERROR_MESSAGE_EXCEPTION + t_exception.toString());
			t_exception.printStackTrace();
		}
	}
}
