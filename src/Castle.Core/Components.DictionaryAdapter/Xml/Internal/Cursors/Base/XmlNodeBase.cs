﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.f
// See the License for the specific language governing permissions and
// limitations under the License.

#if !SILVERLIGHT && !MONO // Until support for other platforms is verified
namespace Castle.Components.DictionaryAdapter.Xml
{
	using System;

	public abstract class XmlNodeBase : IRealizableSource
	{
		protected Type type;
		private readonly IXmlNode parent;
		private readonly IXmlNamespaceSource namespaces;

		protected XmlNodeBase(IXmlNamespaceSource namespaces, IXmlNode parent)
		{
			if (null == namespaces)
				throw Error.ArgumentNull("namespaces");

			this.namespaces = namespaces;
			this.parent     = parent;
		}

		public virtual bool Exists
		{
			get { return true; }
		}

		public virtual Type ClrType
		{
			get { return type; }
		}

		public IXmlNode Parent
		{
			get { return parent; }
		}

		public IXmlNamespaceSource Namespaces
		{
			get { return namespaces; }
		}

#if !SL3
		public virtual CompiledXPath Path
		{
			get { return null; }
		}
#endif

		IRealizable<T> IRealizableSource.AsRealizable<T>()
		{
			return this as IRealizable<T>;
		}

		protected virtual void Realize()
		{
			// Default nodes are fully realized already
		}

		public virtual event EventHandler Realized
		{
			// Default nodes never realize
			add    { }
			remove { }
		}
	}
}
#endif
