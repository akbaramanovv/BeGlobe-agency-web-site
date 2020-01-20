using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Controllers
{
    public class ImagesController : MainController
    {

        public async Task<ActionResult> Index(int? id)
        {
            Photo item = await db.Photos.FindAsync(id);

            byte[] photoBack = item.FileName;

            return File(photoBack, "image/png");
        }
    }
}