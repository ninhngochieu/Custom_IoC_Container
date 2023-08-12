internal class IoCExample
{
    public IoCExample()
    {
    }
}

public interface ICoffeeService
{

}

public interface IWaterService
{

}

public class WaterService : IWaterService
{

}

public class TapWaterService : IWaterService
{

}

public class ArabicaBeanService<T> : IBeanService<T>
{

}

public interface IBeanService<T>
{

}

public class Catimor
{

}

public class CoffeeService : ICoffeeService
{
    private readonly IWaterService _waterService;
    private readonly IBeanService<Catimor> _beanService;

    public CoffeeService(IWaterService waterService, IBeanService<Catimor> beanService)
    {
        _waterService = waterService;
        _beanService = beanService;
    }
}
