using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalGem : BaseGem
{
    [SerializeField]
    private Image normalTypeImage;

    [SerializeField]
    private Sprite[] normalTypeSprites;

    private int normalType;

    public int NormalType => normalType;

    public override void OnCreated()
    {
        normalType = UnityEngine.Random.Range(0, normalTypeSprites.Length);
        normalTypeImage.sprite = normalTypeSprites[normalType];
    }

    public void Trigger()
    {
    
    }

    public override void Destroy(Action onComplete)
    {
        Destroy(gameObject);
        onComplete?.Invoke();
    }

    public override bool IsMatching(BaseGem gem)
    {
        if(gem is NormalGem normalGem)
        {
            return normalGem.NormalType == this.NormalType;
        }

        return false;
    }

    public override void OnMatch()
    {

    }
}
