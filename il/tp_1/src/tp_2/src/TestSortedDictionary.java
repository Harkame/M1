package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestSortedDictionary
{
	final static String[] g_keys_to_put   = {"truc", "machin", "yolo"};
	final static String[] g_values_to_put = {"truc", "macghin", "greger"};
	
	private SortedDictionary a_sorted_dictionary;
	
	@Before
	public void setUp() throws Exception
	{
		a_sorted_dictionary = new SortedDictionary();
	}
	
	@Test
	public void testAddElement()
	{
		assertEquals(0, a_sorted_dictionary.getSize());
		assertTrue(a_sorted_dictionary.isEmpty());
		
		a_sorted_dictionary.put("clef", "Yolo");
		
		assertEquals(1, a_sorted_dictionary.getSize());
		assertTrue(a_sorted_dictionary.containsKey("clef"));
		assertTrue(a_sorted_dictionary.get(g_keys_to_put[0]) != null);
	}
	
	@Test
	public void testAddElements()
	{
		assertEquals(0, a_sorted_dictionary.getSize());
		assertTrue(a_sorted_dictionary.isEmpty());

		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			a_sorted_dictionary.put(g_keys_to_put[g_index], g_values_to_put[g_index]);
		
		assertEquals(3, a_sorted_dictionary.getSize());
		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			assertTrue(a_sorted_dictionary.containsKey(g_keys_to_put[g_index]));
	}
}
