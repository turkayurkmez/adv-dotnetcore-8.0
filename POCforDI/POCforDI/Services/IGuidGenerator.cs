namespace POCforDI.Services
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

    public interface ISingletonGuidGenerator : IGuidGenerator
    {
    }

    public interface IScopedGuidGenerator : IGuidGenerator
    {
    }

    public interface ITransientGuidGenerator : IGuidGenerator
    {
    }

    public class SingletonGuid : ISingletonGuidGenerator
    {
        public SingletonGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class ScopedGuid : IScopedGuidGenerator
    {
        public ScopedGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class TransientGuid : ITransientGuidGenerator
    {
        public TransientGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class ScopedService 
    {
        public ISingletonGuidGenerator Singleton { get; set; }
        public IScopedGuidGenerator Scoped { get; set; }
        public ITransientGuidGenerator Transient { get; set; }

        public ScopedService(ISingletonGuidGenerator singleton, IScopedGuidGenerator scoped, ITransientGuidGenerator transient)
        {
            Singleton = singleton;
            Scoped = scoped;
            Transient = transient;
        }

    }


}
