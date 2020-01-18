using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyManager : MonoBehaviour
{
    public Image Bar;
    public Text texte;  
    public DecreasingController volume;
    public static int health;
    public static int maxHealth;
    public int numberAbsorbed; //nombre de lumières absorbées : RIP :( Mric
    public LightManager lights;
    public float lightHealthRatio;
    public ParticlesManager part;
    public float particlesHealthRatio;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        maxHealth = 20;
        health = maxHealth;
        Bar.fillAmount = 1f;
        numberAbsorbed = 0;
        StartCoroutine(LoseEnergy());
        volume.transform.localScale = volume.getVolume();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = PercentHealth();
        texte.text = health +"/"+maxHealth ;
        UpdateLight();
        UpdateParticles();
    }

    public float PercentHealth()
    {
        return (float)health / (float)maxHealth;
    }

    IEnumerator LoseEnergy()
    {
        while (true)
        { 
            if (health > 0)
            {
                health --;
                float percent = PercentHealth();
                volume.setVolume(new Vector3((1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent));
                volume.transform.localScale = volume.getVolume();
                yield return new WaitForSeconds(1);
            }
            else
            {
                Scene scene = SceneManager.GetActiveScene();
                Container.lastSceneName = scene.name;
                SceneManager.LoadScene("GameOver");
                yield return null;
            }
        }
    }

    public void UpdateAmount(int amount)
    {
        if (health + amount < maxHealth)
        {
            health = health + amount;
        }
        else
        {
            health = maxHealth;
        }
        float percent = PercentHealth();
        volume.setVolume(new Vector3((1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent));
        volume.transform.localScale = volume.getVolume();
    }

    private void UpdateLight()
    {
        lights.UpdateRange(Mathf.FloorToInt(health * lightHealthRatio));
    }

    private void UpdateParticles()
    {
        part.UpdateRateOverTime(Mathf.FloorToInt(health * particlesHealthRatio));
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        health = maxHealth;
        numberAbsorbed++;
        volume.setVolume(new Vector3((1 + numberAbsorbed/4), (1 + numberAbsorbed/4), (1 + numberAbsorbed/4)));
        volume.transform.localScale = volume.getVolume();
    }
}



