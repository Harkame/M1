

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Animal extends UnicastRemoteObject implements InterfaceAnimal
{
	private static final long serialVersionUID = 1L;
	
	private String a_name;
	private String a_master_name;
	private String a_race;
	
	private InterfaceBreed a_breed;
	
	private InterfaceMedicalFile a_medical_file;
	
	
	public Animal(String p_name, String p_master_name, String p_race, Breed p_breed, InterfaceMedicalFile p_medical_file) throws RemoteException
	{
		a_name = p_name;
		a_master_name = p_master_name;
		a_race = p_race;
		
		a_breed = p_breed;
		
		a_medical_file = p_medical_file;
	}
	
	@Override
	public String toString()
	{
		StringBuilder r_to_string = new StringBuilder();
		
		r_to_string.append("Animal");
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("{");			
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("Name  : ");
		r_to_string.append(a_name);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("Master : ");
		r_to_string.append(a_master_name);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("Race  : ");
		r_to_string.append(a_race);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append(a_breed.toString());
		r_to_string.append(a_medical_file.toString());
		r_to_string.append("}");	
		r_to_string.append(System.getProperty("line.separator"));
		
		return r_to_string.toString();
	}
	
	public String getName() throws RemoteException
	{
		return a_name;
	}

	public String getInfos() throws RemoteException
	{
		return toString();
	}

	@Override
	public InterfaceBreed getBreed() throws RemoteException
	{
		return a_breed;
	}
	
	@Override
	public InterfaceMedicalFile getMedicalFile() throws RemoteException
	{
		return a_medical_file;
	}
}
