using UnityEngine;
 
// A speed boost pickup. When the player touches it, it gives the boost,
// plays a sound and particles, hides, and comes back a few seconds later.
public class CoinPickup : MonoBehaviour
{
    // [SerializeField] private float duration = 10f;    // boost length
    // [SerializeField] private float respawnDelay = 5f; // time hidden
    [SerializeField] private GameObject visuals;      // child to hide
    [SerializeField] private AudioClip pickupSound;
    // [SerializeField] private GameObject pickupEffect; // particle prefab
 
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        Destroy(visuals);
        GetComponent<Collider>().enabled = false;
    }
}
