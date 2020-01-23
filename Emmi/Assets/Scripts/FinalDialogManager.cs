/* Author : Raphaël Marczak - 2018, for ENSEIRB-MATMECA
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



// This class is used to correctly display a full dialog
public class FinalDialogManager : MonoBehaviour
{
    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;
    private bool removetext;
    private GameObject todestroy;
    private GameObject player;
    private bool changeScene;

    void Awake()
    {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd, GameObject evil, GameObject player, bool changeScene)
    {
        this.changeScene = changeScene;
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);
        todestroy = evil;
        this.player = player;

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }
            Container.isTalking = true;
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (m_renderText == null)
        {
            Container.isTalking = false;
            Container.timerStop = false;
            this.gameObject.SetActive(false);
        }

        // Displays the current page
        if (m_dialogToDisplay.Count > 0)
        {
            removetext = true;
            m_renderText.text = m_dialogToDisplay[0].text;
        }
        else
        {
            if (!changeScene)
            {
                Debug.Log("Mauvaise foi");
                Destroy(todestroy);
            }
            else {
                SceneManager.LoadScene("Menu 1");
            }
            Container.timerStop = false;
            Container.isTalking = false;
            this.gameObject.SetActive(false);
        }

        // Remoeves the page when the player presses "space"
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && removetext)
        {
            removetext = false;
            m_dialogToDisplay.RemoveAt(0);
        }
    }

}
