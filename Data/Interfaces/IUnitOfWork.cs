using CapiMotors.Data.Interfaces;

namespace CapiMotors.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}