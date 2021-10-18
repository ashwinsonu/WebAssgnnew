using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssgn.AssignModel;

namespace WebAssgn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public  chaatsContext db=new chaatsContext();
        
       
        

        [HttpGet]
        public async Task<IActionResult> Getchaats()
        {
            return Ok(await db.Chaats.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddChaat(Chaat C)
        {
            db.Chaats.Add(C);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChaat(int id, Chaat C
            )
        {
            using (var db = new chaatsContext())
            {
                db.Entry(C).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(C);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteChaat(int id)
        {
            //Chaat C = ;
            db.Chaats.Remove(db.Chaats.Find(id));
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("drinks")]
        public async Task<IActionResult> Getdrinks()
        {
            return Ok(await db.Drinks.ToListAsync());
        }

        [HttpPost]
        [Route("drinks")]
        public async Task<IActionResult> AddDrink(Drink d)
        {
            db.Drinks.Add(d);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        [Route("drinks")]
        public async Task<IActionResult> UpdateDrink(int id, Drink d)
        {
            using (var db = new chaatsContext())
            {
                db.Entry(d).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpDelete]
        [Route("drinks")]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            Drink d = db.Drinks.Find(id);
            db.Drinks.Remove(d);
            await db.SaveChangesAsync();
            return Ok();

        }
    }
}
