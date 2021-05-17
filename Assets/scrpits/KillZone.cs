using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
