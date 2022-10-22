using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private Gradient gradient;
	[SerializeField] private Image fill;
	[SerializeField] private TextMeshProUGUI hp;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
	public void UpdateData()
    {
		slider.maxValue = globalVarables.playerMaxHealth;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
