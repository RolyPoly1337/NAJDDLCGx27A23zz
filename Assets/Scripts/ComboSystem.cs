using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
    
    public enum AttackType {  heavy = 0, light = 1, kick =2};
public class ComboSystem : MonoBehaviour {

    [Header("Inputs")]
    public KeyCode heavyKey;
    public KeyCode lightKey;
    public KeyCode kickKey;

    [Header("Attacks")]
    public KeyCode heavyAtk;
    public KeyCode lightAtk;
    public KeyCode kickAtk;



}

[System.Serializable]
public class Attack
{
    public string name;
    public float length;
}

[System.Serializable]
public class ComboInput
{
    public AttackType type;
    //Insert movement input here eg more forward while atk
}

[System.Serializable]
public class Combo
{
    public List<ComboInput> inputs;
    public Attack comboAttack;
    public UnityEvent onInput;
    int curInput = 0;
}
    /*public bool continueCombo(ComboInput i)
    {
        if (i.type == inputs[curInput].type) // Add && i.movement == Inputs[curInput].movement
        {
             
        }
    }
}
*/
