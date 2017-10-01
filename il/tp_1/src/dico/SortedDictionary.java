package dico;

public class SortedDictionary extends AbstractDictionary
{
	public SortedDictionary()
	{
		setKeys(new Object[1]);
		setValues(new Object[1]);
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
		
		for(int t_index = 0; t_index < getSize() - 1; t_index++)
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
			
			
			int t_index = 0;
			while(t_index < getSize())
			{
				Comparable t_value = (Comparable) getKeys()[t_index];
				
				if(t_value.compareTo(t_key) >= 0)
					break;
				
				t_index++;
			}
			
			System.out.println(t_index + " - " + getSize());
			
			System.arraycopy(getKeys(),   0, t_new_keys,   0, t_index);
			System.arraycopy(getValues(), 0, t_new_values, 0, t_index);
			
			System.arraycopy(getKeys(),   t_index, t_new_keys,   t_index, getSize());
			System.arraycopy(getValues(), t_index, t_new_values, t_index, getSize());
			
			setKeys(t_new_keys);
			setValues(t_new_values);
			
			r_index = t_index;
		}
		
		return r_index;		
	}
	
	public static void main(String[] Args)
	{
		IDictionary t_sorted_dictionary = new SortedDictionary();
		
		System.out.println(t_sorted_dictionary.isEmpty());
		
		System.out.println("---");
		 
		t_sorted_dictionary.put("Test", "Premiere val");
		t_sorted_dictionary.put("Truc", "Yolo").put("Machin", "grtjjhrtj").put("Test", "Nouvelle description").put("Yolo", "42");
		 
		System.out.println(t_sorted_dictionary.toString());
		
		System.out.println("---");
		
		System.out.println(t_sorted_dictionary.get("Machin"));
		System.out.println(t_sorted_dictionary.get("N'existe pas"));
		
		System.out.println("---");
		
		System.out.println(t_sorted_dictionary.isEmpty());
	}
}

