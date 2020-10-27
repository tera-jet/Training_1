using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float moveSpeed;
    public float tailDistance;

    public Material[] materials;

    public GameObject baitPrefab;


    public Collider m_spawnCollider;

    #region Singleton

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn");
            GameObject bait =  Instantiate(baitPrefab, GetRandomPositionInsideCollider(m_spawnCollider), Quaternion.identity);
            bait.GetComponent<Renderer>().sharedMaterial = materials[1];
            bait.tag = "Bait";
        }
    }

    public Vector3 GetRandomPositionInsideCollider(Collider collider)
    {
        Bounds bounds = collider.bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = bounds.extents.z;

        return bounds.center + new Vector3(offsetX, offsetY, offsetZ);
    }
}
