using UnityEngine;

[CreateAssetMenu (menuName ="Dialogue/Speaker")]
public class SpeakerSO : ScriptableObject
{
    public string DisplayName;

    [Header("Portraits")]

    public Sprite Neutral;
    public Sprite Angry;
    public Sprite Sad;
    public Sprite Happy;


}
