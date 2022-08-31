using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUpScript : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color TextColor;
    public Color CritColor;
    private const float Disapear_Timer_Max = 1f;
    
    
    //method to initiate a new damage Popup
    public static DamagePopUpScript Create(Vector3 position, int damageAmount ,bool isCrit)
    {
        //creates the instance with the prefab safed in the GameAssets script
        Transform DamagePopUpTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopUpScript damagePopUp = DamagePopUpTransform.GetComponent<DamagePopUpScript>();
        damagePopUp.Setup(damageAmount,isCrit);

        return damagePopUp;
    }
    private static int sortingOrder;
    // Start is called before the first frame update
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    //define the Text of the popup
    public void Setup(int damageAmount, bool isCrit)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCrit)
        {
            textMesh.fontSize = 1;
            TextColor = textMesh.color;
            disappearTimer = 1f;
        }
        else
        {
            textMesh.fontSize = 2;
            textMesh.color = CritColor;
            TextColor = CritColor;
            disappearTimer = 1f;
        }
               
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }
    private void Update()
    {
        //upwards move speed
        float moveYSpeed = 0.2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        if(disappearTimer > Disapear_Timer_Max * .5f)
        {
            // first half of lifespan
            float increaseSclaeAmount = 1f;
            transform.localScale += Vector3.one * increaseSclaeAmount * Time.deltaTime;
         }
        else
        {
            //second half of lifespan
            float decreaseSclaeAmount = 1f;
            transform.localScale -= Vector3.one * decreaseSclaeAmount * Time.deltaTime;
        }
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {

            //start vanishing
            float disapearSpeed = 1f;
            TextColor.a -= disapearSpeed * Time.deltaTime;
            textMesh.color = TextColor;
            if(TextColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
