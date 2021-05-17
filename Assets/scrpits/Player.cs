using System.Collections;
using UnityEngine;

[RequireComponent(typeof (DisplayWorker))]

public class Player : MonoBehaviour
{
    float lookSpeed = 2.0f;
    float lxlim = 45.0f;
    float lylim = 45.0f;
    float rotx = 0;
    float roty = 0;
   
    DisplayWorker displayworker;
    public Camera playercamera;

    void Start()
    {
        displayworker = gameObject.GetComponent<DisplayWorker>();
        Global.started = true;
        StartCoroutine(Finish(Global.timetogame, Global.tabletime));
    }
    
    void Update()
    {
        rotx += -Input.GetAxis("Mouse Y") * lookSpeed;
        roty += Input.GetAxis("Mouse X") * lookSpeed;
        rotx = Mathf.Clamp(rotx, -lxlim, lxlim);
        roty = Mathf.Clamp(roty, -lylim, lylim);
        playercamera.transform.localRotation = Quaternion.Euler(rotx, roty, 0);
        if (Input.GetKeyDown(KeyCode.Mouse0)&& Global.started)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 1000000f))
            {
                Target trg = hitInfo.collider.GetComponent<Target>();
                if (trg)
                {
                    trg.Shoot();
                    Global.score += trg.bonus;
                    displayworker.AddCount(Global.score);
                }
            }
        }
    }

    IEnumerator Finish(float time, float waittable)
    {
        yield return new WaitForSeconds(time);
        lookSpeed = 0f;
        Global.started = false;
        displayworker.EndDisplay(Global.score);

        yield return new WaitForSeconds(waittable);
        Application.Quit();
    }
}