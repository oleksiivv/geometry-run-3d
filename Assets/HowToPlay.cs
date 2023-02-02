using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
  public float lenCube=0.6f;

  int dx=0;

  bool played=true;

  bool swipped=false;

  public static int cnt=0;

  public GameObject runParticle,bg;

  public ParticleSystem fallParticle;

  public GameObject[] highlights;
  public GameObject loadingPanel;
  // Start is called before the first frame update
  void Start()
  {
    cnt=0;
    //StartCoroutine(cntIncrement());
    screenPosition=Vector2.zero;

  }

  private Vector2 startTouchPosition, endTouchPosition;
  Vector2 screenPosition;




  // Update is called once per frame
  private void Update()
  {


      if(Input.GetMouseButtonDown(0) && Time.timeScale==1){
        screenPosition= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
      }







      if(Input.GetKeyUp(KeyCode.LeftArrow)){
        if(dx>-1){


          dx--;
          played=false;

          if(!played){
            GetComponent<Animator>().SetBool("right",false);
            GetComponent<Animator>().SetBool("left",true);
            played=true;
            //Invoke("cleanAnim",0.2f);
          }


        }
      }

      if(Input.GetKeyUp(KeyCode.RightArrow)){
        if(dx<1){




          dx++;
          played=false;

          if(!played){
            GetComponent<Animator>().SetBool("left",false);
            GetComponent<Animator>().SetBool("right",true);
            played=true;
            //Invoke("cleanAnim",0.2f);
          }

        }
      }

      transform.position=new Vector3(dx*lenCube-0.177f,transform.position.y,transform.position.z);


      for(int i=0;i<highlights.Length;i++){
        if(PlayerPrefs.GetInt("currentStudy")==i){
          highlights[i].SetActive(true);
        }
        else{
          highlights[i].SetActive(false);
        }
      }







  }

  void cleanAnim(){
    GetComponent<Animator>().SetBool("left",false);
    GetComponent<Animator>().SetBool("right",false);

  }

  void cleanAnimDown(){
    GetComponent<Animator>().SetBool("down",false);
  }

  IEnumerator cntIncrement(){
    while(true){
      if(Time.timeScale==1 && bg.activeSelf!=true)cnt++;
      yield return new WaitForSeconds(0.12f);
    }
  }

 bool jump=true;


  void OnCollisionEnter(Collision other){
    jump=true;

    fallParticleStart();
    if(other.gameObject.tag=="Enemy"){
      
      if(PlayerPrefs.GetInt("currentStudy")!=4){
        loadingPanel.SetActive(true);
        Application.LoadLevel(Application.loadedLevel);
        PlayerPrefs.SetInt("currentStudy",0);
      }

    }

  }

  public void move(){
      endTouchPosition=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
      Debug.Log(screenPosition.y-endTouchPosition.y);

      if(screenPosition.y+10<endTouchPosition.y && Mathf.Abs(screenPosition.x-endTouchPosition.x)<70 &&jump){
        GetComponent<Rigidbody>().AddForce(Vector3.up*350);
        jump=false;
        Debug.Log("upppppp");
        runParticle.SetActive(false);
        // Invoke("fallParticleStart",1.4f);
        // Invoke("restartRunParticle",1.8f);

        if(PlayerPrefs.GetInt("currentStudy")==2){
          PlayerPrefs.SetInt("currentStudy",3);
        }



      }

      else if(screenPosition.y-50>endTouchPosition.y && Mathf.Abs(screenPosition.x-endTouchPosition.x)<70){
        // if(GetComponent<Animator>().GetBool("down")==false){
        //   //transform.localScale=new Vector3(0.6f,0.6f,0.6f);
        //   //transform.position=new Vector3(transform.position.x,0.45f,transform.position.z);
        //   GetComponent<Animator>().SetBool("left",false);
        //   GetComponent<Animator>().SetBool("right",false);

        //   GetComponent<Animator>().SetBool("down",true);
        //   Invoke("cleanAnimDown",1.6f);

        //   if(PlayerPrefs.GetInt("currentStudy")==3){
        //     PlayerPrefs.SetInt("currentStudy",4);
        //   }
        // }

        //GetComponent<Animator>().SetBool("down",false);
        if(GetComponent<Animator>().GetBool("down")==false){
          //transform.localScale=new Vector3(0.6f,0.6f,0.6f);
          //transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,0.5f,transform.position.z),0.1f);
          
          
          if(transform.position.y>2f)GetComponent<Rigidbody>().AddForce(-Vector3.up*150);
          if(transform.position.y<=0.5f && Application.loadedLevel!=12){
            GetComponent<Animator>().SetBool("left",false);
            GetComponent<Animator>().SetBool("right",false);
            GetComponent<Animator>().SetBool("down",true);
            Invoke("cleanAnimDown",1.6f);
          }
          if(PlayerPrefs.GetInt("currentStudy")==3){
            PlayerPrefs.SetInt("currentStudy",4);
          }
        }
      }
      else{

      if(screenPosition.x+10<endTouchPosition.x){
        if(dx<1){
          if(PlayerPrefs.GetInt("currentStudy")==0){
            PlayerPrefs.SetInt("currentStudy",1);
          }




          dx++;
          played=false;

          if(!played){
            if(GetComponent<Animator>().GetBool("down")!=true){
              //transform.position=new Vector3(transform.position.x,0.45f,transform.position.z);

            GetComponent<Animator>().SetBool("down",false);
            transform.localScale=new Vector3(0.6f,0.6f,0.6f);
            GetComponent<Animator>().SetBool("left",false);
            GetComponent<Animator>().SetBool("right",true);
            played=true;
            Invoke("cleanAnim",0.2f);
          }

          }


        }
      }
      else if(screenPosition.x-10>endTouchPosition.x){
        if(dx>-1){
          if(PlayerPrefs.GetInt("currentStudy")==1){
            PlayerPrefs.SetInt("currentStudy",2);
          }


          dx--;
          played=false;

          if(!played){
            if(GetComponent<Animator>().GetBool("down")!=true){
              //transform.position=new Vector3(transform.position.x,0.45f,transform.position.z);

            GetComponent<Animator>().SetBool("down",false);
            transform.localScale=new Vector3(0.6f,0.6f,0.6f);
            GetComponent<Animator>().SetBool("right",false);
            GetComponent<Animator>().SetBool("left",true);
            played=true;
            Invoke("cleanAnim",0.2f);
          }


          }



        }
      }

    }



  }

  void restartRunParticle(){
    runParticle.SetActive(true);

  }

  void fallParticleStart(){
    fallParticle.Play();
  }
}
