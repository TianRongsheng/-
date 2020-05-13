namespace ServicesLifetime
{
    //为继承/实现它的子类（每个实例化的服务）指定一个不同的号码
    public interface INumberService
    {
        int GetNumber();
    }
}
