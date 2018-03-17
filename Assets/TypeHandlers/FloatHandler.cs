﻿using System;
using UnityEngine;

namespace UniMsgPack
{
	public class FloatHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsFloat32) return reader.ReadFloat32();
			if(format.IsFloat64) {
				double value = reader.ReadFloat64();
				if(value > float.MaxValue) {
					throw new InvalidCastException(string.Format("{0} is too big for a float", value));
				}
				if(value < float.MinValue) {
					throw new InvalidCastException(string.Format("{0} is too small for a float", value));
				}
				return (float)value;
			}
			if(format.IsNil) return default(float);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write((float)obj);
		}
	}
}
