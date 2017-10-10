package tp_2.src;

public interface IDictionary
{
	Object get(Object p_key);
	
	IDictionary put(Object p_key, Object p_value);
	
	boolean isEmpty();
	
	boolean containsKey(Object p_key);
}
