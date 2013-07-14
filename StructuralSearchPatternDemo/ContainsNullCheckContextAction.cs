using System;
using System.Linq;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Util;

namespace StructuralSearchPatternDemo
{
    [ContextAction(Group = "C#", Name = "ContainsNullCheck", Description = "ContainsNullCheck")]
    public class ContainsNullCheckContextAction: IContextAction
    {
        private readonly ICSharpContextActionDataProvider _Provider;

        public ContainsNullCheckContextAction(ICSharpContextActionDataProvider provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _Provider = provider;
        }

        public void CreateBulbItems(BulbMenu menu)
        {
            menu.ArrangeContextAction(new DoNothingBulbAction());
        }

        public bool IsAvailable(IUserDataHolder cache)
        {
            var method = _Provider.GetSelectedElement<IMethodDeclaration>(false, true);
            if (method == null || method.Body == null)
            {
                return false;
            }

            return method.Body.Statements.Any(s => new NullCheckDetector().IsNullCheck(s));
        }
    }
}
