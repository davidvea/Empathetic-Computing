using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.XR.Cardboard;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class GazeInteractionController : MonoBehaviour
{
    public float interactableDistance = 100;
    public GameObject gazedObject;
    public PointerEventData _eventData;

    public NavMeshAgent playerNavMeshAgent;

    public UnityEvent onFocus;
    public UnityEvent onLoseFocus;
    public UnityEvent onDwell;
    public UnityEvent onLoseDwell;

    enum NavigationMethod {NavMesh, Auto, Teleport }
    [SerializeField] NavigationMethod navigationMethod;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()   
    {
        //shoots a laser from the middle at a distance of interactableDistance
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactableDistance))
        {
            //if it hits a gameobject, gazedobject is referred to as that game object
            gazedObject = hit.transform.gameObject;
            //Debug.Log(gazedObject);
            //reticle color is white
            onFocus.Invoke();

            //if the cardboard button or mouse left click is held down
            if (Api.IsTriggerHeldPressed || Input.GetMouseButton(0))
            {
                //radial bar will fill in time
                onDwell.Invoke();
            }
            else
            {
                //radial bar returns to 0
                onLoseDwell.Invoke();
            }
            
        }
        else
        {
            //gazedobject is empty
            gazedObject = null;
            //reticle color is black
            onLoseFocus.Invoke();
        }
    }
}
