using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject projectile;
    public Transform GunPos;
    
    public void Fire()
    {
        if(!projectile) return;
        Instantiate(projectile, GunPos.position, Quaternion.identity);
    }
}
