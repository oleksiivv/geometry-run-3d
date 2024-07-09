using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    public float lenCube=0.6f;

    public string recordName="hi0";
    int dx=0;

    bool played=true;

    bool swipped=false;

    public Text score,hi;
    public static int cnt=0;

    public GameObject runParticle,bg;

    public ParticleSystem fallParticle;

    public QuestsController quests;

    public bool iceland=false;
    void Start()
    {
      cnt=0;
      StartCoroutine(cntIncrement());
      screenPosition=Vector2.zero;

    }

    private Vector2 startTouchPosition, endTouchPosition;
    Vector2 screenPosition;




    // Update is called once per frame
    private void Update()
    {
        score.GetComponent<Text>().text="Score: "+cnt.ToString();
        hi.GetComponent<Text>().text="HI: "+PlayerPrefs.GetInt(recordName).ToString();
        if(Input.GetMouseButtonDown(0) && Time.timeScale==1){
          screenPosition= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)){
          if(dx>-1 || iceland){


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
          if(dx<1 || iceland){




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






        transform.position=Vector3.MoveTowards(transform.position, new Vector3(dx*lenCube-0.177f,transform.position.y,transform.position.z), 0.1f);
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
        if(Time.timeScale==1 && bg.activeSelf!=true){
          cnt+=Triggers.x2;

          if(cnt>=1000){
            quests.CompleteQuest(quests.mapName+"_1000");
          }
        }
        yield return new WaitForSeconds(0.12f);
      }
    }

   public bool jump=true;
    void OnCollisionEnter(Collision other){
      jump=true;
      fallParticleStart();
      Invoke("restartRunParticle",0.4f);

    }

    private int jumpsInSingleRun=0;

    public void move(){
        endTouchPosition=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //Debug.Log(screenPosition.y-endTouchPosition.y);

        if(Mathf.Abs(screenPosition.x-endTouchPosition.x)<50 || Mathf.Abs(screenPosition.y-endTouchPosition.y) > 200) {
            Debug.Log("UP or DOWN");
            Debug.Log(screenPosition.x-endTouchPosition.x);
            if(screenPosition.y+30<endTouchPosition.y &&  jump){
                GetComponent<Rigidbody>().AddForce(Vector3.up*350);
                jump=false;
                //Debug.Log("upppppp");
                runParticle.SetActive(false);

                //QUESTS ONLY
                jumpsInSingleRun++;
                Debug.Log(jumpsInSingleRun.ToString()+" jumps");
                if(jumpsInSingleRun==10){
                  quests.CompleteQuest("jump_master");
                }

                if(jumpsInSingleRun==30){
                  quests.CompleteQuest("jump_pro");
                }
            }
            else if(screenPosition.y-40>endTouchPosition.y && Mathf.Abs(screenPosition.x-endTouchPosition.x)<100){
                if(GetComponent<Animator>().GetBool("down")==false){
                  if(transform.position.y>2f)GetComponent<Rigidbody>().AddForce(-Vector3.up*150);
                  
                  if(transform.position.y<=0.5f && Application.loadedLevel!=12){
                    GetComponent<Animator>().SetBool("left",false);
                    GetComponent<Animator>().SetBool("right",false);
                    GetComponent<Animator>().SetBool("down",true);
                    Invoke("cleanAnimDown",1.6f);
                  }
                }
            }
        }
        else {
          Debug.Log("LEFT or RIGHT");
          if(screenPosition.x+10<endTouchPosition.x){
            if(dx<1 ||iceland){
              dx++;
              played=false;
              if(!played){
                if(GetComponent<Animator>().GetBool("down")!=true){
                  GetComponent<Animator>().SetBool("down",false);
                  GetComponent<Animator>().SetBool("left",false);
                  GetComponent<Animator>().SetBool("right",true);
                  played=true;
                  Invoke("cleanAnim",0.2f);
                }
              }
            }
          }
          else if(screenPosition.x-10>endTouchPosition.x){
            if(dx>-1 || iceland){
              dx--;
              played=false;

              if(!played){
                if(GetComponent<Animator>().GetBool("down")!=true){
                  GetComponent<Animator>().SetBool("down",false);
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
      //fallParticle.SetActive(false);
    }

    void fallParticleStart(){
      if(!runParticle.activeSelf)fallParticle.Play();
    }


    void fuckFunc(){
      /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
          startTouchPosition = Input.GetTouch(0).position;

      if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
      {
          endTouchPosition = Input.GetTouch(0).position;

          if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
          {
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

          if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.75f){
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
      }
      foreach(Touch t in Input.touches){
        if(t.phase==TouchPhase.Began){
          initTouch=t;

        }
        else if(t.phase==TouchPhase.Moved && !swipped){
          float xMoved=initTouch.position.x-t.position.x;
          float yMoved=initTouch.position.y-t.position.y;

          float dist=Mathf.Sqrt((xMoved*xMoved)+(yMoved*yMoved));

          bool swippedLeft=Mathf.Abs(xMoved)>Mathf.Abs(yMoved);

          if(dist>50){
            if(swippedLeft && xMoved>0){
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
            else if(swippedLeft && xMoved<0){
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
            swipped=true;
          }
        }
        else if(t.phase==TouchPhase.Ended){
          initTouch=new Touch();
          swipped=false;
        }
      }*/
    }
}
