using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    public int maxHealth;
    public int currentHealth;
    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    void Update()
    {
        transform.rotation = cam.transform.rotation;
        transform.position = target.position + new Vector3(0, 1);
        if (currentHealth <= 0)
            Debug.Log("game over");
    }
    public void GetHit()
    {
        currentHealth -= 10;
        slider.value = 1f*currentHealth / maxHealth;
    }
}
