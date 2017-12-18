using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Core
{
    public static class DependencyFactory
    {
        public static LightInject.IServiceContainer Container { get; set; }

        static DependencyFactory()
        {
            Container = new LightInject.ServiceContainer();
        }

        public static void Register<T, V>(LightInject.ILifetime life) where T : class where V : T
        {
            Container.Register<T, V>(life);
        }

        public static void Register<T, V>() where T : class where V : T
        {
            Register<T, V>(new LightInject.PerRequestLifeTime());
        }

        public static void Register(Type serviceType, Type implType, string serviceName)
        {
            Container.Register(serviceType, implType, serviceName);
        }

        public static void container()
        {
        }
    }

    public class LightInjectInstanceProvider : IInstanceProvider
    {
        readonly Type _serviceType;

        public static T GetInstance<T>()
        {
            return (T)(new LightInjectInstanceProvider(typeof(T))).Resolve();
        }

        public LightInjectInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        object IInstanceProvider.GetInstance(InstanceContext instanceContext)
        {
            return Resolve();
        }

        object IInstanceProvider.GetInstance(InstanceContext instanceContext, Message message)
        {
            return Resolve();
        }

        public object Resolve()
        {
            var instance = DependencyFactory.Container.GetInstance(_serviceType);
            return instance;
        }

        void IInstanceProvider.ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }

    public class LightInjectServiceBehavior : IServiceBehavior
    {
        void IServiceBehavior.AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                    {
                        ed.DispatchRuntime.InstanceProvider = new LightInjectInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }

        void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

    public class LightInjectServiceHost : ServiceHost
    {
        public LightInjectServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new LightInjectServiceBehavior());
            base.OnOpening();
        }
    }

    public class LightInjectServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new LightInjectServiceHost(serviceType, baseAddresses);
        }
    }
}