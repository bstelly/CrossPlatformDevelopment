using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Sprite image;
    private bool isColliding;

    public string name;
    public SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        image = sr.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding) return;

        isColliding = true;
        Debug.Log("collided");
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerBehaviour>();
            player.inventory.Add(this);
            Destroy(gameObject);
        }
    }
}