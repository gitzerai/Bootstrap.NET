using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.NET
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class RenderAttribute : Attribute
    {
        private readonly string _renderAs;

        public RenderAttribute(string renderAs)
        {
            this._renderAs = renderAs;
        }

        public override string ToString()
        {
            return _renderAs;
        }
    }
}
