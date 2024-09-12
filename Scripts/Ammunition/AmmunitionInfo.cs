using TMPro;
using UnityEngine;

public class AmmunitionInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammunitionText;
    [SerializeField] private Ammunition _ammunition;

    private void Update()
    {
        ShowAmmunitionCount();
    }

    private void ShowAmmunitionCount() =>
       _ammunitionText.text = $"AMMUNITION \n {_ammunition.CurrentBulletCountInClip} / {_ammunition.CurrentAllBulletCount}";
}