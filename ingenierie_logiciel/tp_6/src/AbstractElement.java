
public abstract class AbstractElement extends AbstractStoringElement
{
	public AbstractElement(String p_absolute_address)
	{
		super(0, p_absolute_address);
	}
	
	public abstract void cat();
}
