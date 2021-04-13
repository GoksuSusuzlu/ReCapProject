using Castle.DynamicProxy;
using RecapCore.Aspects.Autofac.Performance;
using RecapCore.Utility.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RecapCore.Utility.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //Aspects added here will work in the whole program and are not required to be called on top of classes.
            classAttributes.Add(new PerformanceAspect(5));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
