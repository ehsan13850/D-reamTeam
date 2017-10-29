﻿using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

public class BTNetwork : Photon.MonoBehaviour, IPunObservable {


    BombTagCharacterController controlScript;
    //public NetworkManager Instance;


    void Awake()
    {
       // Instance = GameObject.FindGameObjectWithTag("NM").GetComponent<NetworkManager>();
        controlScript = GetComponent<BombTagCharacterController>();
        if (photonView.isMine)
        {
            //MINE: local player, simply enable the local scripts
            controlScript.enabled = true;
        }
        else
        {

            controlScript.enabled = false;
        }
            gameObject.name = gameObject.name + photonView.viewID;

    }

   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}