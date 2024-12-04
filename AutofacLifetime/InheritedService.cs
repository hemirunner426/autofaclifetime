using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacLifetime
{
    public interface IInheritedService
    {

    }

    public abstract class InheritedService<T> : IInheritedService where T : class  //This generic abstract class will cause a SOE when the container is disposed.
    {
        public abstract void BaseMethod();
    }

    public class Child1Service : InheritedService<Child1Service>
    {
        public override void BaseMethod()
        {
            
        }
    }

    public class Child2Service : InheritedService<Child2Service>
    {
        public override void BaseMethod()
        {
            throw new NotImplementedException();
        }
    }
}
