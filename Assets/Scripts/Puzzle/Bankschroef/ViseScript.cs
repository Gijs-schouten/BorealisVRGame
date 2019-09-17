using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViseScript : MonoBehaviour
{
    [Header("Vise Parts")]
    [SerializeField] private GameObject MoveablePart;
    [SerializeField] private GameObject Pin;

    private bool CanTurn;

    private Vector3 OldPinRotation;

    void Start()
    {
        Pin.transform.eulerAngles = new Vector3(0, 90, 0);
        OldPinRotation = Pin.transform.eulerAngles;
    }

    void Update()
    {
        if (Pin.transform.eulerAngles.x < 90)
            Pin.transform.eulerAngles = new Vector3(90, 90, 0);
        if (Pin.transform.eulerAngles.x < -90)
            Pin.transform.eulerAngles = new Vector3(-90, 90, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            Pin.transform.eulerAngles = new Vector3(Pin.transform.eulerAngles.x - 0.1f, 90, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            Pin.transform.eulerAngles = new Vector3(Pin.transform.eulerAngles.x + 0.1f, 90, 0);

        CheckRotation();
    }

    private void CheckRotation()
    {
        if(Pin.transform.eulerAngles == OldPinRotation)
        {
            //Doe niks
        }

        if(Pin.transform.eulerAngles.x > OldPinRotation.x)
        {
            //MoveablePart.transform.Translate(MoveablePart.transform.position.x, MoveablePart.transform.position.y, MoveablePart.transform.position.z + 0.01f);
            OldPinRotation = Pin.transform.eulerAngles;
        }
        if (Pin.transform.eulerAngles.x < OldPinRotation.x)
        {
            //MoveablePart.transform.Translate(MoveablePart.transform.position.x, MoveablePart.transform.position.y, MoveablePart.transform.position.z - 0.01f);
            OldPinRotation = Pin.transform.eulerAngles;
        }
    }
}
