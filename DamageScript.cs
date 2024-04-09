using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{
    public int damageCount = 10;

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == ("Player"))
        {
            Health health = Coll.gameObject.GetComponent<Health>();
            health.TakeHit(damageCount);
        }
    }


}
