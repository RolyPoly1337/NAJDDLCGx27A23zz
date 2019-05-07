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
    public Attack heavyAtk;
    public Attack lightAtk;
    public Attack kickAtk;
    public List<Combo> combos;
    public float comboTimeInBetween = 0.2f;

    [Header("Components")]
    Animator anim;

    Attack curAttack = null;

    ComboInput lastInput = null;
    List<int> currentCombos = new List<int>();

    float timer = 0;
    float leeway = 0;
    bool skip = false;

     void Start()
    {
        anim = GetComponent<Animator>();
        PrimeCombos();
    }
    
    void PrimeCombos()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInput.AddListener(() =>
            {
                // call atk function with the combos atk
                skip = true;
                Attack(c.comboAttack);
                ResetCombos();
            });
        }
    }

     void Update()
    {
        if (curAttack != null)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                curAttack = null;

            return;
        }

        if (currentCombos.Count > 0)
        {
            leeway += Time.deltaTime;
            if (leeway >= comboTimeInBetween)
            {
                if (lastInput != null)
                {
                    Attack(getAttackFromType(lastInput.type));
                    lastInput = null;
                }
                ResetCombos();

            }
        }
        else
            leeway = 0;

            // INPUTS ARE HERE____________________________________________________
            ComboInput input = null;
        if (Input.GetKeyDown(heavyKey))
            input = new ComboInput(AttackType.heavy);
        if (Input.GetKeyDown(lightKey))
            input = new ComboInput(AttackType.light);
        if (Input.GetKeyDown(kickKey))
            input = new ComboInput(AttackType.kick);

        if (input == null) return;
        lastInput = input;

        List<int> remove = new List<int>();
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if (c.continueCombo(input))
                leeway = 0;
            else
                remove.Add(i);
        }

        if (skip)
        {
            skip = false;
            return;
        }

        for (int i = 0; i < combos.Count; i++)
        {
            if (currentCombos.Contains(i)) continue;
            if (combos[i].continueCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }

        }

        foreach (int i in remove)
        
            currentCombos.RemoveAt(i);

        if (currentCombos.Count <= 0)
            Attack(getAttackFromType(input.type));
        

    }

    void ResetCombos()
    {
        leeway = 0;
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();
        }

        currentCombos.Clear();
    }

    void Attack(Attack atk)
    {
        curAttack = atk;
        timer = atk.length;
        anim.Play(atk.name, -1, 0);
        
    }

    Attack getAttackFromType(AttackType t)
    {
        if (t == AttackType.heavy)
            return heavyAtk;
        if (t == AttackType.light)
            return lightAtk;
        if (t == AttackType.kick)
            return kickAtk;
        return null;

    }




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

    public ComboInput (AttackType t)
    {
        type = t;
    }

    public bool IsSameAs(ComboInput test)
    {
        return (type == test.type); // Add && movement == Inputs[curInput].movement
    }

}

[System.Serializable]
public class Combo
{
    public string name;
    public List<ComboInput> inputs;
    public Attack comboAttack;
    public UnityEvent onInput;
    int curInput = 0;

    public bool continueCombo(ComboInput i)
    {
        if (inputs[curInput].IsSameAs(i))
        {
            curInput++;
            if (curInput >= inputs.Count)
            {
                onInput.Invoke();
                curInput = 0;
            }

            return true;
        }
        else
        {
            curInput = 0;
            return false;
        }

    }
    public ComboInput currentComboInput()
    {
        if (curInput >= inputs.Count) return null;
        return inputs[curInput];
    }
    public void ResetCombo()
    {
        curInput = 0;
    }
}
    



