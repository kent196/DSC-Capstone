using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Shoot : MonoBehaviour
{

    public AudioSource atkSFX;
    public GameObject shotgunPrefab;
    public float chargeTime = 1f;
    // [SerializeField] private int numberOfBullets = 5;
    // [SerializeField] private float spreadAngle = 10f;
    // private float currentChargeTime = 0f;
    public Animator shotgunerAnim;
    private Vector3 tempScale;
    public GameObject player;
    public PlayerBehaviour playerBehaviour;

    public GameObject[] detector;
    public FlowerDetector[] flowerDetector;

    private void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        player = FindObjectOfType<PlayerBehaviour>().gameObject;
        shotgunerAnim = GetComponent<Animator>();
        flowerDetector = new FlowerDetector[detector.Length];
        for (int i = 0; i < detector.Length; i++)
        {
            flowerDetector[i] = detector[i].GetComponent<FlowerDetector>();
        }
        atkSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        foreach (FlowerDetector d in flowerDetector)
        {
            if (d.TargetVisible)
            {
                tempScale = transform.localScale;
                if (player.transform.position.x > transform.position.x)
                {
                    tempScale.x = Mathf.Abs(transform.localScale.x);
                    transform.localScale = tempScale;
                }
                else
                {
                    tempScale.x = -Mathf.Abs(transform.localScale.x);
                    transform.localScale = tempScale;
                }
                shotgunerAnim.SetBool("isAttacking", true);
            }
            else
            {
                shotgunerAnim.SetBool("isAttacking", false);
            }

        }
    }

    public void Shoot()
    {
        atkSFX.Play();
        playerBehaviour.TakeDamage(50);
    }
}



