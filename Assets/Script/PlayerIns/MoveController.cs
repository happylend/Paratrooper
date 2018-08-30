using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour {

    LineRenderer reader;
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    float speed;

    private void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }

    private void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    private void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    void OnJoystickMoveEnd(MovingJoystick move)
    {
        if(move.joystickName=="LeftJoystick")
        {
            GetComponent<Animation>().CrossFade("Reload_standing");//换弹
        }
    }

    void OnJoystickMove(MovingJoystick move)
    {
        if (move.joystickName != "LeftJoystick")
        {
            return;
        }

        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            transform.Translate(Vector3.forward * speed);
            GetComponent<Animation>().CrossFade("Run");
            reader.SetVertexCount(2);
            reader.SetWidth(0.6f, 0.6f);
            reader.SetColors(Color.red, Color.red);
            reader.SetPosition(0, transform.position);
        }
    }

    void Awake()
    {
        reader = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reader = GetComponent<LineRenderer>();
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            reader.SetPosition(1, hit.point);
        }
        else
        {
            reader.SetPosition(1, ray.direction * 1000 - transform.position);
        }
    }
}
