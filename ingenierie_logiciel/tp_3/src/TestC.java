import static org.junit.Assert.assertEquals;
import static org.mockito.ArgumentMatchers.anyInt;
import static org.mockito.Mockito.when;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.powermock.api.mockito.PowerMockito;
import org.powermock.core.classloader.annotations.PrepareForTest;
import org.powermock.modules.junit4.PowerMockRunner;


@RunWith(PowerMockRunner.class)
@PrepareForTest(C.class)
public class TestC
{
	@Mock
	private C a_mock     = new C();
	
	@Test
	public void testM1()
	{
		PowerMockito.mockStatic(C.class);
		when(C.m1()).thenReturn(42); //Impossible car final
		assertEquals(C.m1(), 42);
	}
	
	@Test
	public void testM2()
	{
		C t_mock = PowerMockito.mock(C.class);
		when(t_mock.m2(anyInt())).thenReturn(0); //Impossible car final
		assertEquals(t_mock.m2(anyInt()), 0);
	}
}
