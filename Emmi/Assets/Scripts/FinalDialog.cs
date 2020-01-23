using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialog : MonoBehaviour
{
    public List<DialogPage> m_dialogWithPlayer;
    public FinalDialogManager m_dialogDisplayer;
    public GameObject player;
    public GameObject evil;

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Container.timerStop = true;
            m_dialogDisplayer.SetDialog(m_dialogWithPlayer,evil, this.gameObject,player);
        }
    }
}
