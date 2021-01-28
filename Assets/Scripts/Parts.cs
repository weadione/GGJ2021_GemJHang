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

    public string name { get; protected set; }

    public GameObject mainObject;


    public Parts(float partsHealth, float partsDamage, bool partsType, float partsAttSpeed, float partsMoveSpeed, string name)
    {
        this.partsHealth = partsHealth;
        this.partsDamage = partsDamage;
        this.partsType = partsType;
        this.partsAttSpeed = partsAttSpeed;
        this.partsMoveSpeed = partsMoveSpeed;
        this.name = name;
    }
}
