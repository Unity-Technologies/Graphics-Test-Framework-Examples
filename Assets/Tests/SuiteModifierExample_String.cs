using UnityEngine.TestTools.UUTR;

[Unique]
public class SuiteModifierExample_String : TestSuiteModifier
{
    public string stringValue = "Test Value";
    
    public override void Apply()
    {
        DataHolder.modifierString = stringValue;
    }
}
