using System.Web.Optimization;
using Inventory.Handlers;
using Inventory.Messaging;
using Inventory.Web.Services;
using Nancy;
using Nancy.Conventions;

namespace Inventory.Web
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            Wiring.Wire();
            base.ApplicationStartup(container, pipelines);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Styles"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Fonts"));
        }
    }

    public static class Wiring
    {
        public static void Wire()
        {
            var bus = new MiniVan();

            var storage = new RestStore();
            var rep = new Repository<InventoryItem>(storage);
            var commands = new InventoryCommandHandlers(rep);
            bus.RegisterHandler<CheckInItemsToInventory>(commands.Handle);
            bus.RegisterHandler<CreateInventoryItem>(commands.Handle);
            bus.RegisterHandler<DeactivateInventoryItem>(commands.Handle);
            bus.RegisterHandler<RemoveItemsFromInventory>(commands.Handle);
            bus.RegisterHandler<RenameInventoryItem>(commands.Handle);
            ServiceLocator.Bus = bus;
        }
    }
}