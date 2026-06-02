using UnityEngine;

public class UIPurse : MonoBehaviour
{
    [Header("크기 조절 설정")]
    [Tooltip("글자가 커졌다 작아지는 속도를 조절합니다.")]
    public float pulseSpeed = 3f;

    [Tooltip("얼마나 크게 부풀어 오를지 조절합니다. (0.1 = 10% 커짐)")]
    public float scaleAmount = 0.05f;

    // 원래 텍스트의 크기를 기억해둘 변수
    private Vector3 originalScale;

    void Start()
    {
        // 게임 시작 시 이 UI의 원래 크기를 저장해둡니다.
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 시간(Time.time)에 따라 -1과 1 사이를 부드럽게 오가는 수학(Sin) 함수 활용!
        // 이 파도(wave) 모양의 값을 이용해 크기를 조절합니다.
        float wave = Mathf.Sin(Time.time * pulseSpeed);

        // 크기 계산: 1(기본) + (파도값 * 크기변화량)
        float currentScale = 1f + (wave * scaleAmount);

        // 최종적으로 계산된 크기를 오브젝트에 실시간으로 적용합니다.
        transform.localScale = originalScale * currentScale;
    }
}
