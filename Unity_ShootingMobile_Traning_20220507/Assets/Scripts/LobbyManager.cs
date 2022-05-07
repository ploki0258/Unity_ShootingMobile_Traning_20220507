using UnityEngine;
using Photon.Pun; //�ޥ�Photon Pun API
using UnityEngine.UI;
using Photon.Realtime; //�ޥ�Photon �Y�� API

/// <summary>
/// �j�U�޲z��
/// ���a���U��ԫ��s��}�l�ǰt�ж�
/// </summary>
/// MonoBehaviourPunCallbacks �s�u�\��^�G���O
/// �Ҧp: �n�J�j�U��^�G�A���w�o�{��
public class LobbyManager : MonoBehaviourPunCallbacks
{
    //GameObject �C������:�s�� Unity �������Ҧ�����
    //SerializeField �N�p�H�����ܦb�ݩʭ��O�W
    //Header ���D�A�b�ݩʭ��O�W��ܲ���r���D
    [SerializeField,Header("�s�u���e��")]
    private GameObject goConnenctView;
    [SerializeField, Header("��ԫ��s")]
    private Button btnBattle;
    [SerializeField, Header("�s�u�H��")]
    private Text textCountPlayer;

    //����ƥ�:����C���ɰ���@���A��l�Ƴ]�w
    private void Awake()
    {
        //Photon �s�u���s�u�ϥγ]�w
        PhotonNetwork.ConnectUsingSettings();
    }

    //override ���\�Ƽg�~�Ӫ������O����
    //�s�u�ܱ���x
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("<color=yellow>1. �w�g�i�J����x</color>");

        //Photon �s�u.�[�J�j�U
        PhotonNetwork.JoinLobby();
    }

    //�s�u�ܤj�U���\��|���榹��k
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("<color=yellow>2. �w�g�i�J�j�U</color>");
        
        //��ԫ��s.���� = �Ұ�
        btnBattle.interactable = true;
    }

    //����:����
    //�����s�򫰥����q���y�{
    //1. ���Ѥ��}����k Public Method
    //2. ���s�b�I�� On Click ��I�s����k

    //�}�l�s�u���
    public void StarrtConnect()
    {
        print("<color=yellow>3. �}�l�s�u...</color>");

        //�C������.�Ұʳ]�w
        goConnenctView.SetActive(true);

        //Photon �s�u�� �[�J�H���ж�
        PhotonNetwork.JoinRandomRoom();
    }

    //�[�J�H���ж�����
    //1.�s�u�~��t
    //2.�L�ж�
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("<color=red>4. �[�J�H���ж�����</color>");

        RoomOptions ro = new RoomOptions(); //�s�W�ж��]�w����
        ro.MaxPlayers = 20;                 //���w�ж��̤j�H��
        PhotonNetwork.CreateRoom("",ro);    //�إߩж��õ����ж�����
    }

    //�[�J�ж�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("<color=yellow>5. �}�Ъ̶i�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;

        textCountPlayer.text = "�s�u�H��" + currentCount + " / " + maxCount;
    }
}
