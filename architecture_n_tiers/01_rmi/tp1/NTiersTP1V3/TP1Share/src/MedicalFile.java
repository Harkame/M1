

import java.io.Serializable;
import java.rmi.RemoteException;

public class MedicalFile implements InterfaceMedicalFile, Serializable
{
	private static final long serialVersionUID = 1L;
	
	private String a_state;
	
	public MedicalFile(String p_state) throws RemoteException
	{
		a_state = p_state;
	}
	
	@Override
	public String toString()
	{
		StringBuilder r_to_string = new StringBuilder();
		
		r_to_string.append("Medical file");	
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("{");
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("\t");
		r_to_string.append(a_state);
		r_to_string.append(System.getProperty("line.separator"));
		r_to_string.append("}");
		r_to_string.append(System.getProperty("line.separator"));
		
		return r_to_string.toString();
	}

	@Override
	public void setState(String p_new_state) throws RemoteException
	{
		a_state = p_new_state;
	}

	@Override
	public String getState() throws RemoteException
	{
		return a_state;
	}
}
