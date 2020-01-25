using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerScene2 : MonoBehaviour
/* Author : Raphaël Marczak - 2018, for ENSEIRB-MATMECA
 * 
 * This work is licensed under the CC0 License. 
 * 
 */
{

    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;
    private bool removetext;

    void Awake()
    {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
        if (m_dialogToDisplay.Count >0)
        {
            removetext = true;
            m_renderText.text = m_dialogToDisplay[0].text + "\n" + "<size=10><color=#FFA500>Appuyez sur espace pour continuer</color></size>";
        }
        else
        {
            Container.timerStop = false;
            this.gameObject.SetActive(false);
        }

        // Remoeves the page when the player presses "space"
        if (Input.GetKeyDown("space") && removetext)
        {
            removetext = false;
            m_dialogToDisplay.RemoveAt(0);
        }
    }

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }
}
