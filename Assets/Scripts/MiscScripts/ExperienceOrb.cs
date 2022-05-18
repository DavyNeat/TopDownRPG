using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Transform player;
    private Transform orb;
    private void Start()
    {
        orb = GetComponent<Transform>();
        player = GameObject.Find("Player").transform;
    }
    void FixedUpdate()
    {
        orb.position = Vector3.MoveTowards(orb.position, player.position, speed * Time.deltaTime);
    }
}
