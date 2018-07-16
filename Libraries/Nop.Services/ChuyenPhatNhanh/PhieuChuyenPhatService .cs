using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.NhaXes;
using Nop.Core.Domain.Shipping;
using Nop.Services.Configuration;
using Nop.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.ChuyenPhatNhanh;
using Nop.Services.NhaXes;

namespace Nop.Services.ChuyenPhatNhanh
{
    public class PhieuChuyenPhatService : IPhieuChuyenPhatService
    {
        #region Ctor
        private readonly IRepository<PhieuChuyenPhat> _phieuchuyenphatRepository;
        private readonly IRepository<PhieuChuyenPhatVanChuyen> _phieuchuyenphatvanchuyenRepository;
        private readonly IRepository<PhieuChuyenPhatLog> _phieuchuyenphatlogRepository;
        private readonly IRepository<PhieuVanChuyen> _phieuvanchuyenRepository;
        private readonly IRepository<PhieuVanChuyenLog> _phieuvanchuyenlogRepository;
        private readonly IRepository<KhachHang> _khachhangRepository;
        private readonly IRepository<KhuVuc> _khuvucRepository;
        private readonly IRepository<ToVanChuyen> _tovanchuyenRepository;
        private readonly IRepository<VanPhongVuotTuyen> _vanphongvuottuyenRepository;
        private readonly IRepository<HistoryXeXuatBen> _chuyendiRepository;
        private readonly IRepository<DiemDon> _diemdonRepository;
        private readonly IRepository<HanhTrinh> _hanhtrinhRepository;
        private readonly IRepository<TuyenVanDoanh> _tuyenvandoanhoanhRepository;
        private readonly IRepository<NguoiVanChuyen> _nguoivanchuyenRepository;
        private readonly IRepository<ToVanChuyenVanPhong> _tovanchuyenvanphongRepository;
        private readonly IRepository<DB_LaiPhuSoXe> _laiphusoxeRepository;
        private readonly IRepository<DB_GioMoLenh> _giomolenhRepository;
        private readonly IRepository<DB_GhiChu> _dbghichuRepository;
        private readonly IRepository<PhieuNhanTIen> _phieunhantienRepository;
        private readonly IRepository<PhieuNhanTienLog> _phieunhantienlogRepository;
        private readonly IRepository<LuanChuyenTien> _luanchuyentienRepository;
        private readonly IRepository<LuanChuyenTienLog> _luanchuyentienlogRepository;
        private readonly IRepository<TienTrongKet> _tientrongketRepository;
        private readonly IRepository<TienTrongKetLog> _tientrongketlogRepository;
        public PhieuChuyenPhatService(
            IRepository<DB_GhiChu> dbghichuRepository,
            IRepository<DB_LaiPhuSoXe> laiphusoxeRepository,
            IRepository<DB_GioMoLenh> giomolenhRepository,
             IRepository<NguoiVanChuyen> nguoivanchuyenRepository,
            IRepository<HanhTrinh> hanhtrinhRepository,
            IRepository<DiemDon> diemdonRepository,
            IRepository<HistoryXeXuatBen> chuyendiRepository,
            IRepository<PhieuChuyenPhatVanChuyen> phieuchuyenphatvanchuyenRepository,
           IRepository<PhieuChuyenPhat> phieuchuyenphatRepository,
            IRepository<PhieuChuyenPhatLog> phieuchuyenphatlogRepository,
            IRepository<PhieuVanChuyen> phieuvanchuyenRepository,
             IRepository<PhieuVanChuyenLog> phieuvanchuyenlogRepository,
            IRepository<KhachHang> khachhangRepository,
             IRepository<KhuVuc> khuvucRepository,
            IRepository<ToVanChuyen> tovanchuyenRepository,
            IRepository<VanPhongVuotTuyen> vanphongvuottuyenRepository,
            IRepository<TuyenVanDoanh> tuyenvandoanhRepository,
              IRepository<ToVanChuyenVanPhong> tovanchuyenvanphongRepository,
            IRepository<PhieuNhanTIen> phieunhantienRepository,
             IRepository<PhieuNhanTienLog> phieunhantienlogRepository,
            IRepository<LuanChuyenTien> luanchuyentienRepository,
            IRepository<LuanChuyenTienLog> luanchuyentienlogRepository,
            IRepository<TienTrongKet> tientrongketRepository,
            IRepository<TienTrongKetLog> tientrongketlogRepository
           )
        {
            this._dbghichuRepository = dbghichuRepository;
            this._laiphusoxeRepository = laiphusoxeRepository;
            this._giomolenhRepository = giomolenhRepository;
            this._nguoivanchuyenRepository = nguoivanchuyenRepository;
            this._hanhtrinhRepository = hanhtrinhRepository;
            this._diemdonRepository = diemdonRepository;
            this._chuyendiRepository = chuyendiRepository;
            this._phieuchuyenphatvanchuyenRepository = phieuchuyenphatvanchuyenRepository;
            this._phieuchuyenphatRepository = phieuchuyenphatRepository;
            this._phieuchuyenphatlogRepository = phieuchuyenphatlogRepository;
            this._phieuvanchuyenRepository = phieuvanchuyenRepository;
            this._phieuvanchuyenlogRepository = phieuvanchuyenlogRepository;
            this._khachhangRepository = khachhangRepository;
            this._khuvucRepository = khuvucRepository;
            this._tovanchuyenRepository = tovanchuyenRepository;
            this._vanphongvuottuyenRepository = vanphongvuottuyenRepository;
            this._tuyenvandoanhoanhRepository = tuyenvandoanhRepository;
            this._tovanchuyenvanphongRepository = tovanchuyenvanphongRepository;
            this._phieunhantienRepository = phieunhantienRepository;
            this._phieunhantienlogRepository = phieunhantienlogRepository;
            this._luanchuyentienRepository = luanchuyentienRepository;
            this._luanchuyentienlogRepository = luanchuyentienlogRepository;
            this._tientrongketRepository = tientrongketRepository;
            this._tientrongketlogRepository = tientrongketlogRepository;
        }
        #endregion
        #region phieu chuyen phat
        public virtual PagedList<PhieuChuyenPhat> GetAllPhieuChuyenPhat(int NhaXeId = 0, int vanphongguid = 0, string _maphieu = "", string _tennguoigui = "",
           ENTrangThaiChuyenPhat TrangThaiId = ENTrangThaiChuyenPhat.All, DateTime? NgayNhanHang = null,
           int vanphongnhanid = 0,
               int pageIndex = 0,
               int pageSize = int.MaxValue)
        {
            var query = _phieuchuyenphatRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (!String.IsNullOrWhiteSpace(_maphieu))
                query = query.Where(m => m.MaPhieu.Contains(_maphieu));
            if (!String.IsNullOrWhiteSpace(_tennguoigui))
                query = query.Where(m => (m.NguoiGui.HoTen.Contains(_tennguoigui) || m.NguoiNhan.HoTen.Contains(_tennguoigui)));
            if (TrangThaiId > 0)
                query = query.Where(m => m.TrangThaiId == (int)TrangThaiId);
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                query = query.Where(c => c.NgayNhanHang == _ngaynhanhang);
            }

