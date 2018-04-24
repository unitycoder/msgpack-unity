﻿using System.Reflection;

namespace SouthPointe.Serialization.MessagePack
{
	public class MapOptions
	{
		public bool ignoreNullOnPack = true;

		public bool ignoreMissingFieldOnUnpack = true;

		/// <summary>
		/// This is for compatibility with msgpack-php
		/// since php cannot distinguish between ordered array and hashed array.
		/// </summary>
		public bool allowEmptyArrayAsMap = true;

		public IMapNamingStrategy namingStrategy = new DefaultNamingStrategy();

		public BindingFlags fieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField;
	}
}
