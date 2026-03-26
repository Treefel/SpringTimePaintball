using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    [SerializeField] private float value,  minValue, maxValue;

    [FormerlySerializedAs("minValueEvent")] public UnityEvent<float> valueOutOfRange;
    [FormerlySerializedAs("updateValueEvent")] public UnityEvent onValueChanged;
    [FormerlySerializedAs("zeroValueEvent")] public UnityEvent<float> onValueZero;

    public float Value
    {
        get => value;
        set
        {
            this.value = value;
            onValueChanged.Invoke();
            CheckValueRange();
        }
    }

    public void UpdateValue(float amount)
    {
        Value += amount;
    }

    public void UpdateValue(FloatData data)
    {
        Value += data.Value;
    }

    public void SetValue(FloatData data)
    {
        Value = data.Value;
    }
        public void SetValue(float amount)
    {
        Value = amount;
    }

    private void CheckValueRange()
    {
        if (Value == 0)
        {
            onValueZero.Invoke(Value);
        }
        if (!(Value < minValue) && !(Value > maxValue)) return;
        
        valueOutOfRange.Invoke(Value);
        
        Value = Mathf.Clamp(Value, minValue, maxValue);
    }
}