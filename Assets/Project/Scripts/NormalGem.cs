using System;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UIElements;

public class NormalGem : BaseGem
{
    [SerializeField]
    private Image normalTypeImage;

    [SerializeField]
    private Sprite[] normalTypeSprites;

    [SerializeField]
    private int normalType;
 
    public int NormalType => normalType;

    public override void OnCreated()
    {
        var selectedTypoo = UnityEngine.Random.Range(0, normalTypeSprites.Length);
        normalTypeImage.sprite = normalTypeSprites[selectedTypoo];
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
