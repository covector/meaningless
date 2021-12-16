using UnityEngine;

public class Title : MonoBehaviour
{
    public float cooldown = -100f;
    public SoundFXManager audioManager;

    private void Awake()
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
        cooldown = -0.5f;
        FindObjectOfType<BGMusicManager>().SetVolume(0.35f);
        FindObjectOfType<BGMusicManager>().PlayAudio(0);
        FindObjectOfType<FadeTransition>().FadeIn()
        .Then(() => FindObjectOfType<CutsManager>().WaitForSeconds(3))
        .Then(() => FindObjectOfType<FadeTransition>().FadeOut())
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }
}
