namespace SystemSpace{

  public class GameManager{

    readonly LevelLoader levelLoader = new();

    public GameManager(){
      UnityEngine.Debug.Log($"{this} Injected");
    }

    bool CheckIsLevelLoaded(){
      return levelLoader.IsLevelCreated;
    }

  }

}