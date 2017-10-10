import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.*;
import org.mockito.Mockito;

import static org.junit.Assert.*;
import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class) 
public class TestA
{
	@Mock
	private A a_mock     = new A();
	private A a_mock_spy = spy(a_mock);
	
	@Before
	public void setUp()
	{
		when(a_mock.m2(42)).thenReturn(0);
	}

	@Test
	public void testM1()
	{
		assertEquals(a_mock_spy.m1(), 42);
		
		verify(a_mock_spy, atLeastOnce()).m1();
	}
	
	@Test
	public void testM2()
	{
		assertEquals(a_mock_spy.m2(3), 9);

		assertEquals(a_mock.m2(42), 0);
		assertEquals(a_mock_spy.m2(42), 1764); //Le spy garde le comportement avant
	}
}
