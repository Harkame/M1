package compiler.factory;

import compiler.component.generator.AbstractGenerator;
import compiler.component.generator.GeneratorCpp;
import compiler.component.lexer.AbstractLexer;
import compiler.component.lexer.LexerCpp;
import compiler.component.parser.AbstractParser;
import compiler.component.parser.ParserCpp;

public class CompilerFactoryCpp extends AbstractCompilerFactory
{

	@Override
	public AbstractGenerator createGenerator()
	{
		return new GeneratorCpp();
	}

	@Override
	public AbstractLexer createLexer()
	{
		return new LexerCpp();
	}

	@Override
	public AbstractParser createParser()
	{
		return new ParserCpp();
	}

}
