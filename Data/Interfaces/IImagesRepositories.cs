using CapiMotors.Models;
using System.Collections.Generic;

namespace CapiMotors.Data.Interfaces
{
    public interface IImagesRepositories
    {
        List<Image> Images(int id);
        void AddImages(List<Image> images);
    }
}