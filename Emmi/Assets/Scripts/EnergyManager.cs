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
    public int numberAbsorbed; //nombre de lumières absorbées : RIP :( Mric
    public LightManager lights;
    public float lightHealthRatio;
    public ParticlesManager part;
    public float particlesHealthRatio;
    public int LoseHealth;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Container.maxHealth = 20;
        Container.health = Container.maxHealth;
        Bar.fillAmount = 1f;
        numberAbsorbed = 0;
        StartCoroutine(LoseEnergy());
        volume.transform.localScale = volume.getVolume();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = PercentHealth();
        texte.text = Container.health +"/"+Container.maxHealth ;
        UpdateLight();
        UpdateParticles();
    }

    public float PercentHealth()
    {
        return (float)Container.health / (float)Container.maxHealth;
    }

    IEnumerator LoseEnergy()
    {
        while (true)
        { 
            if (Container.health > 0)
            {
                Container.health --;
                float percent = PercentHealth();
                if(volume != null)
                {
                    volume.setVolume(new Vector3((1 + numberAbsorbed / 4) * percent, (1 + numberAbsorbed / 4) * percent, (1 + numberAbsorbed / 4) * percent));
                    volume.transform.localScale = volume.getVolume();
                }

                yield return new WaitForSeconds(1);
            }
            else
            {
                Scene scene = SceneManager.GetActiveScene();
                Destroy(GameObject.FindGameObjectWithTag("Energy Bar"));
                Container.lastSceneName = scene.name;
                SceneManager.LoadScene("GameOver");
                yield return null;
            }
        }
    }

    public void UpdateAmount(int amount)
    {
        if (Container.health + amount < Container.maxHealth)
        {
            Container.health = Container.health + amount;
        }
        else
        {
            Container.health = Container.maxHealth;
        }
        float percent = PercentHealth();
        volume.setVolume(new Vector3((1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent, (1 + numberAbsorbed/4) * percent));
        volume.transform.localScale = volume.getVolume();
    }

    private void UpdateLight()
    {
        if(lights != null)
        {
            lights.UpdateRange(Mathf.FloorToInt(Container.health * lightHealthRatio));
        }
    }

    private void UpdateParticles()
    {
        if(part != null)
        {
            part.UpdateRateOverTime(Mathf.FloorToInt(Container.health * particlesHealthRatio));
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        Container.maxHealth += amount;
        Container.health = Container.maxHealth;
        numberAbsorbed++;
        volume.setVolume(new Vector3((1 + numberAbsorbed/4), (1 + numberAbsorbed/4), (1 + numberAbsorbed/4)));
        volume.transform.localScale = volume.getVolume();
    }
}



