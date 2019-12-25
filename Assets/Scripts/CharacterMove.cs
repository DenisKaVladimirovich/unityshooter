using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public Camera MainCamera;
    public float HorizontalRotationSpeed=5;
    public float VerticalRotationSpeed = 3;
    public float rotSmoothSpeed=5;

    public float MaxCameraAngle=45;
    public float MinCameraAngle = -45;

    // Start is called before the first frame update
    void Start()
    {
        
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
        float mouseX = Input.GetAxis("Mouse X");
        Quaternion newRotation = new Quaternion(0, transform.rotation.y + mouseX, 0, 0);
        transform.Rotate(new Vector3(0, mouseX*Time.deltaTime*HorizontalRotationSpeed));
    }

    void RotateCamera()
    {
        
        float mouseY = -Input.GetAxis("Mouse Y");
        Quaternion newRotation = MainCamera.transform.rotation;
        newRotation.x += mouseY;
        newRotation.x = Mathf.Clamp(newRotation.x, MinCameraAngle, MaxCameraAngle);
        //MainCamera.transform.Rotate(new Vector3(mouseY * Time.deltaTime * VerticalRotationSpeed, 0));
        MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, newRotation, Time.deltaTime * rotSmoothSpeed);
    }

    private bool isCamClamped(Quaternion rotation) {
            Vector3 rot = rotation.eulerAngles;
            
            if (rot.x<=-MinCameraAngle && rot.x>=-MaxCameraAngle){
                return true;

            }
            else return false;
    }
}
