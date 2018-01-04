using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelData :ScriptableObject {
    [System.Serializable]
	public class LevelSetting{

        public int EXP;
        public int ATK;
        public ParticleSystem hitEffect; 
    }


    public LevelSetting[] levelSettings;

    public LevelSetting CurLevelSetting {
        get {
            int LV = GameFacade.GetInstance().playerData.LV; 
            int index = Mathf.Min(LV-1,levelSettings.Length-1);
            return levelSettings[index];
        }


    }


}
