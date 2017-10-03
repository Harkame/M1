package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestDictionary
{
	private TestOrderedDictionary a_test_ordered_dictionary;
	private TestFastDictionary a_test_fast_dictionary;
	private TestSortedDictionary a_test_sorted_dictionary;
	
	@Before
	public void setUp() throws Exception
	{
		a_test_ordered_dictionary = new TestOrderedDictionary();
		a_test_fast_dictionary = new TestFastDictionary();
		a_test_sorted_dictionary = new TestSortedDictionary();
	}
	
	@Test
	public void testAddElement()
	{
		a_test_ordered_dictionary.testAddElement();
		a_test_fast_dictionary.testAddElement();
		a_test_sorted_dictionary.testAddElement();
	}
	
	@Test
	public void testAddElements()
	{
		a_test_ordered_dictionary.testAddElements();
		a_test_fast_dictionary.testAddElements();
		a_test_sorted_dictionary.testAddElements();
	}
}
