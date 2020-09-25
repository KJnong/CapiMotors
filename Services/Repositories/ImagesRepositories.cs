using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.Repositories
{
    public class ImagesRepositories : IImagesRepositories
    {
        private readonly ApplicationDbContext context;

        public ImagesRepositories(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Images> Images(int id)
        {
            var images = context.Images.Where(i => i.VehicleId == id).ToList();

            return images;
        }

        public void AddImages(List<Images> images)
        {
            context.Add(images);
        }

    }
}
