using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class _ThirdPersonController : MonoBehaviour
{
    public FixedJoystick LeftJoystick;
    public FixedTouchField TouchField;
    // public FixedButton Button;

    protected Actions Actions;

    protected Rigidbody Rigidbody;
    protected ThirdPersonUserControl Control;

    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.1f;
    protected float CameraPosY;
    protected float cameraPosSpeed = 0.1f;



    void Start()
    {
        Actions = GetComponent<Actions>();
        Control = GetComponent<ThirdPersonUserControl>();
        Rigidbody = GetComponent<Rigidbody>();
    }

   
    void Update()
    {

        // Camera Movement and display Mechanic Button

        var input = new Vector3(LeftJoystick.inputVector.x,0,LeftJoystick.inputVector.y);
        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up)* input * 5f;

        Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y, vel.z);
        //transform.rotation = Quaternion.AngleAxis(CameraAngleY + 180 + Vector3.SignedAngle(Vector3.forward, input.normalized + Vector3.forward * 0.001f, Vector3.up), Vector3.up);
        if(LeftJoystick.inputVector.x != 0 || LeftJoystick.inputVector.y != 0) transform.rotation = Quaternion.LookRotation(Rigidbody.velocity);

        CameraAngleY += TouchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleY, Vector3.up) * new Vector3(0,3,4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);


        /////// Animation

        // Run & Idle
        if(Rigidbody.velocity.magnitude >0.1f)
            Actions.Run();
            else 
            Actions.Stay();
        
        // Jump

         



    }
}