            if (vanphongnhanid > 0)
                query = query.Where(m => m.VanPhongNhanId == vanphongnhanid);
            if (vanphongguid > 0)
                query = query.Where(m => m.VanPhongGuiId == vanphongguid);
            query = query.OrderByDescending(m => m.Id);
            return new PagedList<PhieuChuyenPhat>(query, pageIndex, pageSize);

        }
        public virtual List<PhieuChuyenPhat> GetAllPhieuChuyenPhat(int NhaXeId, int vanphonggui_id, DateTime? NgayNhanHang = null, string _thongtin = "", ENTrangThaiChuyenPhat TrangThaiId = ENTrangThaiChuyenPhat.All, int PhieuVanChuyenId = 0, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var query = _phieuchuyenphatRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                var lastday = DateTime.Now.AddDays(-1);
                query = query.Where(c => c.NgayNhanHang == _ngaynhanhang ||
                       (c.NgayTao.Year == lastday.Year && c.NgayTao.Month == lastday.Month && c.NgayTao.Day == lastday.Day && c.NgayTao.Hour >= 17));
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayNhanHang > _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayNhanHang < _dengay);
            }
            if (TrangThaiId != ENTrangThaiChuyenPhat.All)
                query = query.Where(m => m.TrangThaiId == (int)TrangThaiId);
            if (vanphonggui_id > 0)
                query = query.Where(m => m.VanPhongGuiId == vanphonggui_id);

            if (!String.IsNullOrWhiteSpace(_thongtin))
            {
                query = query.Where(m => (m.MaPhieu.Contains(_thongtin) || m.NguoiGui.HoTen.Contains(_thongtin) || m.NguoiGui.SoDienThoai.Contains(_thongtin) || m.NguoiNhan.SoDienThoai.Contains(_thongtin) || m.NguoiNhan.HoTen.Contains(_thongtin) || m.TenHang.Contains(_thongtin)));
            }
            if (PhieuVanChuyenId > 0)
            {
                query = query.Where(m => m.PhieuVanChuyenId == PhieuVanChuyenId);
            }
            //var pcps = query.ToList();
            //if (VanPhongNhanId > 0)
            //{
            //    //pcps = pcps.Where(m => m.nhatkyvanchuyens.LastOrDefault().VanPhongNhanId == VanPhongNhanId
            //    //    || (
            //    //       m.VanPhongNhanId == VanPhongNhanId
            //    //       && m.phieuvanchuyen.LoaiPhieuVanChuyenId == (int)ENLoaiPhieuVanChuyen.TrongTuyen
            //    //       )
            //    //    ).ToList();
            //}
            //pcps = pcps.OrderByDescending(m => m.Id).ToList();
            if (VanPhongNhanId > 0)
            {

                query = query.Where(m => m.phieuvanchuyen.nhatkyvanchuyens.Any(nk => nk.VanPhongNhanId == VanPhongNhanId)
                    || (
                       m.VanPhongNhanId == VanPhongNhanId
                       && m.phieuvanchuyen.LoaiPhieuVanChuyenId == (int)ENLoaiPhieuVanChuyen.TrongTuyen
                       )
                    );
            }
            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }
        public List<PhieuChuyenPhat> GetAllPhieuChuyenPhat(int NhaXeId, int vanphongnhan_id, DateTime? TuNgay = null, DateTime? DenNgay = null, ENTrangThaiChuyenPhat TrangThaiId = ENTrangThaiChuyenPhat.All)
        {
            var query = _phieuchuyenphatRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(c => c.NhaXeId == NhaXeId);
            if (vanphongnhan_id > 0)
            {
                query = query.Where(c => c.VanPhongNhanId == vanphongnhan_id);
            }
            if (TuNgay.HasValue)
            {
                query = query.Where(c => c.NgayTao.Date >= TuNgay.Value.Date);
            }
            if (DenNgay.HasValue)
            {
                query = query.Where(c => c.NgayTao.Date <= DenNgay.Value.Date);
            }
            if (TrangThaiId != ENTrangThaiChuyenPhat.All)
                query = query.Where(m => m.TrangThaiId == (int)TrangThaiId);
            query = query.OrderByDescending(c => c.Id);
            return query.ToList();
        }
        public List<PhieuChuyenPhat> GetPhieuChuyenPhatByPhieuVanChuyenId(int PhieuVanChuyenId)
        {
            return _phieuchuyenphatRepository.Table.Where(c => c.PhieuVanChuyenId == PhieuVanChuyenId).ToList();
        }
        public virtual PagedList<PhieuChuyenPhat> GetAllPhieuChuyenPhatPageList(int NhaXeId, int vanphonggui_id, DateTime? NgayNhanHang = null, string _thongtin = "", ENTrangThaiChuyenPhat TrangThaiId = ENTrangThaiChuyenPhat.All, int PhieuVanChuyenId = 0, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _phieuchuyenphatRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                var lastday = DateTime.Now.AddDays(-1);
                query = query.Where(c => c.NgayNhanHang == _ngaynhanhang ||
                       (c.NgayTao.Year == lastday.Year && c.NgayTao.Month == lastday.Month && c.NgayTao.Day == lastday.Day && c.NgayTao.Hour >= 17));
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayNhanHang > _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayNhanHang < _dengay);
            }
            if (TrangThaiId != ENTrangThaiChuyenPhat.All)
                query = query.Where(m => m.TrangThaiId == (int)TrangThaiId);
            if (vanphonggui_id > 0)
                query = query.Where(m => m.VanPhongGuiId == vanphonggui_id);

            if (!String.IsNullOrWhiteSpace(_thongtin))
            {
                query = query.Where(m => (m.MaPhieu.Contains(_thongtin) || m.NguoiGui.HoTen.Contains(_thongtin) || m.NguoiGui.SoDienThoai.Contains(_thongtin) || m.NguoiNhan.SoDienThoai.Contains(_thongtin) || m.NguoiNhan.HoTen.Contains(_thongtin) || m.TenHang.Contains(_thongtin)));
            }
            if (PhieuVanChuyenId > 0)
            {
                query = query.Where(m => m.PhieuVanChuyenId == PhieuVanChuyenId);
            }
            if (VanPhongNhanId > 0)
            {

                query = query.Where(m => m.phieuvanchuyen.nhatkyvanchuyens.Any(nk => nk.VanPhongNhanId == VanPhongNhanId)
                    || (
                       m.VanPhongNhanId == VanPhongNhanId
                       && m.phieuvanchuyen.LoaiPhieuVanChuyenId == (int)ENLoaiPhieuVanChuyen.TrongTuyen
                       )
                    );
            }
            query = query.OrderByDescending(m => m.Id);
            //return query.ToList();
            return new PagedList<PhieuChuyenPhat>(query, pageIndex, pageSize);
        }
        public virtual IList<PhieuChuyenPhat> GetPhieuChuyenPhatsByIds(int[] PhieuGuiHangIds)
        {
            if (PhieuGuiHangIds == null || PhieuGuiHangIds.Length == 0)
                return new List<PhieuChuyenPhat>();
            var query = _phieuchuyenphatRepository.Table.Where(c => PhieuGuiHangIds.Contains(c.Id));
            return query.ToList();

        }
        public virtual List<PhieuChuyenPhat> GetAllPhieuChuyenPhatTrongThang(int NhaXeId, int vanphonggui_id = 0, DateTime? NgayNhanHang = null, string _thongtin = "", int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null, int Thang = 0, int Nam = 0, DateTime? NgayKetThuc = null, bool isGDNhan = true, int TuyenId = 0)
        {
            var arr = new int[] { (int)ENTrangThaiChuyenPhat.DangVanChuyen, (int)ENTrangThaiChuyenPhat.DenVanPhongNhan, (int)ENTrangThaiChuyenPhat.KetThuc };

            var query = _phieuchuyenphatRepository.Table.Where(m => arr.Contains(m.TrangThaiId));
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                query = query.Where(c => c.NgayNhanHang == _ngaynhanhang);
            }
            if (NgayKetThuc.HasValue)
            {
                var _ngayketthuc = NgayKetThuc.Value.Date;
                query = query.Where(c => c.NgayKetThuc == NgayKetThuc);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                if (isGDNhan)
                    query = query.Where(c => c.NgayNhanHang >= _tungay);
                else
                    query = query.Where(c => c.NgayKetThuc >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                if (isGDNhan)
                    query = query.Where(c => c.NgayNhanHang < _dengay);
                else
                    query = query.Where(c => c.NgayKetThuc < _dengay);
            }
            if (Thang > 0 && Nam > 0)
            {
                query = query.Where(c => c.NgayNhanHang.Year == Nam && c.NgayNhanHang.Month == Thang);
            }
            if (vanphonggui_id > 0)
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);

            if (VanPhongNhanId > 0)
            {

                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }

            if (TuyenId > 0)
                query = query.Where(c => c.nhatkyvanchuyens.FirstOrDefault().chuyendi.HanhTrinhId == TuyenId);


            if (!String.IsNullOrWhiteSpace(_thongtin))
            {
                query = query.Where(m => (m.MaPhieu.Contains(_thongtin) || m.NguoiGui.HoTen.Contains(_thongtin) || m.NguoiNhan.HoTen.Contains(_thongtin) || m.TenHang.Contains(_thongtin)));
            }

            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }

        public virtual List<PhieuChuyenPhat> GetAllPhieuChuyenPhatTrongThang(int NhaXeId, int vanphonggui_id = 0, DateTime? NgayNhanHang = null, int VanPhongNhanId = 0, int TuyenId = 0)
        {
            var arr = new int[] { (int)ENTrangThaiChuyenPhat.DangVanChuyen, (int)ENTrangThaiChuyenPhat.DenVanPhongNhan, (int)ENTrangThaiChuyenPhat.KetThuc };

            var query = _phieuchuyenphatRepository.Table.Where(m => arr.Contains(m.TrangThaiId));
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                query = query.Where(c => c.NgayNhanHang == _ngaynhanhang || c.NgayNhanHangVuotTuyen == _ngaynhanhang);
            }

            if (vanphonggui_id > 0)
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);

            if (VanPhongNhanId > 0)
            {

                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }

            if (TuyenId > 0)
                query = query.Where(c => c.nhatkyvanchuyens.FirstOrDefault().chuyendi.HanhTrinhId == TuyenId);
            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }
        public virtual List<PhieuChuyenPhat> GetPhieuTonVaThatLac(int NhaXeId, string _thongtin = "", int VanPhongNhanId = 0, int TrangThaiId = 0)
        {

            var arr = new int[] { (int)ENTrangThaiChuyenPhat.DangVanChuyen, (int)ENTrangThaiChuyenPhat.DaXepLenh };
            var query = _phieuchuyenphatRepository.Table.Where(m => m.NhaXeId == NhaXeId && m.VanPhongNhanId == VanPhongNhanId);
            //get hang ton
            if (TrangThaiId == (int)ENTrangThaiHangTrongKho.HangTon)
            {
                query = query.Where(c => c.TrangThaiId == (int)ENTrangThaiChuyenPhat.DenVanPhongNhan && c.NgayDenVanPhongNhan.Value < DateTime.Now);
            }
            if (TrangThaiId == (int)ENTrangThaiHangTrongKho.HangThatLac)
            {
                var _ngayhientai = DateTime.Now.AddDays(-2);
                query = query.Where(c => arr.Contains(c.TrangThaiId) && c.NgayNhanHang < _ngayhientai);
            }

            if (!String.IsNullOrWhiteSpace(_thongtin))
            {
                query = query.Where(m => (m.MaPhieu.Contains(_thongtin) || m.NguoiGui.HoTen.Contains(_thongtin) || m.NguoiNhan.HoTen.Contains(_thongtin) || m.TenHang.Contains(_thongtin)));
            }
            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }


        private ENNhomPhieuChuyenPhat getNhomPhieuChuyenPhat(PhieuChuyenPhat item)
        {
            if (item.LoaiPhieu == ENLoaiPhieuChuyenPhat.ThuTaiVanPhong)
            {
                if (item.CuocVuotTuyen > 0)
                    return ENNhomPhieuChuyenPhat.VP_VT;
                if (item.CuocCapToc > 0)
                    return ENNhomPhieuChuyenPhat.VP_CT;
                if (item.CuocGiaTri > 0)
                    return ENNhomPhieuChuyenPhat.VP_GT;
                return ENNhomPhieuChuyenPhat.VP;
            }
            else
            {
                if (item.CuocVuotTuyen > 0)
                    return ENNhomPhieuChuyenPhat.TN_VT;
                if (item.CuocCapToc > 0)
                    return ENNhomPhieuChuyenPhat.TN_CT;
                if (item.CuocGiaTri > 0)
                    return ENNhomPhieuChuyenPhat.TN_GT;
                return ENNhomPhieuChuyenPhat.TN;
            }
        }
        public virtual void InsertPhieuChuyenPhat(PhieuChuyenPhat item)
        {
            if (item == null)
                throw new ArgumentNullException("PhieuChuyenPhat");
            item.NgayTao = DateTime.Now;
            item.NgayUpdate = DateTime.Now;
            //tao thong tin nhom phieu
            item.NhomPhieu = getNhomPhieuChuyenPhat(item);
            _phieuchuyenphatRepository.Insert(item);
        }

        public virtual void UpdatePhieuChuyenPhat(PhieuChuyenPhat _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuChuyenPhat");
            _item.NgayUpdate = DateTime.Now;
            _item.NhomPhieu = getNhomPhieuChuyenPhat(_item);
            _phieuchuyenphatRepository.Update(_item);
        }
        public virtual void DeletePhieuChuyenPhat(PhieuChuyenPhat _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuChuyenPhat");
            _phieuchuyenphatRepository.Delete(_item);
        }
        public virtual PhieuChuyenPhat GetPhieuChuyenPhatById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("PhieuChuyenPhat");
            return _phieuchuyenphatRepository.GetById(Id);
        }
        #endregion
        #region phieu chuyen phat nhat ky van chuyen
        public virtual PhieuChuyenPhatVanChuyen GetPhieuChuyenPhatVanChuyenById(int PhieuChuyenPhatId, int ChuyenDiId)
        {

            return _phieuchuyenphatvanchuyenRepository.Table.Where(c => c.PhieuChuyenPhatId == PhieuChuyenPhatId && c.ChuyenDiId == ChuyenDiId).FirstOrDefault();
        }
        public virtual PhieuChuyenPhatVanChuyen GetPhieuChuyenPhatVanChuyen(int PhieuChuyenPhatId, int PhieuVanChuyenId)
        {

            return _phieuchuyenphatvanchuyenRepository.Table.Where(c => c.PhieuChuyenPhatId == PhieuChuyenPhatId && c.PhieuVanChuyenId == PhieuVanChuyenId).FirstOrDefault();
        }
        public virtual List<PhieuChuyenPhatVanChuyen> GetPhieuChuyenPhatVanChuyenByChuyenDiId(int ChuyenDiId, int PhieuVanChuyenId)
        {
            return _phieuchuyenphatvanchuyenRepository.Table.Where(c => c.ChuyenDiId == ChuyenDiId && c.PhieuVanChuyenId == PhieuVanChuyenId).ToList();
        }
        public virtual void DeletePhieuChuyenPhatVanChuyen(PhieuChuyenPhatVanChuyen item)
        {
            _phieuchuyenphatvanchuyenRepository.Delete(item);
        }
        public virtual void UpdatePhieuChuyenPhatVanChuyen(PhieuChuyenPhatVanChuyen _item)
        {
            if (_item.Id == 0)
                _phieuchuyenphatvanchuyenRepository.Insert(_item);
            else
                _phieuchuyenphatvanchuyenRepository.Update(_item);
        }
        public virtual void DeletePhieuChuyenPhatVanChuyen(int Id)
        {
            var _item = _phieuchuyenphatvanchuyenRepository.GetById(Id);
            if (_item == null)
                return;
            _phieuchuyenphatvanchuyenRepository.Delete(_item);
        }
        public virtual List<PhieuChuyenPhatVanChuyen> GetAllPhieuChuyenPhatVanChuyen(DateTime NgayGuiHangTu, DateTime NgayGuiHangDen, int VanPhongGuiId = 0, int VanPhongNhanId = 0, string BienSoXe = "", string SoLenh = "", int TuyenId = 0)
        {
            NgayGuiHangDen = NgayGuiHangDen.Date.AddDays(1);
            var items = _phieuchuyenphatvanchuyenRepository.Table.Where(c => c.phieuchuyenphat.NgayNhanHang >= NgayGuiHangTu
              && c.phieuchuyenphat.NgayNhanHang < NgayGuiHangDen
                );
            if (VanPhongGuiId > 0)
                items = items.Where(c => c.VanPhongGuiId == VanPhongGuiId);
            if (VanPhongNhanId > 0)
                items = items.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            if (!String.IsNullOrWhiteSpace(SoLenh))
                items = items.Where(m => m.phieuvanchuyen.SoLenh.Contains(SoLenh));
            if (!String.IsNullOrWhiteSpace(BienSoXe))
                items = items.Where(m => m.chuyendi.xevanchuyen.BienSo.Contains(BienSoXe));
            if (TuyenId > 0)
                items = items.Where(c => c.TuyenId == TuyenId);
            return items.ToList();
        }

        #endregion
        #region nhat ki phieu chuyen phat
        public List<PhieuChuyenPhatLog> GetAllPhieuChuyenPhatLog(DateTime NgayTao)
        {
            var _ngaytao = NgayTao;
            var query = _phieuchuyenphatlogRepository.Table.Where(c => c.NgayTao.Year == _ngaytao.Year
                && c.NgayTao.Month == _ngaytao.Month
                && c.NgayTao.Day == _ngaytao.Day
                && c.GhiChu.Contains("SMS đến khách hàng lần"));
            return query.ToList();
        }
        public virtual void InsertPhieuChuyenPhatLog(string GhiChu, int PhieuChuyenPhatId)
        {
            if (PhieuChuyenPhatId == 0)
                throw new ArgumentNullException("PhieuChuyenPhatLog");
            var _item = new PhieuChuyenPhatLog();
            _item.PhieuChuyenPhatId = PhieuChuyenPhatId;
            _item.GhiChu = GhiChu;
            _item.NgayTao = DateTime.Now;
            _phieuchuyenphatlogRepository.Insert(_item);
        }
        #endregion
        #region nhat ki phieu van chuyen
        public virtual PhieuVanChuyenLog GetPhieuVanChuyenLog(int PhieuVanChuyenId, int ChuyenDiId)
        {
            var query = _phieuvanchuyenlogRepository.Table.Where(c => c.PhieuVanChuyenId == PhieuVanChuyenId && c.ChuyenDiId == ChuyenDiId).FirstOrDefault();
            return query;
        }
        public virtual void UpdatePhieuVanChuyenLog(PhieuVanChuyenLog _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuVanChuyenLog");
            if (_item.Id == 0)
                _phieuvanchuyenlogRepository.Insert(_item);
            else
                _phieuvanchuyenlogRepository.Update(_item);
        }
        public virtual void DeletePhieuVanChuyenLog(int Id)
        {
            var _item = _phieuvanchuyenlogRepository.GetById(Id);
            if (_item == null)
                return;
            _phieuvanchuyenlogRepository.Delete(_item);
        }
        public List<PhieuVanChuyenLog> GetAllPhieuVanChuyenLog()
        {
            return null;
        }
        public PhieuVanChuyenLog GetPhieuVanChuyenLogById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("PhieuChuyenPhat");
            return _phieuvanchuyenlogRepository.GetById(Id);
        }
        #endregion
        #region phieu van chuyen
        public virtual List<PhieuVanChuyen> GetAllPhieuVanChuyen(int NhaXeId, int VanPhongGuiId = 0, string SoLenh = "", ENTrangThaiPhieuVanChuyen TrangThaiId = ENTrangThaiPhieuVanChuyen.All, DateTime? ngaytao = null, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var query = _phieuvanchuyenRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(m => m.NhaXeId == NhaXeId);
            if (!String.IsNullOrWhiteSpace(SoLenh))
                query = query.Where(m => m.SoLenh.Contains(SoLenh));

            if (VanPhongGuiId > 0)
            {
                query = query.Where(m => (m.VanPhongId == VanPhongGuiId
                    || m.nhatkyvanchuyens.Any(nk => nk.VanPhongGuiId == VanPhongGuiId)
                    || (m.LoaiPhieuVanChuyenId == (int)ENLoaiPhieuVanChuyen.VuotTuyen && m.TrangThaiId == (int)ENTrangThaiPhieuVanChuyen.DenVanPhongNhan && m.nhatkyvanchuyens.Any(nk => nk.VanPhongNhanId == VanPhongGuiId))
                    ));
            }
            if (VanPhongNhanId > 0)
            {
                //co thiet lap nhan hang tu nhat ky, hoa trong phieu chuyen phat co thong tin van phong nhan(chi ap dung doi voi phieu van chuyen trong tuyen)
                query = query.Where(m => m.nhatkyvanchuyens.Any(nk => nk.VanPhongNhanId == VanPhongNhanId)
                    || (
                       m.phieuchuyenphats.Any(p => p.VanPhongNhanId == VanPhongNhanId)
                       && m.LoaiPhieuVanChuyenId == (int)ENLoaiPhieuVanChuyen.TrongTuyen
                       )
                    );
            }
            if (TrangThaiId > 0)
                query = query.Where(m => m.TrangThaiId == (int)TrangThaiId);
            if (ngaytao.HasValue)
                query = query.Where(c => c.NgayTao.Year == ngaytao.Value.Year
                    && c.NgayTao.Month == ngaytao.Value.Month
                    && c.NgayTao.Day == ngaytao.Value.Day);
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayTao > _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayTao < _dengay);
            }

            query = query.OrderByDescending(m => m.Id);
            return query.ToList();

        }
        public virtual void InsertPhieuVanChuyen(PhieuVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuVanChuyen");
            _phieuvanchuyenRepository.Insert(_item);
        }
        public virtual List<PhieuVanChuyen> GetAllPhieuVanChuyenByChuyenId(int ChuyenId, int NhaXeId)
        {
            var query = _phieuvanchuyenRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy);
            query = query.Where(m => m.NhaXeId == NhaXeId
                && m.nhatkyvanchuyens.Any(nk => nk.ChuyenDiId == ChuyenId));

            return query.ToList();
        }
        public virtual void UpdatePhieuVanChuyen(PhieuVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuVanChuyen");

            _phieuvanchuyenRepository.Update(_item);
        }
        public virtual void DeletePhieuVanChuyen(PhieuVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("PhieuVanChuyen");
            _phieuvanchuyenRepository.Delete(_item);
        }
        public virtual PhieuVanChuyen GetPhieuVanChuyenById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("PhieuVanChuyen");
            return _phieuvanchuyenRepository.GetById(id);
        }
        public virtual int GetSoLenhVanChuyenTiepTheo(int NhaXeId, int VanPhongId)
        {
            var ngaytao = DateTime.Now.Date;
            var query = _phieuvanchuyenRepository.Table.Where(m => m.TrangThaiId != (int)ENTrangThaiChuyenPhat.Huy && m.NgayTao > ngaytao);
            query = query.Where(m => m.NhaXeId == NhaXeId && m.VanPhongId == VanPhongId).OrderByDescending(m => m.SoLenhNum);
            var item = query.FirstOrDefault();
            if (item != null)
                return item.SoLenhNum + 1;
            return 1;
        }
        #endregion
        #region khach hang
        public virtual PagedList<KhachHang> GetAllKhachHang(int NhaXeId = 0,
              int pageIndex = 0,
              int pageSize = int.MaxValue)
        {
            var query = _khachhangRepository.Table.Where(m => m.NhaXeId == NhaXeId);

            query = query.OrderByDescending(m => m.Id);
            return new PagedList<KhachHang>(query, pageIndex, pageSize);

        }
        public virtual List<KhachHang> GetAllKhachHang(int NhaXeId, string KeySearch)
        {
            var query = _khachhangRepository.Table.Where(m => m.NhaXeId == NhaXeId);
            if (!string.IsNullOrEmpty(KeySearch))
            {
                query = query.Where(c => c.SoDienThoai.Contains(KeySearch));
            }
            return query.Take(10).ToList();
        }
        public virtual void InsertKhachHang(KhachHang _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhachHang");
            _khachhangRepository.Insert(_item);
        }

        public virtual void UpdateKhachHang(KhachHang _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhachHang");
            _khachhangRepository.Update(_item);
        }
        public virtual void DeleteKhachHang(KhachHang _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhachHang");
            _khachhangRepository.Delete(_item);
        }
        public virtual KhachHang GetKhachHangById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("KhachHang");
            return _khachhangRepository.GetById(id);
        }
        #endregion
        #region khu vuc
        public virtual List<KhuVuc> GetAllKhuVuc(int NhaXeId = 0)
        {
            var query = _khuvucRepository.Table.Where(m => m.NhaXeId == NhaXeId);

            query = query.OrderBy(m => m.Id);
            return query.ToList();

        }
        public virtual void InsertKhuVuc(KhuVuc _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhuVuc");
            _khuvucRepository.Insert(_item);
        }

        public virtual void UpdateKhuVuc(KhuVuc _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhuVuc");
            _khuvucRepository.Update(_item);
        }
        public virtual void DeleteKhuVuc(KhuVuc _item)
        {
            if (_item == null)
                throw new ArgumentNullException("KhuVuc");
            _khuvucRepository.Delete(_item);
        }
        public virtual KhuVuc GetKhuVucById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("KhuVuc");
            return _khuvucRepository.GetById(id);
        }
        #endregion
        #region To van chuyen, tovan chuyen van phong
        public virtual ToVanChuyenVanPhong GetToVanChuyenVanPhong(int VanPhongId, int ToVanChuyenId)
        {

            var query = _tovanchuyenvanphongRepository.Table.Where(c => c.ToVanChuyenId == ToVanChuyenId && c.VanPhongId == VanPhongId);
            return query.ToList().FirstOrDefault();
        }
        public virtual void InsertToVanChuyenVanPhong(ToVanChuyenVanPhong _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyenVanPhong");
            _tovanchuyenvanphongRepository.Insert(_item);
        }

        public virtual void UpdateToVanChuyenVanPhong(ToVanChuyenVanPhong _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyenVanPhong");
            _tovanchuyenvanphongRepository.Update(_item);
        }
        public virtual void DeleteToVanChuyenVanPhong(ToVanChuyenVanPhong _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyenVanPhong");
            _tovanchuyenvanphongRepository.Delete(_item);
        }
        public virtual ToVanChuyenVanPhong GetToVanChuyenVanPhongById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("ToVanChuyenVanPhong");
            return _tovanchuyenvanphongRepository.GetById(id);
        }
        public virtual List<ToVanChuyen> GetAllToVanChuyen(int NhaXeId)
        {
            var query = _tovanchuyenRepository.Table.Where(c => c.NhaXeId == NhaXeId);
            return query.ToList();

        }

        public virtual List<VanPhong> GetAllVanPhongByToVanChuyen(int ToVanChuyenId)
        {
            var query = _tovanchuyenvanphongRepository.Table.Where(c => c.ToVanChuyenId == ToVanChuyenId);

            return query.ToList().Select(c => c.vanphong).ToList();

        }
        public virtual void InsertToVanChuyen(ToVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _tovanchuyenRepository.Insert(_item);
        }

        public virtual void UpdateToVanChuyen(ToVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _tovanchuyenRepository.Update(_item);
        }
        public virtual void DeleteToVanChuyen(ToVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _tovanchuyenRepository.Delete(_item);
        }
        public virtual ToVanChuyen GetToVanChuyenById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("ToVanChuyen");
            return _tovanchuyenRepository.GetById(id);
        }

        public virtual List<NguoiVanChuyen> GetAllNguoiVanChuyen(int ToVanChuyenId)
        {
            var query = _nguoivanchuyenRepository.Table.Where(c => c.ToVanChuyenId == ToVanChuyenId);
            return query.ToList();

        }
        public virtual void InsertNguoiVanChuyen(NguoiVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _nguoivanchuyenRepository.Insert(_item);
        }

        public virtual void UpdateNguoiVanChuyen(NguoiVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _nguoivanchuyenRepository.Update(_item);
        }
        public virtual void DeleteNguoiVanChuyen(NguoiVanChuyen _item)
        {
            if (_item == null)
                throw new ArgumentNullException("ToVanChuyen");
            _nguoivanchuyenRepository.Delete(_item);
        }
        public virtual NguoiVanChuyen GetNguoiVanChuyenById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("ToVanChuyen");
            return _nguoivanchuyenRepository.GetById(Id);
        }
        #endregion
        #region Tuyen van doanh
        public virtual List<TuyenVanDoanh> GetAllTuyenVanDoanh(int NhaXeId = 0)
        {
            var query = _tuyenvandoanhoanhRepository.Table.Where(m => m.NhaXeId == NhaXeId);

            query = query.OrderBy(m => m.STT);
            return query.ToList();

        }
        public virtual void InsertTuyenVanDoanh(TuyenVanDoanh _item)
        {
            if (_item == null)
                throw new ArgumentNullException("TuyenVanDoanh");
            _tuyenvandoanhoanhRepository.Insert(_item);
        }

        public virtual void UpdateTuyenVanDoanh(TuyenVanDoanh _item)
        {
            if (_item == null)
                throw new ArgumentNullException("TuyenVanDoanh");
            _tuyenvandoanhoanhRepository.Update(_item);
        }
        public virtual void DeleteTuyenVanDoanh(TuyenVanDoanh _item)
        {
            if (_item == null)
                throw new ArgumentNullException("TuyenVanDoanh");
            _tuyenvandoanhoanhRepository.Delete(_item);
        }
        public virtual TuyenVanDoanh GetTuyenVanDoanhById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("TuyenVanDoanh");
            return _tuyenvandoanhoanhRepository.GetById(id);
        }
        #endregion
        #region van phong vuot tuyen
        public virtual VanPhongVuotTuyen GetVanPhongVuotTuyenByVanPhongNhan(int VanPhongGuiId, int VanPhongCuoiId)
        {
            if (VanPhongGuiId == 0 || VanPhongCuoiId == 0)
                throw new ArgumentNullException("VanPhongVuotTuyen");
            var query = _vanphongvuottuyenRepository.Table.Where(m => m.VanPhongGuiId == VanPhongGuiId && m.VanPhongCuoiId == VanPhongCuoiId);
            return query.FirstOrDefault();
        }
        public virtual List<VanPhongVuotTuyen> GetVanPhongVuotTuyenByVanPhong(int VanPhongGuiId = 0, int VanPhongCuoiId = 0)
        {

            var query = _vanphongvuottuyenRepository.Table;
            if (VanPhongGuiId > 0)
            {
                query = query.Where(c => c.VanPhongGuiId == VanPhongGuiId);
            }
            if (VanPhongCuoiId > 0)
            {
                query = query.Where(c => c.VanPhongCuoiId == VanPhongCuoiId);
            }
            return query.ToList();
        }
        public virtual List<HistoryXeXuatBen> GetAllChuyenDi(int NhaXeId, int VanPhongGuiId, int VanPhongNhanId, DateTime NgayDi)
        {
            var retcds = new List<HistoryXeXuatBen>();
            var query = _chuyendiRepository.Table.Where(c => c.HanhTrinh.NhaXeId == NhaXeId && c.NgayDi >= NgayDi && c.TrangThaiId != (int)ENTrangThaiXeXuatBen.HUY);
            //lay thong tin diem don co van phong nay
            //cac diem don bat buoc phai co vanphong
            var diemguiquery = _diemdonRepository.Table.Where(c => c.NhaXeId == NhaXeId && c.VanPhongId == VanPhongGuiId).FirstOrDefault();
            //neu ko co thi empty, loi cau hinh diem don van phong
            if (diemguiquery == null)
                return retcds;
            var diemnhanquery = _diemdonRepository.Table.Where(c => c.NhaXeId == NhaXeId && c.VanPhongId == VanPhongNhanId).FirstOrDefault();
            //neu ko co thi empty, loi cau hinh diem don van phong
            if (diemnhanquery == null)
                return retcds;
            //lay tat ca chuyen di co di qua diem don nay
            query = query.Where(c => c.HanhTrinh.DiemDons.Any(h => h.DiemDonId == diemguiquery.Id) && c.HanhTrinh.DiemDons.Any(h => h.DiemDonId == diemnhanquery.Id));
            //phai lay duoc chuyen di di tu VanPhongGuiId-> VanPhongNhanId
            var chuyendis = query.OrderByDescending(c => c.NgayDi).ToList();
            foreach (var cd in chuyendis)
            {
                int sstdiemgui = cd.HanhTrinh.DiemDons.Where(d => d.DiemDonId == diemguiquery.Id).First().ThuTu;
                int sstdiemnhan = cd.HanhTrinh.DiemDons.Where(d => d.DiemDonId == diemnhanquery.Id).First().ThuTu;
                if (sstdiemgui <= sstdiemnhan)
                {
                    retcds.Add(cd);
                }
            }
            return retcds;
        }
        public virtual List<VanPhong> GetAllVanPhongByVanPhongId(int NhaXeId, int VanPhongId)
        {
            var vanphongs = new List<VanPhong>();
            var diemdonquery = _diemdonRepository.Table.Where(c => c.NhaXeId == NhaXeId && c.VanPhongId == VanPhongId).FirstOrDefault();
            if (diemdonquery == null)
                return vanphongs;

            var hanhtrinhs = _hanhtrinhRepository.Table.Where(c => c.NhaXeId == NhaXeId && c.DiemDons.Any(d => d.DiemDonId == diemdonquery.Id)).ToList();
            foreach (var ht in hanhtrinhs)
            {
                foreach (var dd in ht.DiemDons)
                {
                    if (dd.diemdon != null && !vanphongs.Any(c => c.Id == dd.diemdon.VanPhongId))
                    {
                        vanphongs.Add(dd.diemdon.vanphong);
                    }
                }
            }

            return vanphongs;

        }
        #endregion
        #region Thong tin Dinh Bien
        public virtual DB_LaiPhuSoXe GetLaiPhuSoXeById(int Id)
        {
            return _laiphusoxeRepository.GetById(Id);
        }
        public virtual List<DB_LaiPhuSoXe> GetLaiPhuSoXe(int Thang, int Nam, LoaiLaiPhuSoXe Loai = LoaiLaiPhuSoXe.ALL, string _ten = "")
        {
            var query = _laiphusoxeRepository.Table.Where(c => c.Thang == Thang && c.Nam == Nam);
            if (Loai != LoaiLaiPhuSoXe.ALL)
            {
                query = query.Where(c => c.LoaiId == (int)Loai);
            }
            if (!string.IsNullOrEmpty(_ten))
            {
                query = query.Where(c => c.Ten.Contains(_ten));
            }
            //return query.OrderBy(o => o.LoaiId).ThenBy(o1 => o1.Ten).ToList();
            return query.ToList();
        }
        public void InsertLaiPhuSoXe(DB_LaiPhuSoXe item)
        {
            _laiphusoxeRepository.Insert(item);
        }
        public void DeleteLaiPhuSoXe(DB_LaiPhuSoXe item)
        {
            _laiphusoxeRepository.Delete(item);
        }
        public virtual void ImportLaiPhuSoXe(int Thang, int Nam, string LaiXes, string PhuXes, string SoXes)
        {

        }
        public virtual DB_GioMoLenh GetGioMoLenhById(int Id)
        {
            return _giomolenhRepository.GetById(Id);
        }
        public virtual List<DB_GioMoLenh> GetGioMoLenh(int Thang, int Nam, int BenXeId = 0)
        {
            var query = _giomolenhRepository.Table.Where(c => c.Thang == Thang && c.Nam == Nam);
            if (BenXeId > 0)
                query = query.Where(c => c.BenXeId == BenXeId);
            return query.ToList();
        }
        public virtual void InsertGioMoLenh(DB_GioMoLenh item)
        {
            _giomolenhRepository.Insert(item);
        }
        public virtual void DeleteGioMoLenh(DB_GioMoLenh item)
        {
            _giomolenhRepository.Delete(item);
        }
        public virtual void ImportGioMoLenh(int Thang, int Nam, string GioMoLenhs, int BenXeId)
        {

        }
        public virtual List<DB_GhiChu> GetAllDBGhiChu()
        {
            return _dbghichuRepository.Table.ToList();
        }
        #endregion
        #region quan ly chuyen tien
        public virtual List<PhieuNhanTIen> GetAllPhieuChuyenTien(int vanphonggui_id = 0, DateTime? NgayNhanTien = null, ENTrangThaiChuyenTien TrangThaiId = ENTrangThaiChuyenTien.ALL, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var query = _phieunhantienRepository.Table.Where(c=>c.TrangThaiId !=(int)ENTrangThaiChuyenTien.Huy);
            if (NgayNhanTien.HasValue)
            {
                query = query.Where(c => c.NgayNhanTien == NgayNhanTien);
            }
            if (vanphonggui_id != 0)
            {
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);
            }
            if (VanPhongNhanId != 0)
            {
                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayNhanTien >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayNhanTien < _dengay);
            }
            if (TrangThaiId != ENTrangThaiChuyenTien.ALL)
            {
                query = query.Where(c => c.TrangThaiId == (int)TrangThaiId);
            }
            return query.ToList();
        }
        public virtual List<PhieuNhanTIen> GetAllPhieuChuyenTien(int vanphonggui_id = 0, DateTime? NgayNhanTien = null, int VanPhongNhanId = 0, ENTrangThaiChuyenTien TrangThaiId = ENTrangThaiChuyenTien.ALL)
        {
            var query = _phieunhantienRepository.Table;
            if (NgayNhanTien.HasValue)
            {
                query = query.Where(c => c.NgayNhanTien <= NgayNhanTien);
            }
            if (vanphonggui_id != 0)
            {
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);
            }
            if (VanPhongNhanId != 0)
            {
                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }
            if (TrangThaiId != ENTrangThaiChuyenTien.ALL)
            {
                query = query.Where(c => c.TrangThaiId == (int)TrangThaiId);
            }
            return query.ToList();
        }
        public virtual List<PhieuNhanTIen> GetAllPhieuChuyenTienTonTrongNgay(int vanphonggui_id = 0, DateTime? NgayNhanTien = null, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
             var query = _phieunhantienRepository.Table;
            if(NgayNhanTien.HasValue)
            {
                var _ngaynhantien = NgayNhanTien.Value.Date;
                query = query.Where(c => c.NgayNhanTien == _ngaynhantien && c.NgayTraTien>_ngaynhantien);
            }
            if (vanphonggui_id > 0)
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);
            if (VanPhongNhanId > 0)
                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            var arr = new int[] { (int)ENTrangThaiChuyenTien.DangGuiTien, (int)ENTrangThaiChuyenTien.DenVanPhongNhan};
            var query1 = _phieunhantienRepository.Table.Where(c=>arr.Contains(c.TrangThaiId));
            if (NgayNhanTien.HasValue)
            {
                var _ngaynhantien = NgayNhanTien.Value.Date;
                query1 = query1.Where(c => c.NgayNhanTien == _ngaynhantien);
            }
            if (vanphonggui_id > 0)
                query1 = query1.Where(c => c.VanPhongGuiId == vanphonggui_id);
            if (VanPhongNhanId > 0)
                query1 = query1.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            var result1 = query.ToList();
            var result2 = query1.ToList();
            result1.AddRange(result2);
            return result1;
        }
        public virtual List<PhieuNhanTIen> GetAllPhieuChuyenTienTonTrongThang(int vanphonggui_id = 0, int VanPhongNhanId = 0, int Thang = 0, int Nam = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var arr = new int[] { (int)ENTrangThaiChuyenTien.DangGuiTien, (int)ENTrangThaiChuyenTien.DenVanPhongNhan };
            var query = _phieunhantienRepository.Table.Where(c => arr.Contains(c.TrangThaiId));
            if (vanphonggui_id > 0)
                query= query.Where(c => c.VanPhongGuiId == vanphonggui_id);
            if (VanPhongNhanId > 0)
                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            if (Thang > 0 && Nam > 0)
                query = query.Where(c => c.NgayNhanTien.Year == Nam && c.NgayNhanTien.Month == Thang);
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayNhanTien >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayNhanTien < _dengay);
            }
            return query.ToList();
        }
        public virtual List<PhieuNhanTIen> GetAllPhieuNhanTienTrongThang(int vanphonggui_id = 0, DateTime? NgayNhanHang = null, string _thongtin = "", int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null, int Thang = 0, int Nam = 0, DateTime? NgayKetThuc = null, bool isGDNhan = true)
        {
            var arr = new int[] {(int)ENTrangThaiChuyenTien.DangGuiTien, (int)ENTrangThaiChuyenTien.DenVanPhongNhan, (int)ENTrangThaiChuyenTien.KetThuc };

            var query = _phieunhantienRepository.Table.Where(m => arr.Contains(m.TrangThaiId));
            if (NgayNhanHang.HasValue)
            {
                var _ngaynhanhang = NgayNhanHang.Value.Date;
                query = query.Where(c => c.NgayNhanTien == _ngaynhanhang);
            }
            if (NgayKetThuc.HasValue)
            {
                var _ngayketthuc = NgayKetThuc.Value.Date;
                query = query.Where(c => c.NgayTraTien == NgayKetThuc);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                if(isGDNhan)
                    query = query.Where(c => c.NgayNhanTien >= _tungay);
                else
                    query = query.Where(c => c.NgayTraTien >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                if(isGDNhan)
                    query = query.Where(c => c.NgayNhanTien < _dengay);
                else
                    query = query.Where(c => c.NgayTraTien < _dengay);
            }
            if (Thang > 0 && Nam > 0)
            {
                query = query.Where(c => c.NgayNhanTien.Year == Nam && c.NgayNhanTien.Month == Thang);
            }
            if (vanphonggui_id > 0)
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);

            if (VanPhongNhanId > 0)
            {

                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }

            if (!String.IsNullOrWhiteSpace(_thongtin))
            {
                query = query.Where(m => (m.MaPhieu.Contains(_thongtin) || m.NguoiGui.HoTen.Contains(_thongtin) || m.NguoiNhan.HoTen.Contains(_thongtin)));
            }

            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }
        public virtual IList<PhieuNhanTIen> GetPhieuChuyenTiensByIds(int[] PhieuGuiTienIds)
        {
            if (PhieuGuiTienIds == null || PhieuGuiTienIds.Length == 0)
                return new List<PhieuNhanTIen>();
            var query = _phieunhantienRepository.Table.Where(c => PhieuGuiTienIds.Contains(c.Id));
            return query.ToList();

        }
        public virtual PhieuNhanTIen GetPhieuNhanTienById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("PhieuNhanTien");
            return _phieunhantienRepository.GetById(Id);
        }
        public virtual void InsertPhieuNhanTien(PhieuNhanTIen item)
        {
            if (item == null)
                throw new ArgumentNullException("PhieuNhanTien");
            _phieunhantienRepository.Insert(item);
        }
        public virtual void UpdatePhieuNhanTien(PhieuNhanTIen item)
        {
            if (item == null)
                throw new ArgumentNullException("PhieuNhanTien");
            _phieunhantienRepository.Update(item);
        }
        public virtual void DeletePhieuNhanTien(PhieuNhanTIen item)
        {
            if (item == null)
                throw new ArgumentNullException("PhieuNhanTien");
            _phieunhantienRepository.Delete(item);
        }
        public virtual void InsertPhieuChuyenTienLog(string GhiChu, int PhieuChuyenTienId)
        {
            if (PhieuChuyenTienId == 0)
                throw new ArgumentNullException("PhieuChuyenTienLog");
            var _item = new PhieuNhanTienLog();
            _item.PhieuNhanTienId = PhieuChuyenTienId;
            _item.GhiChu = GhiChu;
            _item.NgayTao = DateTime.Now;
            _phieunhantienlogRepository.Insert(_item);
        }
        #endregion
        #region quan ly luan chuyen tien
        public virtual List<LuanChuyenTien> GetAllLuanChuyenTien(int vanphonggui_id = 0, DateTime? NgayChuyenTien = null, ENTrangThaiLuanChuyenTien TrangThaiId = ENTrangThaiLuanChuyenTien.All, int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var query = _luanchuyentienRepository.Table;
            if (NgayChuyenTien.HasValue)
            {
                query = query.Where(c => c.NgayChuyenTien == NgayChuyenTien);
            }
            if (vanphonggui_id != 0)
            {
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);
            }
            if (VanPhongNhanId != 0)
            {
                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayNhanTien >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayNhanTien < _dengay);
            }
            if (TrangThaiId != (int)ENTrangThaiLuanChuyenTien.All)
            {
                query = query.Where(c => c.TrangThaiId == (int)TrangThaiId);
            }
            return query.ToList();
        }
        public virtual List<LuanChuyenTien> GetAllLuanChuyenTienTrongThang(int vanphonggui_id = 0, DateTime? NgayChuyenTien = null, string _thongtin = "", int VanPhongNhanId = 0, DateTime? TuNgay = null, DateTime? DenNgay = null, int Thang = 0, int Nam = 0, DateTime? NgayKetThuc = null)
        {
            var arr = new int[] {  (int)ENTrangThaiLuanChuyenTien.DenVanPhongNhan, (int)ENTrangThaiLuanChuyenTien.KetThuc };

            var query = _luanchuyentienRepository.Table.Where(m => arr.Contains(m.TrangThaiId));
            if (NgayChuyenTien.HasValue)
            {
                var _ngaynhanhang = NgayChuyenTien.Value.Date;
                query = query.Where(c => c.NgayChuyenTien == _ngaynhanhang);
            }
            if (NgayKetThuc.HasValue)
            {
                var _ngayketthuc = NgayKetThuc.Value.Date;
                query = query.Where(c => c.NgayNhanTien == NgayKetThuc);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayChuyenTien >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayChuyenTien < _dengay);
            }
            if (vanphonggui_id > 0)
                query = query.Where(c => c.VanPhongGuiId == vanphonggui_id);

            if (VanPhongNhanId > 0)
            {

                query = query.Where(c => c.VanPhongNhanId == VanPhongNhanId);
            }


            query = query.OrderByDescending(m => m.Id);
            return query.ToList();
        }
        public virtual IList<LuanChuyenTien> GetLuanChuyenTiensByIds(int[] LuanChuyenTienIds)
        {
            if (LuanChuyenTienIds == null || LuanChuyenTienIds.Length == 0)
                return new List<LuanChuyenTien>();
            var query = _luanchuyentienRepository.Table.Where(c => LuanChuyenTienIds.Contains(c.Id));
            return query.ToList();

        }
        public virtual LuanChuyenTien GetLuanChuyenTienById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("LuanChuyenTien");
            return _luanchuyentienRepository.GetById(Id);
        }
        public virtual void InsertLuanChuyenTien(LuanChuyenTien item)
        {
            if (item == null)
                throw new ArgumentNullException("LuanChuyenTien");
            _luanchuyentienRepository.Insert(item);
        }
        public virtual void UpdateLuanChuyenTien(LuanChuyenTien item)
        {
            if (item == null)
                throw new ArgumentNullException("LuanChuyenTien");
            _luanchuyentienRepository.Update(item);
        }
        public virtual void DeleteLuanChuyenTien(LuanChuyenTien item)
        {
            if (item == null)
                throw new ArgumentNullException("LuanChuyenTien");
            _luanchuyentienRepository.Delete(item);
        }
        public virtual void InsertLuanChuyenTienLog(string GhiChu, int LuanChuyenTienId)
        {
            if (LuanChuyenTienId == 0)
                throw new ArgumentNullException("LuanChuyenTienLog");
            var _item = new LuanChuyenTienLog();
            _item.LuanChuyenTienId = LuanChuyenTienId;
            _item.GhiChu = GhiChu;
            _item.NgayTao = DateTime.Now;
            _luanchuyentienlogRepository.Insert(_item);
        }
        #endregion
        #region
        public virtual List<TienTrongKet> GetAllTienTrongKet(int VanPhongId = 0, DateTime? NgayTao = null, DateTime? TuNgay = null, DateTime? DenNgay = null)
        {
            var query = _tientrongketRepository.Table;
            if (VanPhongId > 0)
                query = query.Where(c => c.VanPhongId == VanPhongId);
            if (NgayTao.HasValue)
            {
                var _ngaytao = NgayTao.Value;
                query = query.Where(c => c.NgayTao.Year == _ngaytao.Year
                    && c.NgayTao.Month == _ngaytao.Month);
            }
            if (TuNgay.HasValue)
            {
                var _tungay = TuNgay.Value.Date;
                query = query.Where(c => c.NgayTao >= _tungay);
            }
            if (DenNgay.HasValue)
            {
                var _dengay = DenNgay.Value.Date.AddDays(1);
                query = query.Where(c => c.NgayTao < _dengay);
            }
            query = query.OrderByDescending(c => c.Id);
            return query.ToList();
        }
        public virtual TienTrongKet GetTienTrongKetById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException("TienTrongKet");
            return _tientrongketRepository.GetById(Id);
        }
        public virtual void InsertTienTrongKet(TienTrongKet _item)
        {
            if(_item==null)
                throw new ArgumentNullException("TienTrongKet");
            _tientrongketRepository.Insert(_item);
        }
        public virtual void UpdateTienTrongKet(TienTrongKet _item)
        {
            if(_item==null)
                throw new ArgumentNullException("TienTrongKet");
            _tientrongketRepository.Update(_item);
        }
        public virtual void DeleteTienTrongKet(TienTrongKet _item)
        {
            if(_item==null)
                throw new ArgumentNullException("TienTrongKet");
            _tientrongketRepository.Delete(_item);
        }
        public virtual void InsertTienTrongKetLog(string GhiChu, int TienTrongKetId, int PhieuNhanTienId,int LuanChuyenTienId, decimal TienVon, decimal TienCuoc, decimal SoTien, decimal CuocPhi)
        {
            if (TienTrongKetId == 0)
                throw new ArgumentNullException("TienTrongKetLog");
            var _item = new TienTrongKetLog();
            _item.TienTrongKetId = TienTrongKetId;
            _item.GhiChu = GhiChu;
            _item.NgayTao = DateTime.Now;
            _item.TienVon = TienVon;
            _item.TienCuoc = TienCuoc;
            _item.SoTien = SoTien;
            _item.CuocPhi = CuocPhi;
            _item.PhieuNhanTienId = PhieuNhanTienId;
            _item.LuanChuyenTienId = LuanChuyenTienId;
            _tientrongketlogRepository.Insert(_item);
        }
        public virtual List<TienTrongKetLog> GetTienTrongKetLog(int TienTrongKetId, int PhieuNhanTienId,int LuanChuyenTienId)
        {
            var query = _tientrongketlogRepository.Table;
            if (TienTrongKetId > 0)
                query = query.Where(c => c.TienTrongKetId == TienTrongKetId);
            if (PhieuNhanTienId > 0)
                query = query.Where(c => c.PhieuNhanTienId == PhieuNhanTienId);
            if (LuanChuyenTienId > 0)
                query = query.Where(c => c.LuanChuyenTienId == LuanChuyenTienId);
            return query.ToList();
        }
        #endregion
    }
}
