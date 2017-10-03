package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestOrderedDictionary
{
	final static String[] g_keys_to_put   = {"truc", "machin", "yolo"};
	final static String[] g_values_to_put = {"truc", "macghin", "greger"};
	
	private OrderedDictionary a_ordered_dictionary;
	
	@Before
	public void setUp() throws Exception
	{
		a_ordered_dictionary = new OrderedDictionary();
	}
	
	@Test
	public void testAddElement()
	{
		assertEquals(0, a_ordered_dictionary.getSize());
		assertTrue(a_ordered_dictionary.isEmpty());
		
		a_ordered_dictionary.put(g_keys_to_put[0], g_values_to_put[0]);
		
		assertEquals(1, a_ordered_dictionary.getSize());
		assertTrue(a_ordered_dictionary.containsKey(g_keys_to_put[0]));
		assertTrue(a_ordered_dictionary.get(g_keys_to_put[0]) != null);
	}
	
	@Test
	public void testAddElements()
	{
		assertEquals(0, a_ordered_dictionary.getSize());
		assertTrue(a_ordered_dictionary.isEmpty());

		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			a_ordered_dictionary.put(g_keys_to_put[g_index], g_values_to_put[g_index]);
		
		assertEquals(3, a_ordered_dictionary.getSize());
		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			assertTrue(a_ordered_dictionary.containsKey(g_keys_to_put[g_index]));
	}
}
