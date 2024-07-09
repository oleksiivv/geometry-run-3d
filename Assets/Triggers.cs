using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

[RequireComponent(typeof(InterstitialVideo))]
public class Triggers : RewardedVideo
{

    public GameObject pausePanel,restartPanel,bg,loadingPanel,resumePanel;

    public Text[] money;

    public string recordName="hi0";

    public static bool resumed=false;

#if UNITY_IOS
    string id="3828892";
#else
    string id="3828893";
#endif

    public static int x2=1;


    private InterstitialAd intersitional;

    private InterstitialVideo unityInterst;
#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~3588528660";
    private string intersitionalId="ca-app-pub-4962234576866611/5995200157";
    
    private string bannerId="ca-app-pub-4962234576866611/8328869393";
    private string rewardedId="ca-app-pub-4962234576866611/4297322713";
#else
    private string appId="ca-app-pub-4962234576866611~5349626885";
    private string intersitionalId="ca-app-pub-4962234576866611/8902168514";

    private string bannerId="ca-app-pub-4962234576866611/9835666801";
    private string rewardedId="ca-app-pub-4962234576866611/6782981026";
#endif

    public QuestsController quests;


    // Start is called before the first frame update
    void Start()
    {

      //old
      //MobileAds.Initialize(appId);

      RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
          LoadLoadInterstitialAd();
          CreateBannerView();
          LoadBannerAd();
          InitAdmobRewarded();
        });

        //RequestBannerAd();


      x2=1;
      Advertisement.Initialize(id,false);

      Time.timeScale=1;
      bg.SetActive(!true);
      restartPanel.SetActive(!true);
      pausePanel.SetActive(!true);


      MovePlayer.cnt=score;

      if(resumed){
        resumed=false;

        //QUEST ONLY
        if(!IsInvoking(nameof(CompleteRewardedVideoQuest))){
          Invoke(nameof(CompleteRewardedVideoQuest), 6f);
        }
      }

      firstSecondOfFall=true;

      unityInterst = GetComponent<InterstitialVideo>();

      unityInterst.LoadAd();
      LoadAd();

    }

    void CompleteRewardedVideoQuest(){
      quests.CompleteQuest("reward_ads");
    }


bool firstSecondOfFall=true;
bool showedNewRecord=false;

  public Text newRecord;
    // Update is called once per frame
    void Update()
    {
      for(int i=0;i<money.Length;i++){
        money[i].GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();
      }
      if(transform.position.y<-6 && firstSecondOfFall){
        if(MovePlayer.cnt>PlayerPrefs.GetInt(recordName)){
          PlayerPrefs.SetInt(recordName,MovePlayer.cnt);

        }
        firstSecondOfFall=false;
        if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
        if(score==0){
          resumePanel.SetActive(true);
          bg.SetActive(true);
          StartCoroutine(loadingResumePanel());
          //Invoke("restart",2f);
        }
        else{
          Invoke("restart",1f);
        }
      }
      if(transform.position.z<-3.1f && Application.loadedLevel!=12){
        gameObject.GetComponent<BoxCollider>().enabled=false;
      }
      else if(Application.loadedLevel==12 && transform.position.z<-6.1f){
        gameObject.GetComponent<BoxCollider>().enabled=false;
        
      }

      if(MovePlayer.cnt>PlayerPrefs.GetInt(recordName) && !showedNewRecord && PlayerPrefs.GetInt(recordName)>0 && bg.activeSelf==false){
        newRecord.gameObject.SetActive(true);
        showedNewRecord=true;
      }




    }

    void OnCollisionEnter(Collision other){
      if(other.gameObject.tag=="Enemy"){
        if(PlayerPrefs.GetInt("muted")==0)gameObject.GetComponent<AudioSource>().Play();
        if(MovePlayer.cnt>PlayerPrefs.GetInt(recordName)){
          PlayerPrefs.SetInt(recordName,MovePlayer.cnt);

        }
        for(int i=0;i<money.Length;i++){
          money[i].GetComponent<Text>().text=PlayerPrefs.GetInt("money").ToString();
        }

        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*100);
        //other.gameObject);
        GetComponent<Animator>().SetBool("die",true);

        if(score==0){
          resumePanel.SetActive(true);
          bg.SetActive(true);
          StartCoroutine(loadingResumePanel());
          //Invoke("restart",2f);
        }
        else{
          Invoke("restart",1f);
        }
        gameObject.GetComponent<Rigidbody>().useGravity=false;
        gameObject.GetComponent<BoxCollider>().isTrigger=true;


      }

    }


