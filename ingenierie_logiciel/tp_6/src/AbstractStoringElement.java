
public abstract class AbstractStoringElement
{
	private int a_basic_size;
	
	private String a_absolute_address;
	
	public AbstractStoringElement(int p_basic_size, String p_absolute_address)
	{
		a_basic_size  = p_basic_size;
		
		a_absolute_address = p_absolute_address;
	}
	
	public int getSize()
	{
		return a_basic_size;
	}
	
	public void setSize(int p_basic_size)
	{
		a_basic_size = p_basic_size;
	}
	
	public String getAbsoluteAddress()
	{
		return a_absolute_address;
	}
	
	public abstract int countContent();
}
