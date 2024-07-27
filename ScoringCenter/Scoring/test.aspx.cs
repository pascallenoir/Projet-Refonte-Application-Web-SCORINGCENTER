using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data; 

namespace ScoringCenter.Scoring
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if File is not selected then return  
            if (Request.Files["FileUpload1"].ContentLength <= 0)
            { return; }

            //Get the file extension  
            string fileExtension = Path.GetExtension(Request.Files["FileUpload1"].FileName);

            //If file is not in excel format then return  
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            { return; }

            //Get the File name and create new path to save it on server  
            string fileLocation = Server.MapPath("\\") + Request.Files["FileUpload1"].FileName;

            //if the File is exist on serevr then delete it  
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }
            //save the file lon the server before loading  
            Request.Files["FileUpload1"].SaveAs(fileLocation);

            //Create the QueryString for differnt version of fexcel file  
            string strConn = "";
            switch (fileExtension)
            {
                case ".xls": //Excel 1997-2003  
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation
    + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                    break;
                case ".xlsx": //Excel 2007-2010  
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation
    + ";Extended Properties=\"Excel 12.0 xml;HDR=Yes;IMEX=1\"";
                    break;
            }

            //Get the data from the excel sheet1 which is default  
            string query = "select * from  [Capitaux$]";
            OleDbConnection objConn;
            OleDbDataAdapter oleDA;
            DataTable dt = new DataTable();
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            oleDA = new OleDbDataAdapter(query, objConn);
            oleDA.Fill(dt);
            objConn.Close();
            oleDA.Dispose();
            objConn.Dispose();

            //Bind the datatable to the Grid  
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //Delete the excel file from the server  
            File.Delete(fileLocation);
        }
    }
}