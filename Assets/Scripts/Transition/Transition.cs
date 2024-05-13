using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [Header("Transition Properties")]
    [SerializeField] private Transform _transition;

    [Header("Animation Properties")]
    [SerializeField] private float _transitionTime = 0.1f;

    [SerializeField] private float _transitionRotationValue = 45;

    private bool _onTransition = false;

    public static Transition Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private IEnumerator LoadSceneAdditive(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        yield return new WaitUntil(() => operation.isDone);

        FadeOut();
    }

    public void FadeIn(string sceneKey)
    {
        if (_onTransition) return;
        _onTransition = true;

        Vector3 randomRot = new Vector3(0, 0, Random.Range(-_transitionRotationValue, _transitionRotationValue));

        _transition.gameObject.SetActive(true);

        _transition.rotation = Quaternion.identity;
        _transition.localScale = Vector3.zero;

        _transition.DORotate(randomRot, _transitionTime).SetEase(Ease.InOutSine);
        _transition.DOScale(1, _transitionTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            StartCoroutine(LoadSceneAdditive(sceneKey));
        });
    }

    public void FadeOut()
    {
        Vector3 randomRot = new Vector3(0, 0, Random.Range(-_transitionRotationValue, _transitionRotationValue));

        _transition.rotation = Quaternion.identity;
        _transition.localScale = Vector3.one;

        _transition.DORotate(randomRot, _transitionTime).SetEase(Ease.InOutSine);
        _transition.DOScale(0, _transitionTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _transition.gameObject.SetActive(false);
            _onTransition = false;
        });
    }
}