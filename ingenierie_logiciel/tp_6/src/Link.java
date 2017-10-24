
public class Link extends AbstractElement
{
	private AbstractElement a_content;
	
	public Link(String p_absolute_address)
	{
		super(p_absolute_address);
	}
	
	@Override
	public int countContent()
	{
		return 1;
	}
	
	@Override
	public void cat()
	{
		a_content.cat();
	}
}
