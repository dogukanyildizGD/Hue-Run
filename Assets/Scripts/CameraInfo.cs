using UnityEngine;

public class CameraInfo : MonoBehaviour
{
    Camera Camera;    

    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        Camera.backgroundColor = Colors.ColorGrey();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundChangeRed()
    {
        Camera.backgroundColor = Colors.ColorRed(); 
    }
    public void BackgroundChangeBlue()
    {
        Camera.backgroundColor = Colors.ColorBlue();
    }
    public void BackgroundChangeYellow()
    {
        Camera.backgroundColor = Colors.ColorYellow();
    }

}
