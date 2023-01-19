using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 1;

    ObeliskController obeliskController;
    public GameObject obelisk;

    [SerializeField] private bool obeliskState = false;

    [SerializeField] private bool elevatorActivated = false;
    [SerializeField] private float elevatorSpeed = 2f;

    private void Start()
    {
        obeliskController = obelisk.GetComponent<ObeliskController>();
    }
    // Update is called once per frame
    void Update()
    {
        
        obeliskState = obeliskController.getObeliskState();
        if (obeliskState == true )
        {
            if (elevatorActivated)
            {
                Moving();
            }
        }

    }

    void Moving()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            elevatorActivated = false;
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, elevatorSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && obeliskState == true)
        {
            collision.gameObject.transform.SetParent(transform);
            elevatorActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
