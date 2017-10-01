package dico;

public class FastDictionary extends AbstractDictionary
{
	public FastDictionary()
	{
		setKeys(new Object[1]);
		setValues(new Object[1]);
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
	}

	@Override
	protected int newIndexOf(Object p_key)
	{	
		if(mustGrow())
			grow();
		
		int r_index = indexOf(p_key);
		
		if(r_index == -1)
		{
			r_index++;
			while(getKeys()[r_index] != null)
			{
				if(r_index == getKeys().length)
					r_index = 0;
				
				r_index++;
			}
		}
		
		return r_index;
	}
	
	private boolean mustGrow()
	{
		return getSize() > ((getKeys().length / 4) * 3);
	}
	
	private void grow()
	{
		Object[] t_new_keys   = new Object[getSize() * 2];
		Object[] t_new_values = new Object[getSize() * 2];
		
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
	
	public static void main(String[] Args)
	{
		IDictionary t_fast_dictionary = new FastDictionary();
		
		System.out.println(t_fast_dictionary.isEmpty());
		
		System.out.println("---");
		 
		t_fast_dictionary.put("Test", "Premiere val");
		t_fast_dictionary.put("Truc", "Yolo").put("Machin", "grtjjhrtj").put("Test", "Nouvelle description").put("Yolo", "42");
		 
		System.out.println(t_fast_dictionary.toString());
		
		System.out.println("---");
		
		System.out.println(t_fast_dictionary.get("Machin"));
		System.out.println(t_fast_dictionary.get("N'existe pas"));
		
		System.out.println("---");
		
		System.out.println(t_fast_dictionary.isEmpty());
	}
}
