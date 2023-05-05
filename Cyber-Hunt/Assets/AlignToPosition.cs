using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToPosition : MonoBehaviour
{
    
    [SerializeField] private float FinalPositionX;
    [SerializeField] private float FinalPositionY;
    

    [SerializeField] private float rotationAmount = 120f; // Gradzahl, um die das GameObject rotiert werden soll
    [SerializeField] private float rotationTime = 2f; // Zeit, die f�r die Rotation ben�tigt wird

    private bool isRotating = false; // Flag, ob das GameObject derzeit rotiert
    private float currentRotation = 0f; // Aktueller Rotationswinkel

    private Quaternion startingRotation;



    // Start is called before the first frame update

    public float movementSpeed = 0.002f;

    // Use this for initialization
    void Start()
    {
        startingRotation = transform.localRotation;
        StartRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != new Vector3(FinalPositionX, FinalPositionY, 0))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(FinalPositionX, FinalPositionY, 0), movementSpeed * Time.deltaTime);

            if (!isRotating)
                return;

            // Berechnen, wie weit das GameObject in diesem Frame rotieren soll
            float rotationPerFrame = rotationAmount / rotationTime * Time.deltaTime;
            currentRotation += rotationPerFrame;

            // Wenn das GameObject die gew�nschte Rotation erreicht hat, Rotation beenden
            if (currentRotation >= rotationAmount)
            {
                transform.localRotation = startingRotation * Quaternion.Euler(0, 0, rotationAmount);
                isRotating = false;
                return;
            }

            // GameObject in der Z-Achse rotieren, relativ zum Parent-GameObject
            transform.localRotation = startingRotation * Quaternion.Euler(0, 0, currentRotation);
        }



    }

    
    public void StartRotation()
    {
        if (!isRotating)
        {
            isRotating = true;
            currentRotation = 0f;
        }
    }
    private void OnEnable()
    {
        StartRotation();
    }
}

    
