﻿using System;
using UnityEngine;

namespace UniMsgPack
{
	public class BoolHandler : ITypeHandler
	{
		public object Read(Format format, FormatReader reader)
		{
			if(format.IsFalse) return false;
			if(format.IsTrue) return true;
			if(format.IsNil) return default(bool);
			throw new FormatException();
		}

		public void Write(object obj, FormatWriter writer)
		{
			writer.Write((bool)obj);
		}
	}
}
