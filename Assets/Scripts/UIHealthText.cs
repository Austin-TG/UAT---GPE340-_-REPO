using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class UIHealthText : MonoBehaviour
{
    //private Health health;
    private Text text;

    public Health health;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = string.Format("Health: {0}%", Mathf.RoundToInt(health.HealthPercent() * 100f)) ;
    }

}
