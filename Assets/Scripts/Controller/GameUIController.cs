using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {
    [SerializeField]
    private Text lvLabel;
    [SerializeField]
    private Text attackLabel;
    [SerializeField]
    private Slider expSlider;

    public void UpdataLV(int LV) {

        lvLabel.text = LV.ToString();
        
    }
    public void UpdataAttack(int ATK) {

        attackLabel.text = ATK.ToString();

    }

    public void UpdataEXPSlider(int EXP, int minValue, int maxValue) {
        expSlider.minValue = minValue;
        expSlider.maxValue = maxValue;
        expSlider.value = EXP;

    }
}
