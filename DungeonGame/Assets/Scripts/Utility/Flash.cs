using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Flash
{
    static bool _changingColor = false;
    public static IEnumerator FlashTarget(Color32 firstColor, Color32 secondColor, float duration, SpriteRenderer targetSprite)
    {
        if (_changingColor)
        {
            yield break;
        }
        _changingColor = true;
        float counter = 0;
        
        while (counter < duration)
        {
            counter += Time.deltaTime;

            targetSprite.color = Color32.Lerp(firstColor, secondColor, (counter / 2) / (duration / 2));
            targetSprite.color = Color32.Lerp(secondColor, firstColor, (counter / 2) / (duration / 2));

            yield return null;
        }


        _changingColor = false;
    }
}
