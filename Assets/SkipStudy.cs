using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipStudy : MonoBehaviour
{

  public GameObject loadingPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void skipStudyFunc(){
      PlayerPrefs.SetInt("studied",1);
      loadingPanel.SetActive(true);
      Application.LoadLevel(0);
    }
}
