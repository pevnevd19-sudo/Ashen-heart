using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroAnim : MonoBehaviour
{
    [SerializeField] private Animator heroAnim;
    [SerializeField]private UserInput triggerAnim;
    [SerializeField] private SpriteRenderer heroSprite;  
        void Start()
    {
        heroAnim.GetComponent<Animator>();  
        
    }
    private void Update()
    {
        IsWalk();
    }

    // Update is called once per frame
    void IsWalk()
    {
        // Проверка на движение
        if (Mathf.Abs(triggerAnim.vc.x) >= 0.1f|| Mathf.Abs(triggerAnim.vc.y) >= 0.1f)
        {
            heroAnim.SetBool("IsWalk", true);

            // Поворот персонажа
            if (triggerAnim.vc.x > 0)
                heroSprite.flipX = false;
            else if (triggerAnim.vc.x < 0)
                heroSprite.flipX = true;
        }
        else
        {
            heroAnim.SetBool("IsWalk", false);
        }
    }
}
