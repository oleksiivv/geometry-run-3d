using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public float lenCube=0.6f;
    int dx=0;

    bool played=true;

    bool swipped=false;

    public Text score,hi;
    public static int cnt=0;
    // Start is called before the first frame update
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



        score.GetComponent<Text>().text=cnt.ToString();
        if(Input.GetMouseButtonDown(0)){
          screenPosition= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(Input.GetMouseButtonUp(0)){
          endTouchPosition=new Vector2(Input.mousePosition.x, Input.mousePosition.y);

          if(screenPosition.x<endTouchPosition.x){
            if(dx<1){




              dx++;
              played=false;

              if(!played){
                GetComponent<Animator>().SetBool("left",false);
                GetComponent<Animator>().SetBool("right",true);
                played=true;
                Invoke("cleanAnim",0.2f);
              }

            }
          }
          else{
            if(dx>-1){


              dx--;
              played=false;

              if(!played){
                GetComponent<Animator>().SetBool("right",false);
                GetComponent<Animator>().SetBool("left",true);
                played=true;
                Invoke("cleanAnim",0.2f);
              }


            }

          }
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






        transform.position=new Vector3(dx*lenCube,transform.position.y,transform.position.z);
    }

    void cleanAnim(){
      GetComponent<Animator>().SetBool("left",false);
      GetComponent<Animator>().SetBool("right",false);
    }

    IEnumerator cntIncrement(){
      while(true){
        cnt++;
        yield return new WaitForSeconds(0.12f);
      }
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
