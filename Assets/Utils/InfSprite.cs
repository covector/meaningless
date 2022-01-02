using UnityEngine;

public class InfSprite : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;
    public bool auto;
    public float speed;
    private Transform spriteTrans1;
    private Transform spriteTrans2;
    private float spriteLength;

    void Start()
    {
        spriteTrans1 = sprite1.transform;
        spriteTrans2 = sprite2.transform;
        spriteLength = Mathf.Abs(spriteTrans1.localPosition.x - spriteTrans2.localPosition.x);
    }

    void Update()
    {
        if (auto)
        {
            Translate(speed * Time.deltaTime);
        }
    }

    public void Translate(float magnitude)
    {
        spriteTrans1.localPosition += new Vector3(magnitude, 0f);
        spriteTrans2.localPosition += new Vector3(magnitude, 0f);
        if (Mathf.Abs(spriteTrans1.localPosition.x) > spriteLength)
        {
            spriteTrans1.localPosition = new Vector3(spriteTrans2.localPosition.x - Mathf.Sign(spriteTrans1.localPosition.x) * spriteLength, 0f);
        }
        if (Mathf.Abs(spriteTrans2.localPosition.x) > spriteLength)
        {
            spriteTrans2.localPosition = new Vector3(spriteTrans1.localPosition.x - Mathf.Sign(spriteTrans2.localPosition.x) * spriteLength, 0f);
        }
    }
}
