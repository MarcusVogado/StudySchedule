using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Helpers
{
	public class ObjectGetPropertyValues
	{
		public Dictionary<string, object> getPropertyValues(object o)
		{
			if (o == null) return null;
			Dictionary<string, object> propertyValues = new Dictionary<string, object>();
			Type ObjectType = o.GetType();
			System.Reflection.PropertyInfo[] properties = ObjectType.GetProperties();
			foreach (System.Reflection.PropertyInfo property in properties)
			{
				propertyValues.Add(property.Name, property.GetValue(o, null));
			}
			return propertyValues;

		}
	}
}
