using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static bool InvertHorizontal= false;
    public static bool InvertVertical= false;

    [SerializeField] private Joystick joystick;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");


        if (joystick!=null)
        {
            Horizontal = joystick.Horizontal;
            Vertical = joystick.Vertical;
        }
    }
}
//Bootstrapper
