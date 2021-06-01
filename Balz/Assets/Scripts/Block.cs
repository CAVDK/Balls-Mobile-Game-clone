
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    private SpriteRenderer spriteRendere;
    private TextMeshPro text;
   public int HitsRemaining =2;
    blockPool returningpool;
    BlockSpwaners bs;
    private void Awake()
    {
        spriteRendere = transform.GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        returningpool = FindObjectOfType<blockPool>();
        bs = FindObjectOfType<BlockSpwaners>();
        UpdateLook();
    }

    private void Update()
    {
        if(transform.position.y<-3.2)
        {
            ReloadScrean();
        }
    }
    public  void UpdateLook()
    {
        text.SetText(HitsRemaining.ToString());
        spriteRendere.color = Color.Lerp(Color.white, Color.red, HitsRemaining / 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            HitsRemaining--;
            if(HitsRemaining>0)
            {
                UpdateLook();
            }
            else
            {
                //pool the game object 
                //  Destroy(gameObject);
                GameObject temp = gameObject;
                gameObject.SetActive(false);
                returningpool.activeBlock.Remove(gameObject);
               
                returningpool.inactiveBlock.Enqueue(temp);

            }
        }

      //  if(collision.gameObject.tag == "Floor")
      //  {
           

        //}


    }




  public  void setHits(int hitCount)
    {
        HitsRemaining = hitCount;
        UpdateLook();
    }


    void ReloadScrean()
    {
      gameObject.SetActive(false);
        gameObject.transform.position = Vector2.zero;
      
        Debug.Log("DeathHit");

        

        //yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
