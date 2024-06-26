
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBehavior : MonoBehaviour
{
    protected Button button;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public abstract void OnClick();
}
