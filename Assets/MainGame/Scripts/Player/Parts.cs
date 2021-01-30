using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    public float partsHealth { get; protected set; }
    public float partsDamage { get; protected set; }
    public bool partsType { get; set; }
    public float partsAttSpeed { get; protected set; }
    public float partsMoveSpeed { get; protected set; }
    public float attRange { get; protected set; }

    public string name { get; protected set; }

    public bool dash { get; protected set; }
    public int jumpCount { get; protected set; }

    public float jumpForce { get; protected set; }

    public GameObject mainObject;


    public Parts(float partsHealth, float partsDamage, bool partsType, float partsAttSpeed, float partsMoveSpeed, string name, float attRange, bool dash, int jumpCount, float jumpForce)
    {
        this.partsHealth = partsHealth;
        this.partsDamage = partsDamage;
        this.partsType = partsType;
        this.partsAttSpeed = partsAttSpeed;
        this.partsMoveSpeed = partsMoveSpeed;
        this.name = name;
        this.attRange = attRange;
        this.dash = dash;
        this.jumpCount = jumpCount;
        this.jumpForce = jumpForce;
    }
}
