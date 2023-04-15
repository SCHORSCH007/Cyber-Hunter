using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    [SerializeField] private int _Damage = 1;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHpScript enemy = hitInfo.GetComponent<EnemyHpScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(_Damage* globalVarables.increasingDamage);
            DamagePopUpScript.Create(enemy.transform.position, _Damage * globalVarables.increasingDamage, false, new Color(126f / 255f, 0f / 255f, 255f / 255f));
        }

    }
}
