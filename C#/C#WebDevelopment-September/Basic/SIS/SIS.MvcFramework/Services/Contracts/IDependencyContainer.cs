﻿namespace SIS.MvcFramework.Services.Contracts
{
	using System;

	public interface IDependencyContainer
	{
		void RegisterDependency<TSource, TDestination>();

		T CreateInstance<T>();

		object CreateInstance(Type type);
	}
}
