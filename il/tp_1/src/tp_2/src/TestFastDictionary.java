package tp_2.src;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class TestFastDictionary
{
	final static String[] g_keys_to_put   = {"truc", "machin", "yolo"};
	final static String[] g_values_to_put = {"truc", "macghin", "greger"};
	
	private FastDictionary a_fast_dictionary;
	
	@Before
	public void setUp() throws Exception
	{
		a_fast_dictionary = new FastDictionary();
	}
	
	@Test
	public void testAddElement()
	{
		assertEquals(0, a_fast_dictionary.getSize());
		assertTrue(a_fast_dictionary.isEmpty());
		
		a_fast_dictionary.put("clef", "Yolo");
		
		assertEquals(1, a_fast_dictionary.getSize());
		assertTrue(a_fast_dictionary.containsKey("clef"));
		assertTrue(a_fast_dictionary.get(g_keys_to_put[0]) != null);
	}
	
	@Test
	public void testAddElements()
	{
		assertEquals(0, a_fast_dictionary.getSize());
		assertTrue(a_fast_dictionary.isEmpty());

		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			a_fast_dictionary.put(g_keys_to_put[g_index], g_values_to_put[g_index]);
		
		assertEquals(3, a_fast_dictionary.getSize());
		
		for(int g_index = 0; g_index < g_keys_to_put.length; g_index++)
			assertTrue(a_fast_dictionary.containsKey(g_keys_to_put[g_index]));
	}
}
