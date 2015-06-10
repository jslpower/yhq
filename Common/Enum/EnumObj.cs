using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EyouSoft.Common
{
    /// <summary>
    /// enum helper
    /// </summary>
    public class EnumObj
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// enum to list
        /// </summary>
        /// <param name="type">typeof(enum)</param>
        /// <param name="removeValues">remove values</param>
        /// <param name="replaces">要替换显示Text的KV集</param>
        /// <returns></returns>
        public static List<EnumObj> GetList(Type type, string[] removeValues, List<EnumObj> replaces)
        {
            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            List<EnumObj> list = new List<EnumObj>();
            System.Reflection.FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum == true)
                {
                    EnumObj obj = new EnumObj();

                    string _value = ((int)type.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    string _text = field.Name;

                    if (removeValues != null && removeValues.Length > 0 && removeValues.Contains(_value)) continue;

                    if (replaces != null && replaces.Count > 0)
                    {
                        foreach (var replace in replaces)
                        {
                            if (replace.Value == _value && !string.IsNullOrEmpty(replace.Text))
                            {
                                _text = replace.Text;
                                break;
                            }
                        }
                    }

                    obj.Value = _value;
                    obj.Text = _text;

                    list.Add(obj);
                }
            }

            return list;
        }

        /// <summary>
        /// enum to list
        /// </summary>
        /// <param name="type">typeof(enum)</param>
        /// <param name="removeValues">remove values</param>
        /// <returns></returns>
        public static List<EnumObj> GetList(Type type, string[] removeValues)
        {
            return GetList(type, removeValues, null);
        }

        /// <summary>
        /// enum to list
        /// </summary>
        /// <param name="type">typeof(enum)</param>
        /// <returns></returns>
        public static List<EnumObj> GetList(Type type)
        {
            return GetList(type, null);
        }
    }
}
