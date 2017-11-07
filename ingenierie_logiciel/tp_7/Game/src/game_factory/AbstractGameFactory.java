package game_factory;

public abstract class AbstractGameFactory
{
	public abstract String createCryptedWord(String p_text);
	
	public static AbstractGameFactory getGameFactory(String p_difficulty) throws Exception
	{
		switch(p_difficulty.toLowerCase())
		{
		case "easy":
			return new GameFactoryEasy();
			
		case "medium":
			return new GameFactoryMedium();
			
		case "hard":
				return new GameFactoryHard();
				
		default:
			throw new Exception("Unknow difficulty");
		}
	}
	
	
}
