using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{

    public GameObject on,off,loadingPanel,textDeletedProgress;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerPrefs.GetInt("muted")){
          case 0:
            on.SetActive(true);
            off.SetActive(false);
            break;
          case 1:
            off.SetActive(true);
            on.SetActive(false);
            break;

        }
    }

    public void mute(){
      PlayerPrefs.SetInt("muted",1);
    }

    public void unmute(){
      PlayerPrefs.SetInt("muted",0);
    }

    public void openScene(int id){
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);
    }

    public void undoProgress(){
      int space=PlayerPrefs.GetInt("space");
      int icland=PlayerPrefs.GetInt("iclands");
      gameObject.GetComponent<AudioSource>().Play();
      textDeletedProgress.SetActive(true);
      Invoke("textDeletedProgressOff",1.3f);
      PlayerPrefs.DeleteAll();

      PlayerPrefs.SetInt("studied",1);
      PlayerPrefs.SetInt("rated",1);
      PlayerPrefs.SetInt("space",space);
      PlayerPrefs.SetInt("iclands",icland);
    }

    void textDeletedProgressOff(){
      textDeletedProgress.SetActive(false);
    }
}
