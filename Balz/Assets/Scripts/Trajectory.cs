using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public LineRenderer lr;
    ballLauncher BLc;
    
    private void Start()
    {
        lr = transform.GetComponent<LineRenderer>();
        BLc = FindObjectOfType<ballLauncher>();
    }

    public void setStartposition()
    {
        lr.SetPosition(0, BLc.LaunchPad.transform.position);
    }
    public void EndPosition(Vector2 Endpositioo)
    {

        Vector3 endposLR = new Vector3(Endpositioo.x, Endpositioo.y, -0.21f);
        lr.SetPosition(1,endposLR * 15f);
    }
  }


