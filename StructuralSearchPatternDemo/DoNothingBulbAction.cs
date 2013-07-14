using JetBrains.ProjectModel;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.TextControl;

namespace StructuralSearchPatternDemo
{
    public class DoNothingBulbAction : IBulbAction
    {
        public DoNothingBulbAction()
        {
            Text = "ContainsNullCheck";
        }

        public void Execute(ISolution solution, ITextControl textControl)
        {
        }

        public string Text { get; private set; }
    }
}
