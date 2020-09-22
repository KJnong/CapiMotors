﻿using CapiMotors.Models;
using System.Collections.Generic;

namespace CapiMotors.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetSellerVehicles(string id);
        Vehicle GetVehicle(int id);
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
    }
}