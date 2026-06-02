using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private static readonly ConcurrentDictionary<Type, List<object>> _store = new();

        private List<object> GetList()
        {
            var type = typeof(TEntity);
            return _store.GetOrAdd(type, _ => new List<object>());
        }

        private PropertyInfo? GetIdProperty()
        {
            var prop = typeof(TEntity).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            return prop;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            var list = GetList();
            var idProp = GetIdProperty();

            if (idProp != null)
            {
                var idValue = idProp.GetValue(entity);

                if (typeof(TKey) == typeof(int))
                {
                    var next = list.Count > 0
                        ? list.Cast<TEntity>().Select(x => (int?)Convert.ToInt32(GetIdProperty()!.GetValue(x))).Max() ?? 0
                        : 0;

                    idProp.SetValue(entity, Convert.ChangeType(next + 1, idProp.PropertyType));
                }
                else if (typeof(TKey) == typeof(Guid))
                {
                    var guid = Guid.NewGuid();
                    if (idProp.PropertyType == typeof(Guid) || idProp.PropertyType == typeof(Guid?))
                    {
                        idProp.SetValue(entity, guid);
                    }
                    else
                    {
                        idProp.SetValue(entity, Convert.ChangeType(guid.ToString(), idProp.PropertyType));
                    }
                }
            }

            list.Add(entity!);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(TKey id)
        {
            var list = GetList();
            var idProp = GetIdProperty();

            if (idProp is null)
                return Task.FromResult(false);

            var existing = list.Cast<TEntity>().FirstOrDefault(x =>
            {
                var val = idProp.GetValue(x);
                return Equals(val, id!);
            });

            if (existing is null)
                return Task.FromResult(false);

            list.Remove(existing!);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var list = GetList();
            return Task.FromResult(list.Cast<TEntity>().AsEnumerable());
        }

        public Task<TEntity?> GetByIdAsync(TKey id)
        {
            var idProp = GetIdProperty();
            if (idProp is null)
                return Task.FromResult<TEntity?>(null);

            var existing = GetList().Cast<TEntity>().FirstOrDefault(x =>
            {
                var val = idProp.GetValue(x);
                return Equals(val, id!);
            });

            return Task.FromResult(existing);
        }

        public Task<TEntity?> UpdateAsync(TKey id, TEntity entity)
        {
            var list = GetList();
            var idProp = GetIdProperty();

            if (idProp is null)
                return Task.FromResult<TEntity?>(null);

            var existing = list.Cast<TEntity>().FirstOrDefault(x =>
            {
                var val = idProp.GetValue(x);
                return Equals(val, id!);
            });

            if (existing is null)
                return Task.FromResult<TEntity?>(null);

            var index = list.IndexOf(existing!);
            list[index] = entity!;
            return Task.FromResult<TEntity?>(entity);
        }
    }
}
