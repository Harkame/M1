package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestDictionary
{
	@Suite.SuiteClasses({
		   TestOrderedDictionary.class,
		   TestFastDictionary.class,
		   TestSortedDictionary
		})
}
