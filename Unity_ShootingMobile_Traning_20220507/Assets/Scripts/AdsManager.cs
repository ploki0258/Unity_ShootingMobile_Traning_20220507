using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements; //引用廣告 API

namespace JACK
{
    /// <summary>
    /// 按下看廣告按鈕後觀看廣告
    /// 看完廣告添加鑽石回饋
    /// 看完廣告添加能量回饋
    /// </summary>
    public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
    {
        [SerializeField, Header("看完廣告的鑽石"), Range(0, 1000)]
        private int addCoinValue = 10;
        [SerializeField, Header("看完廣告的能量"), Range(0, 1000)]
        private int addEnergyValue = 1;

        private int coinPlayer;
        /// <summary>
        /// 廣告按鈕添加鑽石
        /// </summary>
        private Button btnAdsAddCoin;

        private int energyPlayer;
        /// <summary>
        /// 廣告按鈕添加能量
        /// </summary>
        private Button btnAdsAddEnergy;

        private string gameIdAndroid = "4774080"; //後台 Android ID
        private string gameIdIos = "4774081";     //後台 iOS ID
        private string gameId;

        private string adsIdAndroid = "AddCoin";
        private string adsIdIos = "AddCoin";
        private string adsId;
        
        //初始化成功會執行的方法
        public void OnInitializationComplete()
        {
            print("<color=green>1. 廣告初始化成功</color>");
        }

        //初始化失敗會執行的方法
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            print("<color=red>廣告初始化失敗，原因：" + message + "</color>");
        }

        //載入廣告成功會執行的方法
        public void OnUnityAdsAdLoaded(string placementId)
        {
            print("<color=green>2. 廣告載入成功" + placementId + "</color>");
        }

        //載入廣告失敗會執行的方法
        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            print("<color=red>廣告載入失敗，原因：" + message + "</color>");
        }

        /// <summary>
        /// 玩家鑽石數量
        /// </summary>
        private Text textCoin;

        /// <summary>
        /// 玩家能量數量
        /// </summary>
        private Text textEnergy;

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            print("<color=red>3. 廣告顯示失敗，原因：" + message + "</color>");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            print("<color=green>3. 廣告顯示開始" + placementId + "</color>");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            print("<color=green>3. 廣告顯示點擊" + placementId + "</color>");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            print("<color=green>3. 廣告顯示完成" + placementId + "</color>");

            coinPlayer += addCoinValue;
            textCoin.text = coinPlayer.ToString();

            energyPlayer += addEnergyValue;
            textEnergy.text = energyPlayer.ToString();
        }

        /// <summary>
        /// 載入廣告
        /// </summary>
        private void LoadAds() 
        {
            print("載入廣告，ID：" + adsId);
            Advertisement.Load(adsId,this);
            ShowAds();
        }

        /// <summary>
        /// 顯示廣告
        /// </summary>
        public void ShowAds()
        {
            Advertisement.Show(adsId, this);
        }

        private void Awake()
        {
            textCoin = GameObject.Find("玩家鑽石數量").GetComponent<Text>();
            btnAdsAddCoin = GameObject.Find("廣告按鈕添加鑽石").GetComponent<Button>();

            textCoin = GameObject.Find("玩家能量數量").GetComponent<Text>();
            btnAdsAddEnergy = GameObject.Find("廣告按鈕添加能量").GetComponent<Button>();
            btnAdsAddCoin.onClick.AddListener(LoadAds);

            InitializeAds();

            //#if 程式區塊判斷式，條件達成才會執行該區塊
            //如果 玩家 作業系統 是 iOS 就指定為 iOS 廣告
            //否則如果 玩家 作業系統 是 Android 就指定為 Android 廣告
#if UNITY_IOS
            adsId = adsIdIos;
#elif UNITY_ANDROID
            adsId = adsAndroid;
#endif
            //PC端測試
            adsId = adsIdAndroid;
        }

        /// <summary>
        /// 初始化廣告系統
        /// </summary>
        private void InitializeAds()
        {
            gameId = gameIdAndroid;
            Advertisement.Initialize(gameId, true, this);
        }

        
    }
}

