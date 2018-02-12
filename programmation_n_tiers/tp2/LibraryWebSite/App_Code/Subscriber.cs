using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Subscriber
/// </summary>
public class Subscriber
{
    private static int G_ID = 0;

    private int a_id = G_ID++;

    public String a_password
    {
        get
        {
            return a_password;
        }
        set
        {
         a_password = value;
        }
    }

	public Subscriber(int p_id, String p_password)
	{
        a_id = p_id;
        a_password = p_password;
	}
}