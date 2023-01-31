using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Animator))]
public class WeaponAnimation : MonoBehaviour
{
    private Weapon weapon;
    private Animator animator;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        animator= GetComponent<Animator>();
    }

    void Start()
    {
        weapon.OnFire += Weapon_Onfire;
    }

    private void Weapon_Onfire()
    {
        animator.SetTrigger("Fire");
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_Onfire;
    }
}
