using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class SliderMaps : MonoBehaviour
{

    public GameObject[] maps, panelsClosed;
    public static int currId=0;

    public Text newLevelAvailable;
    // Start is called before the first frame update
    void Start()
    {
        
      //PlayerPrefs.SetInt("hi0",510);
      newLevelAvailable.gameObject.SetActive(false);

        buySpace();
        buyIclands();
        //currId=0;
        checkAvailableMaps();


        if(PlayerPrefs.GetInt("jurrassicFirst",0)==0 && !newLevelAvailable.gameObject.activeSelf){
            newLevelAvailable.GetComponent<Text>().text="Jurassic peroid is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("jurrassicFirst",1);
            //Invoke("cleanText",5f);
        }
        else if(PlayerPrefs.GetInt("spaceFirst1",0)==0 && !newLevelAvailable.gameObject.activeSelf){
            newLevelAvailable.GetComponent<Text>().text="Space is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("spaceFirst1",1);
            //Invoke("cleanText",2f);

        }
        else if(PlayerPrefs.GetInt("aquaFirst",0)==0 && !newLevelAvailable.gameObject.activeSelf){
            newLevelAvailable.GetComponent<Text>().text="Aquarium is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("aquaFirst",1);
            //Invoke("cleanText",5f);
        }
        

        if(PlayerPrefs.GetInt("roof")==1){
          panelsClosed[0].SetActive(false);


          if(PlayerPrefs.GetInt("roofFirst",0)==0){
            newLevelAvailable.GetComponent<Text>().text="Roof is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("roofFirst",1);
            //Invoke("cleanText",5f);

          }
        }
        if(PlayerPrefs.GetInt("arctic")==1){
          panelsClosed[1].SetActive(false);

          if(PlayerPrefs.GetInt("arcticFirst",0)==0){
            newLevelAvailable.GetComponent<Text>().text="Arctic is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("arcticFirst",1);
            //Invoke("cleanText",5f);

          }


        }
        if(PlayerPrefs.GetInt("desert")==1){
          panelsClosed[2].SetActive(false);

          if(PlayerPrefs.GetInt("desertFirst",0)==0){
            newLevelAvailable.GetComponent<Text>().text="Desert is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("desertFirst",1);
            //Invoke("cleanText",5f);

          }
        }

        if(PlayerPrefs.GetInt("village")==1){
          panelsClosed[3].SetActive(false);

          if(PlayerPrefs.GetInt("villageFirst",0)==0){
            newLevelAvailable.GetComponent<Text>().text="Village is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("villageFirst",1);
            //Invoke("cleanText",5f);

          }
        }

        ///////////

        if(PlayerPrefs.GetInt("space")==1){
          panelsClosed[4].SetActive(false);

          if(PlayerPrefs.GetInt("spaceFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Space is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("spaceFirst",1);
            //Invoke("cleanText",5f);

          }
        }

        if(PlayerPrefs.GetInt("iclands")==1){
          panelsClosed[5].SetActive(false);

          if(PlayerPrefs.GetInt("iclandsFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Paradise Islands are available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("iclandsFirst",1);
            //Invoke("cleanText",5f);

          }
        }

        


    }

    void cleanText(){
      //newLevelAvailable.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      Menu.hi="hi"+currId.ToString();
        foreach(var i in maps){
          i.SetActive(false);
        }
        maps[currId].SetActive(true);
    }

    public void left(){
      if(currId>0){
        currId--;
      }
      else{
        currId=maps.Length-1;
      }
    }

    public void right(){
      if(currId<maps.Length-1){
        currId++;
      }
      else{
        currId=0;
      }
    }


    public void checkAvailableMaps(){
      if(PlayerPrefs.GetInt("hi0")>=300){
        PlayerPrefs.SetInt("roof",1);
      }

      if(PlayerPrefs.GetInt("hi1")>=400){
        PlayerPrefs.SetInt("arctic",1);
      }

      if(PlayerPrefs.GetInt("hi2")>=600){
        PlayerPrefs.SetInt("desert",1);
      }

      if(PlayerPrefs.GetInt("hi5")>=1000){
        PlayerPrefs.SetInt("village",1);
      }



    }


    public void buySpace(){
      if(PlayerPrefs.GetInt("space")==1)return;
      
      PlayerPrefs.SetInt("space",1);

      if(PlayerPrefs.GetInt("space")==1){
          panelsClosed[4].SetActive(false);

          if(PlayerPrefs.GetInt("spaceFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Space is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("spaceFirst",1);
            //Invoke("cleanText",2f);

          }
        }

        if(PlayerPrefs.GetInt("iclands")==1){
          panelsClosed[5].SetActive(false);

          if(PlayerPrefs.GetInt("iclandsFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Paradise Islands are available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("iclandsFirst",1);
            //Invoke("cleanText",2f);

          }
        }
    }

    public void buyIclands(){
       if(PlayerPrefs.GetInt("iclands")==1)return;

      PlayerPrefs.SetInt("iclands",1);

      if(PlayerPrefs.GetInt("space")==1){
          panelsClosed[4].SetActive(false);

          if(PlayerPrefs.GetInt("spaceFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Space is available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("spaceFirst",1);
            //Invoke("cleanText",2f);

          }
        }

        if(PlayerPrefs.GetInt("iclands")==1){
          panelsClosed[5].SetActive(false);

          if(PlayerPrefs.GetInt("iclandsFirst")==0){
            newLevelAvailable.GetComponent<Text>().text="Paradise Islands are available now!";
            newLevelAvailable.gameObject.SetActive(true);
            PlayerPrefs.SetInt("iclandsFirst",1);
            //Invoke("cleanText",2f);

          }
        }
    }



    public void OnPurchaseComplete(Product product){
      switch(product.definition.id){
        case "space_level":
        {
          Invoke(nameof(buySpace),0.2f);
          break;
        }
        case "iclands_level":
        {
          Invoke(nameof(buyIclands),0.2f);
          break;
        }
      }
    }










}
