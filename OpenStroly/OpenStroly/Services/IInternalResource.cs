using System;

namespace OpenStroly
{
	public interface IInternalResource
	{
		byte[] GetResourceData(string fileName);
	}
}

