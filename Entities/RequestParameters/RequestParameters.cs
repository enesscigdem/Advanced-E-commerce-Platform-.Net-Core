namespace Entities.RequestParameters
{
    // abstract bir sınıfı yarıda bırakılmış sınıf olarak düşün.
    // fakat kalıtımla bu sınıf devralındığında bu sınıf newlenebilir.
    public abstract class RequestParameters
    {
        public String? SearchTerm { get; set; }
    }
}