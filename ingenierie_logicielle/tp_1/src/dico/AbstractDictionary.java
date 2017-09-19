package dico;

public abstract class AbstractDictionary implements IDictionary
{
	private int a_size = 0;
	
	private Object[] a_keys;
	private Object[] a_values;
	
	public AbstractDictionary()
	{
		setKeys(new Object[1]);
		setValues(new Object[1]);
	}

	public AbstractDictionary(int p_size)
	{
		setKeys(new String[p_size]);
		setValues(new String[p_size]);
	}

	@Override
	public IDictionary put(Object p_key, Object p_value)
	{
		int t_index = newIndexOf(p_key);
		
		if(a_keys[t_index] == null)
			setSize(getSize() + 1);
		
		a_keys[t_index]   = p_key;
		a_values[t_index] = p_value;
		
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
}
