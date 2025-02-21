using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
    public Rigidbody rb;
    public MeshRenderer mr;
    private Material material;
    public Color color = Color.red;

    [Header("Debug")]
    [SerializeField] private bool refresh = false;
    [SerializeField] private bool setRandomColor = false;

    private void OnValidate()
    {
        // Debug buttons
        if (refresh) refresh = false;
        if (setRandomColor)
        {
            setRandomColor = false;
            color = Random.ColorHSV(0, 1, 0.5f, 1, 0, 1, 1, 1);
        }

        // Get Components
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (mr == null) TryGetComponent(out mr);

        // Instantiate material
        if (material == null) material = Instantiate(Resources.Load<Material>("White"));

        // Assign material to the mesh renderer
        if (mr != null && material != null) mr.material = material;

        // change color to the one selected
        if (material != null && color != null) material.color = color;
    }
}
