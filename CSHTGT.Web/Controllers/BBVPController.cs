using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Models;

namespace Test.Controllers
{
    public class BBVPController : Controller
    {
        private readonly IConfiguration _configuration;

        public BBVPController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: BBVP
        public IActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("sp_getAllBBVP", sqlConnection);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.Fill(dtbl);
            }
            return View(dtbl);
        }



        // GET: BBVP/View

        public IActionResult View(int? id)
        {
            BBVPViewModel bBVPViewModel = new BBVPViewModel();
            if (id > 0)
            {
                bBVPViewModel = FetchBBVPByID(id);
            }
            return View(bBVPViewModel);
        }
        public IActionResult AddOrEdit(int? id)
        {
            BBVPViewModel bBVPViewModel = new BBVPViewModel();
            if (id > 0)
            {
                bBVPViewModel = FetchBBVPByID(id);
            }
            return View(bBVPViewModel);
        }


        // POST: BBVP/AddOrEdit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("HanNopPhat,MaNgTGGiaoThong,MaHinhThucXuPhat,MaCanBo,LoiViPham,NgayLap,NgayViPham,SoQuyetDinh,SoTienPhat,TinhTrangNopPhat,HinhAnhViPham")] BBVPViewModel bBVPViewModel)
        {


            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("sp_AddOrEditBBVP", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("MaBienBan", bBVPViewModel.MaBienBan);
                    sqlCmd.Parameters.AddWithValue("MaNgTGGiaoThong", bBVPViewModel.MaNgTGGiaoThong);
                    sqlCmd.Parameters.AddWithValue("MaHinhThucXuPhat", bBVPViewModel.MaHinhThucXuPhat);
                    sqlCmd.Parameters.AddWithValue("MaCanBo", bBVPViewModel.MaCanBo);
                    sqlCmd.Parameters.AddWithValue("HanNopPhat", bBVPViewModel.HanNopPhat);
                    sqlCmd.Parameters.AddWithValue("LoiViPham", bBVPViewModel.LoiViPham);
                    sqlCmd.Parameters.AddWithValue("NgayLap", bBVPViewModel.NgayLap);
                    sqlCmd.Parameters.AddWithValue("NgayViPham", bBVPViewModel.NgayViPham);
                    sqlCmd.Parameters.AddWithValue("SoQuyetDinh", bBVPViewModel.SoQuyetDinh);
                    sqlCmd.Parameters.AddWithValue("SoTienPhat", bBVPViewModel.SoTienPhat);
                    sqlCmd.Parameters.AddWithValue("TinhTrangNopPhat", bBVPViewModel.TinhTrangNopPhat);
                    sqlCmd.ExecuteNonQuery();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(bBVPViewModel);
        }

        // GET: BBVP/Delete/5
        public IActionResult Delete(int? id)
        {
            BBVPViewModel bBPViewModel = FetchBBVPByID(id);

            return View(bBPViewModel);
        }

        // POST: BBVP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("sp_deleteBBVP", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("MaBienBan", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public BBVPViewModel FetchBBVPByID(int? id)
        {
            BBVPViewModel bBVPViewModel = new BBVPViewModel();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("sp_selectBBVP", sqlConnection);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("MaBienBan", id);
                sqlDA.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    bBVPViewModel.MaBienBan = Convert.ToInt32(dtbl.Rows[0]["MaBienBan"].ToString());
                    bBVPViewModel.HanNopPhat = Convert.ToDateTime(dtbl.Rows[0]["HanNopPhat"].ToString());
                    bBVPViewModel.MaNgTGGiaoThong = Convert.ToInt32(dtbl.Rows[0]["MaNgTGGiaoThong"].ToString());
                    bBVPViewModel.MaHinhThucXuPhat = Convert.ToInt32(dtbl.Rows[0]["MaHinhThucXuPhat"].ToString());
                    bBVPViewModel.MaCanBo = Convert.ToInt32(dtbl.Rows[0]["MaCanBo"].ToString());
                    bBVPViewModel.LoiViPham = dtbl.Rows[0]["LoiViPham"].ToString();
                    bBVPViewModel.NgayLap = Convert.ToDateTime(dtbl.Rows[0]["NgayLap"].ToString());
                    bBVPViewModel.NgayViPham = Convert.ToDateTime(dtbl.Rows[0]["NgayViPham"].ToString());
                    bBVPViewModel.SoQuyetDinh = dtbl.Rows[0]["SoQuyetDinh"].ToString();
                    bBVPViewModel.SoTienPhat = Convert.ToInt32(dtbl.Rows[0]["SoTienPhat"].ToString());
                    bBVPViewModel.TinhTrangNopPhat = dtbl.Rows[0]["TinhTrangNopPhat"].ToString();

                }
                return bBVPViewModel;
            }
        }
    }
}
