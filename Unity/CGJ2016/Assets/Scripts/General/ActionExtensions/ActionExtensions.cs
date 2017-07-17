using System;

public static class ActionExtensions
{
    /// <summary>
    /// Invoke if different from null;
    /// </summary>
    public static void Trigger(this Action action)
    {
        if (!Equals(action, null)) action();
    }

    /// <summary>
    /// Invoke if different from null;
    /// </summary>
    public static void Trigger<T>(this Action<T> action, T obj)
    {
        if (!Equals(action, null)) action(obj);
    }

    /// <summary>
    /// Invoke if different from null;
    /// </summary>
    public static void Trigger<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        if (!Equals(action, null)) action(arg1, arg2);
    }

    /// <summary>
    /// Invoke if different from null;
    /// </summary>
    public static void Trigger<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
    {
        if (!Equals(action, null)) action(arg1, arg2, arg3);
    }

    /// <summary>
    /// Invoke if different from null;
    /// </summary>
    public static void Trigger<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (!Equals(action, null)) action(arg1, arg2, arg3, arg4);
    }
}
