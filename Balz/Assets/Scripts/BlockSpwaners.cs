using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpwaners : MonoBehaviour
{
    public float distanceBetweenBlocks = 0.754666f;
    public float distanceBetweenRows = 0.827f;
    [SerializeField]
    private int BlockRowSize = 7;
    
    public GameObject BlockPrefab;
    private int rowsSpawned = 0;
    blockPool pool;
    public GameObject parentGameObj1;
    public GameObject ParentGameobj2;
    public bool CanSpawn = true;

    private void Awake()
    {
        pool = FindObjectOfType<blockPool>();
    }




    private void OnEnable()
    {
        if(CanSpawn)
        SpawnNewBlockRow();

    }

    bool spawned = false;
    private void SpawnNewBlockRow()
    {
        foreach( GameObject b in  pool.activeBlock)
        {
            if (pool.activeBlock != null)
                b.transform.position += Vector3.down * distanceBetweenRows;
            else break;
           
        }
        
        for(int i=0;i<BlockRowSize;i++)
        {
            int RandomNo = UnityEngine.Random.Range(0, 100);
            if(RandomNo <=40)
           {
                spawned = true;
                SpawnNewBlock(i);
           }

                
        }
        if(spawned == false)
        {
            spawned = true;
            int tempNo = UnityEngine.Random.Range(0, 7);
            SpawnNewBlock(tempNo);

        }
        rowsSpawned++;
    }
    private void SpawnNewBlock( int pos)
    {
        distanceBetweenBlocks = ((Mathf.Abs(parentGameObj1.transform.position.x) * 2f)/6);
        if (pool.inactiveBlock == null)
             {
           // newBlock  = Instantiate(BlockPrefab, Blockposition, Quaternion.identity);
             pool.growThwQueue();


           // newBlock.transform.localScale = 


             }

            Vector2 Blockposition = new Vector2(parentGameObj1.transform.position.x + pos*distanceBetweenBlocks,transform.position.y);
        GameObject newBlock;
        //
       // else
        //{
          newBlock = pool.inactiveBlock.Dequeue();
          newBlock.transform.position = Blockposition;
            //   newBlock.transform.SetParent(parentGameObj.transform);
            newBlock.transform.localScale = parentGameObj1.transform.lossyScale;




//        }
        int hits = UnityEngine.Random.Range(1, 3) + rowsSpawned;
       // newBlock.transform.SetParent(parentGameObj.transform);
       // newBlock.transform.localScale= new Vector3(7f, 7f, 1f);
       // newBlock.transform.localScale = new Vector3(transform.lossyScale.x, transform.lossyScale.x, 1);
        newBlock.GetComponent<Block>().setHits(hits);
        newBlock.GetComponent<Block>().UpdateLook();
        newBlock.SetActive(true);
        pool.activeBlock.Add(newBlock);//add the spawned blokc to the list of active block







    }
}
