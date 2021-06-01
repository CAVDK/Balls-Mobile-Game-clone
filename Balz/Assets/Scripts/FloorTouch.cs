
using UnityEngine;

public class FloorTouch : MonoBehaviour
{
    ballLauncher launcher;
    public bool firstTouch;
    BlockSpwaners bb;
    private void Awake()
    {
        launcher = FindObjectOfType<ballLauncher>();
        bb = FindObjectOfType<BlockSpwaners>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Player")
        {
            if(!firstTouch)
            {
                firstTouch = true;
                launcher.NewLaunchPadpos = new Vector2(coll.GetContact(0).point.x,launcher.LaunchPad.transform.position.y);
                coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                coll.gameObject.transform.position = new Vector2(coll.GetContact(0).point.x, launcher.LaunchPad.transform.position.y);
            }
            else
            {
                coll.gameObject.SetActive(false);
            }
           
            launcher.LaunchPad.gameObject.SetActive(true);
            launcher.RecivedBallCount++;

        }
       

    }

   
    //-0.049558,-2.781232  -2.766232  2.766232   0.75466
}
