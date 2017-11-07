package game_factory;

import java.util.Random;

public class GameFactoryHard extends AbstractGameFactory
{
	@Override
	public String createCryptedWord(String p_text)
	{
		StringBuilder r_crypted_text = new StringBuilder();
		
		int t_percent = (p_text.length() * 80) / 100;
		
		Random rand = new Random();
		
		for(int t_index = 0; t_index < t_percent; t_index++)
		{
			int t_random_index = rand.nextInt((122 - 97) + 1) + 97;
			
			r_crypted_text.append((char) t_random_index);
		}
		
		r_crypted_text.append(p_text.substring(t_percent, p_text.length()));
		
		return r_crypted_text.toString();
	}
}
