using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public Transform playerTransform;
    public float heldObjectDistance = 2.0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // ���콺 ���� ��ư�� ������ ��, ���콺 ��ġ�� �ִ� ������Ʈ�� ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (rb != null && !rb.isKinematic)
                {
                    //hit.transform.gameObject.transform.position = hit.point;

                    // �÷��̾� ��ġ���� �������� heldObjectDistance ��ŭ ������ ��ġ�� ���
                    Vector3 targetPosition = playerTransform.position + playerTransform.forward * heldObjectDistance;

                    // heldObject�� ��ġ�� targetPosition���� �̵�
                    hit.transform.gameObject.transform.position = targetPosition;
                }
            }
        }
    }

}