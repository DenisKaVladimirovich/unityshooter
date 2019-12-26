using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public Camera MainCamera;
    public float HorizontalRotationSpeed=5;
    public float VerticalRotationSpeed = 3;
    public float rotSmoothSpeed=5;
    [Range(1,5)]
    public float Sensetivity;
    public float MaxCameraAngle = 45;
    public float MinCameraAngle = -45;




    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        MaxCameraAngle = -MaxCameraAngle;
        MinCameraAngle = -MinCameraAngle;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCharacter();
    }

    void LateUpdate()
    {
        RotateCamera();
    }



    void RotateCharacter()
    {
        mouseX += Input.GetAxis("Mouse X")*(Sensetivity);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, mouseX, 0), Time.deltaTime*rotSmoothSpeed);
    }

    void RotateCamera()
    {

        mouseY += -Input.GetAxis("Mouse Y") * (Sensetivity);
        mouseY=Mathf.Clamp(mouseY, -45f, 45f);
        MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, Quaternion.Euler(mouseY, MainCamera.transform.rotation.eulerAngles.y, 0), Time.deltaTime * ((float)Screen.height / (float)Screen.width) * rotSmoothSpeed);
    }

    private bool isCamClamped(Quaternion rotation) {
        Vector3 rot = rotation.eulerAngles;
        float angle = rot.x;
        angle = (angle > 180) ? angle - 360 : angle;
        Debug.Log(angle);
        if (rot.x<=MinCameraAngle&& rot.x >= MaxCameraAngle)
        {
            return true;
        }
        else return false;
        


    }
}
