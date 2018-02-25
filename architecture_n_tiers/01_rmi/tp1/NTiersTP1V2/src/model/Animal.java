package model;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Animal extends UnicastRemoteObject implements InterfaceAnimal
{
	private String a_name;
	private String a_master_name;
	private String a_race;
	private Breed a_breed;
	
	private Dossier a_dossier;
	
	
	public Animal(String p_name, String p_master_name, String p_race, String p_breed_name, int p_breed_life, String p_state) throws RemoteException
	{
		a_name = p_name;
		a_master_name = p_master_name;
		a_race = p_race;
		
		a_breed = new Breed(p_breed_name, p_breed_life);
		
		a_dossier = new Dossier(p_state);
	}
	
	@Override
	public String toString()
	{
		StringBuilder r_to_string = new StringBuilder();
		
		r_to_string.append(a_name);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append(a_master_name);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append(a_race);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append(a_breed);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append(a_dossier.toString());
		r_to_string.append(System.getProperty("line.separator"));
		
		return r_to_string.toString();
	}

	public String getInfos() throws RemoteException
	{
		return toString();
	}
	
	public String getName() throws RemoteException
	{
		return a_name;
	}

	@Override
	public InterfaceBreed getBreed() throws RemoteException
	{
		return a_breed;
	}
}
