using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public Text coins;
    public GameObject[] cubes;


    [Header("Same index as in scene")]
    public GameObject[] arrows,clickToBuyText,btns,prices;

    public GameObject loadingPanel;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("fast", 0);

        //PlayerPrefs.SetInt("money", 10000);

        UpdateShopState();
    }

    void Update()
    {
      //UpdateShopState();
    }

    public void buy1(int price)
    {
        if (price <= PlayerPrefs.GetInt("money"))
        {
            PlayerPrefs.SetInt("cube1", 1);
            PlayerPrefs.SetInt("current", 1);
            if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-price);
        }

        UpdateShopState();
    }

    public void buy2(int price)
    {
      if (price <= PlayerPrefs.GetInt("money"))
      {
          PlayerPrefs.SetInt("cube2", 1);
          PlayerPrefs.SetInt("current", 2);
          if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
          PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-price);
      }

      UpdateShopState();
    }

    public void buy3(int price)
    {
      if (price <= PlayerPrefs.GetInt("money"))
      {
          PlayerPrefs.SetInt("cube3", 1);
          PlayerPrefs.SetInt("current", 3);
          if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
          PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-price);
      }

      UpdateShopState();
    }

    public void buy4(int price)
    {
      if (price <= PlayerPrefs.GetInt("money"))
      {
          PlayerPrefs.SetInt("cube4", 1);
          PlayerPrefs.SetInt("current", 4);
          if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
          PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-price);
      }

      UpdateShopState();
    }

    public void buy5(int price)
    {
      if (price <= PlayerPrefs.GetInt("money"))
      {
          PlayerPrefs.SetInt("cube5", 1);
          PlayerPrefs.SetInt("current", 5);
          if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
          PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-price);
      }

      UpdateShopState();
    }

    //

    public void openScene(int id){
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);
    }



    public void choose1()
    {
        if(PlayerPrefs.GetInt("cube1")==1)PlayerPrefs.SetInt("current", 1);
        UpdateShopState();
    }
    public void choose2()
    {
        if (PlayerPrefs.GetInt("cube2") == 1) PlayerPrefs.SetInt("current", 2);
        UpdateShopState();
    }
    public void choose3()
    {
        if (PlayerPrefs.GetInt("cube3") == 1) PlayerPrefs.SetInt("current", 3);
        UpdateShopState();
    }
    public void choose4()
    {
        if (PlayerPrefs.GetInt("cube4") == 1) PlayerPrefs.SetInt("current", 4);
        UpdateShopState();
    }

    public void choose5()
    {
        if (PlayerPrefs.GetInt("cube5") == 1) PlayerPrefs.SetInt("current", 5);
        UpdateShopState();
    }

    public void choose0()
    {
        PlayerPrefs.SetInt("current", 0);
        UpdateShopState();
    }

    public QuestsController quests;
    private int numberOfAvailableSkins=1;

    private void UpdateShopState(){
      numberOfAvailableSkins=1;

      coins.GetComponent<Text>().text = PlayerPrefs.GetInt("money").ToString();

        for(int i=1;i<cubes.Length;i++){
          if(PlayerPrefs.GetInt("cube"+i.ToString())==1){
            btns[i].SetActive(false);
            prices[i].SetActive(false);
            clickToBuyText[i].SetActive(true);
            cubes[i].GetComponent<Image>().color=new Color32(0,27,255,255);

            numberOfAvailableSkins++;

          }
          else{
            btns[i].SetActive(true);
            prices[i].SetActive(true);
            clickToBuyText[i].SetActive(false);
            //cubes[0].GetComponent<Image>().color=new Color32(0,27,255,255);
          }
          cubes[i].GetComponent<Image>().color=new Color32(0,27,255,255);
          arrows[i].SetActive(false);

          if(PlayerPrefs.GetInt("current")==i){
            arrows[i].SetActive(true);
            cubes[i].GetComponent<Image>().color=new Color32(0,255,56,255);
            clickToBuyText[i].SetActive(false);
          }
          else{

            if(PlayerPrefs.GetInt("cube"+i.ToString())==1){
              clickToBuyText[i].SetActive(true);

            }
            else{
              clickToBuyText[i].SetActive(false);


            }
          }
        }

        if(PlayerPrefs.GetInt("current")==0){
          cubes[0].GetComponent<Image>().color=new Color32(0,255,56,255);
          clickToBuyText[0].SetActive(false);
          arrows[0].SetActive(true);
        }
        else{
          clickToBuyText[0].SetActive(true);
          cubes[0].GetComponent<Image>().color=new Color32(0,27,255,255);
          arrows[0].SetActive(false);
        }

        if(numberOfAvailableSkins >= cubes.Length){
          quests.CompleteQuest("buy_all_skins", true);
          Debug.Log("buy_all_quests is completed");
        }

        Debug.Log("number of av skins: "+ numberOfAvailableSkins.ToString());
    }
}
