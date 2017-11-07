package compiler.factory;

import compiler.component.generator.AbstractGenerator;
import compiler.component.generator.GeneratorJava;
import compiler.component.lexer.AbstractLexer;
import compiler.component.lexer.LexerJava;
import compiler.component.parser.AbstractParser;
import compiler.component.parser.ParserJava;

public class CompilerFactoryJava extends AbstractCompilerFactory
{

	@Override
	public AbstractGenerator createGenerator()
	{
		return new GeneratorJava();
	}

	@Override
	public AbstractLexer createLexer()
	{
		return new LexerJava();
	}

	@Override
	public AbstractParser createParser()
	{
		return new ParserJava();
	}

}
