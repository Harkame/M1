package dico;

public class OrderedDictionary extends AbstractDictionary
{	
	@Override
	public int indexOf(Object p_key)
	{
		for(int t_index = 0; t_index < getKeys().length; t_index++)
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
	 
	@Override
	public String toString()
	{
		StringBuilder t_to_string = new StringBuilder();
		 
		for(int t_index = 0; t_index < getSize(); t_index++)
			t_to_string.append(t_index + " - " + getKeys()[t_index].toString() + " - " + getValues()[t_index].toString() + System.getProperty("line.separator"));
		 
		return t_to_string.toString();
	 }
	 
	public static void main(String[] Args)
	{
		IDictionary t_ordered_dictionary = new OrderedDictionary();
		
		System.out.println(t_ordered_dictionary.isEmpty());
		 
		t_ordered_dictionary.put("Test", "Premiere val");
		t_ordered_dictionary.put("Truc", "Yolo").put("Machin", "grtjjhrtj").put("Test", "Nouvelle description").put("Yolo", "42");
		 
		System.out.println(t_ordered_dictionary.toString());
		
		System.out.println(t_ordered_dictionary.get("Machin").toString());
		//System.out.println(t_ordered_dictionary.get("N'existe pas").toString()); //Exception
		
		System.out.println(t_ordered_dictionary.isEmpty());
	}
}
