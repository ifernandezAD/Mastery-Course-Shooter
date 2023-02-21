using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsToggle : MonoBehaviour
{
    [SerializeField] private GameObject[] firstPersonObjects;
    [SerializeField] private GameObject[] thirdPersonObjects;
    [SerializeField] KeyCode toggleKey = KeyCode.F1;
    
    public bool IsFpsMode { get; set; }

    private Weapons weapons;

    private void Awake()
    {
        weapons = FindObjectOfType<Weapons>();
    }

    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        IsFpsMode = !IsFpsMode;
        weapons.isFpsMode = IsFpsMode;

        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(IsFpsMode);
        }

        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!IsFpsMode);
        }
    }
}
