using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Rigidbody BulletPrefab;
    public Transform FirePoint;

    public float MoveSpeed;
    public float RotSpeed;

    private void Start()
    {
        if(isLocalPlayer)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
                r.material.color = Color.green;
        }
        else
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
                r.material.color = Color.red;
        }
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        var y = Input.GetAxis("Horizontal") * Time.deltaTime * RotSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);

        if (Input.GetButtonDown("Fire1")) CmdFire();
    }

    [Command]
    private void CmdFire()
    {
        var bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.velocity = bullet.transform.forward * 10;
        NetworkServer.Spawn(bullet.gameObject);
    }
}
