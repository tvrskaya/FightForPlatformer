using UnityEngine;

public class SpellsExecuter : MonoBehaviour
{
    private Vampirism _vampirism;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
    }

    public void StartVampirism()
    {
        _vampirism.StartVampirism();
    }
}
