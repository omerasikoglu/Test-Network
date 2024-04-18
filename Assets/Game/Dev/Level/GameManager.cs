using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

namespace SystemSpace{

  public class GameManager : MonoBehaviour{

    LevelLoader levelLoader;

    void Awake(){
      levelLoader = new();
    }

    async void Start(){
      await UniTask.WaitUntil(() => levelLoader.IsLevelCreated);
    }

    [Button] void CompleteLevel(){
      levelLoader.UnloadCurrentLevel();
      levelLoader.LoadNextLevel();
    }

  }

}