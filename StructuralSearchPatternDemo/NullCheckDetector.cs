using System;
using JetBrains.ReSharper.Psi.Services.CSharp.StructuralSearch;
using JetBrains.ReSharper.Psi.Services.CSharp.StructuralSearch.Placeholders;
using JetBrains.ReSharper.Psi.Tree;

namespace StructuralSearchPatternDemo
{
    public class NullCheckDetector
    {
        public bool IsNullCheck(ITreeNode treeNode)
        {
            if (treeNode == null) throw new ArgumentNullException("treeNode");

            var pattern =
                new CSharpStructuralSearchPattern("if ($param$ == null) throw new ArgumentNullException($paramName$);",
                                                  new IdentifierPlaceholder("param"),
                                                  new ExpressionPlaceholder("paramName", "System.String"));

            var matcher = pattern.CreateMatcher();
            var matchResult = matcher.Match(treeNode);
            return matchResult.Matched;
        }
    }
}