private int coinsInSingleRun=0, xInSingleRun=0;


public GameObject x2Img;
public Text x2Text;

public ParticleSystem lightGetOtemEffect;
public ParticleSystem redGetItemEffect;
    void OnTriggerEnter(Collider other){
      if(other.gameObject.tag=="coin"){
        PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+5*x2);
        if(PlayerPrefs.GetInt("muted")==0)other.gameObject.GetComponent<AudioSource>().Play();
        other.gameObject.GetComponent<MeshRenderer>().enabled=false;
        Invoke("cleanCoin",1);
        redGetItemEffect.Play();

        //QUESTS ONLY
        coinsInSingleRun += 5*x2;
        if(coinsInSingleRun==100){
          quests.CompleteQuest("collect_coins_100");
          Debug.Log("collect_coins_100 is completed: "+coinsInSingleRun.ToString());
        }

        if(coinsInSingleRun==200){
          quests.CompleteQuest("collect_coins_200");

          Debug.Log("collect_coins_200 is completed: "+coinsInSingleRun.ToString());
        }
      }

      if(other.gameObject.tag=="x2"){
        x2*=2;
        x2Text.text="x"+x2.ToString();
        x2Img.SetActive(true);

        if(PlayerPrefs.GetInt("muted")==0)other.gameObject.GetComponent<AudioSource>().Play();
        other.gameObject.GetComponent<MeshRenderer>().enabled=false;
        other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Invoke("cleanx2",10);
        lightGetOtemEffect.Play();

        //QUESTS ONLY
        quests.CompleteQuest("boost_x2");

        if(x2==4){
          quests.CompleteQuest("boost_x4");
        }
        if(x2==8){
          quests.CompleteQuest("boost_x8");
        }

        xInSingleRun++;
        if(xInSingleRun==5){
          quests.CompleteQuest("boost_use_5");
        }
        if(xInSingleRun==10){
          quests.CompleteQuest("boost_use_10");
        }
      }
    }

    void cleanx2(){
      if(x2!=1)x2/=2;
      x2Text.text="x"+x2.ToString();
      if(x2==1)x2Img.SetActive(false);

    }




    public static int addCnt=2;
    public void restart(){

      if(!resumed){

          bg.SetActive(true);
          restartPanel.SetActive(true);
          score=0;
          Time.timeScale=0;

          if(addCnt%2==1){
            if(!showIntersitionalAd()){
              //if(Advertisement.IsReady())
              //Advertisement.Show("Android_Interstitial");
              unityInterst.ShowAd();
            }
          }
          addCnt++;
       }

       


     }

    public void pauseFunction(){
      Time.timeScale=0;
      bg.SetActive(true);
      pausePanel.SetActive(true);
    }
    public void resumeFunction(){

      bg.SetActive(!true);
      pausePanel.SetActive(!true);

      Time.timeScale=1;

    }
    public void restartFunction(){
      Time.timeScale=1;

        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(Application.loadedLevel);
    }

    public void openScene(int id){
      if(MovePlayer.cnt>PlayerPrefs.GetInt(recordName)){
        PlayerPrefs.SetInt(recordName,MovePlayer.cnt);

      }
      Time.timeScale=1;
      loadingPanel.SetActive(true);
      Application.LoadLevelAsync(id);
    }

    public void skipResumePanel(){
      resumed=false;
      resumePanel.SetActive(false);
      restart();
    }





    public Image loading;

    public static int score=0;

      IEnumerator loadingResumePanel(){

        while(loading.GetComponent<Image>().fillAmount<1){
          loading.GetComponent<Image>().fillAmount+=0.004f;
          yield return new WaitForSeconds(0.021f);
        }
        resumePanel.SetActive(false);
        restart();
      }

      public void resumeByAd(){
        if(!ShowRewardBasedVideo()){
          ShowAd();
        }
      }

    public override void Success(){
        resumed=true;
        score=MovePlayer.cnt;
        Time.timeScale=1;
        loadingPanel.SetActive(true);

        Application.LoadLevelAsync(Application.loadedLevel);
    }

      void cleanCoin(){

      }

    private InterstitialAd _interstitialAd;

    private BannerView _bannerView;
    
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        //Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    //Debug.LogError("interstitial ad failed to load an ad " + "with error : " + error);
                    return;
                }

                //Debug.Log("Interstitial ad loaded with response : " + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }


     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }

      public bool showIntersitionalAd(){
          if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }


    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }

    public void LoadBannerAd()
    {
        // create an instance of a banner view first.
        if(_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }




    /////////////////////////////
    ////////////////////////////
    /////////////////////////////



    private RewardedAd _rewardedAd;
    void InitAdmobRewarded(){
      if (_rewardedAd != null)
      {
            _rewardedAd.Destroy();
            _rewardedAd = null;
      }

      Debug.Log("Loading the rewarded ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();

      // send the request to load the ad.
      RewardedAd.Load(rewardedId, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  return;
              }

              _rewardedAd = ad;

              RegisterReloadHandler(_rewardedAd);
              RegisterEventHandlers(_rewardedAd);
          });
    }
    
    private bool ShowRewardBasedVideo()
    {
      const string rewardMsg =
        "Rewarded ad rewarded the user";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
          Time.timeScale=0;
            _rewardedAd.Show((Reward reward) =>
            {
              Time.timeScale=1;
              resumed=true;
              score=MovePlayer.cnt;
              
              loadingPanel.SetActive(true);

              Application.LoadLevelAsync(Application.loadedLevel);
            });

            return true;
        }
        
        return false;
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
      // Raised when the ad is estimated to have earned money.
      ad.OnAdPaid += (AdValue adValue) =>
      {
        //   Time.timeScale=1;
        //  resumed=true;
        //  score=MovePlayer.cnt;
         
        //  loadingPanel.SetActive(true);

        //  Application.LoadLevelAsync(Application.loadedLevel);

      };
      // Raised when an impression is recorded for an ad.
      ad.OnAdImpressionRecorded += () =>
      {
          Debug.Log("Rewarded ad recorded an impression.");
      };
      // Raised when a click is recorded for an ad.
      ad.OnAdClicked += () =>
      {
          Debug.Log("Rewarded ad was clicked.");
      };
      // Raised when an ad opened full screen content.
      ad.OnAdFullScreenContentOpened += () =>
      {
          Debug.Log("Rewarded ad full screen content opened.");
      };
      // Raised when the ad closed full screen content.
      ad.OnAdFullScreenContentClosed += () =>
      {
          Debug.Log("Rewarded ad full screen content closed.");
      };
      // Raised when the ad failed to open full screen content.
      ad.OnAdFullScreenContentFailed += (AdError error) =>
      {
          Debug.LogError("Rewarded ad failed to open full screen content " +
                        "with error : " + error);
      };
  }

  private void RegisterReloadHandler(RewardedAd ad)
  {
      // Raised when the ad closed full screen content.
      ad.OnAdFullScreenContentClosed += () =>
      {
          Debug.Log("Rewarded Ad full screen content closed.");

          // Reload the ad so that we can show another as soon as possible.
          InitAdmobRewarded();
      };
      // Raised when the ad failed to open full screen content.
      ad.OnAdFullScreenContentFailed += (AdError error) =>
      {
          Debug.LogError("Rewarded ad failed to open full screen content " +
                        "with error : " + error);

          // Reload the ad so that we can show another as soon as possible.
          InitAdmobRewarded();
      };
  }
}
