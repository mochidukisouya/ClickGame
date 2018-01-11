using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerData playerData;
    private LevelData levelData;
    private ParticleSystem[] hitEffects = new ParticleSystem[3];
    private int hitEffectUseIndex;
    private GameUIController gameUIController;

    private void Awake() {
        playerData = GameFacade.GetInstance().playerData;
        levelData = GameFacade.GetInstance().levelData;
        gameUIController = GameFacade.GetInstance().gameUIController;
    }
    private void OnEnable() {
        RefreshPlayerData();

    }
    private void RefreshPlayerData() {
        playerData.ATK = levelData.CurLevelSetting.ATK;
        for (int i = 0; i < hitEffects.Length; i++) {
            if (hitEffects[i] != null) {
                Destroy(hitEffects[i].gameObject);
            }
            Debug.Log("length"+hitEffects.Length);
            Debug.Log("i"+i);
            hitEffects[i] = Instantiate(levelData.CurLevelSetting.hitEffect);
        }
        gameUIController.UpdataAttack(playerData.ATK);
        gameUIController.UpdataLV(playerData.LV);
        int minEXP = levelData.LastLevelSetting.EXP;
        int maxEXP = levelData.CurLevelSetting.EXP;
        if (playerData.LV == 1) {
            minEXP = 0;
        }
        gameUIController.UpdataEXPSlider(playerData.EXP,minEXP,maxEXP);
        //Debug.Log("exp="+playerData.EXP);
        //Debug.Log("min="+minEXP);
        //Debug.Log("max="+maxEXP);
        if (playerData.EXP >= maxEXP)
        {
            LevelUP();
        }
    }
    public void AddEXP(int amount) {
        if (playerData.LV >= levelData.levelSettings.Length) {
            return;
        }
        playerData.EXP += amount;
        //Debug.Log(playerData.EXP);
        RefreshPlayerData();

    }
    private void LevelUP() {
        playerData.LV = Mathf.Min(playerData.LV + 1, levelData.levelSettings.Length);
        playerData.ATK = levelData.CurLevelSetting.ATK;
        RefreshPlayerData();
    }

    public void OnClick(EnemyBehavior enemy) {
        enemy.DoDamage(playerData.ATK);
        ParticleSystem hitEffect = hitEffects[hitEffectUseIndex];
        hitEffect.transform.position = enemy.hitPoint.position;
        hitEffect.Stop();
        hitEffect.Play();
        hitEffectUseIndex = (int)Mathf.Repeat(hitEffectUseIndex + 1, hitEffects.Length);


    }

}
