package game;

import java.util.Scanner;

import game_factory.AbstractGameFactory;

public class Game
{
	String p_word = "hello";
	String p_crypted_word;
	
	public Game(String p_difficulty) throws Exception
	{
		AbstractGameFactory t_game_factory = AbstractGameFactory.getGameFactory(p_difficulty);
		
		p_crypted_word = t_game_factory.createCryptedWord(p_word);
	}
	
	public void play()
	{
		StringBuilder t_command = new StringBuilder();
		Scanner t_scanner = new Scanner(System.in);
		char[] t_char_array = p_crypted_word.toCharArray();
		
		while(true)
		{
			System.out.println(String.valueOf(t_char_array));
			
			System.out.print("> ");
			t_command.append(t_scanner.nextLine());
			
			for(int t_index = 0; t_index < p_word.length(); t_index++)
			{
				if(t_char_array[t_index] == t_command.charAt(0))
					if(t_command.charAt(2) == p_word.charAt(t_index))
						t_char_array[t_index] = t_command.charAt(2);
			}
			
			t_command.setLength(0);
			
			if(String.valueOf(t_char_array).equals(p_word))
			{
				System.out.println(String.valueOf(t_char_array));
				
				System.out.println("Win !");
				t_scanner.close();
				return;
			}
		}
	}
}
