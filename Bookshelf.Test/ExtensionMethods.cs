using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.Test
{
	public static class ExtensionMethods
	{
		public static T SimpleClone<T>(this T source)
		{
			var serialized = JsonConvert.SerializeObject(source);
			return JsonConvert.DeserializeObject<T>(serialized);
		}
	}
}
