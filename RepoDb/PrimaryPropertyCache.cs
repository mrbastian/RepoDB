﻿using System;
using System.Collections.Generic;
using System.Reflection;
using RepoDb.Interfaces;
using RepoDb.Extensions;

namespace RepoDb
{
    public static class PrimaryPropertyCache
    {
        private static readonly IDictionary<Type, PropertyInfo> _cache = new Dictionary<Type, PropertyInfo>();

        public static PropertyInfo Get<TEntity>()
            where TEntity : IDataEntity
        {
            return Get(typeof(TEntity));
        }

        public static PropertyInfo Get(Type type)
        {
            var value = (PropertyInfo)null;
            if (_cache.ContainsKey(type))
            {
                value = _cache[type];
            }
            else
            {
                value = DataEntityExtension.GetPrimaryProperty(type);
                _cache.Add(type, value);
            }
            return value;
        }
    }
}
