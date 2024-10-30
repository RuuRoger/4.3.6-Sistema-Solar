using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    //public properties
    public float speedSun;
    public float speedSatellite1;
    public float speedSatellite2;
    
    //Private attributes
    private Transform _sun;
    private Transform _satellite1;
    [SerializeField] private Transform _satellite2;
    private Camera _camera;



    //Methods
    private void Start()
    {
        //Initialize variables
        _sun = transform;
        _satellite1 = transform.Find("Satellite1");
        _camera = Camera.main;

    }
    private void Update()
    {

        //Looking the center of universe
        transform.LookAt(Vector3.zero);
        
        // Orbit of the sun
        transform.RotateAround(Vector3.zero, Vector3.up, 30 * speedSun * Time.deltaTime);

        //Orbit of satellite1
        _satellite1.RotateAround(_sun.position, Vector3.right, 90 * Time.deltaTime *speedSatellite1);

        //Orbit of satellite 2
        _satellite2.RotateAround(_satellite1.position, Vector3.up,45 * speedSatellite2 * Time.deltaTime);
        //Lookin axis z about satellite 1
        _satellite2.LookAt(_satellite1);

        //Rays between objects
       
        Debug.DrawLine(_sun.position, Vector3.zero,Color.blue); 
        Debug.DrawLine(_satellite1.position, _sun.position, Color.green);
        Debug.DrawLine(_satellite2.position,_sun.position, Color.yellow);
        Debug.DrawLine(_satellite2.position,_satellite1.position, Color.red);

        //Camra always looks sun
        _camera.transform.LookAt(_sun.position);

    }

}
