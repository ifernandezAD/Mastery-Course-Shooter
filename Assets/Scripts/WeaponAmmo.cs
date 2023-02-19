using System;
using System.Collections;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    [SerializeField] private bool infiniteAmmo;
    [SerializeField] private int maxAmmo = 24;
    [SerializeField] private int maxAmmoPerClip = 6;

    private int ammoInClip;
    private int ammoRemainingNotInClip;

    public event Action OnAmmoChanged = delegate { };

    protected override void Awake()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;

        base.Awake();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    public bool IsAmmoReady()
    {
        return ammoInClip > 0;
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        ammoInClip--;
        OnAmmoChanged();
    }

    private IEnumerator Reload()
    {
        int ammoMissingFromClip = maxAmmoPerClip - ammoInClip;
        int ammoToMove = Math.Min(ammoMissingFromClip, ammoRemainingNotInClip);
        if (infiniteAmmo)
        {
            ammoToMove = ammoMissingFromClip;
        }

        while (ammoToMove > 0)
        {
            yield return new WaitForSeconds(0.2f);
            ammoInClip += 1;
            ammoRemainingNotInClip -= 1;
            OnAmmoChanged();
            ammoToMove--;
        }

    }

    internal string GetAmmoText()
    {
        if (infiniteAmmo)
        {
            return string.Format("{0}/∞", ammoInClip, ammoRemainingNotInClip);
        }
        else
        {
            return string.Format("{0}/{1}", ammoInClip, ammoRemainingNotInClip);
        }
        
    }
}