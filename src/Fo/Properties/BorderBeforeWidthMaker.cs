using System.Text;

namespace Fonet.Fo.Properties
{
    internal class BorderBeforeWidthMaker : GenericCondBorderWidth
    {
        new public static PropertyMaker Maker(string propName)
        {
            return new BorderBeforeWidthMaker(propName);
        }

        protected BorderBeforeWidthMaker(string name) : base(name) { }


        public override bool IsCorrespondingForced(PropertyList propertyList)
        {
            StringBuilder sbExpr = new StringBuilder();

            sbExpr.Length = 0;
            sbExpr.Append("border-");
            sbExpr.Append(propertyList.wmRelToAbs(PropertyList.BEFORE));
            sbExpr.Append("-width");
            if (propertyList.GetExplicitProperty(sbExpr.ToString()) != null)
            {
                return true;
            }

            return false;
        }


        public override Property Compute(PropertyList propertyList)
        {
            FObj parentFO = propertyList.getParentFObj();
            StringBuilder sbExpr = new StringBuilder();
            Property p = null;
            sbExpr.Append("border-");
            sbExpr.Append(propertyList.wmRelToAbs(PropertyList.BEFORE));
            sbExpr.Append("-width");
            p = propertyList.GetExplicitOrShorthandProperty(sbExpr.ToString());

            if (p != null)
            {
                p = ConvertProperty(p, propertyList, parentFO);
            }

            return p;
        }

        protected override string getDefaultForConditionality()
        {
            return "retain";
        }

    }
}