import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.*;
import org.mockito.Mockito;

import static org.junit.Assert.*;
import static org.mockito.Mockito.*;

@RunWith(MockitoJUnitRunner.class) 
public class TestC
{
	@Mock
	private C a_mock     = new C();
	
	@Before
	public void setUp()
	{
		when(a_mock.m2(42)).thenReturn(0); //Impossible car final
	}

	@Test
	public void testM1()
	{
		assertEquals(C.m1(), 42);
	}
	
	@Test
	public void testM2()
	{
		assertEquals(a_mock.m2(3), 9);

		//assertEquals(a_mock.m2(42), 0);
		//assertEquals(a_mock.m2(42), 1764); //Le spy garde le comportement avant
	}
}
