import java.util.ArrayList;
import java.util.Collection;

public class Directory extends AbstractStoringElement
{
	private Collection<AbstractStoringElement> a_elements;
	
	public Directory(String p_absolute_address)
	{
		super(4, p_absolute_address);
	}
	
	public void ls()
	{
		for(AbstractStoringElement t_element : a_elements)
			System.out.println(t_element.getAbsoluteAddress());
	}
	
	@Override
	public int countContent()
	{
		return a_elements.size();
	}
	
	public Collection<String> find(String p_absolute_address)
	{
		Collection<String> p_searched_elements = new ArrayList<String>();
		
		for(AbstractStoringElement t_element : a_elements)
			if(t_element.getAbsoluteAddress().equals(p_absolute_address))
				p_searched_elements.add(t_element.getAbsoluteAddress());
			
		return p_searched_elements;	
	}
	
	public Collection<String> findR(String p_absolute_address)
	{
		Collection<String> p_searched_elements = new ArrayList<String>();
		
		return findRAux(p_absolute_address, p_searched_elements);
	}
	
	private Collection<String> findRAux(String p_absolute_address, Collection<String> p_searched_elements)
	{
		for(AbstractStoringElement t_element : a_elements)
		{
			if(t_element.getAbsoluteAddress().equals(p_absolute_address))
				p_searched_elements.add(t_element.getAbsoluteAddress());
			
			if(t_element instanceof Directory)
				((Directory) t_element).findRAux(p_absolute_address, p_searched_elements);
		}
			
		return p_searched_elements;	
	}
}
