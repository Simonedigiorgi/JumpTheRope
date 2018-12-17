using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Components {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rope")
        {
            if (pc.isGrounded)
            {
                an.SetBool("Move", false);

                pc.isActive = false;
                gm.endMenu.SetActive(true);

                gm.tutorialText.enabled = true;

                am.PlayAudio(1);

                sc.score.text = "Score\n" + gm.jumpsDone;
                sc.Save();
            }
        }
    }
}
