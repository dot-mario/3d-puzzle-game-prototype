using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public Transform playerTransform;
    public float heldObjectDistance = 2.0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 마우스 왼쪽 버튼이 눌렸을 때, 마우스 위치에 있는 오브젝트를 가져옴
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (rb != null && !rb.isKinematic)
                {
                    //hit.transform.gameObject.transform.position = hit.point;

                    // 플레이어 위치에서 앞쪽으로 heldObjectDistance 만큼 떨어진 위치를 계산
                    Vector3 targetPosition = playerTransform.position + playerTransform.forward * heldObjectDistance;

                    // heldObject의 위치를 targetPosition으로 이동
                    hit.transform.gameObject.transform.position = targetPosition;
                }
            }
        }
    }

}