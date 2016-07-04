using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace GoogleMusicApi.Common
{
    public class Enumerations
    {
        public static string GetDataName(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DataMemberAttribute[] attributes = (DataMemberAttribute[])fi.GetCustomAttributes(typeof(DataMemberAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Name;
            return value.ToString();
        }
    }
}