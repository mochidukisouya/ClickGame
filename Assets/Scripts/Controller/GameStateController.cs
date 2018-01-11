using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {
    private EnemyController enemyController;
    private GameStateData gameStateData;
    public void Awake() {
        Input.multiTouchEnabled = true;
        enemyController = GameFacade.GetInstance().EnemyController;
        gameStateData = GameFacade.GetInstance().gameStateData;

    }
    private IEnumerator Start() {
        while (true) {
            yield return StartCoroutine(PlayPhase());
            yield return StartCoroutine(EndPhase());
        }

    }
    private IEnumerator PlayPhase() {
        Debug.Log("[GameStataController] PlayPhase");
        yield return StartCoroutine(enemyController.Execute());
    }
    private IEnumerator EndPhase() {
        Debug.Log("[GameStataController] EndPhase");
        gameStateData.NextStage();
        yield return null;
    }
}
