using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 1;

    // ObeliskController obeliskController;
    // public GameObject obelisk;

    // [SerializeField] private bool obeliskState = false;

    [SerializeField] private bool elevatorActivated = false;
    [SerializeField] private float elevatorSpeed = 2f;

    public GameObject player;

    private bool isWaiting = false;
    private void Start()
    {
        // obeliskController = obelisk.GetComponent<ObeliskController>();
    }
    // Update is called once per frame
    void Update()
    {

        // obeliskState = obeliskController.getObeliskState();
        // if (obeliskState == true )
        // {
        if (elevatorActivated)
        {
            Moving();
        }
        // }
        UpdatePlayerPosition();

    }

    void UpdatePlayerPosition()
    {
        if (player == null)
        {
            return;
        }
        if (player.transform.parent == transform)
        {
            player.transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, 0);
        }
    }
    void Moving()
    {
        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, elevatorSpeed * Time.deltaTime);
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                StartCoroutine(Delay());
            }
        }
    }


    IEnumerator Delay()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2f);
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
        isWaiting = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Player") && obeliskState == true)
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.gameObject;
            collision.gameObject.transform.SetParent(transform);
            elevatorActivated = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            player = null;
        }
    }
}
