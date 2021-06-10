using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class Slash : AttackBase
{
    [SerializeField] protected RangeChecker _rangeChecker;
    private int comboCount = 0;
    [SerializeField] private int maxComboCount = 3;
    [SerializeField] private Animator animator;
    
    //combo system
    private static readonly int Animation = Animator.StringToHash("animation");
    private readonly string[] _animatorNames = new[] {"attack1", "attack2", "attack3"};
    public bool canClick;

    public override void Use()
    {
        if (!canClick) return;
        comboCount++;
        
        if (comboCount == 1)
        {
            animator.SetInteger(Animation, 1);
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        for (int i = 0; i < _animatorNames.Length; i++)
        {
            //zo lang we nog niet voorbij de max count zijn kunnen we nog checken voor nog een combo en anders terug naar idle.
            if (i < maxComboCount)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName(_animatorNames[i]) && comboCount > (i + 1))
                {
                    //COMBO
                    animator.SetInteger(Animation, i + 2); //making sure we do the next move count: 2,3,4,5,6 etc.. move 1 is the first move before this is called
                    canClick = true;
                    return;
                }
            }

            //IDLE
            idle:
            animator.SetInteger(Animation, 0);
            comboCount = 0;
            canClick = true;
        }

        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && comboCount == 1)
        // {
        //     //if the first animation is still playing and only 1 click has happened, return to idle
        //     animator.SetInteger(Animation, 0);
        //     comboCount = 0;
        //     canClick = true;
        // }
        // else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && comboCount >= 2)
        // {
        //     //if the first animation is still playing and at least 2 clicks happened, continue to combo
        //     animator.SetInteger(Animation, 2);
        //     comboCount = 0;
        //     canClick = true;
        // }
        //
        // else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && comboCount == 2)
        // {
        //     //if the first animation is still playing and at least 3 clicks happened, continue to combo
        //     animator.SetInteger(Animation, 0);
        //     comboCount = 0;
        //     canClick = true;
        // }
        // else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3") && comboCount >= 2)
        // {
        //     //since this is the third and last animation return to idle
        //     animator.SetInteger(Animation, 0);
        //     comboCount = 0;
        //     canClick = true;
        // }
    }

}
