using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class UIHealthText : MonoBehaviour
{
    //private Health health;
    private Text text;
    [SerializeField] private Image img;
    [SerializeField] private Text textAmmo;

    public Health health;
    private PlayerRootMotion ammo1;

    private void Start()
    {
        ammo1 = GameManager.player.GetComponent<PlayerRootMotion>();
        text = GetComponent<Text>();
        health = GameManager.player.GetComponent<Health>();
    }

    private void Update()
    {
        if (health != null)
        {
            text.text = string.Format("Health: {0}%", Mathf.RoundToInt(health.HealthPercent() * 100f));
            img.fillAmount = health.initialHealth / health.maxHealth;
        }
        else return;
        textAmmo.text = string.Format("Ammunition: {0}/60", ammo1.ammoCount);
    }

}
