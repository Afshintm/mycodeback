using Microsoft.EntityFrameworkCore;
using Services.Utilities.Common;

namespace Services.Utilities.DataAccess
{

    //public interface IBoundedDbContext : DbContext
    //{
    //    event ObjectMaterializedEventHandler ObjectMaterialized;
    //}

    //public abstract class BoundDbContext<TContext> : IBoundedDbContext where TContext : DbContext
    //{
    //    public BoundDbContext(string nameOrConnectionString) :
    //        base(nameOrConnectionString)
    //    {
    //        ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += OnObjectMaterialized;
    //    }

    //    public BoundDbContext() : this("Sales") { }

    //    void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs args)
    //    {
    //        var entity = args.Entity as IObjectState;
    //        if (entity != null)
    //        {
    //            entity.ObjectState = ObjectState.Unchanged;
    //        }

    //        if (ObjectMaterialized != null)
    //        {
    //            ObjectMaterialized(sender, args);
    //        }
    //    }

    //    public event ObjectMaterializedEventHandler ObjectMaterialized;

    //    public override int SaveChanges()
    //    {
    //        this.ApplyStateChanges<TContext>();
    //        return base.SaveChanges();
    //    }

    //    public int Save()
    //    {
    //        return base.SaveChanges();
    //    }
    //}

}
