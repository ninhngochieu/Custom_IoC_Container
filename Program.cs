using Custom_IoC_Container;

var ioc = new IocContainer();

ioc.Register<IWaterService, WaterService>();
ioc.Register<ICoffeeService, CoffeeService>();

var waterService = ioc.Resolve<IWaterService>();
var coffeeService = ioc.Resolve<ICoffeeService>();

Console.ReadLine();