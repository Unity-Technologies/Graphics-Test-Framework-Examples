using UnityEngine.TestTools.UUTR;

[Unique]
public class SuiteModifierExample_Float : TestSuiteModifier
{
    public float floatValue = 42f;
    
    public override void Apply()
    {
        DataHolder.modifierFloat = floatValue;
    }
}
