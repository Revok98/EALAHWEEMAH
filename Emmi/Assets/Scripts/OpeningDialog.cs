using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDialog : MonoBehaviour
{
    public List<DialogPage> m_dialogWithPlayer;
    private bool alreadyTalk = false;
    public DialogManager m_dialogDisplayer;

    public List<DialogPage> GetDialog()
    {
        return m_dialogWithPlayer;
    }

    void Update()
    {


        if (!alreadyTalk)
        {
            Container.timerStop = true;
            m_dialogDisplayer.SetDialog(m_dialogWithPlayer);
            alreadyTalk = true;
        }
    }
}
