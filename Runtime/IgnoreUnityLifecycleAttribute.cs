
using System;
namespace Marmary.Utils.Runtime
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IgnoreUnityLifecycleAttribute : Attribute
    {
    }


}