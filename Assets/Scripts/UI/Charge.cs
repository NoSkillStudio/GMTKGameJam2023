using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Charge : MonoBehaviour
{
    [SerializeField] private Sprite[] powerSprites;
    private TMP_Text chargeText;
    private float _power = 1f;
    public bool isCharging { get; private set; }
    private CursorStateManager manager;
    private ObjectScore objectScore;

    public float Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = Mathf.Clamp(value, 0f, 1f);
            chargeText.text = ((int) (_power * 100)).ToString() + "%";
            if (_power > 0.75f)
                icon.sprite = powerSprites[0];
            else if (_power > 0.5f)
                icon.sprite = powerSprites[1];
            else if (_power > 0.20f)
                icon.sprite = powerSprites[2];
            else
                icon.sprite = powerSprites[3];
        }
    }
    private Image icon;

    private void Start()
    {
        icon = GetComponent<Image>(); 
        chargeText = FindObjectOfType<ChargeText>().GetComponent<TMP_Text>();
        manager = FindObjectOfType<CursorStateManager>();
        objectScore = GetComponent<ObjectScore>();
    }

    private void Update()
    {
        if (_power <= 0.15f && !isCharging)
        {
            objectScore?.Activate();
            isCharging = true;
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorChargingState>());
        }

        if (_power >= 0.80f && isCharging)
        {
            isCharging = false;
        }

        Power += isCharging ? 0.0001f : -0.000002f;
    }
}
