using UnityEngine;
using UnityEngine.SceneManagement;

namespace SystemSpace{

  public class LevelLoader{

    AsyncOperation currentLevelLoadOperation;

    string          currentLevelSceneName = string.Empty;
    readonly string startingLevelName     = "Level01";
    readonly int    startingLevelNumber   = 1;

    public int  CurrentLevel  {get; private set;}
    public bool IsLevelCreated{get; private set;}

    public LevelLoader(int levelNumber = 1){
      CurrentLevel = levelNumber;
      LoadLevel(levelNumber);
    }

    public void LoadLevel(int levelNumber){
      if (IsLevelCreated) return;
      if (currentLevelLoadOperation != null) return;

      string levelSceneName = "Level" + levelNumber.ToString("D2");
      IsValidLevel(ref levelSceneName);

      currentLevelLoadOperation = SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Additive);

      currentLevelLoadOperation.completed += op => {
        currentLevelSceneName     = levelSceneName;
        IsLevelCreated            = true;
        currentLevelLoadOperation = null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelSceneName));
      };
    }

    void IsValidLevel(ref string levelSceneName){
      if (SceneUtility.GetBuildIndexByScenePath(levelSceneName) == -1){
        levelSceneName = startingLevelName;
        CurrentLevel   = startingLevelNumber;
      }
      else{
        CurrentLevel++;
      }
    }

    public void UnloadCurrentLevel(){
      if (!IsLevelCreated) return;

      SceneManager.UnloadSceneAsync(currentLevelSceneName);
      IsLevelCreated        = false;
      currentLevelSceneName = string.Empty;
    }

    public void LoadNextLevel(){
      LoadLevel(CurrentLevel + 1);
      Debug.Log(CurrentLevel);
    }

  }

}