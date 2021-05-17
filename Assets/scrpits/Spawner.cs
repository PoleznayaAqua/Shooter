using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject item;
    public GameObject item2;
    public GameObject block;
    float delay = 0.5f;
    float randdel = 3f;
    int antiperc = 50;
    Quaternion rotblock = new Quaternion(-90, 0, 0, 90);
    float zposblock;
    float posy=2;
    public GameObject spose;
    void Start()
    {
        zposblock = spose.transform.position.z - 1;
        StartCoroutine(SpawnNewItem(delay));
    }
    IEnumerator SpawnNewItem(float time)
    {
        while (true)
        {
            GameObject sitem;
            int perc = Random.Range(0, 100);
            if(perc>antiperc&&Global.diff==2) sitem = Instantiate(item2);
            else sitem = Instantiate(item);
            perc = Random.Range(0, 100);
            sitem.transform.position = spose.transform.position;
            if (Global.diff >= 1&& perc > antiperc)
            {
                GameObject obj = Instantiate(block);
                obj.transform.SetParent(sitem.transform, false);
                obj.transform.SetPositionAndRotation(new Vector3(spose.transform.position.x+Random.Range(-posy, posy), spose.transform.position.y , zposblock), rotblock);
            }
            yield return new WaitForSeconds(time + Random.Range(0, randdel));
        }
    }
}