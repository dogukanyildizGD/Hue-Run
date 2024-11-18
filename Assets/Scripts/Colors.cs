using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Color ColorRed()
    {
        return new Color32(233, 76, 76, 1);
    }

    public static Color ColorBlue()
    {
        return new Color32(42, 35, 255, 1);
    }

    public static Color ColorYellow()
    {
        return new Color32(245, 232, 53, 1);
    }

    public static Color ColorGrey()
    {
        return new Color32(86, 86, 86, 1);
    }
}
