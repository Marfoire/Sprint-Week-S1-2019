using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintFade : MonoBehaviour
{
    #region variables
    // Coroutine
    private IEnumerator coroutine;
    #endregion

    #region setup
    // Assign and start coroutine
    void Start()
    {
        coroutine = ChangeOpcacity();
        StartCoroutine(coroutine);
    }
    #endregion

    #region splattercontrol
    private IEnumerator ChangeOpcacity()
    {
        SpriteRenderer paintRend = GetComponent<SpriteRenderer>();
        paintRend.color = new Color(paintRend.color.r, paintRend.color.g, paintRend.color.b, 1f);

        // Fade the splatter and then destroy it
        while (paintRend.color.a > 0f)
        {
            paintRend.color = new Color(paintRend.color.r, paintRend.color.g, paintRend.color.b, paintRend.color.a - (Time.deltaTime / 3));
            yield return null;
        }
        Destroy(gameObject);
    }
    #endregion
}
