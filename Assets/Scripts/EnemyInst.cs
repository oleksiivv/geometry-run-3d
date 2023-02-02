using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInst : MonoBehaviour
{

    public GameObject[] enemies,coins;

    public GameObject[] newEnemies;

    public GameObject[] additionalEnemies;
    public GameObject x2;

    public int instPos=100;

    public float min=0.5f;
    public float mid=1.84f;
    public float max=3.2f;

    public float minCoin,maxCoin,midCoin;
    // Start is called before the first frame update
    void Start()
    {
      if(enemies.Length>0){
        for(int i=20;i<instPos-10;i+=8){
        int id=0;
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
      }

      StartCoroutine(coinInst());

      StartCoroutine(x2Inst());
      Invoke("startNewEnemies",25f);

      if(additionalEnemies.Length>0){
        Invoke(nameof(startAdditionalEnemies),10);
      }

    }

    void startAdditionalEnemies(){
      instNewEnemies=true;
      //StartCoroutine(additionalEnemiesC());
    }

    bool instNewEnemies=false;

    // Update is called once per frame
    void Update()
    {

    }

    float pauseTime=0.7f;

    IEnumerator enemyInst(){
      while(true){
        int id=Random.Range(0,Random.Range(0,enemies.Length)+1);
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
        if(enemies.Length>1){
          if(id==0 || id==1)Instantiate(enemies[id],new Vector3(posX,enemies[id].transform.position.y,instPos),Quaternion.identity);
          else {

            int obj = Random.Range(0,3);
            if((obj==1 && instNewEnemies && additionalEnemies.Length>0) || (obj==1 && Application.loadedLevel==4)){
              
              int id2=Random.Range(0,additionalEnemies.Length);
              Instantiate(additionalEnemies[id2],new Vector3(additionalEnemies[id2].transform.position.x,additionalEnemies[id2].transform.position.y,instPos-12),
                      additionalEnemies[id2].transform.rotation);
            }
            else {
              Instantiate(enemies[id],new Vector3(enemies[id].transform.position.x,enemies[id].transform.position.y,instPos),enemies[id].transform.rotation);
          
            }
          }
            //if(pauseTime>0.1f)pauseTime-=0.01f;
          yield return new WaitForSeconds(pauseTime);
        }
      
      else if(Application.loadedLevel!=6) {

          int obj = Random.Range(0,3);
          if((obj==1 && instNewEnemies && additionalEnemies.Length>0) || (obj==1 && Application.loadedLevel==4)){
            
            int id2=Random.Range(0,additionalEnemies.Length);
            Instantiate(additionalEnemies[id2],new Vector3(additionalEnemies[id2].transform.position.x,additionalEnemies[id2].transform.position.y,instPos-12),
                    additionalEnemies[id2].transform.rotation);
          }
          else {
            Instantiate(enemies[0],new Vector3(enemies[0].transform.position.x,enemies[0].transform.position.y,instPos),enemies[0].transform.rotation);
        
          }
          yield return new WaitForSeconds(pauseTime);
        }
      
      else if(Application.loadedLevel==6){

        Instantiate(enemies[0],new Vector3(posX,enemies[0].transform.position.y,instPos),Quaternion.identity);
        yield return new WaitForSeconds(pauseTime);
      }
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
        Instantiate(coins[id],new Vector3(posX2,coins[id].transform.position.y,instPos-12),Quaternion.identity);
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

    void startNewEnemies(){
      
      if(Application.loadedLevel>4)StartCoroutine(newEnemiesIns());
    }

    IEnumerator newEnemiesIns(){
      while(true){
        int id=Random.Range(0,newEnemies.Length);
        Instantiate(newEnemies[id],new Vector3(newEnemies[id].transform.position.x,newEnemies[id].transform.position.y,instPos-12),
                    newEnemies[id].transform.rotation);

                    yield return new WaitForSeconds(5);
      }
    }

    IEnumerator additionalEnemiesC(){
      while(true){
        int id=Random.Range(0,additionalEnemies.Length);
        Instantiate(additionalEnemies[id],new Vector3(additionalEnemies[id].transform.position.x,additionalEnemies[id].transform.position.y,instPos-12),
                    additionalEnemies[id].transform.rotation);

                    yield return new WaitForSeconds(Random.Range(5,15));
      }
    }
}
