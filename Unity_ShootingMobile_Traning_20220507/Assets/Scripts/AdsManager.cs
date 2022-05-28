using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements; //�ޥμs�i API

namespace JACK
{
    /// <summary>
    /// ���U�ݼs�i���s���[�ݼs�i
    /// �ݧ��s�i�K�[�p�ۦ^�X
    /// �ݧ��s�i�K�[��q�^�X
    /// </summary>
    public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
    {
        [SerializeField, Header("�ݧ��s�i���p��"), Range(0, 1000)]
        private int addCoinValue = 10;
        [SerializeField, Header("�ݧ��s�i����q"), Range(0, 1000)]
        private int addEnergyValue = 1;

        private int coinPlayer;
        /// <summary>
        /// �s�i���s�K�[�p��
        /// </summary>
        private Button btnAdsAddCoin;

        private int energyPlayer;
        /// <summary>
        /// �s�i���s�K�[��q
        /// </summary>
        private Button btnAdsAddEnergy;

        private string gameIdAndroid = "4774080"; //��x Android ID
        private string gameIdIos = "4774081";     //��x iOS ID
        private string gameId;

        private string adsIdAndroid = "AddCoin";
        private string adsIdIos = "AddCoin";
        private string adsId;
        
        //��l�Ʀ��\�|���檺��k
        public void OnInitializationComplete()
        {
            print("<color=green>1. �s�i��l�Ʀ��\</color>");
        }

        //��l�ƥ��ѷ|���檺��k
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            print("<color=red>�s�i��l�ƥ��ѡA��]�G" + message + "</color>");
        }

        //���J�s�i���\�|���檺��k
        public void OnUnityAdsAdLoaded(string placementId)
        {
            print("<color=green>2. �s�i���J���\" + placementId + "</color>");
        }

        //���J�s�i���ѷ|���檺��k
        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            print("<color=red>�s�i���J���ѡA��]�G" + message + "</color>");
        }

        /// <summary>
        /// ���a�p�ۼƶq
        /// </summary>
        private Text textCoin;

        /// <summary>
        /// ���a��q�ƶq
        /// </summary>
        private Text textEnergy;

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            print("<color=red>3. �s�i��ܥ��ѡA��]�G" + message + "</color>");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            print("<color=green>3. �s�i��ܶ}�l" + placementId + "</color>");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            print("<color=green>3. �s�i����I��" + placementId + "</color>");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            print("<color=green>3. �s�i��ܧ���" + placementId + "</color>");

            coinPlayer += addCoinValue;
            textCoin.text = coinPlayer.ToString();

            energyPlayer += addEnergyValue;
            textEnergy.text = energyPlayer.ToString();
        }

        /// <summary>
        /// ���J�s�i
        /// </summary>
        private void LoadAds() 
        {
            print("���J�s�i�AID�G" + adsId);
            Advertisement.Load(adsId,this);
            ShowAds();
        }

        /// <summary>
        /// ��ܼs�i
        /// </summary>
        public void ShowAds()
        {
            Advertisement.Show(adsId, this);
        }

        private void Awake()
        {
            textCoin = GameObject.Find("���a�p�ۼƶq").GetComponent<Text>();
            btnAdsAddCoin = GameObject.Find("�s�i���s�K�[�p��").GetComponent<Button>();

            textCoin = GameObject.Find("���a��q�ƶq").GetComponent<Text>();
            btnAdsAddEnergy = GameObject.Find("�s�i���s�K�[��q").GetComponent<Button>();
            btnAdsAddCoin.onClick.AddListener(LoadAds);

            InitializeAds();

            //#if �{���϶��P�_���A����F���~�|����Ӱ϶�
            //�p�G ���a �@�~�t�� �O iOS �N���w�� iOS �s�i
            //�_�h�p�G ���a �@�~�t�� �O Android �N���w�� Android �s�i
#if UNITY_IOS
            adsId = adsIdIos;
#elif UNITY_ANDROID
            adsId = adsAndroid;
#endif
            //PC�ݴ���
            adsId = adsIdAndroid;
        }

        /// <summary>
        /// ��l�Ƽs�i�t��
        /// </summary>
        private void InitializeAds()
        {
            gameId = gameIdAndroid;
            Advertisement.Initialize(gameId, true, this);
        }

        
    }
}

