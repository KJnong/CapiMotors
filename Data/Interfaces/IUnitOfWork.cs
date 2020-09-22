using CapiMotors.Data.Interfaces;

namespace CapiMotors.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }

        void Complete();
    }
}