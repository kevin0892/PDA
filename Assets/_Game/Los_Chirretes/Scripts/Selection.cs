using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    public int currentSelection;
    int totalCharacters=2;
    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentSelection<totalCharacters)
        {
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, 90, 0);
            currentSelection++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSelection > 1)
        {
            currentAngle = transform.eulerAngles;
            targetRot = targetRot - new Vector3(0, 90, 0);
            currentSelection--;
        }
        currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y, 2.0f * Time.deltaTime));
        transform.eulerAngles = currentAngle;
    }
}
