using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFieldController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _explosion;


    private void Awake()
    {
        transform.localScale = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.LeanScale(Vector3.one, 0.2f).setEaseInOutSine();
    }

    public void OnWin()
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        StartCoroutine(GameOverAnimation(Vector3.zero));
    }
    public void OnDraw(Vector3 gameOverPosition)
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        StartCoroutine(GameOverAnimation(gameOverPosition));
    }


    private IEnumerator GameOverAnimation(Vector3 gameOverPosition)
    {
        yield return new WaitForSeconds(0.2f);

        transform.LeanMoveLocal(gameOverPosition, 1).setEaseInOutSine();
        yield return new WaitForSeconds(1);

        transform.LeanScale(Vector2.one * 1.5f, 1).setEaseOutSine();
        yield return new WaitForSeconds(1);

        transform.LeanScale(Vector2.zero, 0.2f);
        yield return new WaitForSeconds(0.2f);

        AudioController.Instance.PlaySound("Explosion");
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
