using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;

    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }
   
    void Update()
    {
        cam.fieldOfView = view + zoom;

        //ズームアップの上限値を決める。
        if (cam.fieldOfView < 20f)
        {
            cam.fieldOfView = 20f;
        }
        //元の位置を決める。
        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            //ズームアップのスピード。
            zoom -= 3.0f;

            if (zoom < -40f)  
            {
                zoom = -40f;
            }
        }
        else
        {
            zoom += 1.2f;

            if (zoom > 0)
            {
                zoom = 0;
            }
        }
        print("zoomの値" + zoom);
    }
}
