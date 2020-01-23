/* Author : Raphaël Marczak - 2018, for ENSEIRB-MATMECA
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class is used to correctly display a full dialog
public class FinalDialogManager : MonoBehaviour
{

    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;
    private bool removetext;
    private GameObject todestroy;
    private GameObject collide;
    private GameObject player;

    void Awake()
    {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd, GameObject evil, GameObject coll, GameObject player)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);
        todestroy = evil;
        collide = coll;
        this.player = player;

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }
            this.player.SetActive(true);
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (m_renderText == null)
        {
            this.player.SetActive(false);
            this.gameObject.SetActive(false);
        }

        // Displays the current page
        if (m_dialogToDisplay.Count > 0)
        {
            removetext = true;
            Destroy(collide);
            Destroy(todestroy);
            m_renderText.text = m_dialogToDisplay[0].text;
        }
        else
        {
            Container.timerStop = false;
            this.gameObject.SetActive(false);
            this.player.SetActive(false);
        }

        // Remoeves the page when the player presses "space"
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && removetext)
        {
            removetext = false;
            m_dialogToDisplay.RemoveAt(0);
        }
    }

}
