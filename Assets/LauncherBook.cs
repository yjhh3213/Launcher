using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동 필수!
using System.Collections;

public class LauncherBook : MonoBehaviour
{
    [Header("씬 이동 설정")]
    [Tooltip("책이 사라진 후 넘어갈 다음 씬의 이름을 적어주세요.")]
    public string nextSceneName = "MainScene";

    [Header("사라지는 연출 설정")]
    [Tooltip("몇 초에 걸쳐서 서서히 사라질지 설정합니다.")]
    public float fadeOutDuration = 2f;

    private Renderer[] renderers;
    private bool isClicked = false; // 중복 클릭 방지용

    void Start()
    {
        // 책에 포함된 모든 외형(Renderer)을 가져옵니다.
        renderers = GetComponentsInChildren<Renderer>();
    }

    // 마우스로 이 오브젝트(책)를 클릭했을 때 자동으로 실행되는 함수입니다!
    void OnMouseDown()
    {
        // 이미 클릭해서 연출이 진행 중이라면 무시합니다.
        if (isClicked) return;

        isClicked = true;
        Debug.Log("책을 클릭했습니다! 사라지는 연출을 시작합니다.");

        // 서서히 사라지는 코루틴 시작
        StartCoroutine(FadeOutAndLoadScene());
    }

    IEnumerator FadeOutAndLoadScene()
    {
        float elapsedTime = 0f;

        // 설정한 시간(fadeOutDuration) 동안 반복해서 투명도를 낮춥니다.
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            // 1(불투명)에서 0(투명)으로 부드럽게 줄어듭니다.
            float currentAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);

            SetAlpha(currentAlpha);
            yield return null; // 1프레임 대기
        }

        // 완전히 투명해지면 0으로 확실히 굳히고 씬을 이동합니다.
        SetAlpha(0f);
        Debug.Log($"[{nextSceneName}] 씬으로 이동합니다.");
        SceneManager.LoadScene(nextSceneName);
    }

    // 책의 투명도를 조절하는 내부 함수
    void SetAlpha(float alpha)
    {
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                // 재질의 현재 색상을 가져와서 알파(a) 값만 덮어씌웁니다.
                if (mat.HasProperty("_Color"))
                {
                    Color color = mat.color;
                    color.a = alpha;
                    mat.color = color;
                }
            }
        }
    }
}
