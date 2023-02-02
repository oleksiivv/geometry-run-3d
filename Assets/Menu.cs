using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Menu : MonoBehaviour
{
    public Text hiText,money;
    public GameObject loadingPanel,startQuestion;

    public static string hi="hi0";

    string id="3828893";

    public StudyController studyController;


    void Awake(){
      if(PlayerPrefs.GetInt("studied")==0){
        startQuestion.SetActive(true);
        PlayerPrefs.SetInt("studied",1);

      }
    }


    public void skipStudy(){
      PlayerPrefs.SetInt("studied",1);
      startQuestion.SetActive(false);
    }


    static public int remindCnt=0;
    public GameObject bgRateUs,rateUs;
    // Start is called before the first frame update
    void Start()
    {
      Advertisement.Initialize(id,false);
      Time.timeScale=1;
      //hi="hi";
      if(remindCnt==2 && PlayerPrefs.GetInt("rated")==0){
        bgRateUs.SetActive(true);
        rateUs.SetActive(true);
      }
      else{
        bgRateUs.SetActive(false);
        rateUs.SetActive(false);
      }

      remindCnt++;

    }

    // Update is called once per frame
    void Update()
    {
      hiText.GetComponent<Text>().text="HI "+PlayerPrefs.GetInt(hi).ToString();
      money.GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();


    }

    public void openScene(int id){

      if(id==6){
        if(PlayerPrefs.GetInt("roof")==1){
          loadingPanel.SetActive(true);
          Application.LoadLevelAsync(id);
        }
      }
      else if(id==7){
        if(PlayerPrefs.GetInt("arctic")==1){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
      }

    }
    else if(id==8){
      if(PlayerPrefs.GetInt("desert")==1){
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);
    }
  }

    else if(id==9){
      if(PlayerPrefs.GetInt("village")==1){
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);
    }
  }
  else if(id==10){
      if(PlayerPrefs.GetInt("space")==1){
        PlayerPrefs.SetInt("spaceFirst1",1);
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id+1);
      }
  }
  else if(id==11){
      if(PlayerPrefs.GetInt("iclands")==1){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id+1);
      }
  }

    else{
      if(id==4){
        PlayerPrefs.SetInt("jurrassicFirst",1);
      }
      if(id==5){
        PlayerPrefs.SetInt("aquaFirst",1);
      }
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);

    }

  }



    public void openGameLevel(){
      if(SliderMaps.currId==0){
        loadingPanel.SetActive(true);

        Application.LoadLevelAsync(1);
      }
      else{
        if(SliderMaps.currId==3){
          if(PlayerPrefs.GetInt("roof")==1){
            loadingPanel.SetActive(true);
            Application.LoadLevelAsync(SliderMaps.currId+3);
          }
        }
        else if(SliderMaps.currId==4){
          if(PlayerPrefs.GetInt("arctic")==1){
          loadingPanel.SetActive(true);
          Application.LoadLevelAsync(SliderMaps.currId+3);
        }

      }
      else if(SliderMaps.currId==5){
        if(PlayerPrefs.GetInt("desert")==1){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(SliderMaps.currId+3);
      }
    }

      else if(SliderMaps.currId==6){
        if(PlayerPrefs.GetInt("village")==1){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(SliderMaps.currId+3);
      }



      }
      else if(SliderMaps.currId==7){
        if(PlayerPrefs.GetInt("space")==1){
          loadingPanel.SetActive(true);
         Application.LoadLevelAsync(11);
        }
      }
      else if(SliderMaps.currId==8){
        if(PlayerPrefs.GetInt("iclands")==1){
         loadingPanel.SetActive(true);
         Application.LoadLevelAsync(12);
        }
      }


      else{
        if(SliderMaps.currId==1){
          PlayerPrefs.SetInt("jurrassicFirst",1);
        }
        if(SliderMaps.currId==2){
          PlayerPrefs.SetInt("aquaFirst",1);
        }
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(SliderMaps.currId+3);
      }



    }}

    public void watchAdd(){
      ShowOptions options = new ShowOptions();
      options.resultCallback = AdCallbackHandler;
      if(Advertisement.IsReady()){
        Advertisement.Show("Android_Rewarded",options);
      }
    }








    void AdCallbackHandler(ShowResult res)
    {
        if (res == ShowResult.Finished)
        {
          PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+20);
          gameObject.GetComponent<AudioSource>().Play();

        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (res == ShowResult.Skipped)
        {
            Debug.Log("error");
        }
    }


    public void study(){
      // PlayerPrefs.SetInt("currentStudy",0);
      // loadingPanel.SetActive(true);
      // Application.LoadLevelAsync(10);
      startQuestion.gameObject.SetActive(false);
      studyController.setStudyPanelActive(true);
    }



    
}
