namespace SmartAdLibrary.Utils
{
    public interface IBusinessCheck<in Context>
    {
        void Execute(Context context);
    }
}
