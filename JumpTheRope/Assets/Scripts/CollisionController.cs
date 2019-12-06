using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Components {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rope")
        {
            if (pc.isTutorial)
            {
                if (pc.isGrounded)
                {
                    an.SetBool("Move", false);

                    pc.isActive = false;
                    gm.endMenu.SetActive(true);

                    //gm.tutorialText.enabled = true;

                    am.PlayAudio(1);

                    sc.score.text = "Score\n" + gm.jumpsDone;
                    sc.Save();

                    pc.canJump = false;
                }
            }
            else
            {
                an.speed = 0;
                gm.tutorialText.enabled = true;
                pc.canJump = true;
            }
        }
    }
}
