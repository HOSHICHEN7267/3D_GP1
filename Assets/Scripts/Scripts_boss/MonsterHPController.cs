using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Text = TMPro.TextMeshProUGUI;

public class MonsterHPController : MonoBehaviour{
    public Text text_;

    void Start(){
        text_ = this.GetComponent<Text>();
        text_.text = "HP: --";
    }

    public void HPDisplay( int in_HP ){
        text_.text = "HP: " + in_HP.ToString();
    }
}
