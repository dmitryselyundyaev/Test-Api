using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class CommandsController:ControllerBase
    {
        public readonly CommandContext _context;
        public CommandsController(CommandContext context) => _context = context;
        ///GET: api command api/test
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetData()
        {
            return _context.CommandItems;
        }
        ///GET: api command api/test/n
        [HttpGet("{id}")]
        public ActionResult<Command> GetDataById(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }
        ///POST: post to db api/test/
        [HttpPost]
        [ActionName(nameof(SetData))]
        public ActionResult<Command> SetData(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();
            return command;
        }

    }
}
