﻿using UnityEngine;
using System;

namespace UniMsgPack
{
	public class QuaternionHandler : ITypeHandler
	{
		ITypeHandler floatHandler;

		public object Read(Format format, FormatReader reader)
		{
			if(format.IsArrayFamily) {
				floatHandler = floatHandler ?? TypeHandlers.Get(typeof(float));
				Quaternion quaternion = new Quaternion();
				quaternion.x = (float)floatHandler.Read(reader.ReadFormat(), reader);
				quaternion.y = (float)floatHandler.Read(reader.ReadFormat(), reader);
				quaternion.z = (float)floatHandler.Read(reader.ReadFormat(), reader);
				quaternion.w = (float)floatHandler.Read(reader.ReadFormat(), reader);
				return quaternion;
			}
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			Quaternion quaternion = (Quaternion)obj;
			writer.WriteArrayHeader(4);
			writer.Write(quaternion.x);
			writer.Write(quaternion.y);
			writer.Write(quaternion.z);
			writer.Write(quaternion.w);
		}
	}
}
