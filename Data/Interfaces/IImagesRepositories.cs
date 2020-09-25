using CapiMotors.Models;
using System.Collections.Generic;

namespace CapiMotors.Data.Interfaces
{
    public interface IImagesRepositories
    {
        List<Images> Images(int id);
        void AddImages(List<Images> images);
    }
}