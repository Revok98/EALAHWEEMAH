using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialog : MonoBehaviour
{
    public List<DialogPage> m_dialogWithPlayer;
    public FinalDialogManager m_dialogDisplayer;
    public GameObject player;
    public bool isLast = false;
    private bool notRead;

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && !notRead)
        {
            notRead = true;
            Container.isTalking = true;
            Container.timerStop = true;
            m_dialogDisplayer.SetDialog(m_dialogWithPlayer, this.gameObject,player,isLast);
        }
    }
}
