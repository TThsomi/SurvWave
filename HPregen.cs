using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPregen : MonoBehaviour
{
    public int hpRegen = 25;

    void OnTriggerEnter(Collider Coll)
    {
        if(Coll.tag == ("Player"))
        {
            Health health = Coll.gameObject.GetComponent<Health>();
            health.SetHealth(hpRegen);
        }
    }
}
