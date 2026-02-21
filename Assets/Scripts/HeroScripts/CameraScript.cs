using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private UserControl userControl;
    Vector3 camPos;
    private float xPos = 4;
    private float yPos = 2;
    private float zPos = 10;
    private void Update()
    {
        camPos = cam.transform.localPosition;
        camPos.x = userControl.transform.localPosition.x + xPos;
        camPos.y = userControl.transform.localPosition.y + yPos;
        camPos.z = userControl.transform.localPosition.z - zPos;
        cam.transform.position = camPos;
    }
}
