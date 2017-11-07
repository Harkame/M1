package game_factory;

import java.util.Random;

public class GameFactoryEasy extends AbstractGameFactory
{
	@Override
	public String createCryptedWord(String p_text)
	{
		StringBuilder r_crypted_text = new StringBuilder();
		
		int t_percent = (p_text.length() * 70) / 100;
		
		Random rand = new Random();
		
		for(int t_index = 0; t_index < t_percent; t_index++)
		{
			int t_random_index = rand.nextInt((75 - 0) + 1) + 0;
			int count = 0;
			int i;
		    for (i=0x2500;i<=0x257F;i++)
		    {
		        if(count == t_random_index)
		        	break;
		        count++;
		    }
			
			r_crypted_text.append((char) i);
		}
		
		r_crypted_text.append(p_text.substring(t_percent, p_text.length()));
		
		return r_crypted_text.toString();
	}
}
