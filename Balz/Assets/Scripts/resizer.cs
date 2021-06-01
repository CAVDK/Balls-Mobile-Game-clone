using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizer : MonoBehaviour
{
   public  Camera MainCam;
    public GameObject[] resizableGameObjects;

    private void Awake()
    {
        AdjustGameObjToScreenSize();
       // MainCam = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        AdjustGameObjToScreenSize();
    }

    void AdjustGameObjToScreenSize()
    {
        //get the screen aspet ratio and screen resolutoiom

        Vector2 DeviceScreenResolution = new Vector2(Screen.width, Screen.height);
       // Debug.Log(DeviceScreenResolution);


        float scrWidth = Screen.width;
        float scrHeight = Screen.height;


        float DEVICE_ASPECT_RATIO = DeviceScreenResolution.x / DeviceScreenResolution.y;//Screen.width / Screen.height;
       // Debug.Log(DEVICE_ASPECT_RATIO);

        //apply the aspect ratio to the camera

        MainCam.aspect = DEVICE_ASPECT_RATIO;

        //now scale te imageand to the device size

        float camHeight = MainCam.orthographicSize * 2f * 100f;
        float camWith = camHeight * DEVICE_ASPECT_RATIO;

    //    Debug.Log("camHeight " + camHeight);
//Debug.Log("CamWidth " + camWith);

        foreach (GameObject obj in resizableGameObjects )
        {
            SpriteRenderer bgSr = obj.GetComponent<SpriteRenderer>();
            float bgHeight = bgSr.sprite.rect.height;
            float bgWidth = bgSr.sprite.rect.width;

           // Debug.Log("sprite Height and Width " + bgWidth + " , " + bgHeight);


            //adjust the scale of  gameobject
            float bgImage_new_scaelRatio_Height = camHeight / bgHeight;
            float bgImage_new_scaelRatio_Width = camWith / bgWidth;

            obj.transform.localScale = new Vector3(bgImage_new_scaelRatio_Width, bgImage_new_scaelRatio_Height, 1f);

        }

    }
}
