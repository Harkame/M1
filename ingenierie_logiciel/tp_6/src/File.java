
public class File extends AbstractElement
{
	private String a_content;
	
	public File(String p_absolute_address)
	{
		super(p_absolute_address);
	}

	@Override
	public int countContent()
	{
		return a_content.length();
	}
	
	@Override
	public void cat()
	{
		System.out.println(a_content);
	}
}
