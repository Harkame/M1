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
	public void testEmpty()
	{
		assertTrue(a_ordered_dictionary.isEmpty());
		
		a_ordered_dictionary.put(g_keys_to_put[0], g_values_to_put[0]);
		
		assertFalse(a_ordered_dictionary.isEmpty());
	}
	
	@Test
	public void testSize()
	{
		assertEquals(0, a_ordered_dictionary.getSize());
		
		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
		{
			assertEquals(t_index, a_ordered_dictionary.getSize());
			a_ordered_dictionary.put(g_keys_to_put[t_index], g_values_to_put[t_index]);
			assertEquals(t_index + 1, a_ordered_dictionary.getSize());
		}
	}
	
	@Test
	public void testAddElements()
	{
		assertEquals(0, a_ordered_dictionary.getSize());
		assertTrue(a_ordered_dictionary.isEmpty());

		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			a_ordered_dictionary.put(g_keys_to_put[t_index], g_values_to_put[t_index]);
		
		assertEquals(3, a_ordered_dictionary.getSize());
		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			assertTrue(a_ordered_dictionary.containsKey(g_keys_to_put[t_index]));
	}
	
	@Test
	public void testAddSameElements()
	{
		assertEquals(0, a_ordered_dictionary.getSize());
		assertTrue(a_ordered_dictionary.isEmpty());

		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			a_ordered_dictionary.put(g_keys_to_put[t_index], g_values_to_put[t_index]);
		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			a_ordered_dictionary.put(g_keys_to_put[t_index], g_values_to_put[t_index]);
		
		assertEquals(3, a_ordered_dictionary.getSize());
		
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			assertTrue(a_ordered_dictionary.containsKey(g_keys_to_put[t_index]));
	}
	
	@Test
	public void testGetElement()
	{	
		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			a_ordered_dictionary.put(g_keys_to_put[t_index], g_values_to_put[t_index]);

		for(int t_index = 0; t_index < g_keys_to_put.length; t_index++)
			assertEquals(a_ordered_dictionary.get(g_keys_to_put[t_index]), g_values_to_put[t_index]);
		
		assertNull(a_ordered_dictionary.get("oyotrohtrkk"));
	}
}
