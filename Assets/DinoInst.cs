using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoInst : MonoBehaviour
{
  public GameObject[] enemies,coins;

  public int instPos=100;

  public float min=0.5f;
  public float mid=1.84f;
  public float max=3.2f;

  // Start is called before the first frame update
  void Start()
  {


    StartCoroutine(enemyInst());


  }

  // Update is called once per frame
  void Update()
  {

  }

  float pauseTime=2f;

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
      if(id==0 || id==1)Instantiate(enemies[id],new Vector3(posX,enemies[id].transform.position.y,instPos+10),Quaternion.identity);
      else Instantiate(enemies[id],new Vector3(enemies[id].transform.position.x,enemies[id].transform.position.y,instPos),enemies[id].transform.rotation);
      //if(pauseTime>0.1f)pauseTime-=0.01f;
      yield return new WaitForSeconds(pauseTime);
    }
  }
}
