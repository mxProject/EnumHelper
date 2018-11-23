using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace mxProject.Core
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <remarks>
    /// http://csharpvbcomparer.blogspot.com/2014/09/net-cast-cheats-compiler.html
    /// </remarks>
    internal static class ExpressionCast<TResult>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        private static class Caster<TSource>
        {
            static Caster()
            {
                // (S s) => (T)s
                var p = Expression.Parameter(typeof(TSource));
                var c = Expression.ConvertChecked(p, typeof(TResult));
                Cast = Expression.Lambda<Func<TSource, TResult>>(c, p).Compile();
            }
            internal static readonly Func<TSource, TResult> Cast;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TResult CastFrom<TSource>(TSource source)
        {
            return Caster<TSource>.Cast(source);
        }

    }

}
