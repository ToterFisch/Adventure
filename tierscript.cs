using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Data;
public class tierscript : MonoBehaviour
{
    public string name;
    public string maineffect;
    public int mainstrength;
    public string sideeffect1;
    public int sidestrength1;
    public string sideeffect2;
    public int sidestrength2;
    public string sideeffect3;
    public int sidestrength3;
    public string sideeffect4;
    public int sidestrength4;
    public string sideeffect5;
    public int sidestrength5;
    public string sideeffect6;
    public int sidestrength6;
    public int multiplier1;
    public int multiplier2;
    public float cooldown;
    public float basiscooldown;
    public TMP_InputField namestuffr;
    public effectpossscript maineffectr;
    public effectpossscript number1r;
    public effectpossscript sideeffect1r;
    public effectpossscript number2r;
    public effectpossscript sideeffect2r;
    public effectpossscript number3r;
    public effectpossscript sideeffect3r;
    public effectpossscript number4r;
    public effectpossscript sideeffect4r;
    public effectpossscript number5r;
    public effectpossscript sideeffect5r;
    public effectpossscript number6r;
    public effectpossscript sideeffect6r;
    public effectpossscript multiplier1r;
    public effectpossscript multiplier2r;
    public int tiertier;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MachMathe()
    {
        name = namestuffr.text;
        cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown+sideeffect1r.das.cooldown+sideeffect2r.das.cooldown+sideeffect3r.das.cooldown+sideeffect4r.das.cooldown+number3r.das.cooldown+number4r.das.cooldown+number5r.das.cooldown+number6r.das.cooldown+multiplier1r.das.cooldown;
        maineffect = null;
        multiplier1 = 0;
        mainstrength = 0;
        sideeffect1 = null;
        sidestrength1 = 0;
        sideeffect2 = null;
        sidestrength2 = 0;
        sideeffect3 = null;
        sidestrength3 = 0;
        sideeffect4 = null;
        sidestrength4 = 0;
        sideeffect5 = null;
        sidestrength5 = 0;
        sideeffect6 = null;
        sidestrength6 = 0;
        if (tiertier == 1)
        {
            cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown;
            maineffect = maineffectr.das.name;
            mainstrength = (number1r.das.strength + number2r.das.strength)*multiplier1r.das.strength;
            
        }
        else if (tiertier == 2)
        {
            cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown+sideeffect1r.das.cooldown+sideeffect2r.das.cooldown+multiplier1r.das.cooldown;
            maineffect = maineffectr.das.name;
            multiplier1 = multiplier1r.das.strength;
            mainstrength = (number1r.das.strength + number2r.das.strength)*multiplier1;
            sideeffect1 = sideeffect1r.das.name;
            sidestrength1 = number1r.das.strength;
            sideeffect2 = sideeffect2r.das.name;
            sidestrength2 = number2r.das.strength;
            
        }
        else if (tiertier == 3)
        {
            cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown+sideeffect1r.das.cooldown+sideeffect2r.das.cooldown+number3r.das.cooldown+number4r.das.cooldown+multiplier1r.das.cooldown;
            maineffect = maineffectr.das.name;
            multiplier1 = multiplier1r.das.strength;
            mainstrength = (number1r.das.strength + number2r.das.strength)*multiplier1;
            sideeffect1 = sideeffect1r.das.name;
            sidestrength1 = number1r.das.strength+number3r.das.strength;
            sideeffect2 = sideeffect2r.das.name;
            sidestrength2 = number2r.das.strength+number4r.das.strength;
            
        }
        else if(tiertier == 4)
        {
            cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown+sideeffect1r.das.cooldown+sideeffect2r.das.cooldown+sideeffect3r.das.cooldown+sideeffect4r.das.cooldown+number3r.das.cooldown+number4r.das.cooldown+multiplier1r.das.cooldown;
            maineffect = maineffectr.das.name;
            multiplier1 = multiplier1r.das.strength;
            mainstrength = (number1r.das.strength + number2r.das.strength)*multiplier1;
            sideeffect1 = sideeffect1r.das.name;
            sidestrength1 = number1r.das.strength+number3r.das.strength;
            sideeffect2 = sideeffect2r.das.name;
            sidestrength2 = number2r.das.strength+number4r.das.strength;
            sideeffect3 = sideeffect3r.das.name;
            sidestrength3 = number3r.das.strength;
            sideeffect4 = sideeffect4r.das.name;
            sidestrength4 = number4r.das.strength;
        }
        else if(tiertier == 5)
        {
            cooldown = basiscooldown+number1r.das.cooldown+number2r.das.cooldown+sideeffect1r.das.cooldown+sideeffect2r.das.cooldown+sideeffect3r.das.cooldown+sideeffect4r.das.cooldown+number3r.das.cooldown+number4r.das.cooldown+multiplier1r.das.cooldown;
            maineffect = maineffectr.das.name;
            multiplier1 = multiplier1r.das.strength;
            mainstrength = (number1r.das.strength + number2r.das.strength)*multiplier1;
            sideeffect1 = sideeffect1r.das.name;
            sidestrength1 = number1r.das.strength+number3r.das.strength;
            sideeffect2 = sideeffect2r.das.name;
            sidestrength2 = number2r.das.strength+number4r.das.strength;
            sideeffect3 = sideeffect3r.das.name;
            sidestrength3 = number3r.das.strength;
            sideeffect4 = sideeffect4r.das.name;
            sidestrength4 = number4r.das.strength;
            sideeffect5 = sideeffect5r.das.name;
            sidestrength5 = number3r.das.strength;
            sideeffect6 = sideeffect6r.das.name;
            sidestrength6 = number4r.das.strength;

        }
    }
}
