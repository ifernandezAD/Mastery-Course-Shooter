using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] private float drawWeaponSpeed;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(FadeFromShootingLayer());
        }


    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 1);
    }

    private IEnumerator FadeFromShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 0);
    }
}
