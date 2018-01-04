using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    private GameStateData gameStateData;
    [SerializeField]
    private Transform enemySpawnPoint;

    private void Awake() {

        gameStateData = GameFacade.GetInstance().gameStateData;

    }
    public IEnumerator Execute() {

        Debug.Log("[EnemyController] Execute");
        StageData stagedata = gameStateData.CurStageData;
        for (int i = 0 ;i<stagedata.enemys.Length;i++) {
            EnemyData enemyData = stagedata.enemys[i];
            EnemyBehavior enemy = Instantiate(enemyData.enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
            yield return StartCoroutine(enemy.Execute(enemyData));
            Destroy(enemy.gameObject);
        }
        

    }
}
