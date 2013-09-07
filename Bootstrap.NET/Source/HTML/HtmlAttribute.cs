using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.NET.HTML
{
    internal class HtmlAttribute
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        private bool? _isRendered;
        public bool IsRendered
        {
            get
            {
                if (_isRendered.HasValue)
                    return _isRendered.Value;

                return !string.IsNullOrWhiteSpace(Value);
            }
        }

        public HtmlAttribute(string name, string value, bool? isRendered = null)
        {
            this.Name = name;
            this.Value = value;
            this._isRendered = isRendered;
        }

        public HtmlAttribute(string name, object value, bool? isRendered = null)
            : this(name, (value == null) ? String.Empty : value.ToString().ToLower(), isRendered)
        { }
        
    }

    internal class HtmlIdAttribute : HtmlAttribute
    {
        public HtmlIdAttribute(string value) : base("id", value) { }
        public HtmlIdAttribute(object value) : base("id", (value == null) ? String.Empty : value.ToString().ToLower()) { }
    }

    internal class HtmlTypeAttribute : HtmlAttribute
    {
        public HtmlTypeAttribute(string value) : base("type", value) { }
        public HtmlTypeAttribute(object value) : base("type", (value == null) ? String.Empty : value.ToString().ToLower()) { }
    }

    internal class HtmlNameAttribute : HtmlAttribute
    {
        public HtmlNameAttribute(string value) : base("name", value) { }
        public HtmlNameAttribute(object value) : base("name", (value == null) ? String.Empty : value.ToString().ToLower()) { }
    }

    internal class HtmlClassAttribute : HtmlAttribute
    {
        public HtmlClassAttribute(string value) : base("class", value) { }
        public HtmlClassAttribute(object value) : base("class", (value == null) ? String.Empty : value.ToString()) { }
        public HtmlClassAttribute(params object[] values) : base("class", (values.Length == 0) ? String.Empty : BuildClass(values)) { }

        public static string BuildClass(params object[] classNames) {
            StringBuilder classes = new StringBuilder();

            foreach (object o in classNames)
            {
                string str = o.ToString();
                if (!string.IsNullOrWhiteSpace(str))
                    classes.Append(string.Format("{0} ", str));
            }

            if (classes.Length > 0)
                classes.Remove(classes.Length - 1, 1);

            return classes.ToString();
        }
    }

    internal class HtmlHrefAttribute : HtmlAttribute
    {
        public HtmlHrefAttribute(string value) : base("href", value) { }
        public HtmlHrefAttribute(object value) : base("href", (value == null) ? String.Empty : value.ToString().ToLower()) { }
    }
}
