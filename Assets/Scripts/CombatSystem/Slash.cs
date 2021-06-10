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
    private static readonly int Animation = Animator.StringToHash("Animation");
    private readonly string[] _animatorNames = {"attack1", "attack2", "attack3"};
    public bool canClick = true;

    public override void Use()
    {
        if (!canClick) return;
        comboCount++;
        print(comboCount);
        if (comboCount == 1)
        {
            animator.SetInteger(Animation, 1);
        }
    }

    public override void ComboCheck()
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
    }

}
