using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTurret : MonoBehaviour
{
    [SerializeField] private float MinAngle;
    [SerializeField] private float MaxAngle;

    [SerializeField] private Shooting TurretR;
    [SerializeField] private Shooting TurretL;
    private Shooting TurretMain;
    private Camera mainCam;

    private void Awake()
    {
       
            mainCam = Camera.main;

        
        TurretMain = gameObject.GetComponent<Shooting>();
    }
    private void Update()
    {
        
        float DistanceR = (mainCam.ScreenToWorldPoint(Input.mousePosition) - TurretR.gameObject.transform.position).magnitude;
        float DistanceL = (mainCam.ScreenToWorldPoint(Input.mousePosition) -TurretL.gameObject.transform.position).magnitude;
        float DistanceM = (mainCam.ScreenToWorldPoint(Input.mousePosition) - TurretMain.gameObject.transform.position).magnitude;

        if(DistanceM<DistanceL && DistanceM < DistanceR)
        {
            TurretMain.Activate(true);
            TurretL.Activate(false);
            TurretR.Activate(false);
        }
        else if(DistanceR < DistanceL && DistanceR < DistanceM)
        {
            TurretMain.Activate(false);
            TurretL.Activate(false);
            TurretR.Activate(true);
        }
        else
        {
            TurretMain.Activate(false);
            TurretR.Activate(false);
            TurretL.Activate(true);
        }
    }
}
