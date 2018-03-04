﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniMsgPack
{
	public class ListHandler : ITypeHandler
	{
		readonly Type elementType;
		readonly ITypeHandler handler;

		public ListHandler(Type elementType)
		{
			this.elementType = elementType;
			this.handler = TypeDefinition.Get(elementType);
		}

		public object Read(Format format, FormatReader reader)
		{
			Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
			IList list = (IList)Activator.CreateInstance(listType);
			int size = reader.ReadArraySize(format);
			for(int i = 0; i < size; i++) {
				list.Add(handler.Read(reader.ReadFormat(), reader));
			}
			return list;
		}
	}
}
