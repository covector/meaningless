using UnityEngine;

public class Desk : MonoBehaviour
{
    public float cooldown = -100f;
    public SoundFXManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
    }

    private void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= 1f)
        {
            audioManager.PlayAudio(0, 2);
            cooldown %= 1f;
        }
    }

    void OnEnable()
    {
        cooldown = 0.5f;
        FindObjectOfType<FadeTransition>().SetTransparency(true);
    }

    protected void FinZoom()
    {
        FindObjectOfType<CutsManager>().incrementCut();
    }
}
