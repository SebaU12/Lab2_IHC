using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnScript : MonoBehaviour
{
    // Instanciar un objeto que contenga el prefab
    public GameObject prefab;
    // Instanciar el objeto creado
    GameObject myObj;
    // Instanciar un objeto que contenga las funciones ARPlaneManager
    ARPlaneManager arPlaneManager;
    // Start is called before the first frame update
    void Start()
    {
        // Obtener el objeto actual de la camara
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        // Agregar al objeto la funcion privada 
        arPlaneManager.planesChanged += CheckPlanes;
    }
    private void CheckPlanes(ARPlanesChangedEventArgs args)
    {
        foreach (ARPlane plane in args.added)
        {
            Debug.Log("Buscando plano.");
            // Verificar si esta en un plano horizontal 
            if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
                Debug.Log("Plano horizontal detectado.");
                Vector3 spawnPosition = plane.center; 
                // Hacer Spawn del objeto 
                myObj=Instantiate(prefab, spawnPosition, Quaternion.identity);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
