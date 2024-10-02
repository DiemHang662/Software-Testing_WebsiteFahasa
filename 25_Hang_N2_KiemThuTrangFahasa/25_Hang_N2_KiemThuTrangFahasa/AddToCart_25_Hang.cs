using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace _25_Hang_N2_KiemThuTrangFahasa
{

    [TestClass]
    public class AddToCart_25_Hang
    {
        private IWebDriver driver_25_Hang;

        [TestInitialize] // Khởi tạo trước mỗi test method.
        public void SetUp_25_Hang()  // Phương thức này dùng để truy cập vào trang web
        {
            driver_25_Hang = new ChromeDriver();  // Khởi tạo driver bằng trình duyệt Chrome
            driver_25_Hang.Navigate().GoToUrl("https://www.fahasa.com/"); // Đưa url vào để mở trang web
        }

        [TestMethod]  // Thực hiện kiểm thử test case
        public void TC1_AddToCart_25_Hang()
        {
            // Để thêm sản phẩm vào giỏ hàng, cần phải tìm kiếm một sản phẩm để chọn thêm vào giỏ
            IWebElement searchInput_25_Hang = driver_25_Hang.FindElement(By.Name("q")); // Lấy name của ô tìm kiếm

            searchInput_25_Hang.Click(); // Click vào ô tìm kiếm
            searchInput_25_Hang.SendKeys("Tô Bình Yên Vẽ Hạnh Phúc (Tái Bản 2022)"); // Nhập tên sản phẩm cần tìm vào ô tìm kiếm
            Thread.Sleep(2000); // Chờ 2 giây để load web
            searchInput_25_Hang.SendKeys(Keys.Enter);  // Nhấn Enter tìm kiếm
            Thread.Sleep(3000); // Chờ 3 giây để load web

            // Lấy CssSelector của một sản phẩm sau khi tìm thấy
            IWebElement product_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#wrapper > div.page > div.main-container.col1-layout.no-margin-top > div > div.col-main > div > div > div.container > div > div > div.col-lg-9.col-md-9.col-sm-12.col-xs-12.col-fhs-main-body > div > div > div.category-products.row > ul > li:nth-child(1) > div > div > div.products.clearfix"));

            product_25_Hang.Click(); // Click vào sản phẩm đó

            Thread.Sleep(3000); // Chờ load web 3 giây

            // Tìm nút "Thêm vào giỏ hàng" bằng CSS Selector
            IWebElement btnAdd_25_Hang = driver_25_Hang.FindElement(By.CssSelector("button.btn-cart-to-cart[title='Thêm vào giỏ hàng']"));
           
            btnAdd_25_Hang.Click();  // Click vào nút "Thêm vào giỏ hàng"
            Thread.Sleep(5000); // Chờ 5s để load web

            //Vào giỏ hàng để kiểm tra sản phẩm đã được thêm chưa bằng cách lấy CssSelector của giỏ hàng
            IWebElement cart_25_Hang = driver_25_Hang.FindElement(By.CssSelector("#header > div.fhs_header_desktop > div.container > div > div.fhs_center_space > div.cart-top.no_cover.fhs_dropdown_hover > div"));
            
            cart_25_Hang.Click(); // Click vào giỏ hàng và xem có sản phẩm đã thêm chưa
        }
    }
}
