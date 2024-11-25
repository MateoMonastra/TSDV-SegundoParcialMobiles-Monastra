using Menu.MenuButton;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Menu.LevelSelector
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private ButtonAction buttonAction = null;
        
        [SerializeField] private Image image = null;
        [SerializeField] private GameObject levelText = null;
        [SerializeField] private GameObject price = null;

        [SerializeField] private Sprite activeImage = null;
        [SerializeField] private Sprite blockedImage = null;

        public int priceValue;

        public void ActivateLevel()
        {
            image = GetComponent<Image>();
            levelText?.SetActive(true);
            if (price)
            {
                price.SetActive(false);
            }

            image.sprite = activeImage;
        }

        public void DeactivateLevel()
        {
            image = GetComponent<Image>();
            levelText?.SetActive(false);
            price?.SetActive(true);
            image.sprite = blockedImage;
        }

        public void HandleClick()
        {
            if (buttonAction != null && levelText.activeInHierarchy)
                buttonAction.HandleClick();
        }
    }
}