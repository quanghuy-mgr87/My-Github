using WebApplication1.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class HocVienServices : IHocVienServices
    {
        private readonly AppDbContext _context;
        public HocVienServices()
        {
            _context = new AppDbContext();
        }
        public HocVien AddHocVien(HocVien hocVien)
        {
            bool IsHocVienExist = _context.HocViens.Any(x => x.HocVienId == hocVien.HocVienId);
            if (IsHocVienExist)
                return null;
            _context.HocViens.Add(hocVien);
            return hocVien;
        }

        public HocVien DeleteHocVien(HocVien hocVien)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HocVien> GetHocViens(string orderBy = "", string name = "")
        {
            throw new NotImplementedException();
        }

        public HocVien UpdateHocVien(HocVien hocVien)
        {
            throw new NotImplementedException();
        }
    }
}
