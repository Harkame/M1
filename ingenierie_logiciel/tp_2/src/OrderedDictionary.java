package tp_2.src;

public class OrderedDictionary extends AbstractDictionary
{	
	public OrderedDictionary()
	{
		setKeys(new Object[0]);
		setValues(new Object[0]);
	}
	
	@Override
	public int indexOf(Object p_key)
	{
		if(isEmpty())
			return -1;
		
		for(int t_index = 0; t_index < getSize(); t_index++)
			if(getKeys()[t_index].equals(p_key))
				return t_index;
				
		return -1;
	}
	
	@Override
	protected int newIndexOf(Object p_key)
	{		
		int r_index = indexOf(p_key);
		
		if(r_index == -1)
		{
			Object[] t_new_keys   = new Object[getSize() + 1];
			Object[] t_new_values = new Object[getSize() + 1];
			
			System.arraycopy(getKeys(),   0, t_new_keys,   0, getSize());
			System.arraycopy(getValues(), 0, t_new_values, 0, getSize());
			
			setKeys(t_new_keys);
			setValues(t_new_values);
			
			r_index = getSize();
		}
		
		return r_index;		
	}
}
