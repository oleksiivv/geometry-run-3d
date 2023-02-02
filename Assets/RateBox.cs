using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBox : MonoBehaviour
{
  public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rate(){


      Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudioGames.GeometryRun3D");
      PlayerPrefs.SetInt("rated",1);
      gameObject.SetActive(false);
      bg.SetActive(false);


    }

    public void remindLater(){
      Menu.remindCnt=3;
      gameObject.SetActive(false);
        bg.SetActive(false);

    }

    public void remindNewer(){
      PlayerPrefs.SetInt("rated",1);
      gameObject.SetActive(false);
        bg.SetActive(false);
    }
}
