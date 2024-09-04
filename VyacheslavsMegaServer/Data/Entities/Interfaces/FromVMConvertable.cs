namespace VyacheslavsMegaServer.Data.Entities.Interfaces
{
    public interface FromVMConvertable<VM, Entity> where Entity : Base.EntityBase
    {
        public Entity GetValuesFromVM(VM viewModel);
    }
}
