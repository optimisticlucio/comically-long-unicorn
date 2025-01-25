using UnityEngine;

public class CupGenerator : MonoBehaviour
{
    [SerializeField] private DraggableBobaTea cupPrefab;  // Assign the DraggableBobaTea prefab in the Inspector
    [SerializeField] private float spawnOffsetY = 1.0f;  // Offset above parent object

    private DraggableBobaTea currentCup;

    void Update()
    {
        CheckAndSpawnCup();
    }

    private void CheckAndSpawnCup()
    {
        // Check if the current cup still exists
        if (currentCup == null)
        {
            SpawnCup();
        }
    }

    private void SpawnCup()
    {
        if (cupPrefab != null)
        {
            // Calculate spawn position (right above the parent's transform)
            Vector3 spawnPosition = transform.position + new Vector3(0, spawnOffsetY, 0);

            // Instantiate the cup and set it as the current cup
            DraggableBobaTea newCup = Instantiate(cupPrefab, spawnPosition, Quaternion.identity);
            newCup.transform.parent = transform;  // Optional: Keep cup under the generator

            currentCup = newCup.GetComponent<DraggableBobaTea>();

            if (currentCup == null)
            {
                Debug.LogError("The spawned cup does not contain a DraggableBobaTea component.");
            }
        }
        else
        {
            Debug.LogError("Cup prefab is not assigned in the CupGenerator script.");
        }
    }
}
