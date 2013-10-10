using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

//KIS aka "keep it simple"

namespace KISContainer
{
    public class KISComponent : IDisposable
    {
        protected bool isLoaded;

        public bool IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; }
        }

        protected bool isRemoved;

        public bool IsRemoved
        {
            get { return isRemoved; }
            set { isRemoved = value; }
        }

        protected bool isContracted;

        public bool IsContracted
        {
            get { return isContracted; }
            set { isContracted = value; }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    public interface KISContainerComponent
    {

        bool TryLoadComponent<T>();
        bool TryLoadComponent<T>(KISConfiguration.KISContract contract);
        bool TryRemoveComponent(KISComponent component);
        bool TryRemoveComponent<T>(KISComponent component, KISConfiguration.KISContract contract);
        void BootStrap();


    }

    public abstract class KISConfiguration : KISComponent
    {
        public enum ConfigurationModelType
        {
            [Description("The configuration design resides in the model itself")]
            Convention,
            [Description("The configuration design is made explicit by using attributes extensions")]
            Explicit
        }

        public enum KISContract
        {
            Import,
            ImportMany
        }

        public abstract KISConfiguration.ConfigurationModelType ModelType { get; set; }
        protected abstract KISComponent ConfigurationSource { get; set; }
        public abstract KISComponent ConfigurationModel { get; set; }
        protected abstract void LoadConfigurationFromSource();

    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class KISComponentDefaultAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;

        // This is a positional argument
        public KISComponentDefaultAttribute(string positionalString)
        {
            this.positionalString = positionalString;

            // TODO: Implement code here
            throw new NotImplementedException();
        }

        public string PositionalString
        {
            get { return positionalString; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }

    //todo:
    //add two different types of factories according to the configuration model that is used

    public partial class KISContainer : KISComponent, KISContainerComponent
    {
        //dictionary will contain all instances as well as thier parent
        private Dictionary<KeyValuePair<object, Type>, object> _registeredComponents;
        private readonly RegistrationBuilder _regBuilder = new RegistrationBuilder();

        private void RegisterType<T>() where T : KISComponent
        {
            _regBuilder.ForType<T>();
        }

        public bool TryLoadComponent<T>()
        {
            throw new NotImplementedException();
        }

        public bool TryLoadComponent<T>(KISConfiguration.KISContract contract)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveComponent(KISComponent component)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveComponent<T>(KISComponent component, KISConfiguration.KISContract contract)
        {
            throw new NotImplementedException();
        }

        public void BootStrap()
        {
            throw new NotImplementedException();

        }


        private class ConventionBasedFactory
        {


        }

        private class ExplicitTypeFactory
        {

        }

        private class ContainerUtil
        {
            private static Castle.DynamicProxy.ProxyGenerator _proxy = new ProxyGenerator();

            public static object Wrap<T>(IInterceptor[] interceptors) where T : class //new [] {new KISComponentInterceptor()}
            {

                return _proxy.CreateClassProxy<T>(interceptors);
            }

        }

        private class KISComponentInterceptor : IInterceptor
        {

            public void Intercept(IInvocation invocation)
            {
                //  DoSomeWorkBefore(invocation);

                invocation.Proceed();

                //   DoSomeWorkAfter(invocation, retValue);

            }
        }
    }



}
