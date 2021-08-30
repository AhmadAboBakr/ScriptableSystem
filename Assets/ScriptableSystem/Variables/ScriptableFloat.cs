
namespace ScriptableSystem
{
    public class ScriptableFloat : ScriptableVariable<float>
    {
        public override void Parse(string value)
        {
            this.value = float.Parse(value);
        }
    }
}