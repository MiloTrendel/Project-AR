using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestParticuleAlaCONBehaviour : MonoBehaviour
{
    public Transform particuleTransform;
    public Camera cam;

    public float screenH = 1080f;
    public float screenV = 1920f;

    public float sensibility = 0.25f;

    private Ray rayPickPos;

    

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition - new Vector3(screenH / 2f, screenV / 2f, 0f); ;

        /*
        Vector3 direction = mouseScreenPosition - transform.position;

        // Calcule la rotation (angle d'Euler) pour pointer dans cette direction
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Convertit la rotation en angles d'Euler
        Vector3 angles = rotation.eulerAngles;

        particuleTransform.transform.eulerAngles = angles;

        Debug.Log("Position de la souris en 2D : " + mouseScreenPosition);
        */
        cam.transform.eulerAngles += new Vector3(-mouseScreenPosition.y, mouseScreenPosition.x, 0f) * sensibility * Time.deltaTime;
        particuleTransform.transform.eulerAngles = cam.transform.eulerAngles;


        if (Input.GetButton("Fire1"))
        {
            rayPickPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(rayPickPos, out rh))
            {
                particuleTransform.position = Vector3.Lerp(transform.position,rh.point,0.5f);
            }
        }
    }
}
