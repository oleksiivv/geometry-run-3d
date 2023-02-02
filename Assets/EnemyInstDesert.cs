using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstDesert : MonoBehaviour
{
  public GameObject[] enemies,coins;
  public GameObject x2;

  public int instPos=100;

  public float min=0.5f;
  public float mid=1.84f;
  public float max=3.2f;

  public float minCoin,maxCoin,midCoin;
  // Start is called before the first frame update
  void Start()
  {
    for(int i=20;i<instPos-10;i+=8){
      int id=Random.Range(0,enemies.Length);
      int dx=Random.Range(-1,2);

      var posX=0f;
      switch(dx){
        case -1:
        posX=min;
        break;
        case 0:
        posX=mid;
        break;
        default:
        posX=max;
        break;
      }
      Instantiate(enemies[id],new Vector3(posX,enemies[id].transform.position.y,i),Quaternion.identity);

    }

    StartCoroutine(enemyInst());

    StartCoroutine(coinInst());

    StartCoroutine(x2Inst());

  }

  // Update is called once per frame
  void Update()
  {

  }

  float pauseTime=0.7f;

  IEnumerator enemyInst(){
    while(true){
      int id=Random.Range(0,enemies.Length);
      int dx=Random.Range(-1,2);

      var posX=0f;
      switch(dx){
        case -1:
        posX=min;
        break;
        case 0:
        posX=mid;
        break;
        default:
        posX=max;
        break;
      }
      Instantiate(enemies[id],new Vector3(posX,enemies[id].transform.position.y,instPos),Quaternion.identity);

      //if(pauseTime>0.1f)pauseTime-=0.01f;
      yield return new WaitForSeconds(pauseTime);
    }
  }


  IEnumerator coinInst(){
    float posX2=0f;
    while(true){

      int id=Random.Range(0,coins.Length);
      int dx=Random.Range(-1,2);

      posX2=0f;
      switch(dx){
        case -1:
        posX2=minCoin;
        break;
        case 0:
        posX2=midCoin;
        break;
        default:
        posX2=maxCoin;
        break;
      }
      Instantiate(coins[id],new Vector3(posX2,coins[id].transform.position.y,instPos-10),Quaternion.identity);
      //if(pauseTime>0.1f)pauseTime-=0.01f;
      yield return new WaitForSeconds(2);
    }
  }

  IEnumerator x2Inst(){
      float posX2=0f;
      while(true){
        yield return new WaitForSeconds(6);

        int id=Random.Range(0,coins.Length);
        int dx=Random.Range(-1,2);

        posX2=dx-0.1f;
        
        Instantiate(x2,new Vector3(posX2,x2.transform.position.y,instPos-12),x2.transform.rotation);
        //if(pauseTime>0.1f)pauseTime-=0.01f;
        
      }
    }
}
