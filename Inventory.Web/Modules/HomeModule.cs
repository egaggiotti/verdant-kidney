using System;
using Inventory.Messaging;
using Inventory.Web.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Inventory.Web.Modules
{
    public class HomeModule : NancyModule
    {
        private readonly MiniVan _bus = ServiceLocator.Bus;

        public HomeModule()
        {
            Get["/"] = _ => View["Views/Index"];

            Post["/"] = parameters =>
            {
                var command = this.Bind<Command>();
                _bus.Send(new CreateInventoryItem(Guid.NewGuid(), command.Name));
                return View["Views/Index"];
            };

            Put["/{guid:id}/{int:version}"] = _ =>
            {
                _bus.Send(new RenameInventoryItem(_.id, Request.Form.name, _.version));
                return View["Views/Index"];
            };

            Delete["/{guid:id}/{int:version}"] = _ =>
            {
                _bus.Send(new DeactivateInventoryItem(_.id, _.version));
                return View["Views/Index"];
            };

            Post["/Checkin/{guid:id}/{int:version}"] = _ =>
            {
                _bus.Send(new CheckInItemsToInventory(_.id, Request.Form.number, _.version));
                return View["Views/Index"];
            };


            Post["/Checkout/{guid:id}/{int:version}"] = _ =>
            {
                _bus.Send(new RemoveItemsFromInventory(_.id, Request.Form.number, _.version));
                return View["Views/Index"];
            };
        }
    }
}