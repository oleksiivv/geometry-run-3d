using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
public class Triggers : MonoBehaviour
{

    public GameObject pausePanel,restartPanel,bg,loadingPanel,resumePanel;

    public Text[] money;

    public string recordName="hi0";

    public static bool resumed=false;

    string id="3828893";

    public static int x2=1;


    private InterstitialAd intersitional;
    
    private string intersitionalId="ca-app-pub-4962234576866611/8902168514";

    private string appId="ca-app-pub-4962234576866611~5349626885";


    // Start is called before the first frame update
    void Start()
    {

      //old
      //MobileAds.Initialize(appId);

      RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => { });

        //RequestBannerAd();
        RequestConfigurationAd();
        InitAdmobRewarded();
        RequestBannerAd();


      x2=1;
      Advertisement.Initialize(id,false);

      Time.timeScale=1;
      bg.SetActive(!true);
      restartPanel.SetActive(!true);
      pausePanel.SetActive(!true);


      MovePlayer.cnt=score;

      if(resumed)resumed=false;
      firstSecondOfFall=true;

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

          if(addCnt%3==0){
            
            if(!showIntersitionalAd()){
              if(Advertisement.IsReady())Advertisement.Show("Android_Interstitial");
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
        //ShowOptions options = new ShowOptions();
        //options.resultCallback = AdCallbackHandler;
        // if(Advertisement.IsReady("rewardedVideo")){
        //   Advertisement.Show("rewardedVideo",options);
        // }
        // else{
        //   ShowRewardBasedVideo();
        // }
        if(!ShowRewardBasedVideo()){
          ShowOptions options = new ShowOptions();
          options.resultCallback = AdCallbackHandler;
          if(Advertisement.IsReady()){
             Advertisement.Show("Android_Rewarded",options);
          }
        }

      }

      void AdCallbackHandler(ShowResult res)
      {
          if (res == ShowResult.Finished)
          {
            resumed=true;
            score=MovePlayer.cnt;
            Time.timeScale=1;
            loadingPanel.SetActive(true);

            Application.LoadLevelAsync(Application.loadedLevel);

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

      void cleanCoin(){

      }


     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }


      void RequestConfigurationAd(){
          intersitional=new InterstitialAd(intersitionalId);
          AdRequest request=AdRequestBuild();
          intersitional.LoadAd(request);
          intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
          intersitional.OnAdOpening+=this.HandleOnAdOpening;
          intersitional.OnAdClosed+=this.HandleOnAdClosed;

    }


      public bool showIntersitionalAd(){
          if(intersitional.IsLoaded()){
              intersitional.Show();
              return true;
          }
          return false;
      }

      private void OnDestroy(){
          DestroyIntersitional();

          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

      }

      private void HandleOnAdClosed(object sender, EventArgs e)
      {
          intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
          intersitional.OnAdOpening-=this.HandleOnAdOpening;
          intersitional.OnAdClosed-=this.HandleOnAdClosed;

          //RequestConfigurationAd();

        
      }

     private void HandleOnAdOpening(object sender, EventArgs e)
     {
        
     }

     private void HandleOnAdLoaded(object sender, EventArgs e)
     {
        
     }

     public void DestroyIntersitional(){
         intersitional.Destroy();
     }


    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }


    private string bannerId="ca-app-pub-4962234576866611/9835666801";
    private BannerView banner;

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.Bottom);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }




    /////////////////////////////
    ////////////////////////////
    /////////////////////////////



    private RewardedAd rewardBasedVideo;
    void InitAdmobRewarded(){
        this.rewardBasedVideo = new RewardedAd("ca-app-pub-4962234576866611/6782981026");

        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request);
     // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
        this.rewardBasedVideo.OnUserEarnedReward += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;

        request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request);
    }
    public void Clickonrewardreqest()
    {
        this.ShowRewardBasedVideo ();
    }
    public void Clickonrewardshow()
    {
        this.ShowRewardBasedVideo ();
    }
    
    private bool ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            Time.timeScale=0;
            this.rewardBasedVideo.Show();

            return true;
        }
        else{
          return false;
        }
    }
    
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
      
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
      InitAdmobRewarded();
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
      //cleanHandles();
      Time.timeScale=1;
         resumed=true;
         score=MovePlayer.cnt;
         
         loadingPanel.SetActive(true);

         Application.LoadLevelAsync(Application.loadedLevel);

      // resumed=true;
      // score=MovePlayer.cnt;
      // Time.timeScale=1;
      // loadingPanel.SetActive(true);

      // Application.LoadLevelAsync(Application.loadedLevel);
      
      //Debug.Log("The ad was successfully shown.");
        
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
      //cleanHandles();
      resumed=false;
      Time.timeScale=1;
      restart();
       
        Debug.Log("The ad was skipped before reaching the end.");
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    void cleanHandles(){
          rewardBasedVideo.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening -= HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnUserEarnedReward -= HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed -= HandleRewardBasedVideoClosed;

    }




}
