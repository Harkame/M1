package compiler;
import compiler.component.generator.AbstractGenerator;
import compiler.component.lexer.AbstractLexer;
import compiler.component.parser.AbstractParser;
import compiler.factory.AbstractCompilerFactory;

public class Compiler
{
	private String a_language;
	private AbstractLexer a_lexer;
	private AbstractParser a_parser;
	private AbstractGenerator a_generator;
	
	public Compiler(String p_language) throws Exception
	{
		a_language = p_language;
		
		AbstractCompilerFactory t_factory = AbstractCompilerFactory.getFactory(a_language);

		a_lexer = t_factory.createLexer();
		a_parser = t_factory.createParser();
		a_generator = t_factory.createGenerator();
	}

	public void compil(String p_text)
	{		
		a_lexer.lexe(p_text);
		a_parser.parse(p_text);
		a_generator.generate(p_text);	
	}
}
