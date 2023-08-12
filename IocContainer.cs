using System;
using System.Linq;
using System.Reflection;

namespace Custom_IoC_Container
{
    internal class IocContainer
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private MethodInfo? _resolveMethod;
        public void Register<TContract, TImplement>()
        {
            if (!_map.ContainsKey(typeof(TContract)))
            {
                _map.Add(typeof(TContract), typeof(TImplement));
            }
        }

        public TContract Resolve<TContract>()
        {
            if (!_map.ContainsKey(typeof(TContract)))
            {
                throw new ArgumentException($"No registration found for {typeof(TContract)}");
            }
            else
            {
                return Create<TContract>(_map[typeof(TContract)]);
            }
        }

        private TContract Create<TContract>(Type type)
        {
            if (_resolveMethod == null)
            {
                _resolveMethod = typeof(IocContainer).GetMethod(nameof(Resolve));
            }

            //Idea: Make paramter in this constructor into list object paramenters
            //Order by constructor has least parameter
            //Get first constructor
            var constructorParameters = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First()
                .GetParameters().Select(p =>
                {
                    //Lấy method Resolve T với T là tham số từ kiểu Args từ Constructor bên trên
                                            //Coffee(IWaterService ...)
                    var method = _resolveMethod?.MakeGenericMethod(p.ParameterType);
                    
                    //Chạy method này để tạo Instance của các tham số. Rồi gán vào list
                    return method?.Invoke(this, null);
                }).ToArray();

            return (TContract)Activator.CreateInstance(type, constructorParameters);
        }
    }
}
