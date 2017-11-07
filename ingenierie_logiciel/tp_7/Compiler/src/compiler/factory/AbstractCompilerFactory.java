package compiler.factory;

import compiler.component.generator.AbstractGenerator;
import compiler.component.lexer.AbstractLexer;
import compiler.component.parser.AbstractParser;

public abstract class AbstractCompilerFactory
{
	public abstract AbstractLexer createLexer();
	public abstract AbstractParser createParser();
	public abstract AbstractGenerator createGenerator();
	
	public static AbstractCompilerFactory getFactory(String p_language) throws Exception
	{
		switch(p_language.toLowerCase())
		{
			case "java":
				return new CompilerFactoryJava();
			
			case "cpp":
			case "c++":
				return new CompilerFactoryCpp();
				
			default:
				throw new Exception("Unknow language");
		}
		
	}
}
