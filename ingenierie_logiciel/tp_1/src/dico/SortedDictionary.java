package tp_2.src;

public class SortedDictionary extends AbstractDictionary
{
	public SortedDictionary()
	{
		setKeys(new Object[0]);
		setValues(new Object[0]);
	}

	public SortedDictionary(int p_size)
	{
		setKeys(new String[p_size]);
		setValues(new String[p_size]);
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
		Comparable t_key = (Comparable) p_key;
		
		if(r_index == -1)
		{
			Object[] t_new_keys   = new Object[getSize() + 1];
			Object[] t_new_values = new Object[getSize() + 1];
			
			
			int t_position = 0;
			while(t_position < getSize())
			{
				Comparable t_value = (Comparable) getKeys()[t_position];
				
				if(t_value.compareTo(t_key) >= 0)
					break;
				
				t_position++;
			}

			int t_index;
			if(t_position == 0)
			{
				for(t_index = 1; t_index < t_new_keys.length; t_index++)
				{
					t_new_keys[t_index] = getKeys()[t_index - 1];
					t_new_values[t_index] = getValues()[t_index - 1];
				}
			}
			else
			{
				for(t_index = 0; t_index < t_position; t_index++)
				{
					t_new_keys[t_index]  = getKeys()[t_index];
					t_new_values[t_index] = getValues()[t_index];
				}
				
				for(t_index = t_position + 1; t_index < t_new_keys.length; t_index++)
				{
					t_new_keys[t_index] = getKeys()[t_index - 1];
					t_new_values[t_index] = getValues()[t_index - 1];
				}
			}


			
			setKeys(t_new_keys);
			setValues(t_new_values);
			
			r_index = t_position;
		}
		
		return r_index;		
	}
}

