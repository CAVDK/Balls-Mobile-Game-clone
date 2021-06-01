using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPool : MonoBehaviour
{
    public List<GameObject> activeBlock = new List<GameObject>();
     public  Queue<GameObject> inactiveBlock = new Queue<GameObject>();
    public GameObject BlockPrefabNormal;
    int sizoofpool =20;
    blockPool instance;



    //singleton
    private void Awake()
    {
        instance = this;
        growThwQueue();
    }
    private void Update()
    {
        if (inactiveBlock.Count < 7 && inactiveBlock.Count<65)
            growThwQueue();


       // Debug.Log(inactiveBlock.Count);
        
    }

    public  void growThwQueue()
    {
       // Debug.Log("Growing");
        for (int i = 0; i < sizoofpool; i++)
        {
            GameObject newInactiveblock = Instantiate(BlockPrefabNormal);
            newInactiveblock.SetActive(false);
            inactiveBlock.Enqueue(newInactiveblock);

        }
    }



}
