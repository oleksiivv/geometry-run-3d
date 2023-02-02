using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public GameObject[] audioSourceHold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      switch(PlayerPrefs.GetInt("muted")){
        case 0:
          foreach(var a in audioSourceHold){
            a.GetComponent<AudioSource>().enabled=true;
          }
          break;
        case 1:
        foreach(var a in audioSourceHold){
          a.GetComponent<AudioSource>().enabled=false;
        }
          break;

      }
    }
}
