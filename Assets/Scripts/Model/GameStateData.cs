using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateData {

    public bool isFail;
    public StageData CurStageData {
        get {
            PlayerData playerData =  GameFacade.GetInstance().playerData;
            return GameFacade.GetInstance().stageDatas[playerData.StageIndex];
        }


    }
    public void NextStage() {
        PlayerData playerData = GameFacade.GetInstance().playerData;
        StageData[] stageDatas = GameFacade.GetInstance().stageDatas;
        playerData.StageIndex = Mathf.Min(playerData.StageIndex + 1, stageDatas.Length-1);

    }

}
