package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestSortedDictionary
{
	final static String[] g_keys_to_put   = {"truc", "machin", "yolo"};
	final static String[] g_values_to_put = {"truc", "macghin", "greger"};
	
	private SortedDictionary g_sorted_dictionary;
	
	@Before
	public void setUp() throws Exception
	{
		g_sorted_dictionary = new SortedDictionary();
	}
	
	@Test
	public void testAddElement()
	{
		assertEquals(0, g_sorted_dictionary.getSize());
		assertTrue(g_sorted_dictionary.isEmpty());
		
		g_sorted_dictionary.put("clef", "Yolo");
		
		assertEquals(1, g_sorted_dictionary.getSize());
		assertTrue(g_sorted_dictionary.containsKey("clef"));
	}
	
	@Test
	public void testAddElements()
	{
		assertEquals(0, g_sorted_dictionary.getSize());
		assertTrue(g_sorted_dictionary.isEmpty());

		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			g_sorted_dictionary.put(g_keys_to_put[g_index], g_values_to_put[g_index]);
		
		assertEquals(3, g_sorted_dictionary.getSize());
		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			assertTrue(g_sorted_dictionary.containsKey(g_keys_to_put[g_index]));
	}
}
