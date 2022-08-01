﻿using System.Pooling;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic.Pooling
{
    public class StackPool<T>
        : Pool<Stack<T>
        , DefaultConstructorInstantiator<Stack<T>>>
    {
        public StackPool()
            : base()
        { }

        public StackPool(UniqueQueue<Stack<T>> queue)
            : base(queue)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void ReturnPreprocess(Stack<T> instance)
            => instance.Clear();
    }
}
