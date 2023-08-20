using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaKalemPopup : DevExpress.XtraEditors.XtraForm
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            //label1.Text = id.ToString();
            DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
            gridControl1.DataSource = db.TBLFATURADETAY.Where(x => x.FATURAID == id).ToList();
            gridControl2.DataSource = db.TBLFATURABILGI.Where(x => x.ID == id).ToList();
        }

        private void pdtresim_EditValueChanged(object sender, EventArgs e)
        {
            string path = "dosyacikti.pdf";
            gridControl1.ExportToPdf(path);
            //Open the created PDF file with the default application
           
        }

        private void excelresim_EditValueChanged(object sender, EventArgs e)
        {
            string path = "dosyacikti.xls";
            gridControl1.ExportToXls(path);
            //Open the created PDF file with the default application
        }
    }
}