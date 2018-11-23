using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject
{

    /// <summary>
    /// Basic implementation of the factory of EnumMetadata.
    /// </summary>
    /// <typeparam name="TMetadata">The type of EnumMetadata.</typeparam>
    /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
    public abstract class EnumMetadataFactoryBase<TMetadata, TItem> where TMetadata : IEnumMetadata
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected EnumMetadataFactoryBase()
        {
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private readonly IDictionary<Type, WeakReference<IEnumMetadata>> m_Cache = new Dictionary<Type, WeakReference<IEnumMetadata>>();

        /// <summary>
        /// Methods that get the information associated with the enum value.
        /// </summary>
        private readonly IDictionary<Type, Delegate> m_ItemGetters = new Dictionary<Type, Delegate>();

        /// <summary>
        /// Gets the metadata of the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>metadata.</returns>
        public TMetadata GetMetadata<TEnum>() where TEnum : Enum
        {

            if (m_Cache.TryGetValue(typeof(TEnum), out WeakReference<IEnumMetadata> weak))
            {
                if (weak.TryGetTarget(out IEnumMetadata ctx))
                {
                    return (TMetadata)ctx;
                }
                else
                {
                    TMetadata context = CreateContext<TEnum>();
                    weak.SetTarget(context);
                    return context;
                }
            }
            else
            {
                TMetadata context = CreateContext<TEnum>();
                m_Cache.Add(typeof(TEnum), new WeakReference<IEnumMetadata>(context));
                return context;
            }

        }

        /// <summary>
        /// Creates a metadata of the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>metadata.</returns>
        public TMetadata CreateContext<TEnum>() where TEnum : Enum
        {

            Func<TEnum, FieldInfo, TItem> itemGetter = null;

            if (m_ItemGetters.TryGetValue(typeof(TEnum), out Delegate func))
            {
                itemGetter = (Func<TEnum, FieldInfo, TItem>)func;
            }

            return CreateContext(itemGetter ?? GetItem);

        }

        /// <summary>
        /// Creates a metadata of the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>metadata.</returns>
        protected abstract TMetadata CreateContext<TEnum>(Func<TEnum, FieldInfo, TItem> itemGetter) where TEnum : Enum;

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="field">The field information of the enum value.</param>
        /// <returns>the information associated with the enum value.</returns>
        protected abstract TItem GetItem<TEnum>(TEnum value, FieldInfo field) where TEnum : Enum;

        /// <summary>
        /// Regists the method that get the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="itemGetter">The method that get the information associated with the enum value.</param>
        public void RegistItemGetter<TEnum>(Func<TEnum, TItem> itemGetter) where TEnum : Enum
        {
            Func<TEnum, FieldInfo, TItem> func = (TEnum value, FieldInfo field) =>
            {
                return itemGetter(value);
            }
            ;

            m_ItemGetters[typeof(TEnum)] = func;
            m_Cache.Remove(typeof(TEnum));
        }

        /// <summary>
        /// Regists the method that get the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="itemGetter">The method that get the information associated with the enum value.</param>
        public void RegistItemGetter<TEnum>(Func<TEnum, FieldInfo, TItem> itemGetter) where TEnum : Enum
        {
            m_ItemGetters[typeof(TEnum)] = itemGetter;
            m_Cache.Remove(typeof(TEnum));
        }

        /// <summary>
        /// Unregists the method that get the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        public void UnregistItemGetter<TEnum>()
        {
            m_ItemGetters.Remove(typeof(TEnum));
            m_Cache.Remove(typeof(TEnum));
        }

    }

}
