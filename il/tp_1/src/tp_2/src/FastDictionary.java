package tp_2.src;

public class FastDictionary extends AbstractDictionary
{
	public FastDictionary()
	{
		setKeys(new Object[10]);
		setValues(new Object[10]);
	}

	public FastDictionary(int p_size)
	{
		setKeys(new String[p_size]);
		setValues(new String[p_size]);
	}

	@Override
	protected int indexOf(Object p_key)
	{
		if(isEmpty())
			return -1;
		
		for(int t_index = 0; t_index < getKeys().length; t_index++)
			if(getKeys()[t_index] != null)
				if(getKeys()[t_index].equals(p_key))
					return t_index;
				
		return -1;
		
		/*
		if(isEmpty())
			return -1;
		
		int r_index = p_key.hashCode() % getKeys().length;
		
		if(r_index < 0)
			r_index = 0;
		
		while(getKeys()[r_index] != null)
		{
			if(getKeys()[r_index].equals(p_key))
				return r_index;
			
			r_index++;
			
			if(r_index == getKeys().length)
				r_index = 0;
		}
		
		return r_index;
		*/
	}

	@Override
	protected int newIndexOf(Object p_key)
	{	
		if(mustGrow())
			grow();
		
		int r_index = indexOf(p_key);
		
		if(r_index == -1)
		{
			int r_new_index = p_key.hashCode() % getKeys().length;
			
			if(r_new_index < 0)
				r_new_index = 0;
	
			while(getKeys()[r_new_index] != null)
			{
				
				if(r_new_index == getKeys().length)
					r_new_index = 0;
				
				r_new_index++;
			}
			r_index = r_new_index;
		}
		
		return r_index;
	}
	
	private boolean mustGrow()
	{
		return getSize() > ((getKeys().length / 4) * 3);
	}
	
	private void grow()
	{
		Object[] t_new_keys   = new Object[getKeys().length * 2];
		Object[] t_new_values = new Object[getKeys().length * 2];
		
		for(int t_index = 0; t_index < getKeys().length; t_index++)
		{
			if(getKeys()[t_index] != null)
			{
				int t_new_index = getKeys()[t_index].hashCode() % t_new_keys.length;
				
				if(t_new_index < 0)
					t_new_index = 0;
				
				while(t_new_keys[t_new_index] != null)
					t_new_index++;
						
				t_new_keys[t_new_index] = getKeys()[t_index];
				t_new_values[t_new_index] = getValues()[t_index];
			}
		}
		
		setKeys(t_new_keys);
		setValues(t_new_values);
	}
	
	@Override
	public String toString()
	{
		StringBuilder t_to_string = new StringBuilder();
		 
		for(int t_index = 0; t_index < getKeys().length; t_index++)
		{
			if(getKeys()[t_index] != null)
			{
				t_to_string.append(t_index + " - " + getKeys()[t_index].toString() + " - " + getValues()[t_index].toString());
			
				if(t_index < getKeys().length - 1)
					t_to_string.append(System.getProperty("line.separator"));
			}
		}
		 
		return t_to_string.toString();
	 }
	
	public static void main(String[] Args)
	{
		IDictionary t_ordered_dictionary = new FastDictionary();
		
		System.out.println(t_ordered_dictionary.isEmpty());
		
		System.out.println("---");
		 
		t_ordered_dictionary.put("Test", "Premiere val");
		t_ordered_dictionary.put("Truc", "Yolo").put("Machin", "grtjjhrtj").put("Test", "Nouvelle description");
		t_ordered_dictionary.put("Yolo", "42");
		 
		System.out.println(t_ordered_dictionary.toString());
		
		System.out.println("---");
		
		System.out.println(t_ordered_dictionary.get("Machin"));
		System.out.println(t_ordered_dictionary.get("N'existe pas"));
		
		System.out.println("---");
		
		System.out.println(t_ordered_dictionary.isEmpty());
	}
}
