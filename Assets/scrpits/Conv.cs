using UnityEngine;
public class Conv : MonoBehaviour
{
    private Vector3 moveobj = new Vector3(0, 0, 0);
    public float Speed = 1f;

    private void Update()
    {
        moveobj = -transform.right;
    }
    private void OnTriggerStay(Collider collision)
    {
        collision.gameObject.transform.position += moveobj * Time.deltaTime * Speed;
    }
}