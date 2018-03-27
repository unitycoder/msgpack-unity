﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UniMsgPack.Tests
{
	public class Color32UnpackTest : TestBase
	{
		[Test]
		public void AsBinary()
		{
			Color32 value = new Color32(100, 100, 100, 255);
			byte[] data = MsgPack.Pack(value);
			Color32 result = MsgPack.Unpack<Color32>(data);
			Assert.AreEqual(value, result);
		}

		[Test]
		public void AsArray()
		{
			int[] value = { 100, 100, 100, 255 };
			byte[] data = MsgPack.Pack(value);
			Color32 result = MsgPack.Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}

		[Test]
		public void AsString()
		{
			string value = "#646464ff";
			byte[] data = MsgPack.Pack(value);
			Color32 result = MsgPack.Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}

		[Test]
		public void AsMap()
		{
			Dictionary<string, byte> value = new Dictionary<string, byte>();
			value.Add("r", 100);
			value.Add("g", 100);
			value.Add("b", 100);
			value.Add("a", 255);
			byte[] data = MsgPack.Pack(value);
			Color32 result = MsgPack.Unpack<Color32>(data);
			Assert.AreEqual(new Color32(100, 100, 100, 255), result);
		}
	}
}
