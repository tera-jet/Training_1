using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public List<GameObject> m_Tails;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TailGenerate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TailGenerate()
    {
        while (true)
        {
            Vector3 lastTailPos = transform.position;

            for (int i = 0; i < m_Tails.Count; i++)
            {
                Vector3 prePos;
                prePos = i > 0 ? m_Tails[i - 1].transform.position : lastTailPos;
                if (Vector3.Distance(m_Tails[i].transform.position, prePos) > GameController.Instance.tailDistance)
                    m_Tails[i].transform.position = Vector3.MoveTowards(m_Tails[i].transform.position, prePos, GameController.Instance.moveSpeed * Time.deltaTime);
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.tag);
        if (other.CompareTag("Bait"))
        {
            other.tag = "Tail";
            other.gameObject.GetComponent<Renderer>().sharedMaterial = GameController.Instance.materials[0];
            other.gameObject.transform.position = m_Tails[m_Tails.Count - 1].transform.position;
            m_Tails.Insert(m_Tails.Count - 1, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
