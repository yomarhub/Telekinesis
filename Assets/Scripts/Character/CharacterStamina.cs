using UnityEngine;

public class CharacterStamina : MonoBehaviour
{
    public float stamina = 1;
    public float regenSpeed = .5f;
    public bool isRegen = false;

    public void Increase(float amount)
    {
        Modify(stamina + amount);
    }
    public void Decrease(float amount)
    {
        Modify(stamina - amount);
    }
    public void Modify(float amount)
    {
        stamina = Mathf.Clamp01(amount);
    }
    public void Update()
    {
        if (isRegen) Increase(regenSpeed * Time.deltaTime);
    }
}
