import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.*;
import org.mockito.Mockito;

import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class) 
public class TestI
{
	@Mock
	private I a_mock = Mockito.mock(I.class);
	
	@Before
	public void setUp() throws Exception
	{
		when(a_mock.methodeInt()).thenReturn(1, 2, 3, 4);
		doThrow(new Exception()).when(a_mock).methodVoid();
	}
	
	@Test
	public void testMetodeInt() throws Exception
	{
		for(int t_index = 1; t_index <= 4; t_index++)
			assertEquals(a_mock.methodeInt(), t_index);
		
		verify(a_mock, times(4)).methodeInt();
	}
	
	@Test(expected = Exception.class)
	public void testMethodVoid() throws Exception
	{
		a_mock.methodVoid();
	}
	
	public void testMethodParam()
	{
		assertEquals(a_mock.methodeParam(0), 0);
		assertEquals(a_mock.methodeParam(3), 3);
		assertEquals(a_mock.methodeParam(5), 10);
	}
}
