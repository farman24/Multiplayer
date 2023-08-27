using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public GameObject spawnPoint;
    void Start()
    {
        Debug.Log("Connecting");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected To Server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("Test",null,null);
        Debug.Log("we are in a room RightNow");

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject __player = PhotonNetwork.Instantiate(player.name, spawnPoint.transform.position, Quaternion.identity);
    }
}
