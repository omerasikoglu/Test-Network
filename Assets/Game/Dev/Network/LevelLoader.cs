using UnityEngine;
using UnityEngine.SceneManagement;

namespace SystemSpace{

  public class LevelLoader{

    AsyncOperation currentLevelLoadOperation;

    string currentLevelSceneName = string.Empty;

    public bool IsLevelCreated{get; private set;}

    public LevelLoader(int levelNumber = 1){
      LoadLevel(levelNumber);
    }

    public void LoadLevel(int levelNumber){
      if (IsLevelCreated) return;
      if (currentLevelLoadOperation != null) return;

      string levelSceneName = "Level" + levelNumber.ToString("D2");

      currentLevelLoadOperation = SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Additive);

      currentLevelLoadOperation.completed += op => {
        currentLevelSceneName = levelSceneName;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelSceneName));
        IsLevelCreated            = true;
        currentLevelLoadOperation = null;
      };
    }

    public void UnloadCurrentLevel(){
      if (!IsLevelCreated) return;

      SceneManager.UnloadSceneAsync(currentLevelSceneName);
      IsLevelCreated        = false;
      currentLevelSceneName = string.Empty;
    }

  }

}