using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Network{

  public class NetworkManagerUI : MonoBehaviour{

    [SerializeField] Button serverBtn;
    [SerializeField] Button hostBtn;
    [SerializeField] Button clientBtn;

    void Awake(){
      serverBtn.onClick.AddListener(() => NetworkManager.Singleton.StartServer());
      hostBtn.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
      clientBtn.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }

    void OnServerButtonClicked(){
      NetworkManager.Singleton.StartServer();
    }

  }

}