package tp_2.src;

public abstract class AbstractDictionary implements IDictionary
{
	private int a_size = 0;
	
	private Object[] a_keys;
	private Object[] a_values;
	
	@Override
	public IDictionary put(Object p_key, Object p_value)
	{
		int t_index = indexOf(p_key);
	
		if(t_index == -1)
		{
			t_index = newIndexOf(p_key);
			
			a_size++;
		
			a_keys[t_index]   = p_key;
			a_values[t_index] = p_value;
		}
		
		return this;
	}
	
	@Override
	public Object get(Object p_key)
	{
		int t_index = indexOf(p_key);
		
		if(t_index != -1)
			return a_values[t_index];
		else
			return null;
	}
	
	@Override
	public boolean containsKey(Object p_key)
	{
		return indexOf(p_key) != -1;
	}

	@Override
	public final boolean isEmpty()
	{
		return a_size == 0;
	}
	
	protected abstract int indexOf(Object p_key);

	protected abstract int newIndexOf(Object p_key);
	
	/* Getters - Setters*/
	protected final Object[] getKeys()
	{
		return a_keys;
	}
	
	protected final void setKeys(Object[] p_keys)
	{
		a_keys = p_keys;
	}
	
	protected final Object[] getValues()
	{
		return a_values;
	}
	
	protected final void setValues(Object[] p_values)
	{
		a_values = p_values;
	}
	
	protected final int getSize()
	{
		return a_size;
	}
	
	protected final void setSize(int p_new_size)
	{
		a_size = p_new_size;
	}
	/* *** */
	
	@Override
	public String toString()
	{
		StringBuilder t_to_string = new StringBuilder();
		 
		for(int t_index = 0; t_index < getKeys().length; t_index++)
		{
			if(getKeys()[t_index] != null)
				t_to_string.append(t_index + " - " + getKeys()[t_index].toString() + " - " + getValues()[t_index].toString());
			
			if(t_index < getKeys().length - 1)
				t_to_string.append(System.getProperty("line.separator"));
		}
		 
		return t_to_string.toString();
	 }
}
