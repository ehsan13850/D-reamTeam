﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTPlayerHandler : Photon.MonoBehaviour, IPunObservable
{

    static public LTPlayerHandler instance;
    public List<GameObject> playerList = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        instance = this;
    }


    void FixedUpdate()
    {
        //if (SumoNetworkManager.Instance.currentGameState == GameStates.Starting)
        //{
        //    SumoNetworkManager.Instance.photonView.RPC("AddPlayers", PhotonTargets.All);
        //}

    }

    [PunRPC]
    public void AddPlayers()
    {
        // GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");
        playerList = new List<GameObject>(LTNetworkManager.Instance.allPlayers);
        // SumoNetworkManager.Instance.currentGameState = GameStates.Assigning;

        /* for (int i = 0; i < NetworkManager.Instance.allPlayers.Count; i++)
         {
             playerList.Add(NetworkManager.Instance.allPlayers[i]);
             Debug.Log(playerList.Count);
         }*/
    }

    [PunRPC]
    public void RemovePlayer(string gameObjectToCheckForName)
    {
        GameObject gameObjecToCheckFor = GameObject.Find(gameObjectToCheckForName);
        if (playerList.Contains(gameObjecToCheckFor))
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i] == gameObjecToCheckFor)
                {
                    playerList.Remove(playerList[i]);
                }
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}