using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public int LV;
    public int ATK;
    public int EXP;
    public int Coin;
    public int StageIndex;
    public PlayerData() {
        LV = 1;
        ATK = 1;
        EXP = 0;
        Coin = 0;
        StageIndex = 0;
    }
}
