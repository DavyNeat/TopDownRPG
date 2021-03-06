using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, HurtResponder
{

    [SerializeField] private int health = 10;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int expAmount;
    //[SerializeField] private Rigidbody2D rb;
    private float flashTime;
    Color originalColor;
    private SpriteRenderer sprite;

    private List<BasicHurtBox> hurtBoxes = new List<BasicHurtBox>();

    public bool checkHit(HitData data)
    {
        return true;
    }

    public void Response(HitData data)
    {
        health -= data.damage;
        flashRed();
    }
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        originalColor = sprite.color;
        hurtBoxes = new List<BasicHurtBox>(GetComponentsInChildren<BasicHurtBox>());
        foreach (BasicHurtBox hurtBox in hurtBoxes)
        {
            hurtBox.hurtResponder = this;
        }
        flashTime = .1f;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            for (int i = 0; i < expAmount; i++) {
                GameObject obj = Object.Instantiate(prefab, transform.position, transform.rotation);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f));
            }
        }
    }

    public void flashRed()
    {
        Color newColor = Color.red;
        //newColor.a = 0.2f;
        sprite.color = newColor;
        Invoke("resetColor", flashTime);
    }

    void resetColor()
    {
        sprite.color = originalColor;
    }
}
