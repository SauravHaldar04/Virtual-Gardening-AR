using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] plants;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public XROrigin origin;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private void Update()
    {
        if(Input.GetTouch(0).phase== TouchPhase.Began)
        {
            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);
            if (collision)
            {
                GameObject _object = Instantiate(plants[Random.Range(0, plants.Length-1)]);
           _object.transform.position = raycastHits[0].pose.position;   
            }
            foreach(var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;
        }
    }
}
