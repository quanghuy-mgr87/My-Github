using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface IHocVienServices
    {
        public IEnumerable<HocVien> GetHocViens(string orderBy = "", string name = "");
        public HocVien AddHocVien(HocVien hocVien);
        public HocVien UpdateHocVien(HocVien hocVien);
        public HocVien DeleteHocVien(HocVien hocVien);
    }
}
