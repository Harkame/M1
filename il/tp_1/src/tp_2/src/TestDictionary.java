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
	public void testEmpty()
	{
		a_test_ordered_dictionary.testEmpty();
		a_test_fast_dictionary.testEmpty();
		a_test_sorted_dictionary.testEmpty();
	}
	
	@Test
	public void testSize()
	{
		a_test_ordered_dictionary.testSize();
		a_test_fast_dictionary.testSize();
		a_test_sorted_dictionary.testSize();
	}
	
	@Test
	public void testAddElements()
	{
		a_test_ordered_dictionary.testAddElements();
		a_test_fast_dictionary.testAddElements();
		a_test_sorted_dictionary.testAddElements();
	}
	
	@Test
	public void testAddSameElements()
	{
		a_test_ordered_dictionary.testAddSameElements();
		a_test_fast_dictionary.testAddSameElements();
		a_test_sorted_dictionary.testAddSameElements();
	}
	
	@Test
	public void testGetElement()
	{	
		a_test_ordered_dictionary.testGetElement();
		a_test_fast_dictionary.testGetElement();
		a_test_sorted_dictionary.testGetElement();
	}
	
}
