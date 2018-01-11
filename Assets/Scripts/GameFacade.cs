using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(GameStateController))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GameUIController))]
public class GameFacade : MonoBehaviour {
    private static GameFacade instance;

    public static GameFacade GetInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<GameFacade>();
            if (instance == null)
                throw new System.Exception("GameFacade不存在於場景中，請在場景中添加");
            instance.Initalize();

        }
        return instance;

    }
    #region Controller
    public EnemyController EnemyController { private set; get; }
    public GameStateController GameStateController { private set; get; }
    public PlayerController playerController { private set; get; }
    public GameUIController gameUIController { private set; get; }
    #endregion
    #region Model
    public StageData[] stageDatas;
    public PlayerData playerData;
    public GameStateData gameStateData;
    public LevelData levelData;
    //public GameController gameController;
    #endregion

    private void Initalize() {
        Debug.Log("[GameFacade] Initalize");
        EnemyController = GetComponent<EnemyController>();
        GameStateController= GetComponent<GameStateController>();
        playerController = GetComponent<PlayerController>();
        gameUIController = GetComponent<GameUIController>();
        //playerData = new PlayerData();
        playerData = GameDataBase.Load<PlayerData>(typeof(PlayerData).Name);
        gameStateData = new GameStateData();

    }
    [ContextMenu("Clear Data")]
    public void Clear() {
        GameDataBase.Clear();
    }

    public void Awake() {
        GetInstance();
    }
    //手機關閉APP時 Pause→Quit
    private void OnApplicationPause(bool pause) {
        Save();
    }

    private void OnApplicationQuit() {
        Save();
    }
    private void Save() {

        GameDataBase.Save(typeof(PlayerData).Name,playerData);
    }
}
