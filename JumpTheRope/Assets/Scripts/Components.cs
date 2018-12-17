using UnityEngine;

public class Components : MonoBehaviour {

    public PlayerController pc;
    public Animator an;
    public AudioManager am;
    public Scoreboard sc;
    public GameManager gm;

	void Awake () {

        pc = FindObjectOfType<PlayerController>();
        gm = FindObjectOfType<GameManager>();
        am = FindObjectOfType<AudioManager>();
        sc = FindObjectOfType<Scoreboard>();
        an = FindObjectOfType<RopeController>().GetComponent<Animator>();
    }
}
