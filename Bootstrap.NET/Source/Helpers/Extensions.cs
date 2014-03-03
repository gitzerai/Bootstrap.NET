using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bootstrap.NET.Helpers
{
    internal static class Extensions
    {
        public static bool HasKey(this StateBag bag, string key)
        {
            foreach (string bagKey in bag.Keys)
            {
                if (bagKey == key)
                    return true;
            }
            return false;
        }

        public static T GetValue<T>(this StateBag bag, string key, T defaultValue) where T : class
        {
            if (!bag.HasKey(key))
                return defaultValue;

            return bag[key] as T;
        }

        public static void AddRange(this ControlCollection thisCollection, ControlCollection collection)
        {
            foreach (Control control in collection)
            {
                thisCollection.Add(control);
            }
        }

        public static string ToRender(this Enum enumerator)
        {
            Type type = enumerator.GetType();
            System.Reflection.FieldInfo fieldInfo = type.GetField(enumerator.ToString());
            RenderAttribute attribute = fieldInfo.GetCustomAttributes(typeof(RenderAttribute), false).FirstOrDefault() as RenderAttribute;
            if (attribute == null)
                return enumerator.ToString();

            return attribute.ToString();
        }

        public static bool HasAttribute(Type what, Type which)
        {
            return !(Attribute.GetCustomAttribute(what, which) == null);
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsSet(this string str)
        {
            return !str.IsEmpty();
        }

        public static void AddClass(this WebControl control, string cssClass) {
            if (string.IsNullOrWhiteSpace(control.CssClass)) {
                control.CssClass = cssClass;
            } else {
                control.CssClass = string.Format("{0} {1}", cssClass, control.CssClass);
            }
        }

        public static void EnsureClass(this WebControl control, string cssClass) {
            if (!control.CssClass.Contains(cssClass)) {
                control.AddClass(cssClass);
            }
        }
    }
}
