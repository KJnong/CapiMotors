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

        public List<Image> Images(int id)
        {
            var images = context.Images.Where(i => i.ProductId == id).ToList();

            return images;
        }

        public void AddImages(List<Image> images)
        {
            context.Add(images);
        }

    }
}
