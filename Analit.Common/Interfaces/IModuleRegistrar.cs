namespace Analit.Common.Interfaces
{
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
    }
}