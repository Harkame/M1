package dico;

public class FastDictionary extends AbstractDictionary
{
	@Override
	protected int indexOf(Object p_key)
	{
		if(isEmpty())
			return -1;
		
		int r_index = p_key.hashCode() % getSize();
		
		while(getKeys()[r_index] != null &&
				!getKeys()[r_index].equals(p_key))
		{
			if(r_index == getKeys().length - 1)
				return -1;
			
			r_index++;
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
			if(getSize() > 0)
				r_index = p_key.hashCode() % getSize();
			else
				r_index = 0;
		
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
		
		System.arraycopy(getKeys(),   0, t_new_keys,   0, getSize());
		System.arraycopy(getValues(), 0, t_new_values, 0, getSize());
		
		setKeys(t_new_keys);
		setValues(t_new_values);
	}
	
	@Override
	public String toString()
	{
		StringBuilder t_to_string = new StringBuilder();
		 
		int t_count = 0;
		int t_index = 0;
		while(t_count != getSize())
		{
			if(getKeys()[t_index] != null)
			{
				t_to_string.append(t_count + " - " + getKeys()[t_index].toString() + " - " + getValues()[t_index].toString() + System.getProperty("line.separator"));
				t_count++;
			}
			t_index++;
		}
		 
		return t_to_string.toString();
	 }
	
	public static void main(String[] Args)
	{
		IDictionary t_fast_dictionary = new FastDictionary();
		
		System.out.println(t_fast_dictionary.isEmpty());
		 
		t_fast_dictionary.put("Test", "Premiere val");
		t_fast_dictionary.put("Truc", "Yolo").put("Machin", "grtjjhrtj").put("Test", "Nouvelle description").put("Yolo", "42");
		 
		System.out.println(t_fast_dictionary.toString());
		
		System.out.println(t_fast_dictionary.get("Machin").toString());
		//System.out.println(t_fast_dictionary.get("N'existe pas").toString()); //Exception
		
		System.out.println(t_fast_dictionary.isEmpty());
	}
}
