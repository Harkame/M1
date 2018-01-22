package model;

public class Dossier
{
	private String a_state;
	
	public Dossier(String p_state)
	{
		a_state = p_state;
	}
	
	@Override
	public String toString()
	{
		return "Dossier : " + a_state;
	}
}
