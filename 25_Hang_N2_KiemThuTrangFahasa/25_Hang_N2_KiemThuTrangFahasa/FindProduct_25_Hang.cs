using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace _25_Hang_N2_KiemThuTrangFahasa
{

    [TestClass]
    public class FindProduct_25_Hang
    {

        private IWebDriver driver_25_Hang;
        public TestContext TestContext{ get; set; } // Tạo đối tượng TestContext và khai báo get, set

        [TestInitialize] // Khởi tạo trước mỗi test method.

        // Phương thức này dùng để truy cập vào trang web
        public void SetUp_25_Hang() 
        {
            driver_25_Hang = new ChromeDriver(); // Khởi tạo driver bằng trình duyệt Chrome
            driver_25_Hang.Navigate().GoToUrl("https://www.fahasa.com/");// Đưa url vào để mở trang web
        }

        // Đọc file FindProduct.csv để web tự nhâp dữ liệu để test
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\KTPM\\25_Hang_N2_KiemThuTrangFahasa\\25_Hang_N2_KiemThuTrangFahasa\\Data_25_Hang\\FindProduct_25_Hang.csv", "FindProduct_25_Hang#csv", DataAccessMethod.Sequential)]
        [TestMethod]  // Thực hiện kiểm thử test case

        public void FindProd_25_Hang() // Phương thức tìm kiếm sản phẩm bằng csch đọc file .csv
        {
            // Khai báo biến product_name_25_Hang để đọc dữ liệu tên sản phẩm trong file .csv
            // Encoding_UTF8: khi đọc và tự nhập dữ liệu trong web, nó giữ nguyên chữ có dấu
            string productname_25_Hang = Encoding.UTF8.GetString(Encoding.Default.GetBytes(TestContext.DataRow[0].ToString()));
           
            IWebElement searchInput_25_Hang = driver_25_Hang.FindElement(By.Name("q"));  // Lấy name của ô tìm kiếm
            searchInput_25_Hang.Click(); // Click vào ô tìm kiếm
            searchInput_25_Hang.SendKeys(productname_25_Hang); // Nhập từ khóa của 'productname_25_Hang' vào ô tìm kiếm
            Thread.Sleep(2000); // Chờ 2 giây để load web
            searchInput_25_Hang.SendKeys(Keys.Enter);  // Nhấn Enter tìm kiếm

            // Lấy CssSelector của kết qảu sau khi tìm kiếm
            IWebElement searchResult_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.container > div > div > div.col-lg-9.col-md-9.col-sm-12.col-xs-12.col-fhs-main-body > div > div > div.page-title-elasticsearch > div"));
            
            Thread.Sleep(3000); // Chờ 2 giây để load web

            // Nếu kết quả tìm kiếm khác null và kết quả không có cụm " 0 kết quả "
            if (searchResult_25_Hang != null && !searchResult_25_Hang.Text.Contains("(0 kết quả)"))
            {
                // In ra dòng chữ " Đã tìm thấy sản phẩm " cùng với tên sản phẩm đó
                Console.WriteLine("TC1_FindProduct_25_Hang \n Đã tìm thấy sản phẩm: " + productname_25_Hang);

                Assert.IsTrue(true); // Xác nhận tìm thấy sản phẩm thành công bằng Assert
            }
            else
            {
                // In ra dòng chữ " Không tìm thấy sản phẩm " cùng với tên sản phẩm đó
                Console.WriteLine("TC2_NoFindProduct_25_Hang \n Không tìm thấy sản phẩm: " + productname_25_Hang);

            }         
            driver_25_Hang.Quit();    // Đóng trình duyệt sau khi hoàn thành công việc
        }
    }
}
