
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsAndCollections.Classes
{
    
    
        public abstract class FormatBase
        {
            public virtual string ToFormat()
            {
                string output = "";

                var properties = GetType().GetProperties();

                for (var i = 0; i < properties.Length; i++)
                {
                    output += properties[i].GetValue(this).ToString();
                    if (i != properties.Length - 1)
                    {
                        output += ",";
                    }
                }
                return output;
            }

        public virtual void AssignValuesFromFormat(string[] propertyValues)
        {
            var properties = GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType
                    .IsSubclassOf(typeof(FormatBase)))
                {
                    var instance = Activator.CreateInstance(properties[i].PropertyType);
                    var instanceProperties = instance.GetType().GetProperties();
                    var propertyList = new List<string>();

                    for (var j = 0; j < instanceProperties.Length; j++)
                    {
                        propertyList.Add(propertyValues[i + j]);
                    }
                    var m = instance.GetType().GetMethod("AssignValuesFromFormat", new Type[] { typeof(string[]) });
                    m.Invoke(instance, new object[] { propertyList.ToArray() });
                    properties[i].SetValue(this, instance);

                    i += instanceProperties.Length;
                }
                else
                {
                    var type = properties[i].PropertyType.Name;
                    switch (type)
                    {
                        case "Int32":
                            properties[i].SetValue(this,
                                            int.Parse(propertyValues[i]));
                            break;
                        default:
                            properties[i].SetValue(this, propertyValues[i]);
                            break;
                    }
                }
            }
        }
    }
    
}
