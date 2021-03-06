﻿using MongoDB.Driver;
using MongoDB.Entities.Core;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB.Entities
{
    public partial class DB
    {
        internal static Task CreateIndexAsync<T>(CreateIndexModel<T> model, CancellationToken cancellation = default) where T : IEntity
        {
            return Collection<T>().Indexes.CreateOneAsync(model, cancellationToken: cancellation);
        }

        internal static async Task DropIndexAsync<T>(string name, CancellationToken cancellation = default) where T : IEntity
        {
            await Collection<T>().Indexes.DropOneAsync(name, cancellation);
        }

        /// <summary>
        /// Represents an index for a given IEntity
        /// <para>TIP: Define the keys first with .Key() method and finally call the .Create() method.</para>
        /// </summary>
        /// <typeparam name="T">Any class that implements IEntity</typeparam>
        public static Index<T> Index<T>() where T : IEntity
        {
            return new Index<T>();
        }

        /// <summary>
        /// Represents an index for a given IEntity
        /// <para>TIP: Define the keys first with .Key() method and finally call the .Create() method.</para>
        /// </summary>
        /// <typeparam name="T">Any class that implements IEntity</typeparam>
        public Index<T> Index<T>(bool _ = false) where T : IEntity
        {
            return new Index<T>();
        }
    }
}
