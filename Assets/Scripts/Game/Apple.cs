using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private const float VALUE = 1;
    //private float speed = 1f;

    private Player player = default;

    private AudioSource audioSourceMiss;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        if (player == null)
        {
            Debug.Log("Player is null");
        }

        audioSourceMiss = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        // TODO: Make the apple spin while moving down

        float yMin = -5.2f;

        if (transform.position.y < yMin)
        {
            if (isDead == true)
            {
                return;
            }
            else
            {
                isDead = true;
                player.Damage();
                audioSourceMiss.Play();
                Destroy(gameObject, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Player cPlayer = other.GetComponent<Player>();
            cPlayer.Collect(VALUE);
            Destroy(gameObject);
        }
    }

    public float getValue()
    {
        return VALUE;
    }
}
