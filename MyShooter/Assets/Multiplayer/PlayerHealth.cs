using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public Transform HealthCanvas;
    public Image FillImage;

    public int MaxHealth = 100;
    [SyncVar(hook = "OnHealthChanged")]
    public int CurrentHealth = 100;

    public void LateUpdate()
    {
        HealthCanvas.LookAt(Camera.main.transform);
    }

    public void GetDamage(int damage)
    {
        if (!isServer) return;

        if (CurrentHealth <= 0) return;

        CurrentHealth -= damage;
        if (CurrentHealth <= 0) RpcRespawn();
    }

    private void OnHealthChanged(int health)
    {
        CurrentHealth = health;
        FillImage.fillAmount = (float)CurrentHealth / MaxHealth;
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        CurrentHealth = MaxHealth;
        transform.position = Vector3.up * 2f;
    }
}
