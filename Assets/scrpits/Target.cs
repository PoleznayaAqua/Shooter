using UnityEngine;

public class Target : MonoBehaviour
{
    public int bonus;
    public void Shoot()
    {
        Destroy(gameObject);
    }
}
